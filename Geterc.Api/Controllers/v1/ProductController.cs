using Gertec.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Gertec.Api.Application.Product.Commands.CreateProductCommand;
using Gertec.Api.Application.Product.Commands.DeleteProductCommand;
using Gertec.Api.Application.Product.Commands.UpdateProductCommand;
using Gertec.Api.Application.Product.Queries.QueryProduct.Request;
using Gertec.Api.Application.Product.Queries.QueryProduct.Response;

namespace Gertec.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateProductResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorCustomResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorCustomResult), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ErrorCustomResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CreateProductRequest command)
        {
            try
            {
                var result = await _mediator.Send(command).ConfigureAwait(false);

                if (result.Messages.Any())
                    return Conflict(new ErrorCustomResult(result.Messages));
                else
                    return Created($"/api/v1/product?productId={result.Result.Select(x => x.ProductId).First()}", result);
            }
            catch (Exception ex)
            {
                if (ex.StackTrace.Contains("Gertec.Api.Application.Handlers.ValidationHandler",StringComparison.InvariantCultureIgnoreCase))                
                    return BadRequest(new ErrorCustomResult(ex.Message));                
                else                
                    return StatusCode(StatusCodes.Status500InternalServerError, new ErrorCustomResult(ex.Message));
                
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(UpdateProductResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorCustomResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorCustomResult), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ErrorCustomResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody] UpdateProductRequest command)
        {
            try
            {
                var result = await _mediator.Send(command).ConfigureAwait(false);

                if (result.Messages.Any())
                    return Conflict(new ErrorCustomResult(result.Messages));
                else
                    return Ok();
            }
            catch (Exception ex)
            {
                if (ex.StackTrace.Contains("Gertec.Api.Application.Handlers.ValidationHandler", StringComparison.InvariantCultureIgnoreCase))
                    return BadRequest(new ErrorCustomResult(ex.Message));
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, new ErrorCustomResult(ex.Message));

            }
        }

        [HttpDelete("{productId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorCustomResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorCustomResult), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ErrorCustomResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromRoute] int productId)
        {
            try
            {
                var result = await _mediator.Send(new DeleteProductRequest() { ProductId = productId }).ConfigureAwait(false);

                if (result.Messages.Any())
                    return Conflict(new ErrorCustomResult(result.Messages));
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                if (ex.StackTrace.Contains("Gertec.Api.Application.Handlers.ValidationHandler", StringComparison.InvariantCultureIgnoreCase))                
                    return BadRequest(new ErrorCustomResult(ex.Message));                
                else                
                    return StatusCode(StatusCodes.Status500InternalServerError, new ErrorCustomResult(ex.Message));
                
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(QueryProductResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorCustomResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorCustomResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromQuery] QueryProductAllRequest command)
        {
            try
            {
                var result = await _mediator.Send(command).ConfigureAwait(false);

                if (result.Messages.Any())
                    return Conflict(new ErrorCustomResult(result.Messages));
                else
                    return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.StackTrace.Contains("Gertec.Api.Application.Handlers.ValidationHandler", StringComparison.InvariantCultureIgnoreCase))
                    return BadRequest(new ErrorCustomResult(ex.Message));
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, new ErrorCustomResult(ex.Message));
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(QueryProductResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorCustomResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorCustomResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var command = new QueryProductByIdRequest { ProductId = id };

                var result = await _mediator.Send(command).ConfigureAwait(false);

                if (result.Messages.Any())
                    return Conflict(new ErrorCustomResult(result.Messages));
                else
                    return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.StackTrace.Contains("Gertec.Api.Application.Handlers.ValidationHandler", StringComparison.InvariantCultureIgnoreCase))
                    return BadRequest(new ErrorCustomResult(ex.Message));
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, new ErrorCustomResult(ex.Message));
            }
        }

        [HttpGet("get-amount/{id}")]
        [ProducesResponseType(typeof(QueryProductResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorCustomResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorCustomResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAmount(int id)
        {
            try
            {
                var command = new QueryProductAmountByIdRequest { ProductId = id };

                var result = await _mediator.Send(command).ConfigureAwait(false);

                if (result.Messages.Any())
                    return Conflict(new ErrorCustomResult(result.Messages));
                else
                    return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.StackTrace.Contains("Gertec.Api.Application.Handlers.ValidationHandler", StringComparison.InvariantCultureIgnoreCase))
                    return BadRequest(new ErrorCustomResult(ex.Message));
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, new ErrorCustomResult(ex.Message));
            }
        }

    }
}
