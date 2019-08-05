using HelloWorld.Api.Randomizer;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Api.Controllers
{
    [Route("helloworld")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        private readonly IRandomOutcomeGenerator _generator;

        public HelloWorldController(IRandomOutcomeGenerator generator)
        {
            _generator = generator;
        }

        [HttpGet]
        public IActionResult HelloWorld()
        {
            return Ok(_generator.GetHelloWorldString());
        }
    }
}