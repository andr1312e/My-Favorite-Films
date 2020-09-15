using GoodFilms.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GoodFilms.Services
{
    public interface IFilmReviewService
    {
        FilmReview Get(long id);
        List<FilmReview> GetAll(Film film);
        void Create(FilmReview filmReview);
        void Update(FilmReview filmReview);
        void Delete(long id);
    }
}
