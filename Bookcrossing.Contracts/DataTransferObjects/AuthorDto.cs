using System;
using System.Collections.Generic;

namespace Bookcrossing.Contracts.DataTransferObjects
{
    public class AuthorDto
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public virtual ICollection<BookDto> Books { get; set; }
    }
}
