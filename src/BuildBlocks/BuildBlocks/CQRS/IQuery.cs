using MediatR;

namespace BuildBlocks.CQRS;

public interface IQuery : IQuery<Unit>
{
}

public  interface IQuery<out TResponse> : IRequest<TResponse>
    where TResponse : notnull
{
}
