using System;

namespace Bookcrossing.Contracts.DataTransferObjects.Creation
{
    public class BookCreationDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ISBIN { get; set; }
        public Guid PublisherId { get; set; }
        public Guid OwnerId { get; set; }
        public Guid? RecipientId { get; set; }
    }
}
