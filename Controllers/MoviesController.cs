using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelloDotNet3.Models;

namespace HelloDotNet3.Controllers
{
    public class MoviesController : Controller
    {
        static IList<MovieInfo> _movies = new List<MovieInfo>
        {
            new MovieInfo {
                Genre = "Fantasy",
                Id = 1,
                ReleaseDate = new DateTime(2004, 5, 8),
                Title = "Van Helsing",
            },
        };

        public IActionResult Index()
        {
            return View(_movies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MovieInfo movie)
        {
            movie.Id = _movies.Max(x => x.Id) + 1;
            _movies.Add(movie);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            var movie = _movies.FirstOrDefault(x => x.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        public IActionResult DeleteConfirm(int id)
        {
            var movie = _movies.FirstOrDefault(x => x.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            _movies.Remove(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}
