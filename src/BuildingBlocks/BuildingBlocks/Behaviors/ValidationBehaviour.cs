
using BuildingBlocks.CQRS;
using FluentValidation;
using MediatR;

namespace BuildingBlocks.Behaviors
{
    public class ValidationBehaviour<TRequest,TResponse>
       (IEnumerable<IValidator<TRequest>> validators) :IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand<TResponse>
    {
        #region CodeNotes
        //video no 85 is  very important as it has explanantion why and how we can add generics to our Behavior which things we can consider for it.
        //Pipeline Behaviors: These are middleware components in the pipeline. Each behavior can process the request before or after passing it to the next behavior in the chain.
        // Mediator pipeline behavior allows us to introduce additional processing steps such as the validation into the handling of the request.
        #endregion

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            //So the first parameter is representing the incoming request from the client, and the second parameter
            // is representing the next request handle delegate which means the next pipeline behavior or actual handler


            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(validators.Select(v=>v.ValidateAsync(context,cancellationToken)));
           
            var failures=validationResults.Where(r=>r.Errors.Any())
                .SelectMany(r=>r.Errors)
                .ToList();


            if (failures.Any())
                throw new ValidationException(failures);

            return await next();

            //This will be run the next pipeline behavior, which will be the our actual command handle method.
            // This is very crucial to calling this next method in order to continue this pipeline request lifecycle.
        }
    }
}
