using System;

namespace Bookcrossing.Contracts.Abstractions.RequestFeatures
{
    public class HistoryParams : RequestFeatures
    {
        public string OrderBy { get; set; } = "abc"; // abc/cba
        public DateTime From { get; set; } = default;
        public DateTime To { get; set; } = default;
    }
}
