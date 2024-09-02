using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.Application.Common.Queries
{
    public abstract class QueryResponseBase<T> where T : class
    {
        public IEnumerable<T> Result { get; protected set; }

        public int Pages { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public IEnumerable<string> Messages { get; set; }

        protected QueryResponseBase(
            IEnumerable<T> result, int pages, int page, IEnumerable<string> messages)
        {
            if (messages != null && messages.Any())
            {
                Messages = messages;
            }
            else
            {
                Result = result;
                Pages = pages;
                Page = page;
                PageSize = result.Count();
                Messages = Enumerable.Empty<string>();
            }
        }
    }
}
