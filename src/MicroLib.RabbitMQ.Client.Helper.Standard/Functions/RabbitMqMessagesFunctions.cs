﻿using System;
using System.Collections.Generic;
using System.Text;
using MicroLib.RabbitMQ.Client.Helper.Standard.Model;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace MicroLib.RabbitMQ.Client.Helper.Standard.Functions
{
    public class RabbitMqMessagesFunctions : RabbitMqHelperFunctions, IRabbitMqMessagesFunctions
    {

        /// <summary>
        /// Serialize the value and then send result json
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="exchangeName"></param>
        /// <param name="routeKey"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SendMessage(IModel channelModel, string exchangeName, string routeKey, object value, bool messagePersistent = true)
        {
            return SendMessage(channelModel, exchangeName, routeKey, JsonConvert.SerializeObject(value), messagePersistent);
        }

        /// <summary>
        /// send plain text
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="exchangeName"></param>
        /// <param name="routeKey"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool SendMessage(IModel channelModel, string exchangeName, string routeKey, string message, bool messagePersistent=true)
        {
            try
            {
                var properties = channelModel.CreateBasicProperties();
                properties.Persistent = messagePersistent;

                channelModel.BasicPublish(exchangeName, routeKey, properties, Encoding.ASCII.GetBytes(message));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public uint GetMessageCount(IModel channelModel, string queueName)
        {
            var q = CreateQueueDeclare(channelModel, new QueueModel
            {
                QueueName = queueName
            });
            return q.MessageCount;
        }

        public IEnumerable<string> ReciveMessages_BasicConsume(IModel channelModel, string queueName, uint msgCount = 0)
        {
            if (msgCount == 0)
                msgCount = GetMessageCount(channelModel, queueName);

            List<string> output = new List<string>();

            var consumer = new QueueingBasicConsumer(channelModel);            
            channelModel.BasicConsume(queueName, true, consumer);

            var count = 0;
            while (count < msgCount)
            {
                output.Add(Encoding.ASCII.GetString(consumer.Queue.Dequeue().Body));
                count++;
            }
            return output;
        }

        public IEnumerable<string> ReciveMessages_BasicGet(IModel channelModel, string queueName, uint msgCount = 0)
        {
            if (msgCount == 0)
                msgCount = GetMessageCount(channelModel, queueName);

            List<string> output = new List<string>();

            var count = 0;
            while (count < msgCount)
            {
                var result = channelModel.BasicGet(queueName, true);
                if (result is null)
                    break;
                output.Add(Encoding.ASCII.GetString(result.Body));

                count++;
            }
            return output;
        }
    }
}
