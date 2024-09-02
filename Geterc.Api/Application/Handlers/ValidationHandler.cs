using FluentValidation;
using MediatR;

namespace Gertec.Api.Application.Handlers
{
    public class ValidationHandler<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator> _validators;

        public ValidationHandler(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            return failures.Any()
                ? throw new Exception(string.Join("| ", failures.Select(x => x.ErrorMessage).ToArray()))
                : next();
        }
    }
}