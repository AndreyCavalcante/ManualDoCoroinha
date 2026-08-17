using ManualDoCoroinha.Shared.DTOs;
using System.Linq.Expressions;

namespace ManualDoCoroinha.Repositories;

public interface IBaseRepository<T> where T : class
{
    Task<ResponseListDto<T>> GetAll(int page, int pageSize, Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);
    Task<T?> Get(Expression<Func<T, bool>> predicate);
    Task<T?> Create(T entity);
    Task<T> Update(T entity);
    Task<bool> Delete(T entity);
}
