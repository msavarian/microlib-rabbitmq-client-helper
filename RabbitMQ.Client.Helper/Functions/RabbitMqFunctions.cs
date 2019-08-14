using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client.Helper.Model;

namespace RabbitMQ.Client.Helper.Functions
{
    public class RabbitMqFunctions : IRabbitMqFunctions
    {
        public bool CreateAndBindExchange(IConnection connection, ExchangeModel exchangeModel, string routeKey, QueueModel queueModel)
        {
            throw new NotImplementedException();
        }

        public bool CreateConnection(ConnectionInputModel connectionInputModel)
        {
            throw new NotImplementedException();
        }

        public IList<string> ReciveMessages(IConnection connection, string queueName)
        {
            throw new NotImplementedException();
        }

        public bool SendMessage(IConnection connection, string message, string routeKey)
        {
            throw new NotImplementedException();
        }
    }
}
