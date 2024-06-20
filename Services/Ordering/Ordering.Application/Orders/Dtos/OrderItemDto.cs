namespace Ordering.Application.Orders.Dtos;

public record OrderItemDto(
    Guid Order,
    Guid ProductId,
    int Quantity,
    decimal Price
    );