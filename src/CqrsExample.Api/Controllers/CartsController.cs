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
        public IActionResult AddItem([FromRoute] string cartId)
        {
            try
            {
                var result = Mediatr.Send(new AddItemCommand("ABC", 1, cartId)).GetAwaiter().GetResult();
            
                return Ok(result);
            }
            catch (CartNotFoundException)
            {
                return NotFound();
            }
        }
    }
}