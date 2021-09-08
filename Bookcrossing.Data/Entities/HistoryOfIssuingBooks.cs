using System;
using System.ComponentModel.DataAnnotations;

namespace Bookcrossing.Data.Entities
{
    public class HistoryOfIssuingBooks
    {
        [Required]
        public Guid Id { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public Guid BookId { get; set; }
        public Book Book { get; set; }

        public DateTime DateOfReceiving { get; set; }
        public DateTime? DateOfDelivery { get; set; }
    }
}
