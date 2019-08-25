using System;
using MicroLib.RabbitMQ.Client.Helper.Standard.Model;
using RabbitMQ.Client;

namespace MicroLib.RabbitMQ.Client.Helper.Standard.Functions
{
    public class RabbitMqDefinationFunctions : IRabbitMqDefinationFunctions
    {
        public IConnection CreateConnection(ConnectionInputModel connectionInputModel)
        {
            ConnectionFactory _factory;
            IConnection _connection;
            _factory = new ConnectionFactory
            {
                HostName = connectionInputModel.ServerIP,
                //Port = connectionInputModel.ServerPort,
                UserName = connectionInputModel.Username,
                Password = connectionInputModel.Password
            };
            _connection = _factory.CreateConnection(connectionInputModel.ClientName);
            return _connection;
        }

        public IModel GetModelFromConnection(IConnection connection)
        {
            return connection.CreateModel();
        }
        public IModel GetModelFromConnection(ConnectionInputModel connectionInputModel)
        {
            var c = CreateConnection(connectionInputModel);
            return GetModelFromConnection(c);
        }


        public bool CreateAndBindExchange(IModel channelModel, ExchangeModel exchangeModel, string routeKey, QueueModel queueModel)
        {
            try
            {
                RabbitMqHelperFunctions.CreateQueueDeclare(channelModel, queueModel);
                RabbitMqHelperFunctions.CreateExchangeDeclare(channelModel, exchangeModel);

                channelModel.QueueBind(
                    queueModel.QueueName,
                    exchangeModel.ExchangeName,
                    routeKey);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
