using GoodFilms.Data;
using GoodFilms.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodFilms.Services
{
    public class FilmReviewService : IFilmReviewService
    {
        private FilmsDbContext reviewDbContext;
        public FilmReviewService(FilmsDbContext filmsDb)
        {
            reviewDbContext = filmsDb;
        }
        void IFilmReviewService.Create(FilmReview filmReview)
        {
            reviewDbContext.Add(filmReview);
            reviewDbContext.SaveChanges();
        }

        void IFilmReviewService.Delete(long id)
        {
            var review = this.reviewDbContext.FilmReviews.FirstOrDefault<FilmReview>(review => review.Id == id);
            if(review!=null)
            {
                reviewDbContext.Remove(review);
                reviewDbContext.SaveChanges();
            }
            else
            {
                throw new Exception("FilmReview not found.Can't delete it.");
            }
        }

        FilmReview IFilmReviewService.Get(long id)
        {
            return reviewDbContext.FilmReviews.FirstOrDefault<FilmReview>(review=>review.Id==id);
        }

        List<FilmReview> IFilmReviewService.GetAll(Film film)
        {
            return reviewDbContext.FilmReviews.Where(rewiew => rewiew.Film == film).ToList();
        }

        void IFilmReviewService.Update(FilmReview filmReview)
        {
            var review = reviewDbContext.FilmReviews.FirstOrDefault<FilmReview>(review => review.Id == filmReview.Id);
                if(review!=null)
            {
                review.Review = filmReview.Review;
                review.ReviewAuthor = filmReview.ReviewAuthor;
                review.Film = filmReview.Film;
                review.Created = filmReview.Created;
                review.UpdatedOn = filmReview.UpdatedOn;
                reviewDbContext.SaveChanges();
            }
                else
            {
                throw new Exception("Film Review don't found. Can't update");
            }
        }
    }
}
