using RabbitMQ.Client.Helper.Standard.Model;
using System.Collections.Generic;

namespace RabbitMQ.Client.Helper.Standard.Functions
{
    public interface IRabbitMqFunctions
    {
        bool CreateConnection(ConnectionInputModel connectionInputModel);
        bool CreateAndBindExchange(IConnection connection, ExchangeModel exchangeModel, string routeKey, QueueModel queueModel);
        bool SendMessage(IConnection connection, string message, string routeKey);
        IList<string> ReciveMessages(IConnection connection, string queueName);
    }
}
