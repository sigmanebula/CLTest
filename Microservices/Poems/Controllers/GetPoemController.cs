using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using People.Classes;
using People.Database;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Poems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetPoemController : ControllerBase
    {

        // POST api/<GetPoemController>/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var poemsString = Manipulations.GetDataByUrl(Settings.Poems);
                var poems = JsonSerializer.Deserialize<List<Poem>>(poemsString);
                var etalonPoem = Settings.EtalonPoem;

                var poem = Manipulations.GetRandomPoem(poems);
                var distance = JaroWinklerDistance.distance(poem, etalonPoem);

                var person = new Person()
                {
                    Poem = poem,
                    Distance = Math.Round(distance, 2)
                };

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Settings.Localhost);
                    var res = client.PostAsJsonAsync($"getinfo/{id}", person).Result;
                }

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

    }
}
