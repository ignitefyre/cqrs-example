using MediatR;

namespace CqrsExample.Application.Carts.Commands;

public record RemoveItemCommand(string ProductId, string CartId) : IRequest<bool>;