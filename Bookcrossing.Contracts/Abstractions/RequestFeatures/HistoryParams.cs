using Bookcrossing.Contracts.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcrossing.Contracts.Abstractions.RequestFeatures
{
    public class HistoryParams : RequestFeatures
    {
        public string OrderBy { get; set; } = "abc"; // abc/cba
        public DateTime From { get; set; } = default;
        public DateTime To { get; set; } = default;
    }
}
