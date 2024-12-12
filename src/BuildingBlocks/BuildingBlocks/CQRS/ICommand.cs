using MediatR;

namespace BuildingBlocks.CQRS
{
    public interface ICommand : ICommand<Unit> //regular interface
    {

    }
    //this is for if there is no any response then we can use this.
    //this is void type interface which does not return response.Unit is type in Mediator which is used for void.
   public interface ICommand<out TResponse> :IRequest<TResponse> //generic interface
    {
    }

   //this interface for those who produced response
}
