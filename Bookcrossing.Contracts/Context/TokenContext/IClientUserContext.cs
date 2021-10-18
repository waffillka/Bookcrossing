using System;

namespace Bookcrossing.Contracts.Context.TokenContext
{
    public interface IClientUserContext
    {
        Guid UserId { get; set; }
        string Email { get; set; }
        string Phone { get; set; }
        string Role { get; set; }
        string Name { get; set; }
        string NickName { get; set; }
    }
}
