using RabbitMQ.Client;
using System.Collections.Generic;

namespace MicroLib.RabbitMQ.Client.Helper.Standard.Functions
{
    public interface IRabbitMqMessagesFunctions
    {
        bool SendMessage(IModel channelModel, string exchangeName, string routeKey, string message);
        bool SendMessage(IModel channelModel, string exchangeName, string routeKey, object value);


        uint GetMessageCount(IModel channelModel, string queueName);
        IEnumerable<string> ReciveMessages(IModel channelModel, string queueName, uint msgCount = 0);
    }
}
