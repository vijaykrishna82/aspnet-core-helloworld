using dotnethelloworld.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnethelloworld.Controllers
{
    public class MoviesController
    {
        private readonly MyOptions MyOptions;


        public MoviesController(IOptions<MyOptions> configuration)
        {

            MyOptions = configuration.Value;
        }

        public string Index()
        {
            return "<B>Movies</B>" + MyOptions.MyKey;
        }
    }
}
