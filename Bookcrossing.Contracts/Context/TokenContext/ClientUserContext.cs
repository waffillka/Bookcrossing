﻿using System;

namespace Bookcrossing.Contracts.Context.TokenContext
{
    public class ClientUserContext : IClientUserContext
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
    }
}
