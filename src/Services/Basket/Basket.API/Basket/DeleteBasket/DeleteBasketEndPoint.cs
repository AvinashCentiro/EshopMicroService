using Basket.API.Basket.GetBasket;

namespace Basket.API.Basket.DeleteBasket;

//public record DeleteBasketRequest(string Username);

public record DeleteBasketResponse(bool IsSuccess);
public class DeleteBasketEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/basket/{userName}", async (string userName, ISender sender) =>
        {
            var result = await sender.Send(new DeleteBasketCommand(userName));
            var response = result.Adapt<DeleteBasketResponse>();
            Results.Ok(response);
        }).WithName("Delete by UserName")
        .Produces<DeleteBasketResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete Basket By UserName")
        .WithDescription("Delete Basket By UserName");
    }
}

