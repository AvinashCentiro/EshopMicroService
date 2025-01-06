using Catalog.API.Products.GetProductById;

namespace Catalog.API.Products.GetProductByCategory
{
    public class GetProductByCategoryEndPoint : ICarterModule
    {
       // public record GetProductByCategoryRequest();
        public record GetProductByCategoryResponse(IEnumerable<Product> Products);

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{category}", async (string category, ISender sender) =>
            {
                var result = await sender.Send(new
                    GetProductByCategoryQuery(category));

                var response = result.Adapt<GetProductByCategoryResponse>();

                return Results.Ok(response);
            })
            .WithName("GetProductByCategory")
            .Produces<GetProductByCategoryResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Product By Category")
            .WithDescription("Get Product By Category");
        }

        /*
In this endpoint definition we basically map Http get method with these URL /products/category and {category name}.
And this endpoint uses mediator to send the get products by category query.
And then this will be trigger the handler method and then adapts to our response object that will be
returned to the client.
         */
    }
}
