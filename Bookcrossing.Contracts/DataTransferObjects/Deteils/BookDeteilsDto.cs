using System;
using System.Collections.Generic;

namespace Bookcrossing.Contracts.DataTransferObjects.Deteils
{
    public class BookDeteilsDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ISBIN { get; set; }
        public Guid PublisherId { get; set; }
        public PublisherDeteilsDto Publisher { get; set; }
        public virtual UserDeteilsDto Owner { get; set; }
        public virtual UserDeteilsDto Recipient { get; set; }

        public virtual ICollection<AuthorDeteilsDto> Authors { get; set; }
    }
}
