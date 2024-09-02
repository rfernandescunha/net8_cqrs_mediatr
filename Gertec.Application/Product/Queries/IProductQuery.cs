using Gertec.Domain.Entities;
using Gertec.Domain.Interface.Repository;
using System.Linq.Expressions;

namespace Gertec.Application.Product.Queries
{
    public interface IProductQuery: IBaseQuery<Domain.Entities.Product>
    { 
        Task<IEnumerable<Domain.Entities.Product>> Find(int? productId, string productName);
        Task<bool> Exist(Expression<Func<Domain.Entities.Product, bool>> predicate);
        Task<int> GetStockCount(Expression<Func<Domain.Entities.Product, bool>> predicate);
    }
}