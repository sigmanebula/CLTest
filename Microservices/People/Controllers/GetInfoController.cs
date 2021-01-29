using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using People.Classes;
using People.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace People.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetInfoController : ControllerBase
    {
        DatabaseContext db;

        public GetInfoController()
        {
            db = new DatabaseContext();
        }

        // GET: api/<GetInfoController>
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return db.Persons.ToList();
        }

        // GET api/<GetInfoController>/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return db.Persons.Find(id);
        }

        // POST api/<GetInfoController>
        [HttpPost]
        public IActionResult Post()
        {
            var randomPerson = Manipulations.GetDataByUrl(Settings.RandomUser);
            var quote = Manipulations.GetDataByUrl(Settings.Quote);

            var person = Manipulations.PersonParseFromJson(randomPerson, quote);

            try
            {
                db.Persons.Add(person);
                db.SaveChanges();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Settings.Localhost);
                    var response = client.GetAsync($"getpoem/{person.Id}").Result;

                    if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                        return StatusCode(StatusCodes.Status500InternalServerError);
                    else
                        return StatusCode(StatusCodes.Status201Created);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<GetInfoController>/5
        [HttpPost("{id}")]
        public IActionResult Post(int id, [FromBody] Person value)
        {
            var person = db.Persons.First(x => x.Id == id);

            person.Poem = value.Poem;
            person.Distance = value.Distance;

            try
            {
                db.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
