using Gertec.Application.Product.Repositories;
using Gertec.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Gertec.Infrastructure.Data.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly GertecDbContext _context;
        public ProductRepository(GertecDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int Id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(o => o.Id == Id);

            if(product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                return true;
            }
            else
                return false;
        }

        public async Task<Domain.Entities.Product> Insert(Domain.Entities.Product product)
        {
            if (product == null)
                return new Domain.Entities.Product();


            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Domain.Entities.Product> Update(Domain.Entities.Product product)
        {
            var prod = await _context.Products.FirstOrDefaultAsync(o => o.Id == product.Id);

            if (prod != null)
            {
                prod = product;
                await _context.SaveChangesAsync();
            };

            return product;

        }
    }
}
