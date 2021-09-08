using Bookcrossing.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookcrossing.Data.Entities
{
    public class AuthorEntity
    {
        [Required]
        public Guid Id;
        [Required]
        public string Name;
        public ICollection<BookEntity>? Books;
    }
}
