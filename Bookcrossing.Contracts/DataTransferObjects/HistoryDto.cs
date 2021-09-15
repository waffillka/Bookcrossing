using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcrossing.Contracts.DataTransferObjects
{
    public class HistoryDto
    {
        public virtual UserDto User { get; set; }
        public virtual BookDto Book { get; set; }
        public DateTime DateOfReceiving { get; set; }
        public DateTime DateOfDelivery { get; set; }
    }
}
