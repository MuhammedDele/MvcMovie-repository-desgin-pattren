using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
using MvcMovie.DAL;
using MvcMovie.Data;
using MvcMovie.Models;
using MvcMovie.Models.ViewModels;

namespace MvcMovie.Controllers
{
	public class MoviesController : Controller
	{
		private IUnitOfWork _uow;

		public MoviesController(IUnitOfWork uow)
		{
			_uow = uow;
		}

		public IActionResult List(int ratingID = 0)
		{
			var listMoviesVM = new ListMoviesViewModel();

			if (ratingID != 0)
			{
				listMoviesVM.Movies = _uow.MovieRepository.GetAll().Where(m => m.RatingID == ratingID).OrderBy(m => m.Title).ToList();
			}
			else
			{
				listMoviesVM.Movies = _uow.MovieRepository.GetAll().OrderBy(m => m.Title).ToList();
			}

			listMoviesVM.Ratings =
				new SelectList(_uow.RatingRepository.GetAll().OrderBy(r => r.Name),
								"RatingID", "Name");
			listMoviesVM.ratingID = ratingID;

			return View(listMoviesVM);
		}

		public IActionResult Details(int id)
		{
			var movie = _uow.MovieRepository.Get(
				filter: x => x.MovieID == id,
				includes: x => x.Rating).FirstOrDefault();							

			return View(movie);
		}

		// GET: Movies/Create
		public IActionResult Create()
		{
			ViewData["Ratings"] =
				new SelectList(_uow.RatingRepository.GetAll().OrderBy(r => r.Name),
							   "RatingID",
							   "Name");

			return View();
		}
	}
}