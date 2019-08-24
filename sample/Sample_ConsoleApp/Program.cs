using MicroLib.RabbitMQ.Client.Helper.Standard.Functions;
using MicroLib.RabbitMQ.Client.Helper.Standard.Model;
using System;

namespace Sample_ConsoleApp
{
    class Program
    {
        static RabbitMqDefinationFunctions rabbitMqDefinationFunctions;
        static RabbitMqMessagesFunctions rabbitMqMessagesFunctions;
        static void Main(string[] args)
        {
            rabbitMqDefinationFunctions = new RabbitMqDefinationFunctions();
            rabbitMqMessagesFunctions = new RabbitMqMessagesFunctions();

            // Init connection to rabbitMQ
            var RabbitMqModel = InitModel();

            // Create a Direct Exchange
            CreateAndBind_DirectExchange(RabbitMqModel);

            // Create a fanout Exchange
            CreateAndBind_FanoutExchange(RabbitMqModel);

            // Create a Header Excahnge
            CreateAndBind_HeadersExchange(RabbitMqModel);

            // Create a Topic Exchange
            CreateAndBind_TopicExchange(RabbitMqModel);


            // Send Message to Exchanges
            rabbitMqMessagesFunctions.SendMessage(RabbitMqModel, "directExchange1", "directExchange1routeKey1", "msg1");
            rabbitMqMessagesFunctions.SendMessage(RabbitMqModel, "fanoutExchange1", "fanoutExchange1routeKey1", "msg1");
            rabbitMqMessagesFunctions.SendMessage(RabbitMqModel, "headresExchange1", "headresExchange1routeKey1", "msg1");
            rabbitMqMessagesFunctions.SendMessage(RabbitMqModel, "topicExchange1", "topicExchange1routeKey1", "msg1");
            rabbitMqMessagesFunctions.SendMessage(RabbitMqModel, "topicExchange1", "topicExchange1routeKey1", new { a= "asdasd", b="adsasdasd" });


            // Recive Messages from Exchanges
            var queue1Messages = rabbitMqMessagesFunctions.ReciveMessages(RabbitMqModel, "queue1");
            var queue2Messages = rabbitMqMessagesFunctions.ReciveMessages(RabbitMqModel, "queue2");
            var queue3Messages = rabbitMqMessagesFunctions.ReciveMessages(RabbitMqModel, "queue3");
            var queue4Messages = rabbitMqMessagesFunctions.ReciveMessages(RabbitMqModel, "queue4");


            Console.WriteLine("Press enter to exit...");
            Console.ReadKey();
        }


        private static RabbitMQ.Client.IModel InitModel()
        {
            return rabbitMqDefinationFunctions.GetModelFromConnection(
                new ConnectionInputModel
                {
                    ClientName="ConsoleSampleApp1000",
                    ServerIP = "localhost",
                    ServerPort = 15672,
                    Username = "guest",
                    Password = "guest"
                });
        }


        #region "Create Different types of Exchanges"
        private static void CreateAndBind_DirectExchange(RabbitMQ.Client.IModel RabbitMqModel)
        {
            var directExchange1 = rabbitMqDefinationFunctions.CreateAndBindExchange(
                            RabbitMqModel,
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

        private static void CreateAndBind_FanoutExchange(RabbitMQ.Client.IModel RabbitMqModel)
        {
            var fanoutExchange1 = rabbitMqDefinationFunctions.CreateAndBindExchange(
                            RabbitMqModel,
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
        private static void CreateAndBind_HeadersExchange(RabbitMQ.Client.IModel RabbitMqModel)
        {
            var headresExchange1 = rabbitMqDefinationFunctions.CreateAndBindExchange(
                RabbitMqModel,
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
        private static void CreateAndBind_TopicExchange(RabbitMQ.Client.IModel RabbitMqModel)
        {
            var topicExchange1 = rabbitMqDefinationFunctions.CreateAndBindExchange(
                RabbitMqModel,
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
