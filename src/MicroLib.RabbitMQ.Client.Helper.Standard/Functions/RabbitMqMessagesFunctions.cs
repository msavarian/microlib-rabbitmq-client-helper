using System;
using System.Collections.Generic;
using System.Text;
using MicroLib.RabbitMQ.Client.Helper.Standard.Model;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace MicroLib.RabbitMQ.Client.Helper.Standard.Functions
{
    public class RabbitMqMessagesFunctions : IRabbitMqMessagesFunctions
    {

        /// <summary>
        /// Serialize the value and then send result json
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="exchangeName"></param>
        /// <param name="routeKey"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SendMessage(IModel model, string exchangeName, string routeKey, object value)
        {
            return SendMessage(model, exchangeName, routeKey, JsonConvert.SerializeObject(value));
        }

        /// <summary>
        /// send plain text
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="exchangeName"></param>
        /// <param name="routeKey"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool SendMessage(IModel model, string exchangeName, string routeKey, string message)
        {
            try
            {
                var properties = model.CreateBasicProperties();
                properties.Persistent = true;

                model.BasicPublish(exchangeName, routeKey, properties, Encoding.ASCII.GetBytes(message));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public uint GetMessageCount(IModel model, string queueName)
        {
            var q = RabbitMqHelperFunctions.CreateQueueDeclare(model, new QueueModel
            {
                QueueName = queueName
            });
            return q.MessageCount;
        }

        public IEnumerable<string> ReciveMessages(IModel model, string queueName, uint msgCount = 0)
        {
            if (msgCount == 0)
                msgCount = GetMessageCount(model, queueName);

            List<string> output = new List<string>();

            var consumer = new QueueingBasicConsumer(model);
            model.BasicConsume(queueName, true, consumer);

            var count = 0;
            while (count < msgCount)
            {
                output.Add(Encoding.ASCII.GetString(consumer.Queue.Dequeue().Body));
                count++;
            }
            return output;
        }
    }
}
