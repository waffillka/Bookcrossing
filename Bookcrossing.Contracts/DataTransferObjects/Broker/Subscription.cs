using Bookcrossing.Contracts.Abstractions.BrokerModels;
using System;
using System.Collections.Generic;

namespace Bookcrossing.Contracts.DataTransferObjects.Broker
{
    public class Subscription : ISubscription
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserNickname { get; set; }
        public string UserEmail { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public Guid BookId { get; set; }
        public string BookName { get; set; }
        public string BookISBIN { get; set; }
        public ICollection<string> Authors { get; set; }
    }
}
