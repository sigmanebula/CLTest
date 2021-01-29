using Newtonsoft.Json.Linq;
using People.Database;
using System;
using System.Net.Http;

namespace People.Classes
{
    public static class Manipulations
    {
        public static string GetDataByUrl(string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                try
                {
                    return client.GetAsync("").Result.Content.ReadAsStringAsync().Result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static Person PersonParseFromJson(string json, string quote)
        {
            Person person;
            try
            {
                var jsonPerson = JObject.Parse(json);

                person = new Person()
                {
                    Id        = 0,
                    Thumbnail = jsonPerson["results"][0]["picture"]["thumbnail"].ToString(),
                    FirstName = jsonPerson["results"][0]["name"]["first"].ToString(),
                    LastName  = jsonPerson["results"][0]["name"]["last"].ToString(),
                    City      = jsonPerson["results"][0]["location"]["city"].ToString(),
                    Street    = jsonPerson["results"][0]["location"]["street"]["name"].ToString(),
                    Email     = jsonPerson["results"][0]["email"].ToString(),
                    Gender    = jsonPerson["results"][0]["gender"].ToString(),
                    Quote     = quote,
                    Poem      = null,
                    Distance = 0
                };

                return person;
            }
            catch (Exception ex)
            {
                person = new Person();
                return person;
            }

        }
    }
}
