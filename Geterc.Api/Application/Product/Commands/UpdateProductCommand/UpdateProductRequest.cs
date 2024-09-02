namespace Gertec.Api.Application.Product.Commands.UpdateProductCommand
{
    public class UpdateProductRequest : MediatR.IRequest<UpdateProductResponse>
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; }

        public string ProductCategoryName { get; set; }

        public string ProductImgUrl { get; set; }

        public int ProductAmount { get; set; }

    }
}