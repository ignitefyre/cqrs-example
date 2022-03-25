using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CqrsExample.Application.Carts;
using CqrsExample.Application.Carts.Commands;
using CqrsExample.Application.Carts.Handlers;
using CqrsExample.Domain.Carts;
using CqrsExample.Domain.Exceptions;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace CqrsExample.Application.Tests.Carts;

public class RemoveItemCommandHandlerTests : TestBase
{
    [Test]
    public void ShouldRemoveItemFromTheCart()
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
        
        var sut = new RemoveItemCommandHandler(cartRepositoryMock.Object);

        var request = new RemoveItemCommand("123", cartId);
        
        //act
        var result = sut.Handle(request, CancellationToken.None);
        
        //assert
        cart.GetItems().Count().Should().Be(0);
        cartRepositoryMock.Verify(x => x.Update(cart), Times.Once);
    }
    
    [Test]
    public void ShouldThrowExceptionWhenNoCartFound()
    {
        //arrange
        const string cartId = "abc";
        
        var cartRepositoryMock = new Mock<ICartRepository>();
        cartRepositoryMock.Setup(x => x.GetById(cartId)).Returns(default(Cart));
        
        var sut = new RemoveItemCommandHandler(cartRepositoryMock.Object);

        var request = new RemoveItemCommand("123", cartId);

        //act
        var result = () => sut.Handle(request, CancellationToken.None);

        //assert
        cartRepositoryMock.Verify(x => x.Update(It.IsAny<Cart>()), Times.Never);
        result.Should().ThrowAsync<CartNotFoundException>();
    }
}