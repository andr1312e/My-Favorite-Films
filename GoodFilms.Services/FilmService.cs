using GoodFilms.Data;
using GoodFilms.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoodFilms.Services
{
    public class FilmService : IFilmService
    {
        private readonly FilmsDbContext filmDbContext;
        public FilmService (FilmsDbContext dbContext)
        {
            filmDbContext = dbContext;
        }
        public void AddFilm(Film Film)
        {
            filmDbContext.Add(Film);
            filmDbContext.SaveChanges();
        }

        public void DeleteFilm(int filmId)
        {
            var filmToDelete = filmDbContext.Films.FirstOrDefault<Film>(film => film.Id == filmId);
            if (filmToDelete!=null)
            {
                filmDbContext.Remove(filmToDelete);
                filmDbContext.SaveChanges();
                return;
            }
            throw new Exception("Film not found.Can't delete it.");

        }

        public List<Film> GetAllFilms()
        {
            return filmDbContext.Films.ToList<Film>();
        }

        public Film GetFilm(int filmId)
        {
            return filmDbContext.Films.FirstOrDefault<Film>(film => film.Id == filmId);
        }
    }
}
