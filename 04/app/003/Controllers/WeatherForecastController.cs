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
            //    $"name£ºsampleScoped,Id£º{_sampleScoped.Id},hashCode£º{ _sampleScoped.GetHashCode()},\n" +
            //$"name£ºsampleTransient,Id£º{ _sampleTransient.Id},hashCode£º{ _sampleTransient.GetHashCode()},\n" +
            //$"name£ºsampleSingleton£¬Id£º{ _sampleSingleton.Id},hashCode£º{ _sampleSingleton.GetHashCode()}\n");
            //return Ok();
            //    var sampleSingleton = _serviceProvider.GetService<ISampleSingleton>();
            //    var sampleScoped = _serviceProvider.GetService<ISampleScoped>();
            //    var sampleTransient = _serviceProvider.GetService<ISampleTransient>();

            //    Console.WriteLine(
            //        $"name£ºsampleScoped,Id£º{ _sampleScoped.Id },hashCode£º{ _sampleScoped.GetHashCode()},\n" +
            //$"name£ºsampleTransient,Id£º{_sampleTransient.Id},hashCode£º{ _sampleTransient.GetHashCode()},\n" +
            //$"name£ºsampleSingleton£¬Id£º{_sampleSingleton.Id},hashCode£º{ _sampleSingleton.GetHashCode()}\n");

            //    Console.WriteLine(
            //        $"name£ºsampleScoped,Id£º{ sampleScoped.Id },hashCode£º{ sampleScoped.GetHashCode()},\n" +
            //        $"name£ºsampleTransient,Id£º{sampleTransient.Id},hashCode£º{ sampleTransient.GetHashCode()},\n" +
            //        $"name£ºsampleSingleton£¬Id£º{sampleSingleton.Id},hashCode£º{ sampleSingleton.GetHashCode()}\n");
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

                Console.WriteLine("-----------------------×ÓÈÝÆ÷ 1 -------------------------------");
                Console.WriteLine(
                    $"name£ºscope1,Id£º{ scopeobj1.Id },hashCode£º{scopeobj1.GetHashCode()},\n" +
                    $"name£ºtransient1,Id£º{transient1.Id},hashCode£º{transient1.GetHashCode()},\n" +
                    $"name£ºsingleton1£¬Id£º{singleton1.Id},hashCode£º{singleton1.GetHashCode()}\n");

                Console.WriteLine($"name£ºscope2,Id£º{ scopeobj2.Id },hashCode£º{ scopeobj2.GetHashCode()},\n " +
                          $"name£ºtransient2,Id£º{transient2.Id},hashCode£º{ transient2.GetHashCode()}, \n" +
                          $"name£ºsingleton2,Id£º{singleton2.Id},hashCode£º{ singleton2.GetHashCode()}\n");
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
                Console.WriteLine("-----------------------×ÓÈÝÆ÷ 2 -------------------------------");
                Console.WriteLine(
                    $"name£ºscope1,Id£º{ scopeobj1.Id },hashCode£º{scopeobj1.GetHashCode()},\n" +
                    $"name£ºtransient1,Id£º{transient1.Id},hashCode£º{transient1.GetHashCode()},\n" +
                    $"name£ºsingleton1£¬Id£º{singleton1.Id},hashCode£º{singleton1.GetHashCode()}\n");
                
                Console.WriteLine($"name£ºscope2,Id£º{ scopeobj2.Id },hashCode£º{ scopeobj2.GetHashCode()},\n " +
                          $"name£ºtransient2,Id£º{transient2.Id},hashCode£º{ transient2.GetHashCode()}, \n" +
                          $"name£ºsingleton2,Id£º{singleton2.Id},hashCode£º{ singleton2.GetHashCode()}\n");
            }
            return Ok();
        }
    }
}