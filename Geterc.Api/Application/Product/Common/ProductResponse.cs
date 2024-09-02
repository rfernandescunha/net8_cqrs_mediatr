using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Gertec.Api.Application.Product.Common
{
    public class ProductResponse
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public string ProductDescription { get; set; }

        public string ProductCategoryName { get; set; }

        public string ProductImgUrl { get; set; }

        public int ProductAmount { get; set; }

        public ProductResponse()
        {
        }

        public ProductResponse(int productId, string productName)
        {
            ProductId = productId;
            ProductName = productName;
        }


        public ProductResponse(int productId, string productName, decimal productPrice, string productDescription, string productCategoryName, string productImgUrl, int productAmount)
        {
            ProductId = productId;
            ProductName = productName;
            ProductPrice = productPrice;
            ProductDescription = productDescription;
            ProductCategoryName = productCategoryName;
            ProductImgUrl = productImgUrl;
            ProductAmount = productAmount;
        }
    }
}