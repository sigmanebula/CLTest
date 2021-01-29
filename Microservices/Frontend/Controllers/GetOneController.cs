using Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Frontend.Controllers
{
    public class GetOneController : Controller
    {
        public IActionResult GetOnePerson()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Settings.Localhost);
                var res = client.PostAsync("", null).Result;
            }

            return View("Index");
        }
    }
}
