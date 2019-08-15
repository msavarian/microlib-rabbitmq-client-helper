namespace MicroLib.RabbitMQ.Client.Helper.Standard.Model
{
    /// <summary>
    //public const string Direct = "direct";
    //public const string Fanout = "fanout";
    //public const string Headers = "headers";
    //public const string Topic = "topic";
    /// </summary>
    public enum ExchangeType
    {
        Direct = 1,
        Fanout = 2,
        Headers = 3,
        Topic = 4
    }
}
