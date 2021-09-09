using Bookcrossing.Data.DbContext;
using Bookcrossing.Data.Entities;
using Bookcrossing.Data.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcrossing.Data.Repositories
{
    public class HistoryOfIssuingBooksRepository : RepositoryBase<HistoryOfIssuingBooks>, IHistoryOfIssuingBooksRepository
    {
        public HistoryOfIssuingBooksRepository(BookcrossingDbContext dbContext)
           : base(dbContext)
        {

        }
    }
}
