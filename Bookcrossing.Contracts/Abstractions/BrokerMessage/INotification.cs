using System;

namespace Notification.Contracts.Abstractions.Broker
{
    public interface INotification
    {
        Guid BookId { get; set; }
    }
}
