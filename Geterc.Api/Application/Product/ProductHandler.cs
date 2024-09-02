using Gertec.Api.Application.Product.Commands.CreateProductCommand;
using Gertec.Api.Application.Product.Commands.DeleteProductCommand;
using Gertec.Api.Application.Product.Commands.UpdateProductCommand;
using Gertec.Api.Application.Product.Common;
using Gertec.Api.Application.Product.Queries;
using Gertec.Api.Application.Product.Queries.QueryProduct.Request;
using Gertec.Api.Application.Product.Queries.QueryProduct.Response;
using Gertec.Api.Application.Product.Repositories;
using MediatR;

namespace Gertec.Api.Application.Product
{
    public class ProductHandler :
        IRequestHandler<CreateProductRequest, CreateProductResponse>,
        IRequestHandler<UpdateProductRequest, UpdateProductResponse>,
        IRequestHandler<DeleteProductRequest, DeleteProductResponse>,
        IRequestHandler<QueryProductAllRequest, QueryProductResponse>,
        IRequestHandler<QueryProductByIdRequest, QueryProductResponse>,
        IRequestHandler<QueryProductAmountByIdRequest, QueryProductAmountByIdResponse>
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

        public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var product = new Domain.Entities.Product(request.ProductName);

            var products = await _productQuery.Find().ConfigureAwait(false);

            product.ValidateCreate(products);

            if (product.HasNotificationBlockers)
            {
                return new UpdateProductResponse(null, product.NotificationBlockers);
            }

            await _productRepository.Insert(product).ConfigureAwait(false);

            return new UpdateProductResponse(new List<ProductResponse>() { new ProductResponse(product.Id, product.Name) }, null);
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

        public async Task<QueryProductResponse> Handle(QueryProductAllRequest request, CancellationToken cancellationToken)
        {
            var product = await _productQuery.Find();

            return new QueryProductResponse(product.Select(x => new ProductResponse(    x.Id,
                                                                                        x.Name,
                                                                                        x.Price,
                                                                                        x.Description,
                                                                                        x.CategoryName,
                                                                                        x.ImgUrl,
                                                                                        x.Amount)), 1, 1, null);
        }

        public async Task<QueryProductResponse> Handle(QueryProductByIdRequest request, CancellationToken cancellationToken)
        {
            var product = new Domain.Entities.Product(request.ProductId);
            var products = await _productQuery.Find(x => x.Id == request.ProductId);

            product.ValidateGetById(products);

            if (product.HasNotificationBlockers)
            {
                return new QueryProductResponse(null, 0, 0, product.NotificationBlockers);
            }

            return new QueryProductResponse(products.Select(x => new ProductResponse(
                                                                                        x.Id,
                                                                                        x.Name,
                                                                                        x.Price,
                                                                                        x.Description,
                                                                                        x.CategoryName,
                                                                                        x.ImgUrl,
                                                                                        x.Amount)), 1, 1, null);
        }

        public async Task<QueryProductAmountByIdResponse> Handle(QueryProductAmountByIdRequest request, CancellationToken cancellationToken)
        {
            var product = new Domain.Entities.Product(request.ProductId);
            var products = await _productQuery.Find(x => x.Id == request.ProductId);

            product.ValidateGetById(products);

            if (product.HasNotificationBlockers)
            {
                return new QueryProductAmountByIdResponse(null,product.NotificationBlockers);
            }

            return new QueryProductAmountByIdResponse(products.Select(x => new ProductAmountByIdResponse(
                                                                                        x.Id, 
                                                                                        x.Amount)), null);
        }

    }
}