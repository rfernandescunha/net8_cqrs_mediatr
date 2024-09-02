using Gertec.Api.Application.Product.Commands.CreateProductCommand;
using Gertec.Api.Application.Product.Commands.UpdateProductCommand;
using Gertec.Api.Application.Product.Common;
using Gertec.Api.Application.Product.Repositories;
using Gertec.Api.Controllers.v1;
using Gertec.Api.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Controller;
using Microsoft.Win32;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Gertec.Tests.Product.Controller
{
    public class ProductTest
    {
        private readonly Mock<IMediator> _mediator;

        public ProductTest()
        {
            _mediator = new Mock<IMediator>();

        }

        [Fact]
        public async Task Test_Create_POST_CreatedResult()
        {

            var command = new CreateProductRequest()
            {
                ProductName = "Test Four",
                ProductCategoryName = "Test Four",
                ProductDescription = "teste teste",
                ProductImgUrl = "http://testetesteteste.com.br",
                ProductPrice = 59,
                ProductAmount = 9
            };
            var response = new CreateProductResponse(new List<ProductResponse>() { new ProductResponse(1, "Teste") }, null);


            _mediator.Setup(m => m.Send(It.IsAny<CreateProductRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);


            var controller = new ProductController(_mediator.Object);

            var result = await controller.Post(new CreateProductRequest());

            var viewResult = Assert.IsAssignableFrom<CreatedResult>(result);


            Assert.Single(((CreateProductResponse)viewResult.Value).Result);
            Assert.Equal(201, viewResult.StatusCode);
        }


        [Fact]
        public async Task Test_Update_PUT_OkResult()
        {

            var command = new UpdateProductRequest()
            {
                ProductId = 1,
                ProductName = "Test Four",
                ProductCategoryName = "Test Four",
                ProductDescription = "teste teste",
                ProductImgUrl = "http://testetesteteste.com.br",
                ProductPrice = 59,
                ProductAmount = 9
            };
            var response = new UpdateProductResponse(new List<ProductResponse>() { new ProductResponse(1, "Teste") }, null);


            _mediator.Setup(m => m.Send(It.IsAny<UpdateProductRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);


            var controller = new ProductController(_mediator.Object);

            var result = await controller.Put(new UpdateProductRequest());

            var viewResult = Assert.IsAssignableFrom<OkResult>(result);


            Assert.Equal(200, viewResult.StatusCode);
        }
    }
}
