using System.Collections.Generic;

namespace Bookcrossing.Contracts.Abstractions.RequestFeatures
{
    public class BookParams : RequestFeatures
    {
        public string SearchString { get; set; } = string.Empty;
        public ICollection<string> Authors { get; set; }
        public ICollection<string> Publishers { get; set; }
        public bool IsFree { get; set; }
    }
}
