using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookcrossing.Data.Entities
{
    public class Publisher : EntityBase
    {
        public Publisher()
        {
            Books = new List<Book>();
        }

        [Required]
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }        
    }
}
