using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookcrossing.Data.Entities
{
    public class Book
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [MinLength(9)]
        [MaxLength(17)]
        public string ISBIN { get; set; }

        public ICollection<Author>? Authors { get; set; }

        public Guid IdPulisher { get; set; }
        public Publisher? Publisher { get; set; }

        public int IdOwner { get; set; }
        public User? Owner { get; set; }

        public int IdRecipient { get; set; }
        public User? Recipient { get; set; }
        public bool Free { get; set; } = true;

    }
}
