using System;

namespace Bookcrossing.Contracts.DataTransferObjects.LookUp
{
    public class AuthorLookUpDto
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}
