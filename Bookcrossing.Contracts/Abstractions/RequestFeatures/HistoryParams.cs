using System;

namespace Bookcrossing.Contracts.Abstractions.RequestFeatures
{
    public class HistoryParams : RequestFeatures
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
