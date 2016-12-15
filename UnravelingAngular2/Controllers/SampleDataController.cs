using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace UnravelingAngular2.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [HttpGet("[action]")]
        public IEnumerable<Dive> Dives()
        {
            return new List<Dive>
            {
                new Dive {Site="Abu Gotta Ramada", Location="Hurghada, Egypt", Depth = 72, Time = 54},
                new Dive {Site="Ponte Mahoon", Location="Maehbourg, Mauritius", Depth = 54, Time = 38},
                new Dive {Site="Molnar Cave", Location="Budapest, Hungary", Depth = 98, Time = 62}
            };
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }

        public class Dive
        {
            public string Site { get; set; }
            public string Location { get; set; }
            public int Depth { get; set; }
            public int Time { get; set; }
        }
    }
}
