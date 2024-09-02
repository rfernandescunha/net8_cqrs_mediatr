using System.Collections.Generic;

namespace Gertec.Application.Produto.Common
{
    public class ProductResponse
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public ProductResponse()
        {
        }

        public ProductResponse(int productId, string productName)
        {
            ProductId = productId;
            ProductName = productName;
        }
    }
}