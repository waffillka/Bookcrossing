using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookcrossing.Data.Entities
{
    public class Book : EntityBase
    {
        public Book()
        {
            Authors = new List<Author>();
        }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [MinLength(9)]
        [MaxLength(17)]
        public string ISBIN { get; set; }
        public Guid PublisherId { get; set; }
        public Guid OwnerId { get; set; }
        public Guid? RecipientId { get; set; }

        public virtual User Owner { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual User Recipient { get; set; }
        public virtual ICollection<Author> Authors { get; set; }

        [NotMapped]
        public bool Free => RecipientId == null;
    }
}
