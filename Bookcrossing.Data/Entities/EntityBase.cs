using Bookcrossing.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcrossing.Data.Entities
{
    public class EntityBase : IIdentifiable<Guid>, ISoftDeleteable
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
