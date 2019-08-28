using RabbitMQ.Client;
using System.Collections.Generic;

namespace MicroLib.RabbitMQ.Client.Helper.Standard.Functions
{
    public interface IRabbitMqMessagesFunctions
    {
        bool SendMessage(IModel channelModel, string exchangeName, string routeKey, string message, bool messagePersistent = true);
        bool SendMessage(IModel channelModel, string exchangeName, string routeKey, object value, bool messagePersistent = true);


        uint GetMessageCount(IModel channelModel, string queueName);
        IEnumerable<string> ReciveMessages_BasicConsume(IModel channelModel, string queueName, uint msgCount = 0);
        IEnumerable<string> ReciveMessages_BasicGet(IModel channelModel, string queueName, uint msgCount = 0);
    }
}
