using Bookcrossing.Contracts.DataTransferObjects.LookUp;
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
        public PublisherLookUpDto Publisher { get; set; }
        public UserLookUpDto Owner { get; set; }
        public UserLookUpDto Recipient { get; set; }

        public ICollection<AuthorDeteilsDto> Authors { get; set; }
    }
}
