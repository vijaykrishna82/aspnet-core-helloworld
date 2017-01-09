using dotnethelloworld.Models;
using dotnethelloworld.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnethelloworld.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MyOptions MyOptions;


        public MoviesController(IOptions<MyOptions> configuration)
        {

            MyOptions = configuration.Value;
        }

        public IActionResult Index()
        {
            Movie movie = new Movie();
            movie.Name = "Movie Name " + DateTime.Now;
            movie.Config = MyOptions.MyKey;

            return View(movie);
        }
    }
}
