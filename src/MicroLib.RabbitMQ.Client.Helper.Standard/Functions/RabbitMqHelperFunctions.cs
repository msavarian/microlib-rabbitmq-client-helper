using MicroLib.RabbitMQ.Client.Helper.Standard.Model;
using RabbitMQ.Client;

namespace MicroLib.RabbitMQ.Client.Helper.Standard.Functions
{
    public static class RabbitMqHelperFunctions
    {
        public static QueueDeclareOk CreateQueueDeclare(IModel channelModel, QueueModel queueModel)
        {
            return channelModel.QueueDeclare(
                queueModel.QueueName,
                queueModel.Durable,
                queueModel.Exclusive,
                queueModel.AutoDelete,
                queueModel.Arguments);
        }
        public static void CreateExchangeDeclare(IModel channelModel, ExchangeModel exchangeModel)
        {
            channelModel.ExchangeDeclare(
                exchangeModel.ExchangeName,
                exchangeModel.ExchangeType.ToString().ToLower(),
                exchangeModel.Durable,
                exchangeModel.AutoDelete,
                exchangeModel.Arguments);
        }
    }
}
