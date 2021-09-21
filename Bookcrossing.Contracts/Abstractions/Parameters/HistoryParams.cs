using System;

namespace Bookcrossing.Contracts.Abstractions.RequestFeatures
{
    public class HistoryParams : ParametersBase
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
