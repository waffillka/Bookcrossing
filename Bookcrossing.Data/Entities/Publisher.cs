using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookcrossing.Data.Entities
{
    public class Publisher : EntityBase
    {
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public Publisher()
        {
            Books = new List<Book>();
        }
    }
}
