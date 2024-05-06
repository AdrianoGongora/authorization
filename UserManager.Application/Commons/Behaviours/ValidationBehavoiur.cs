using FluentValidation;
using MediatR;
using UserManager.Application.Commons.Bases;
using ValidationException = UserManager.Application.Commons.Exceptions.ValidationException;

namespace UserManager.Application.Commons.Behaviours;

public class ValidationBehavoiur<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!validators.Any()) return await next();
        var context = new ValidationContext<TRequest>(request);

        var validationResults =
            await Task.WhenAll(validators.Select(x => x.ValidateAsync(context, cancellationToken)));

        var failures = validationResults
            .Where(x => x.Errors.Count != 0)
            .SelectMany(x => x.Errors)
            .Select(x => new BaseError()
            {
                PropertyName = x.PropertyName,
                ErrorMessage = x.ErrorMessage
            }).ToList();

        if (failures.Count != 0)
        {
            throw new ValidationException(failures);
        }

        return await next();
    }
}
