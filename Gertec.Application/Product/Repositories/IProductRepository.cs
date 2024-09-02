using Gertec.Domain.Entities;
using Gertec.Domain.Interface.Repository;
using System.Linq.Expressions;

namespace Gertec.Application.Product.Repositories
{
    public interface IProductRepository : IBaseRepository<Domain.Entities.Product>
    {

    }
}