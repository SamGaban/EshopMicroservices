using MediatR;

namespace BuildingBlocks.CQRS;

// Unit is a type from MediatR that represents a void response so we can use it as a response type for commands that don't return anything.
public interface ICommand : ICommand<Unit>
{
    
}

// This interface is used for commands that return a response. the out keyword is used to specify that the type parameter can only be used as a return type.
public interface ICommand<out TResponse> : IRequest<TResponse>
{
    
}