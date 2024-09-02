using System.Collections.Generic;
using System.Linq;

namespace Gertec.Application.Product.Commands.DeleteProductCommand
{
    public class DeleteProductResponse
    {
        public IEnumerable<string> Messages { get; set; }

        public DeleteProductResponse()
        {
            Messages = Enumerable.Empty<string>();
        }

        public DeleteProductResponse(string message)
        {
            Messages = Enumerable.Empty<string>();
            Messages = new List<string>() { message };
        }

        public DeleteProductResponse(IEnumerable<string> messages)
        {
            Messages = Enumerable.Empty<string>();
            Messages = messages;
        }
    }
}