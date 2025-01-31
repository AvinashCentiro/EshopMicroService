namespace Basket.API.Basket.DeleteBasket;

public record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketResult>;

public record DeleteBasketResult(bool IsSuccess);

public class DeleteBasketValidator : AbstractValidator<DeleteBasketCommand>
{
    public DeleteBasketValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("User Name is required.");
    }
}

public class DeleteBasketHandler : ICommandHandler<DeleteBasketCommand,DeleteBasketResult>
{
    public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
    {
        //TODO:delete basket from db and cache
        //TODO:session.Delete<Product>(Command.ID)  

        return new DeleteBasketResult(true);
    }
}

