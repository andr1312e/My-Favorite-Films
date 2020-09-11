using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodFilms.Data.Models
{
    public class FilmReview
    {
        public int Id { set; get; }
        public DateTime Created { set; get; }
        public DateTime UpdatedOn { set; get; }
        public string ReviewAuthor { set; get; }
        public string Review { set; get; }
        public Film Film { set; get; }
    }
}
