using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CqrsExample.Application.Carts;
using CqrsExample.Application.Carts.Handlers;
using CqrsExample.Application.Carts.Queries;
using CqrsExample.Domain.Carts;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace CqrsExample.Application.Tests.Carts;

public class GetCartByIdQueryHandlerTests : TestBase
{
    [Test]
    public async Task ShouldReturnACartDtoResult()
    {
        //arrange
        const string cartId = "abc";
        var cartItems = new List<CartItem>
        {
            new CartItem("123", 1)
        };
        var cart = new Cart(cartId, cartItems);
        
        var cartRepositoryMock = new Mock<ICartRepository>();
        cartRepositoryMock.Setup(x => x.GetById(cartId)).Returns(cart);
        
        var sut = new GetCartByIdQueryHandler(cartRepositoryMock.Object);

        var request = new GetCartByIdQuery(cartId);
        
        //act
        var result = await sut.Handle(request, CancellationToken.None);
        
        //assert
        result.Id.Should().Be(cartId);
        result.Items.Count.Should().Be(1);
        result.Items.First().Id.Should().Be("123");
        result.Items.First().Quantity.Should().Be(1);
    }
}