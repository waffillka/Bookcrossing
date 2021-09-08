using Bookcrossing.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookcrossing.Data.Entities
{
    public class BookEntity
    {
        [Required]
        public Guid Id;
        [MinLength(1)]
        public string Name;
        public string Description;
        [MinLength(9)]
        [MaxLength(17)]
        public string ISBIN;

        public ICollection<AuthorEntity> Author;
        public PublisherEntity Publisher;

    }
}
