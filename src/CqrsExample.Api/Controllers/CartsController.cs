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
            catch (CartNotFoundException e)
            {
                return NotFound();
            }
        }
    }
}