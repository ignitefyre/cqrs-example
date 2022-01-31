using MediatR;

namespace CqrsExample.Application.Carts.Queries;

public record GetCartByIdQuery(string Id) : IRequest<CartDto>;