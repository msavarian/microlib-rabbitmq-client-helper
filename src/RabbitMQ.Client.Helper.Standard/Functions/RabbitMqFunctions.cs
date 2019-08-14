using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client.Helper.Standard.Model;

namespace RabbitMQ.Client.Helper.Standard.Functions
{
    public class RabbitMqFunctions : IRabbitMqFunctions
    {
        public IConnection CreateConnection(ConnectionInputModel connectionInputModel)
        {
            ConnectionFactory _factory;
            IConnection _connection;
            _factory = new ConnectionFactory
            {
                HostName = connectionInputModel.ServerIP,
                Port = connectionInputModel.ServerPort,
                UserName = connectionInputModel.Username,
                Password = connectionInputModel.Password
            };
            _connection = _factory.CreateConnection(connectionInputModel.ClientName);
            return _connection;
        }


        public bool CreateAndBindExchange(IConnection connection, ExchangeModel exchangeModel, string routeKey, QueueModel queueModel)
        {
            IModel _model;
            _model = connection.CreateModel();

            try
            {
                _model.QueueDeclare(queueModel.QueueName, true, false, false, null);
                _model.ExchangeDeclare(exchangeModel.ExchangeName, exchangeModel.ExchangeType.ToString().ToLower(), true, false, null);
                _model.QueueBind(queueModel.QueueName, exchangeModel.ExchangeName, routeKey);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SendMessage(IConnection connection, string exchangeName, string routeKey, string message)
        {
            IModel _model;
            _model = connection.CreateModel();

            try
            {
                var properties = _model.CreateBasicProperties();
                properties.Persistent = true;
                _model.BasicPublish(exchangeName, routeKey, properties, Encoding.ASCII.GetBytes(message));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<string> ReciveMessages(IConnection connection, QueueModel queueModel, int msgCount=1)
        {
            List<string> output = new List<string>();
            IModel _model = connection.CreateModel();

            var q = _model.QueueDeclare(
                queueModel.QueueName,
                queueModel.Durable,
                queueModel.Exclusive,
                queueModel.AutoDelete,
                queueModel.Arguments);

            var consumer = new QueueingBasicConsumer(q);
            q.BasicConsume(queueModel.QueueName, true, consumer);

            var count = 0;
            while (count < msgCount)
            {
                output.Add(consumer.Queue.Dequeue().Body.ToString());
                count++;
            }
            return output;
        }
    }
}
