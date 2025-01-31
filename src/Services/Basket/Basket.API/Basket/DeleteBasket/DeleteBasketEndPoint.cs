using Basket.API.Basket.GetBasket;

namespace Basket.API.Basket.DeleteBasket;

//public record DeleteBasketRequest(string Username);

public record DeleteBasketResponse();
public class DeleteBasketEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket/{userName}", async (string userName, ISender sender) =>
        {
            var result = await sender.Send(new DeleteBasketCommand(userName));
            var response = result.Adapt<DeleteBasketResponse>();
            Results.Ok(response);
        }).WithName("Delete by UserName")
        .Produces<DeleteBasketResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Delete Basket By UserName")
        .WithDescription("Delete Basket By UserName");
    }
}

