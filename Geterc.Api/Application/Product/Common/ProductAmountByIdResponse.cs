namespace Gertec.Api.Application.Product.Common
{
    public class ProductAmountByIdResponse
    {
        public int ProductId { get; set; }

        public int ProductAmount { get; set; }

        public ProductAmountByIdResponse()
        {
        }

        public ProductAmountByIdResponse(int productId, int productAmount)
        {
            ProductId = productId;
            ProductAmount = productAmount;
        }

    }
}