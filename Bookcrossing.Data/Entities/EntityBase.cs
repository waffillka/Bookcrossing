using Bookcrossing.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Bookcrossing.Data.Entities
{
    public class EntityBase : IIdentifiable<Guid>, ISoftDeleteable
    {
        [Key]
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
