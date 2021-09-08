using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Bookcrossing.Data.Entities
{
    public class User : EntityBase
    {
        public string Nickname { get; set; }

        public ICollection<Book> OwnerBook { get; set; }
        public ICollection<Book> BookRecipient { get; set; }
    }
}
