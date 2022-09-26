using Microsoft.AspNetCore.Mvc;
using LTN;
using System.Text.Json;

namespace DOTNETAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class
     WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "HEITOR"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public string Get()
        {
            return "Dados do Server";
        }
        [HttpPost(Name = "post")]
            public string post(post Request)
            {
                MySql MySqlInstance = new MySql();
                MySqlInstance.GET(Request.nome,Request.idade);
                return "DONE";
            }
    }
}