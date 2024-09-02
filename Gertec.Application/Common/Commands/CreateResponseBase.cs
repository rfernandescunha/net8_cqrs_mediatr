using System.Collections.Generic;
using System.Linq;

namespace Gertec.Application.Common.Commands
{
    public abstract class CreateResponseBase<T> where T : class
    {
        public IEnumerable<T> Result { get; protected set; }

        public int Pages { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public IEnumerable<string> Messages { get; set; }

        protected CreateResponseBase(IEnumerable<T> result, IEnumerable<string> messages)
        {
            if (messages != null && messages.Any())
            {
                Messages = messages;
            }
            else
            {
                Result = result;
                Pages = 1;
                Page = 1;
                PageSize = result.Count();
                Messages = Enumerable.Empty<string>();
            }
        }
    }
}