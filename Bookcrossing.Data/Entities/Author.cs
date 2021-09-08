using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookcrossing.Data.Entities
{
    public class Author : EntityBase
    {
        [Required]
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
