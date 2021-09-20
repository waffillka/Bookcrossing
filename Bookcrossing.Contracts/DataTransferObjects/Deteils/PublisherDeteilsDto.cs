using Bookcrossing.Contracts.DataTransferObjects.LookUp;
using System.Collections.Generic;

namespace Bookcrossing.Contracts.DataTransferObjects.Deteils
{
    public class PublisherDeteilsDto
    {
        public string Name { get; set; }
        public ICollection<BookLookUpDto> Books { get; set; }
    }
}
