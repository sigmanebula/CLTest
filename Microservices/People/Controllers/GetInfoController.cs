using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using People.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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

        public string GetDataByUrl(string url)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (var reader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
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
        public int Post()
        {
            string randomPerson = GetDataByUrl("https://randomuser.me/api/");
            string quote = GetDataByUrl("https://geek-jokes.sameerkumar.website/api");

            var jsonPerson = JObject.Parse(randomPerson);

            Person person = new Person()
            {
                Id = 0,
                Thumbnail = jsonPerson["results"][0]["picture"]["thumbnail"].ToString(),
                FirstName = jsonPerson["results"][0]["name"]["first"].ToString(),
                LastName = jsonPerson["results"][0]["name"]["last"].ToString(),
                City = jsonPerson["results"][0]["location"]["city"].ToString(),
                Street = jsonPerson["results"][0]["location"]["street"]["name"].ToString(),
                Email = jsonPerson["results"][0]["email"].ToString(),
                Gender = jsonPerson["results"][0]["gender"].ToString(),
                Quote = quote,
                Poem = null,
                Distance = 0
            };
            

            try
            {
                db.Persons.Add(person);
                db.SaveChanges();

                var id = person.Id;

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
