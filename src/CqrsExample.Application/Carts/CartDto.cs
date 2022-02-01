namespace CqrsExample.Application.Carts;

public record CartDto(string Id, ICollection<CartItemDto> Items);