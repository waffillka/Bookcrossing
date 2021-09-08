using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookcrossing.Data.Entities
{
    public class Publisher
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}
