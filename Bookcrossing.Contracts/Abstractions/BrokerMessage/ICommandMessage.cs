using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcrossing.Contracts.Abstractions.BrokerMessage
{
    public interface ICommandMessage
    {
        string Command { get; set; }
    }
}
