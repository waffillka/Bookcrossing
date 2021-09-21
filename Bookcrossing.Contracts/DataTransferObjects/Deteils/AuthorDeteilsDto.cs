using Bookcrossing.Contracts.DataTransferObjects.LookUp;
using System;
using System.Collections.Generic;

namespace Bookcrossing.Contracts.DataTransferObjects.Deteils
{
    public class AuthorDeteilsDto
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public ICollection<BookLookUpDto> Books { get; set; }
    }
}
