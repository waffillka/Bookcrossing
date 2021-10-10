using System;

namespace Bookcrossing.Contracts.Abstractions.BrokerModels
{
    public interface IUnsubscription
    {
        Guid UserId { get; set; }
        Guid BookId { get; set; }
    }
}
