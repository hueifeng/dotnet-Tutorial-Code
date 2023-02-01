using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _002
{
    [ApiController]
    [Route("[controller]")]
    [MiddlewareFilter(typeof(CustomPipeline))]
    public class ValuesController : ControllerBase
    {
        public OkResult Get()
        {
            return Ok();
        }
    }
}

