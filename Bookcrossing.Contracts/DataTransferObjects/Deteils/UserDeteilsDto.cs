using Bookcrossing.Contracts.DataTransferObjects.LookUp;
using System;
using System.Collections.Generic;

namespace Bookcrossing.Contracts.DataTransferObjects.Deteils
{
    public class UserDeteilsDto
    {
        public string Nickname { get; set; }
        public string Email { get; set; }
        public Guid UserAuthId { get; set; }
        public ICollection<BookLookUpDto> OwnerBook { get; set; }
        public ICollection<BookLookUpDto> BookRecipient { get; set; }
        public  ICollection<BookLookUpDto> Subscribe { get; set; }
    }
}
