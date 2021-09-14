using Bookcrossing.Data.Interfaces;
using System;

namespace Bookcrossing.Data.Entities
{
    public class EntityBase : IIdentifiable<Guid>, ISoftDeleteable
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
