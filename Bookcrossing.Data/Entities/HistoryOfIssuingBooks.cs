using System;
using System.ComponentModel.DataAnnotations;

namespace Bookcrossing.Data.Entities
{
    public class HistoryOfIssuingBooks
    {
        [Required]
        public Guid Id { get; set; }
        //user id
        public User? User { get; set; }
        public DateTime DateOfReceiving { get; set; }
        public DateTime? DateOfDelivery { get; set; }
    }
}
