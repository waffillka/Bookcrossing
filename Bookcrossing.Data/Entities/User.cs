using System.Collections.Generic;

namespace Bookcrossing.Data.Entities
{
    public class User : EntityBase
    {
        public string Nickname { get; set; }

        public virtual ICollection<Book> OwnerBook { get; set; }
        public virtual ICollection<Book> BookRecipient { get; set; }

        public User()
        {
            OwnerBook = new List<Book>();
            BookRecipient = new List<Book>();
        }
    }
}
