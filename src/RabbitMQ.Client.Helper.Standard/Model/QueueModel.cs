using System.Collections.Generic;

namespace RabbitMQ.Client.Helper.Standard.Model
{
    public class QueueModel
    {
        public string QueueName { get; set; }
        public bool Durable { get; set; } = true;
        public bool Exclusive { get; set; } = false;
        public bool AutoDelete { get; set; } = false;
        public IDictionary<string, object> Arguments { get; set; } = null;
    }
}
