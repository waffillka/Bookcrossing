using Bookcrossing.Contracts.DataTransferObjects.LookUp;
using System.Collections.Generic;

namespace Bookcrossing.Contracts.DataTransferObjects.Deteils
{
    public class UserDeteilsDto
    {
        public string Nickname { get; set; }
        public virtual ICollection<BookLookUpDto> OwnerBook { get; set; }
        public virtual ICollection<BookLookUpDto> BookRecipient { get; set; }
    }
}
