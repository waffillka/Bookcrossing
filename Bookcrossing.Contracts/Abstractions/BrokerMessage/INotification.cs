using System;

namespace Bookcrossing.Contracts.Abstractions.BrokerModels
{
    public interface INotification
    {
        Guid BookId { get; set; }
    }
}
