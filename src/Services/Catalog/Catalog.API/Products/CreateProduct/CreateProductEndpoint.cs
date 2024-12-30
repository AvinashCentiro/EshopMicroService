
namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price);
    public record CreateProductResponse(Guid Id);

    public class CreateProductEndpoint : ICarterModule
    {
        #region ObjectiveOfAddRoutes
        //So in this function we will define our Http post endpoint using Carter and Napster.
        //And after that we will map the our request to a command object.
        //And after that we will send it through the mediator and then map the result back to the response model.

        //Second parameter of AddRoutes function is Actual Handler method of this request
        //we will use Sender of type ISender in order to send our function thr mediator  

        #endregion

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/Products",
                    async (CreateProductRequest request, ISender sender) =>
                    {
                        var command = request.Adapt<CreateProductCommand>();
                        //here we are creating request object to command using napster
                        //Why we need a command object? Because our mediator is requiring command object in order to trigger our command handler.
                        var result = await sender.Send(command);
                        //This command will be Start the mediator and trigger the handler class.
                        var response = result.Adapt<CreateProductResponse>();
                        //here we will convert result to our response object.

                        return Results.Created($"/products/{response.Id}", response);
                    })
                .WithName("CreateProduct")
                .Produces<CreateProductResponse>(StatusCodes.Status201Created)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Create Product")
                .WithDescription("Create Product");
        }
    }

        #region AboutLiabries

    //Carter is a library that extends the capabilities of ASP.Net core minimal APIs.
    //It provides a more structured way to organize our endpoints and simplify the creation of the Http request.
    // So Carter is especially beneficial in minimal APIs-->imp not that useful in conventional MVC or asp.net core api , 

    //we need to convert incoming request object into its equivalent Command object in order to execute command handler
    //and to achieve this we need mapping library .So Mapter helps us to to do that.it is object mapping library.
    // we are mapster library becoz i think Mdiator and CQRS pattern 

    #endregion
}

