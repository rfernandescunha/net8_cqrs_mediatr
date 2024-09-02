using System.Collections.Generic;

namespace Gertec.Api.Common
{
    public class ErrorCustomResult
    {
        public IEnumerable<string> Messages { get; set; }

        public ErrorCustomResult(string message)
        {
            Messages = new List<string>() { message };
        }

        public ErrorCustomResult(IEnumerable<string> messages)
        {
            Messages = messages;
        }
    }
}