using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Frontend.Models
{
    public static class PeopleGetter
    {
        public static List<Person> GetPeople()
        {
            string result;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Settings.Localhost);
                result = client.GetAsync("").Result.Content.ReadAsStringAsync().Result;
            }

            var people = JsonSerializer.Deserialize<List<Person>>(result);

            return people;
        }

        public static List<string> GetTitles()
        {
            return typeof(Person)
                .GetProperties()
                .Select(x => new CultureInfo("en-US", false).TextInfo.ToTitleCase(x.Name))
                .ToList();
        }
    }
}
