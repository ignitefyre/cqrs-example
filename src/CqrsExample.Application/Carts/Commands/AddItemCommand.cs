using MediatR;

namespace CqrsExample.Application.Carts.Commands;

public record AddItemCommand(string ProductId, int Quantity, string CartId) : IRequest<bool>;