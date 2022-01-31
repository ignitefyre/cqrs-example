using CqrsExample.Application.Carts.Commands;
using MediatR;

namespace CqrsExample.Application.Carts.Handlers;

public class AddItemCommandHandler : IRequestHandler<AddItemCommand, bool>
{
    public Task<bool> Handle(AddItemCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}