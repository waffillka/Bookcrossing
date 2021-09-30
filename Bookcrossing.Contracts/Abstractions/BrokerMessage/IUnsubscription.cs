using System;

namespace Notification.Contracts.Abstractions.Broker
{
    public interface IUnsubscription
    {
        Guid UserId { get; set; }
        Guid BookId { get; set; }
    }
}
