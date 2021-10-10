using Bookcrossing.Contracts.Abstractions.BrokerModels;
using System;

namespace Bookcrossing.Contracts.DataTransferObjects.Broker
{
    public class Unsubscription : IUnsubscription
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
    }
}
