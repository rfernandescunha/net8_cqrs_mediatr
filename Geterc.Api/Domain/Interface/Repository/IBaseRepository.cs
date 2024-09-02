using System.Linq.Expressions;

namespace Gertec.Api.Domain.Interface.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> Insert(T Objeto);
        Task<T> Update(T Objeto);
        Task<bool> Delete(int Id);
    }
}
