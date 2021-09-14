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
