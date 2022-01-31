using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsExample.Api.Controllers
{
    [Route("v1/carts")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ISender _mediatr;

        public CartsController()
        {
            _mediatr = HttpContext.RequestServices.GetRequiredService<ISender>();
        }
        
        [HttpGet]
        [Route("{cartId}")]
        public IActionResult GetCart([FromRoute] string cartId)
        {
            return Ok();
        }
    }
}