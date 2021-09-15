using System;
using System.Collections.Generic;

namespace Bookcrossing.Contracts.DataTransferObjects.LookUp
{
    public class BookLookUpDto
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<AuthorLookUpDto> Authors { get; set; }
        public virtual PublisherLookUpDto Publisher { get; set; }
    }
}
