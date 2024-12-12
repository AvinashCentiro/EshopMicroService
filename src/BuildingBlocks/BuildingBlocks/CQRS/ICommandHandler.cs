using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BuildingBlocks.CQRS
{

    public interface ICommandHandler<in TCommand> : ICommandHandler<TCommand, Unit>
        where TCommand : ICommand<Unit>
    {

    }
    //this handler interface is for if we do not receive any response 

    public interface ICommandHandler<in TCommand, TResponse> //generic interface to handle command and its response
        : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
        where TResponse : notnull
    {
    }
    //this handler interface is for if we receive any response then we uses this interface 
    //To ICommandHandler pass command which we want to execute and expect generic response of that command. i.e  public interface ICommandHandler<in TCommand, TResponse> 

    /*
    we are using  where  TCommand:ICommand<TResponse> to specify that TCommand should be type  of ICommand 
    which we have already defined.if we remove this where it will give error saying that TCommand type can not used as TRequest becoz TCommand comes from mediator .
    so by specifying where TCommand we are telling that TCommand  is of ICommand which we have defined already in this project and it is returning response of type TResponse.
   */

}
