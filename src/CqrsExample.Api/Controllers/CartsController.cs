using CqrsExample.Api.Models;
using CqrsExample.Application.Carts.Commands;
using CqrsExample.Application.Carts.Queries;
using CqrsExample.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsExample.Api.Controllers
{
    [Route("v1/carts")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private ISender Mediatr => HttpContext.RequestServices.GetRequiredService<ISender>();

        [HttpGet]
        [Route("{cartId}")]
        public IActionResult GetCart([FromRoute] string cartId)
        {
            try
            {
                var result = Mediatr.Send(new GetCartByIdQuery(cartId)).GetAwaiter().GetResult();
            
                return Ok(result);
            }
            catch (CartNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("{cartId}/items")]
        public IActionResult AddItem([FromRoute] string cartId, [FromBody] AddItemRequest request)
        {
            var (productId, quantity) = request;
            
            try
            {
                var result = Mediatr.Send(new AddItemCommand(productId, quantity, cartId)).GetAwaiter().GetResult();
            
                return Ok(result);
            }
            catch (CartNotFoundException)
            {
                return NotFound();
            }
        }
        
        [HttpPatch]
        [Route("{cartId}/items/{productId}")]
        public IActionResult UpdateItemQuantity([FromRoute] string cartId, [FromRoute] string productId, [FromBody] UpdateItemQuantityRequest request)
        {
            try
            {
                var result = Mediatr.Send(new UpdateItemQuantityCommand(productId, request.Quantity, cartId)).GetAwaiter().GetResult();
            
                return Ok(result);
            }
            catch (CartNotFoundException)
            {
                return NotFound();
            }
        }
        
        [HttpDelete]
        [Route("{cartId}/items/{productId}")]
        public IActionResult RemoveItem([FromRoute] string cartId, [FromRoute] string productId)
        {
            try
            {
                var result = Mediatr.Send(new RemoveItemCommand(productId, cartId)).GetAwaiter().GetResult();
            
                return Ok(result);
            }
            catch (CartNotFoundException)
            {
                return NotFound();
            }
        }
    }
}