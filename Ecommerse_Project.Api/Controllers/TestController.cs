using Microsoft.AspNetCore.Mvc;

namespace Ecommerce__Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("divide-by-zero")]
        public IActionResult DivideByZero()
        {
            var n = 0;
            var result = 1 / n; // This will throw DivideByZeroException
            return Ok(result);
        }

        [HttpGet("null-reference")]
        public IActionResult NullReference()
        {
            string? str = null;
            var length = str.Length; // This will throw NullReferenceException
            return Ok(length);
        }

        [HttpGet("custom-exception")]
        public IActionResult CustomException()
        {
            throw new Exception("This is a custom test exception");
        }
    }
}