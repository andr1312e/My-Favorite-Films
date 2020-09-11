using System.Collections.Generic;
using GoodFilms.Data.Models;
namespace GoodFilms.Services
{
    public interface IFilmService
    {
        public void AddFilm(Film Film);
        public void DeleteFilm(int filmId);
        public List<Film> GetAllFilms();
        public Film GetFilm(int filmId);
    }
}