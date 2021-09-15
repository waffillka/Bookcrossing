using System;
using System.Collections.Generic;

namespace Bookcrossing.Contracts.DataTransferObjects
{
    public class BookDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ISBIN { get; set; }
        public Guid PublisherId { get; set; }
        public PublisherDto Publisher { get; set; }
        public virtual UserDto Owner { get; set; }
        public virtual UserDto Recipient { get; set; }

        public virtual ICollection<AuthorDto> Authors { get; set; }
    }
}
