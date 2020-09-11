using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoodFilms.Data.Models;
using GoodFilms.Services;
using GoodFilms.Web.RequestModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GoodFilms.Web.Controllers
{
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly ILogger<FilmsController> _logger;
        private readonly IFilmService filmService;
        // The Web API will only accept tokens 1) for users, and 2) having the access_as_user scope for this API
        static readonly string[] scopeRequiredByApi = new string[] { "access_as_user" };

        public FilmsController(ILogger<FilmsController> logger, IFilmService service)
        {
            filmService = service;
            _logger = logger;
        }

        [HttpGet("/api/films")]
        public ActionResult Get()
        {
            List<Film> films = filmService.GetAllFilms();
            return Ok(films);
        }
        [HttpGet("/api/films/{id}")]
        public ActionResult Get(int id)
        {
            Film films = filmService.GetFilm(id);
            if (films == null)
            {
                return RedirectToAction(nameof(Get));
            }
            else
            {
                return Ok(films);
            }

        }
        [HttpPost("/api/films")]
        public ActionResult AddNewFilm([FromBody] NewFilmRequest filmRequest)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Model stage is not valid");
            }
            var now = DateTime.UtcNow;
            var film = new Film
            {
                Created = now,
                UpdatedOn = now,
                Producer = filmRequest.Producer,
                Title = filmRequest.Title
            };
            filmService.AddFilm(film);
            return Ok($"Film added: {film.Title}");
        }
        [HttpDelete("/api/films/{id}")]
        public ActionResult Delete(int id)
        {
            Film firmtodel = filmService.GetFilm(id);
            if (firmtodel != null)
            {
                filmService.DeleteFilm(id);
                return Ok($"Film Deleted: {id}");
            }
            else
            {
                return RedirectToAction(nameof(Get));
            }
        }

    }
}
