using Gertec.Application.Product.Commands.CreateProductCommand;
using Gertec.Application.Product.Commands.DeleteProductCommand;
using Gertec.Application.Product.Queries;
using Gertec.Application.Product.Queries.ProdutoQuery;
using Gertec.Application.Product.Repositories;
using Gertec.Application.Produto.Common;
using MediatR;

namespace Gertec.Application.Product
{
    public class ProductHandler :
        IRequestHandler<CreateProductRequest, CreateProductResponse>,
        IRequestHandler<DeleteProductRequest, DeleteProductResponse>,
        IRequestHandler<QueryProductRequest, QueryProductResponse>
    {
        private readonly IProductQuery _productQuery;
        private readonly IProductRepository _productRepository;

        public ProductHandler(
            IProductQuery productQuery,
            IProductRepository productRepository)
        {
            _productQuery = productQuery;
            _productRepository = productRepository;
        }

        public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var product = new Domain.Entities.Product(request.ProductName);

            var products = await _productQuery.Find().ConfigureAwait(false);

            product.ValidateCreate(products);

            if (product.HasNotificationBlockers)
            {
                return new CreateProductResponse(null, product.NotificationBlockers);
            }

            await _productRepository.Insert(product).ConfigureAwait(false);

            return new CreateProductResponse(new List<ProductResponse>() { new ProductResponse(product.Id, product.Name) }, null);
        }

        public async Task<DeleteProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var product = new Domain.Entities.Product(request.ProductId);
            var products = await _productQuery.Find().ConfigureAwait(false);

            product.ValidateDelete(products);

            if (product.HasNotificationBlockers)
            {
                return new DeleteProductResponse(product.NotificationBlockers);
            }

            await _productRepository.Delete(product.Id).ConfigureAwait(false);

            return new DeleteProductResponse();
        }

        public async Task<QueryProductResponse> Handle(QueryProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _productQuery.Find().ConfigureAwait(false);

            return new QueryProductResponse(product.Select(x => new ProductResponse(x.Id, x.Name)), 1, 1, null);
        }
    }
}