using System.Collections.Generic;
using Xunit;

namespace Gertec.Tests.Product.Domain
{
    public class ProductTests
    {
        [Fact]
        public void Create_Product_Should_Notify_Blocker_Duplicated()
        {
            var productName = "product_03";
            var product = new Api.Domain.Entities.Product(productName);
            var products = GenerateProducts();

            product.ValidateCreate(products);

            Assert.Contains($"ProductName [{productName}] already exists!", product.NotificationBlockers);
        }

        [Fact]
        public void Create_Product_Should_Not_Notify_Blocker_Duplicated()
        {
            var productName = "product_06";
            var product = new Api.Domain.Entities.Product(productName);
            var products = GenerateProducts();

            product.ValidateCreate(products);

            Assert.DoesNotContain($"[{productName}] already exists", product.NotificationBlockers);
        }

        [Fact]
        public void Delete_Product_Should_Notify_Blocker_Not_found()
        {
            var productId = 6;
            var product = new Api.Domain.Entities.Product(productId);
            var products = GenerateProducts();

            product.ValidateDelete(products);

            Assert.Contains($"ProductId [{productId}] not found!", product.NotificationBlockers);
        }

        [Fact]
        public void Delete_Product_Should_Not_Notify_Blocker_Not_found()
        {
            var productId = 3;
            var product = new Api.Domain.Entities.Product(productId);
            var products = GenerateProducts();

            product.ValidateDelete(products);

            Assert.DoesNotContain($"ProductId [{productId}] not found!", product.NotificationBlockers);
        }

        private IEnumerable<Api.Domain.Entities.Product> GenerateProducts()
        {
            return
            [
                new Api.Domain.Entities.Product(1, "product_01"),
                new Api.Domain.Entities.Product(2, "product_02"),
                new Api.Domain.Entities.Product(3, "product_03"),
                new Api.Domain.Entities.Product(4, "product_04"),
                new Api.Domain.Entities.Product(5, "product_05")
            ];
        }
    }
}