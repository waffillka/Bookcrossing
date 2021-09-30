using Notification.Contracts.Abstractions.Broker;
using System;

namespace Notification.Contracts.DataTransferObject.Broker
{
    public class Unsubscription : IUnsubscription
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
    }
}
