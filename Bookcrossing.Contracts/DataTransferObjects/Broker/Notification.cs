using Bookcrossing.Contracts.Abstractions.BrokerModels;
using System;

namespace Bookcrossing.Contracts.DataTransferObjects.Broker
{
    public class Notification : INotification
    {
        public Guid BookId { get; set; }
    }
}
