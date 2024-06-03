using MediatR;

namespace BuildingBlocks.CQRS;

// This interface is used for queries that return a response. the out keyword is used to specify that the type parameter can only be used as a return type.
public interface IQuery<out TResponse> : IRequest<TResponse>
    where TResponse : notnull
{
    
}