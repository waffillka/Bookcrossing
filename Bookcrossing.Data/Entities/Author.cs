using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookcrossing.Data.Entities
{
    public class Author : EntityBase
    { 
        public Author()
        {
            Books = new List<Book>();
        }

        [Required]
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
