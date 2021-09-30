﻿using Bookcrossing.Contracts.Abstractions.BrokerMessage;
using System;
using System.Collections.Generic;

namespace Bookcrossing.Contracts.Abstractions.BrokerModels
{
    public interface IBrokerMessage : ICommandMessage
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