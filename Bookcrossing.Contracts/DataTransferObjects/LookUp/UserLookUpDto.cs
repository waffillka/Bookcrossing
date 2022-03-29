using System;

namespace Bookcrossing.Contracts.DataTransferObjects.LookUp
{
    public class UserLookUpDto
    {
        public Guid id { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
    }
}
