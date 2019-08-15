using System.Collections.Generic;

namespace MicroLib.RabbitMQ.Client.Helper.Standard.Model
{
    public class ExchangeModel
    {
        public string ExchangeName { get; set; }
        public ExchangeType ExchangeType { get; set; } = ExchangeType.Direct;
        public bool Durable { get; set; } = true;
        public bool AutoDelete { get; set; } = false;
        public IDictionary<string, object> Arguments { get; set; } = null;

    }
}
