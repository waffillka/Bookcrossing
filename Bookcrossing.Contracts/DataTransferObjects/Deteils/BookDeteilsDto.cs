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
        public UserDeteilsDto Owner { get; set; }
        public UserDeteilsDto Recipient { get; set; }

        public ICollection<AuthorDeteilsDto> Authors { get; set; }
    }
}
