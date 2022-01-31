using MediatR;

namespace CqrsExample.Application.Carts.Commands;

public record AddItemCommand(string ProductId, int Quantity) : IRequest<bool>;