namespace DOTNETAPI
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
    public class post
    {
        public string nome { get; set; }
        public string idade { get; set; }
        public string str {get;set;}
    }
}