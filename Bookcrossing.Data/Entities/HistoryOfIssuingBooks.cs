using System;

namespace Bookcrossing.Data.Entities
{
    public class HistoryOfIssuingBooks : EntityBase
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime DateOfReceiving { get; set; }
        public DateTime? DateOfDelivery { get; set; }

        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}
