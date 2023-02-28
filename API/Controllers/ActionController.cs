using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ActionController : BaseController
    {
        [HttpGet("calculate")]
        public void shouldCalculateRoutes()
        {
            Console.WriteLine("Route was triggered!");
        }
    }
}