using Gertec.Api.Application.Product.Commands.CreateProductCommand;
using Xunit;

namespace Gertec.Tests.Product.Application
{
    public class ProductTests
    {
        [Fact]
        public void CreateCommand_Product_Should_Null_Invalid()
        {
            var command = new CreateProductValidator();
            var test1 = command.Validate(new CreateProductRequest());

            Assert.False(test1.IsValid, "Validation against [ProductName null] fail!");
        }

        [Fact]
        public void CreateCommand_Product_Should_Empty_Invalid()
        {
            var command = new CreateProductValidator();
            var test2 = command.Validate(new CreateProductRequest() { ProductName = string.Empty });

            Assert.False(test2.IsValid, "Validation against [ProductName empty] fail!");
        }

        [Fact]
        public void CreateCommand_Product_Should_Characters_Invalid()
        {
            var command = new CreateProductValidator();
            var test3 = command.Validate(new CreateProductRequest() { ProductName = "UAHuaHAUhauHAUhauHAuhaUHAuhauhAUHauauauAUHuahUAHuahUAHhauHASUhauHAUhauHAUhauHAHUA" });

            Assert.False(test3.IsValid, "Validation against [ProductName greater then 64 charcteres] fail!");
        }

        [Fact]
        public void CreateCommand_Product_Should_Valid()
        {
            var command = new CreateProductValidator();
            var test1 = command.Validate(new CreateProductRequest() { ProductName = "flag_01" });

            Assert.True(test1.IsValid, "Validation against [ProductName] passed!");
        }
    }
}