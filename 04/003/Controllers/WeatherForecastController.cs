using Microsoft.AspNetCore.Mvc;

namespace _003.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ISampleSingleton _sampleSingleton;
        private readonly ISampleScoped _sampleScoped;
        private readonly ISampleTransient _sampleTransient;
        private readonly IServiceProvider _serviceProvider;

        public WeatherForecastController(ISampleSingleton sampleSingleton, ISampleScoped
       sampleScoped, ISampleTransient sampleTransient, IServiceProvider serviceProvider)
        {
            _sampleSingleton = sampleSingleton;
            _sampleScoped = sampleScoped;
            _sampleTransient = sampleTransient;
            _serviceProvider = serviceProvider;
        }

        [HttpGet]
        public OkResult Get()
        {
            //Console.WriteLine(
            //    $"name��sampleScoped,Id��{_sampleScoped.Id},hashCode��{ _sampleScoped.GetHashCode()},\n" +
            //$"name��sampleTransient,Id��{ _sampleTransient.Id},hashCode��{ _sampleTransient.GetHashCode()},\n" +
            //$"name��sampleSingleton��Id��{ _sampleSingleton.Id},hashCode��{ _sampleSingleton.GetHashCode()}\n");
            //return Ok();
            //    var sampleSingleton = _serviceProvider.GetService<ISampleSingleton>();
            //    var sampleScoped = _serviceProvider.GetService<ISampleScoped>();
            //    var sampleTransient = _serviceProvider.GetService<ISampleTransient>();

            //    Console.WriteLine(
            //        $"name��sampleScoped,Id��{ _sampleScoped.Id },hashCode��{ _sampleScoped.GetHashCode()},\n" +
            //$"name��sampleTransient,Id��{_sampleTransient.Id},hashCode��{ _sampleTransient.GetHashCode()},\n" +
            //$"name��sampleSingleton��Id��{_sampleSingleton.Id},hashCode��{ _sampleSingleton.GetHashCode()}\n");

            //    Console.WriteLine(
            //        $"name��sampleScoped,Id��{ sampleScoped.Id },hashCode��{ sampleScoped.GetHashCode()},\n" +
            //        $"name��sampleTransient,Id��{sampleTransient.Id},hashCode��{ sampleTransient.GetHashCode()},\n" +
            //        $"name��sampleSingleton��Id��{sampleSingleton.Id},hashCode��{ sampleSingleton.GetHashCode()}\n");
            //    return Ok();
            using (var scope = _serviceProvider.CreateScope())
            {
                var p = scope.ServiceProvider;

                var scopeobj1 = p.GetService<ISampleScoped>();
                var transient1 = p.GetService<ISampleTransient>();
                var singleton1 = p.GetService<ISampleSingleton>();

                var scopeobj2 = p.GetService<ISampleScoped>();
                var transient2 = p.GetService<ISampleTransient>();
                var singleton2 = p.GetService<ISampleSingleton>();

                Console.WriteLine("-----------------------������ 1 -------------------------------");
                Console.WriteLine(
                    $"name��scope1,Id��{ scopeobj1.Id },hashCode��{scopeobj1.GetHashCode()},\n" +
                    $"name��transient1,Id��{transient1.Id},hashCode��{transient1.GetHashCode()},\n" +
                    $"name��singleton1��Id��{singleton1.Id},hashCode��{singleton1.GetHashCode()}\n");

                Console.WriteLine($"name��scope2,Id��{ scopeobj2.Id },hashCode��{ scopeobj2.GetHashCode()},\n " +
                          $"name��transient2,Id��{transient2.Id},hashCode��{ transient2.GetHashCode()}, \n" +
                          $"name��singleton2,Id��{singleton2.Id},hashCode��{ singleton2.GetHashCode()}\n");
            }

            using (var scope = _serviceProvider.CreateScope())
            {
                var p = scope.ServiceProvider;

                var scopeobj1 = p.GetService<ISampleScoped>();
                var transient1 = p.GetService<ISampleTransient>();
                var singleton1 = p.GetService<ISampleSingleton>();

                var scopeobj2 = p.GetService<ISampleScoped>();
                var transient2 = p.GetService<ISampleTransient>();
                var singleton2 = p.GetService<ISampleSingleton>();
                Console.WriteLine("-----------------------������ 2 -------------------------------");
                Console.WriteLine(
                    $"name��scope1,Id��{ scopeobj1.Id },hashCode��{scopeobj1.GetHashCode()},\n" +
                    $"name��transient1,Id��{transient1.Id},hashCode��{transient1.GetHashCode()},\n" +
                    $"name��singleton1��Id��{singleton1.Id},hashCode��{singleton1.GetHashCode()}\n");
                
                Console.WriteLine($"name��scope2,Id��{ scopeobj2.Id },hashCode��{ scopeobj2.GetHashCode()},\n " +
                          $"name��transient2,Id��{transient2.Id},hashCode��{ transient2.GetHashCode()}, \n" +
                          $"name��singleton2,Id��{singleton2.Id},hashCode��{ singleton2.GetHashCode()}\n");
            }
            return Ok();
        }
    }
}