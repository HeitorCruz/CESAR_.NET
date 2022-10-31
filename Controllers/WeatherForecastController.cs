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
            MySql MySqlInstance = new MySql();
            return MySqlInstance.GET();
            }

        [HttpPost(Name = "post")]
            public string post(post Request)
            {
                MySql MySqlInstance = new MySql();
                MySqlInstance.POST(Request.nome,Request.idade);
                return "DONE";
            }
        [HttpPost("update")]
            public string edit(post Request)
            {
                MySql MySqlInstance = new MySql();
                MySqlInstance.UPDATE(Request.nome,Request.idade,Request.str);
                return "DONE";
            }
        [HttpDelete("{id}")]
            public void delete([FromRoute] string id)
            {
                MySql MySqlInstance = new MySql();
                MySqlInstance.DELETE(id);
                System.Console.WriteLine(id);
            }
    }
}