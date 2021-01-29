using Poems;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public static string GetRandomPoem(List<Poem> poems)
        {
            var nonEmptyPoems = poems.Where(x => !string.IsNullOrEmpty(x.content)).ToArray();
            var random = new Random().Next(nonEmptyPoems.Count() - 1);

            return nonEmptyPoems[random].content;
        }
    }
}
