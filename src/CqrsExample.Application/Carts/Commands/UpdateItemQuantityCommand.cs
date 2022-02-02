using MediatR;

namespace CqrsExample.Application.Carts.Commands;

public record UpdateItemQuantityCommand(string ProductId, int Quantity, string CartId) : IRequest<bool>;