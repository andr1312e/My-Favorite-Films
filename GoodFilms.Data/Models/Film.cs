using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodFilms.Data.Models
{
    public class Film
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { set; get; }
        public DateTime Created { set; get; }
        public DateTime UpdatedOn { set; get; }
        public string Title { set; get; }
        public string Producer { set; get; }
        public string PathToCover { set; get; }
        //public string IEnumerable<FilmReview> Review{ set;get; }
    }
}
