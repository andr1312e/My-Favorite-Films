using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GoodFilms.Web.Controllers
{
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly ILogger<FilmsController> _logger;

        // The Web API will only accept tokens 1) for users, and 2) having the access_as_user scope for this API
        static readonly string[] scopeRequiredByApi = new string[] { "access_as_user" };

        public FilmsController(ILogger<FilmsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/api/books")]
        public ActionResult Get()
        {
            return Ok("books");
        }
    }
}
