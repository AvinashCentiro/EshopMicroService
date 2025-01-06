namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductRequest(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price);
    public record UpdateProductResponse(bool IsSuccess);

    /*These parameter names should be exactly name with the command object in the UpdateProductHandler
      Because mapster will be mapped these objects looking for the parameter type and the parameter name.
      So make sure that you have created update product request correctly.
    */
   
    public class UpdateProductEndpoint:ICarterModule
    {
        public  void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/products", async (UpdateProductRequest request,ISender sender) =>
            {
                var command = request.Adapt<UpdateProductCommand>();
               var result = await sender.Send(command);

              var response= result.Adapt<UpdateProductResponse>();

              return Results.Ok(response);
            })
            .WithName("UpdateProduct")
            .Produces<UpdateProductResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Update Product")
            .WithDescription("Update Product");
        }

        /*In this endpoint class we basically define a put request for slash products endpoint and the endpoint
         receive an update product request object, and it adapts it to do an update product command using the mapster.
         And we basically send this command through the mediator.
         And mediator will be triggered the command handler and respond back the result object.
        Again We will adapt the result object to the response object and send back to the client.
        */
    }
}
