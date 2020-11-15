using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bidly.Models;

namespace Bidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult random()
        {
            var movie = new Movie() { Name = "Bangla Movie" };
            return View(movie);

        }

    }   
          
}
    
