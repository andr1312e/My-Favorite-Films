using GoodFilms.Data.Models;
using GoodFilms.Services;
using GoodFilms.Web.RequestModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodFilms.Web.Controllers
{
        [ApiController]   
    public class ReviewsController : ControllerBase
    {

        private readonly ILogger<ReviewsController> _logger;
        private IFilmReviewService reviewService;
        private IFilmService filmService;
        public ReviewsController(ILogger<ReviewsController> logger, IFilmReviewService rev, IFilmService film)
        {
            _logger = logger;
            reviewService = rev;
            filmService = film;
        }
        [HttpGet("/api/film/{id}/reviews")]
        public ActionResult Index(int id)
        {
            List<FilmReview> filmReviews = reviewService.GetAll(filmService.GetFilm(id));
            return Ok(filmReviews);
        }
        [HttpPost("/api/film/{id}/reviews")]
        public ActionResult AddNewReview(int id, [FromBody] NewReviewRequest reviewRequest)
        {
            var film = filmService.GetFilm(id);
            if (film != null)
            {
                if (reviewRequest.Review != "" && reviewRequest.ReviewAuthor != "")
                {
                    reviewService.Create(new FilmReview
                    {
                        Review = reviewRequest.Review,
                        ReviewAuthor = reviewRequest.ReviewAuthor,
                        Film = film,
                        Created = DateTime.UtcNow,
                        UpdatedOn = DateTime.UtcNow,
                    });
                    return Ok($"Review added");
                }
                else
                {
                    return BadRequest("Cant find film");
                }

            }
            else
            {
                return BadRequest("Cant find film");
            }


        }
    }
}
