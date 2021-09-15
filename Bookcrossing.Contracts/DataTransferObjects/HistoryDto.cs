using Bookcrossing.Contracts.DataTransferObjects.Deteils;
using Bookcrossing.Contracts.DataTransferObjects.LookUp;
using System;

namespace Bookcrossing.Contracts.DataTransferObjects
{
    public class HistoryDto
    {
        public virtual UserDeteilsDto User { get; set; }
        public virtual BookLookUpDto Book { get; set; }
        public DateTime DateOfReceiving { get; set; }
        public DateTime DateOfDelivery { get; set; }
    }
}
