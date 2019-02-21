using System.Linq;
using GraphQL.Business;
using GraphQL.Business.Models;
using GraphQL.Business.Models.Parameters;

namespace GraphQL.Data.Commands
{
    public interface ICreatePagination<TEntity> : ICommand<IQueryable<TEntity>, Pagination<TEntity>>
    {
        ICreatePagination<TEntity> With(PaginationParameter pagination);
    }
}
