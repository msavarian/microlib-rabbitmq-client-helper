using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client.Helper.Standard.Model;

namespace RabbitMQ.Client.Helper.Standard.Functions
{
    public class RabbitMqFunctions : IRabbitMqFunctions
    {
        public bool CreateAndBindExchange(IConnection connection, ExchangeModel exchangeModel, string routeKey, QueueModel queueModel)
        {
            throw new NotImplementedException();
        }

        public IConnection CreateConnection(ConnectionInputModel connectionInputModel)
        {
            throw new NotImplementedException();
        }

        public IList<string> ReciveMessages(IConnection connection, string queueName)
        {
            throw new NotImplementedException();
        }

        public bool SendMessage(IConnection connection, string exchangeName, string routeKey, string message)
        {
            throw new NotImplementedException();
        }
    }
}
