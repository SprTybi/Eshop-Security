using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DataAccessServiceContract.Base
{
    public interface IBaseRepositorySearchable<TModel, TKey, TSearchModel, TListItem> : IBaseRepository<TModel, TKey>
    {
        List<TListItem> Search(TSearchModel sm,out int RecordCount);
    }
}
