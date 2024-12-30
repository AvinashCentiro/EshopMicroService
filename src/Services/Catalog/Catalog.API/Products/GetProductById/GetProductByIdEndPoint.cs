namespace Catalog.API.Products.GetProductById
{
    //  public record GetProductByIdRequest();

    public record GetProductByIdResponse(Product Product);
    // here we are mentioning response object as record type and in the response we are expecting single product

    public class GetProductByIdEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByIdQuery(id));
                //So by this way we will pass these query object to the mediator.
                // And mediator will be trigger corresponding query handler class and perform its logic and return back

                var response = result.Adapt<GetProductByIdResponse>();

                return Results.Ok(response);
            })
            .WithName("GetProductById")
            .Produces<GetProductByIdResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Product By Id")
            .WithDescription("Get Product By Id");
        }

        /*
        So basically in this endpoint definition we are mapping the Get request with this product slash ID information which takes a product id as a parameter.
           
        And the endpoint is using the mediator.In order to send get product by id query object, then mediator will be trigger the corresponding query
        
        handler, and after that with getting the result object mapping this result object to the or get product*/
    }
}
