using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcrossing.Contracts.DataTransferObjects.LookUp
{
    public class UserLookUpDto
    {
        public Guid id { get; set; }
        public string Nickname { get; set; }
    }
}
