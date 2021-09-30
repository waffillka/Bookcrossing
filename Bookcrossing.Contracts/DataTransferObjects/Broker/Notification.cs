using Notification.Contracts.Abstractions.Broker;
using System;

namespace Notification.Contracts.DataTransferObject.Broker
{
    public class Notification : INotification
    {
        public Guid BookId { get; set; }
    }
}
