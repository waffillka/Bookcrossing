using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcrossing.Data.Repositories.Interface
{
    public interface IRepositoryManager
    {
        IAuthorRepository Authors { get; }
        IBookRepository Books { get; }
        IHistoryOfIssuingBooksRepository History { get; }
        IPublisherRepository Publisher { get; }
        Task SaveAsync();
    }
}
