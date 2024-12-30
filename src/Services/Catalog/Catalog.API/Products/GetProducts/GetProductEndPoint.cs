
namespace Catalog.API.Products.GetProducts
{
    //We should always define request and response in the endpoint
    //and always define query or command and Result in the handler class.

    public record GetProductResponse(IEnumerable<Product> Products);


    public class GetProductEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender) =>
            {
                var result = await sender.Send(new GetProductQuery());
                var response = result.Adapt<GetProductResponse>();

                return Results.Ok(response);
            })
            .WithName("GetProduct") 
            .Produces<GetProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Product")
            .WithDescription("Get Product");
        }
    }
}
