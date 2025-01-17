
namespace Catalog.API.Products.GetProducts
{
    //We should always define request and response in the endpoint
    //and always define query or command and Result in the handler class.
    public record GetProductRequest(int? PageNumber = 1, int? PageSize = 10);

    public record GetProductResponse(IEnumerable<Product> Products);


    public class GetProductEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async ([AsParameters] GetProductRequest request, ISender sender) =>
                {

                    var query = request.Adapt<GetProductQuery>();
                    var result = await sender.Send(query);
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
