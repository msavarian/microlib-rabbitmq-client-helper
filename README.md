# microlib-rabbitmq-client-helper
a ***wrapper*** project on ***RabbitMQ.Client*** for some common usecases

1. Create and get a Connection
2. Create different types of Exchanges and bind them to queues with route-key
3. Send messages to queues
4. Get messages numbers of each queue
5. Get Top(n) messgaes on queues
6. etc

## How to Use
1. Install the nuget package
```
Install-Package MicroLib.RabbitMQ.Client.Helper.Standard
```

2.
```
    class Program
    {
        static RabbitMqFunctions _rabbitMQFunctions;
        static void Main(string[] args)
        {
            _rabbitMQFunctions = new RabbitMqFunctions();

            // Init connection to rabbitMQ
            var _connection = _rabbitMQFunctions.CreateConnection(
                new ConnectionInputModel
                {
                    ClientName="ConsoleSampleApp1000",
                    ServerIP = "localhost",
                    ServerPort = 15672,
                    Username = "guest",
                    Password = "guest"
                });
            ...
            ...
            ...            
```
