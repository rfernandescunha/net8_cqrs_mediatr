namespace Gertec.Api.Application.Product.Commands.CreateProductCommand
{
    public class CreateProductRequest : MediatR.IRequest<CreateProductResponse>
    {
        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; }

        public string ProductCategoryName { get; set; }

        public string ProductImgUrl { get; set; }

        public int ProductAmount { get; set; }

    }
}