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

public class AddItemCommandHandlerTests : TestBase
{
    [Test]
    public void ShouldAddItemToExistingCart()
    {
        //arrange
        const string cartId = "abc";
        var cart = new Cart(cartId);
        
        var cartRepositoryMock = new Mock<ICartRepository>();
        cartRepositoryMock.Setup(x => x.GetById(cartId)).Returns(cart);

        var eventRepositoryMock = new Mock<IEventRepository>();

        var sut = new AddItemCommandHandler(cartRepositoryMock.Object, eventRepositoryMock.Object);

        var request = new AddItemCommand("123", 1, cartId);

        //act
        var result = sut.Handle(request, CancellationToken.None);

        //assert
        cart.GetItems().Count().Should().Be(1);
        cart.GetItems().First().Quantity.Should().Be(1);
        cartRepositoryMock.Verify(x => x.Update(cart), Times.Once);
    }
    
    [Test]
    public void ShouldThrowExceptionWhenNoCartFound()
    {
        //arrange
        const string cartId = "abc";
        
        var cartRepositoryMock = new Mock<ICartRepository>();
        cartRepositoryMock.Setup(x => x.GetById(cartId)).Returns(default(Cart));
        
        var eventRepositoryMock = new Mock<IEventRepository>();
        
        var sut = new AddItemCommandHandler(cartRepositoryMock.Object, eventRepositoryMock.Object);

        var request = new AddItemCommand("123", 1, cartId);

        //act
        var result = () => sut.Handle(request, CancellationToken.None);

        //assert
        cartRepositoryMock.Verify(x => x.Update(It.IsAny<Cart>()), Times.Never);
        result.Should().ThrowAsync<CartNotFoundException>();
    }
}