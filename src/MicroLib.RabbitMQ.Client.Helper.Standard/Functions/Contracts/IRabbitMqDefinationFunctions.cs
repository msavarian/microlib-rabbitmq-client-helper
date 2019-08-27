using MicroLib.RabbitMQ.Client.Helper.Standard.Model;
using RabbitMQ.Client;

namespace MicroLib.RabbitMQ.Client.Helper.Standard.Functions
{
    public interface IRabbitMqDefinationFunctions
    {
        IConnection CreateConnection(ConnectionInputModel connectionInputModel);
        IModel GetModelFromConnection(IConnection connection);
        IModel GetModelFromConnection(ConnectionInputModel connectionInputModel);
        bool CreateAndBindExchange(IModel channelModel, ExchangeModel exchangeModel, string routeKey, QueueModel queueModel);
    }
}
