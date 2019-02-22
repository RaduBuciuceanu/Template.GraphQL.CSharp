using System.Linq;
using Template.Business;
using Template.Business.Models;
using Template.Business.Models.Parameters;

namespace Template.Data.Commands
{
    public interface ICreatePagination<TEntity> : ICommand<IQueryable<TEntity>, Pagination<TEntity>>
    {
        ICreatePagination<TEntity> With(PaginationParameter pagination);
    }
}
