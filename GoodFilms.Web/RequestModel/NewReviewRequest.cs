using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodFilms.Web.RequestModel
{
    public class NewReviewRequest
    {
        public string ReviewAuthor { set; get; }
        public string Review { set; get; }
    }
}
