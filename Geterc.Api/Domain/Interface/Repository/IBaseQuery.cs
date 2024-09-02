using System.Linq.Expressions;

namespace Gertec.Api.Domain.Interface.Repository
{
    public interface IBaseQuery<T> where T : class
    {
        Task<T> Find(int Id);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>>? predicate = null);
    }
}
