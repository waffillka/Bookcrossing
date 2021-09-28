using Bookcrossing.Contracts.Abstractions.BrokerModels;

namespace Bookcrossing.Contracts.DataTransferObjects.Broker
{
    public class BrokerMessage : IBrokerMessage
    {
        public string Value { get; set; }
    }
}
