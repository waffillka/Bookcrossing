using System;
using System.Collections.Generic;

namespace Notification.Contracts.Abstractions.Broker
{
    public interface ISubscription
    {
        Guid UserId { get; set; }
        string UserName { get; set; }
        string UserNickname { get; set; }
        string UserEmail { get; set; }

        Guid BookId { get; set; }
        string BookName { get; set; }
        string BookISBIN { get; set; }
        public ICollection<string> Authors { get; set; }
    }
}
