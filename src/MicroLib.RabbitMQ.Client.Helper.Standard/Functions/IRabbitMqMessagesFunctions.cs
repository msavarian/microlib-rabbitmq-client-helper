using RabbitMQ.Client;
using System.Collections.Generic;

namespace MicroLib.RabbitMQ.Client.Helper.Standard.Functions
{
    public interface IRabbitMqMessagesFunctions
    {
        bool SendMessage(IModel model, string exchangeName, string routeKey, string message);
        bool SendMessage(IModel model, string exchangeName, string routeKey, object value);


        uint GetMessageCount(IModel model, string queueName);
        IEnumerable<string> ReciveMessages(IModel model, string queueName, uint msgCount = 0);
    }
}
