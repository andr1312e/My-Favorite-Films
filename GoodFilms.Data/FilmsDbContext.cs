using GoodFilms.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodFilms.Data
{
    public class FilmsDbContext:DbContext
    {
        public FilmsDbContext()
        {

        }
        public FilmsDbContext(DbContextOptions options) : base(options) { }
        public virtual DbSet<Film> Films { set; get;  }
        public virtual DbSet<FilmReview> FilmReviews { set; get; }
    
    }
}
