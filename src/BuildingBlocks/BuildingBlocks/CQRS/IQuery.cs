using MediatR;

namespace BuildingBlocks.CQRS
{
    //public interface IQuery : IRequest<Unit> //regular interface
    //{

    //}

    public interface IQuery<out TResponse> : IRequest<TResponse> //generic interface used to read from Db
        where TResponse : notnull
    {
    }
}
