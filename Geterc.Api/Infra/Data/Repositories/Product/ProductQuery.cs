using Gertec.Api.Application.Product.Queries;
using Gertec.Api.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Gertec.Api.Infra.Data.Repositories.Product
{
    public class ProductQuery : IProductQuery
    {
        private readonly GertecDbContext _context;
        public ProductQuery(GertecDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Exist(Expression<Func<Domain.Entities.Product, bool>> predicate)
        {
            var itens = await _context.Set<Api.Domain.Entities.Product>().Where(predicate).AsNoTracking().ToListAsync();

            return itens.Count != 0;
        }

        public async Task<Domain.Entities.Product> Find(int Id)
        {
            var result = await _context.Products.FirstOrDefaultAsync(x => x.Id == Id) ?? new Domain.Entities.Product();

            return result;

        }

        public async Task<IEnumerable<Domain.Entities.Product>> Find(Expression<Func<Domain.Entities.Product, bool>>? predicate = null)
        {

            if (predicate != null)
            {
                return await _context.Products.Where(predicate).AsNoTracking().ToListAsync();
            }
            else
            {
                return await _context.Products.ToListAsync();
            }
        }

        public async Task<IEnumerable<Domain.Entities.Product>> Find(int? productId, string productName)
        {
            if (productId != null)
                return await _context.Products.Where(x => x.Id == productId && x.Name == productName).ToListAsync();
            else
                return await _context.Products.Where(x => x.Name == productName).ToListAsync();
        }

        public async Task<int> GetStockCount(Expression<Func<Domain.Entities.Product, bool>> predicate)
        {
            var amount = await _context.Products.Where(predicate).AsNoTracking().CountAsync();

            return amount;
        }
    }
}
