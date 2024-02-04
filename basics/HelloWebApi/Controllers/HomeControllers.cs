using HelloWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloWebApi.AddControllers
{
    [ApiController]
    [Route("home")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMessage()
        {
            var result = new ResponseModel()
            { 
                HttpStatus = 200,
                Message = "Hello AP.NET Core Web API"
            };
            return Ok(result);
        }
    }
}