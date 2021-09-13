using Bookcrossing.Data.DbContext;
using Bookcrossing.Data.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcrossing.Data.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly BookcrossingDbContext _dbContext;
        private IAuthorRepository _authorsRepository;
        private IBookRepository _bookRepository;
        private IHistoryOfIssuingBooksRepository _historyRepository;
        private IPublisherRepository _publisherRepository;

        public RepositoryManager(BookcrossingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IAuthorRepository Authors
        {
            get
            {
                if (_authorsRepository == null)
                    _authorsRepository = new AuthorRepository(_dbContext);

                return _authorsRepository;
            }
        }

        public IBookRepository Books
        {
            get
            {
                if (_bookRepository == null)
                    _bookRepository = new BookRepository(_dbContext);

                return _bookRepository;
            }
        }

        public IHistoryOfIssuingBooksRepository History
        {
            get
            {
                if (_historyRepository == null)
                    _historyRepository = new HistoryOfIssuingBooksRepository(_dbContext);

                return _historyRepository;
            }
        }

        public IPublisherRepository Publisher
        {
            get
            {
                if (_publisherRepository == null)
                    _publisherRepository = new PublisherRepository(_dbContext);

                return _publisherRepository;
            }
        }

        public Task SaveAsync() => _dbContext.SaveChangesAsync();
    }
}
