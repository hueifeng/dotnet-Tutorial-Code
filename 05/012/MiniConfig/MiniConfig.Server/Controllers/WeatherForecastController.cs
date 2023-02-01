using Microsoft.AspNetCore.Mvc;
using System;

namespace MiniConfig.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet("/configuration/test.json")]
        public OkObjectResult Get()
        {
            var rng = new Random();
            return Ok(new TestConfig
            {
                Key = rng.Next(-20, 55).ToString(),
                Key1 = "Key1"
            });
        }
    }

    public class TestConfig
    {
        public string Key { get; set; }

        public string Key1 { get; set; }
    }
}
