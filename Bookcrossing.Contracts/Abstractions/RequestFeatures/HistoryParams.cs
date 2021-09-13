using System;

namespace Bookcrossing.Contracts.Abstractions.RequestFeatures
{
    public class HistoryParams : RequestFeatures
    {
        public string MatchString { get; set; }
        public DateTime From { get; set; } = default;
        public DateTime To { get; set; } = default;
    }
}
