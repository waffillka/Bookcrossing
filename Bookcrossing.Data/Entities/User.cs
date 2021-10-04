using System.Collections.Generic;

namespace Bookcrossing.Data.Entities
{
    public class User : EntityBase
    {
        public User()
        {
            OwnerBook = new List<Book>();
            BookRecipient = new List<Book>();
            Subscribe = new List<Book>();
        }

        public string Nickname { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Book> OwnerBook { get; set; }
        public virtual ICollection<Book> BookRecipient { get; set; }
        public virtual ICollection<Book> Subscribe { get; set; }
    }
}
