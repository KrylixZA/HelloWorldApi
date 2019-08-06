using HelloWorld.Api.Randomizer;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HelloWorld.Api.Controllers
{
    [Route("helloworld")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        private readonly IRandomOutcomeGenerator _generator;

        public HelloWorldController(IRandomOutcomeGenerator generator)
        {
            _generator = generator ?? throw new ArgumentNullException(nameof(generator));
        }

        [HttpGet]
        [Produces("application/json")]
        public IActionResult HelloWorld()
        {
            var helloWorld = _generator.GetHelloWorldString();
            return Ok(helloWorld);
        }
    }
}