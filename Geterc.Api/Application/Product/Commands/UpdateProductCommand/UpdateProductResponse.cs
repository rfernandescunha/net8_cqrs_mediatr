using Gertec.Api.Application.Common.Commands;
using Gertec.Api.Application.Product.Common;

namespace Gertec.Api.Application.Product.Commands.UpdateProductCommand
{
    public class UpdateProductResponse : UpdateResponseBase<ProductResponse>
    {
        public UpdateProductResponse(
            IEnumerable<ProductResponse> result, IEnumerable<string> messages)
                : base(result, messages)
        {
        }
    }
}