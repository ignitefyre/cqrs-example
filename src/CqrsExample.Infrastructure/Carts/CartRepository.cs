using CqrsExample.Application.Carts;
using CqrsExample.Domain.Carts;

namespace CqrsExample.Infrastructure.Carts;

public class CartRepository : ICartRepository
{
    public Cart GetById(string id)
    {
        throw new NotImplementedException();
    }
}