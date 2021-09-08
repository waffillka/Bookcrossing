using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcrossing.Data.Interfaces
{
    public interface IIdentifiable<TIdentifierType>
    {
        TIdentifierType Id { get; set; }
    }
}
