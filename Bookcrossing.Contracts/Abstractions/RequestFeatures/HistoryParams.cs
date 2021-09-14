using System;

namespace Bookcrossing.Contracts.Abstractions.RequestFeatures
{
    public class HistoryParams : RequestFeatures
    {
        public string SearchStringh { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
