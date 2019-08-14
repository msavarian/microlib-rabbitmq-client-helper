using RabbitMQ.Client.Helper.Standard.Model;
using System.Collections.Generic;

namespace RabbitMQ.Client.Helper.Standard.Functions
{
    public interface IRabbitMqFunctions
    {
        IConnection CreateConnection(ConnectionInputModel connectionInputModel);
        bool CreateAndBindExchange(IConnection connection, ExchangeModel exchangeModel, string routeKey, QueueModel queueModel);
        bool SendMessage(IConnection connection, string exchangeName, string routeKey,string message);
        IEnumerable<string> ReciveMessages(IConnection connection, string queueName);
    }
}
