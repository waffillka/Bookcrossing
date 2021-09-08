using System;
using System.ComponentModel.DataAnnotations;

namespace Bookcrossing.Data.Entities
{
    public class HistoryOfIssuingBooks
    {
        [Required]
        public Guid Id { get; set; }
        public int idUser { get; set; }
        public User? User { get; set; }
        public DateTime DateOfReceiving { get; set; }
        public DateTime? DateOfDelivery { get; set; }
    }
}
