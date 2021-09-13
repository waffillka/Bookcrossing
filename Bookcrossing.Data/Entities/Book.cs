using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookcrossing.Data.Entities
{
    public class Book : EntityBase
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [MinLength(9)]
        [MaxLength(17)]
        public string ISBIN { get; set; }

        public ICollection<Author> Authors { get; set; }

        public Guid PublisherId { get; set; }
        public Publisher? Publisher { get; set; }

        public Guid OwnerId { get; set; }
        public User Owner { get; set; }

        public Guid? RecipientId { get; set; }
        public User Recipient { get; set; }

        [NotMapped]
        public bool Free => RecipientId == null;

    }
}
