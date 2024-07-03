using BuildingBlocks.CQRS;
using Ordering.Application.Orders.Dtos;

namespace Ordering.Application.Orders.Queries.GetOrdersByName;

public record GetOrdersByNameQuery(string Name) : IQuery<GetOrdersByNameResut>;
public record GetOrdersByNameResut(IEnumerable<OrderDto> Orders);