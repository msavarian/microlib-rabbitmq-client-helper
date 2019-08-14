using RabbitMQ.Client.Helper.Standard.Functions;
using RabbitMQ.Client.Helper.Standard.Model;
using System;

namespace Sample_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var rabbitMQFunctions = new RabbitMqFunctions();

            // Init connection to rabbitMQ
            RabbitMQ.Client.IConnection _connection = InitConnection(rabbitMQFunctions);

            // Create a Direct Exchange
            CreateAndBind_DirectExchange(rabbitMQFunctions, _connection);

            // Create a fanout Exchange
            CreateAndBind_FanoutExchange(rabbitMQFunctions, _connection);

            // Create a Header Excahnge
            CreateAndBind_HeadersExchange(rabbitMQFunctions, _connection);

            // Create a Topic Exchange
            CreateAndBind_TopicExchange(rabbitMQFunctions, _connection);


            // Send Message to Exchanges
            rabbitMQFunctions.SendMessage(_connection, "directExchange1", "directExchange1routeKey1", "msg1");
            rabbitMQFunctions.SendMessage(_connection, "fanoutExchange1", "fanoutExchange1routeKey1", "msg1");
            rabbitMQFunctions.SendMessage(_connection, "headresExchange1", "headresExchange1routeKey1", "msg1");
            rabbitMQFunctions.SendMessage(_connection, "topicExchange1", "topicExchange1routeKey1", "msg1");


            // Recive Messages from Exchanges
            var queue1Messages = rabbitMQFunctions.ReciveMessages(_connection, "queue1");
            var queue2Messages = rabbitMQFunctions.ReciveMessages(_connection, "queue2");
            var queue3Messages = rabbitMQFunctions.ReciveMessages(_connection, "queue3");
            var queue4Messages = rabbitMQFunctions.ReciveMessages(_connection, "queue4");


            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }


        private static RabbitMQ.Client.IConnection InitConnection(RabbitMqFunctions rabbitMQFunctions)
        {
            return rabbitMQFunctions.CreateConnection(
                new ConnectionInputModel
                {
                    ServerIP = "127.0.0.1",
                    ServerPort = 15672,
                    Username = "guest",
                    Password = "guest"
                });
        }


        #region "Create Different types of Exchanges"
        private static void CreateAndBind_DirectExchange(RabbitMqFunctions rabbitMQFunctions, RabbitMQ.Client.IConnection _connection)
        {
            var directExchange1 = rabbitMQFunctions.CreateAndBindExchange(
                            _connection,
                            new ExchangeModel
                            {
                                ExchangeName = "directExchange1",
                                ExchangeType = ExchangeType.Direct
                            },
                            "directExchange1routeKey1",
                            new QueueModel
                            {
                                QueueName = "queue1"
                            }
                            );
        }

        private static void CreateAndBind_FanoutExchange(RabbitMqFunctions rabbitMQFunctions, RabbitMQ.Client.IConnection _connection)
        {
            var fanoutExchange1 = rabbitMQFunctions.CreateAndBindExchange(
                            _connection,
                            new ExchangeModel
                            {
                                ExchangeName = "fanoutExchange1",
                                ExchangeType = ExchangeType.Fanout
                            },
                            "fanoutExchange1routeKey1",
                            new QueueModel
                            {
                                QueueName = "queue2"
                            }
                            );
        }
        private static void CreateAndBind_HeadersExchange(RabbitMqFunctions rabbitMQFunctions, RabbitMQ.Client.IConnection _connection)
        {
            var headresExchange1 = rabbitMQFunctions.CreateAndBindExchange(
                _connection,
                new ExchangeModel
                {
                    ExchangeName = "headresExchange1",
                    ExchangeType = ExchangeType.Headers
                },
                "headresExchange1routeKey1",
                new QueueModel
                {
                    QueueName = "queue3"
                }
                );
        }
        private static void CreateAndBind_TopicExchange(RabbitMqFunctions rabbitMQFunctions, RabbitMQ.Client.IConnection _connection)
        {
            var topicExchange1 = rabbitMQFunctions.CreateAndBindExchange(
                _connection,
                new ExchangeModel
                {
                    ExchangeName = "topicExchange1",
                    ExchangeType = ExchangeType.Topic
                },
                "topicExchange1routeKey1",
                new QueueModel
                {
                    QueueName = "queue4"
                }
                );
        }
        #endregion
    }
}
