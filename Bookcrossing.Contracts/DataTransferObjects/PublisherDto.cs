using System.Collections.Generic;

namespace Bookcrossing.Contracts.DataTransferObjects
{
    public class PublisherDto
    {
        public string Name { get; set; }
        public virtual ICollection<BookDto> Books { get; set; }
    }
}
