using System.Net;
using Microsoft.AspNetCore.Mvc;
using Team1_ABCPublishingProblem_WebApp.BusinessLogic;
using Team1_ABCPublishingProblem_WebApp.Models.Interfaces;
using Team1_ABCPublishingProblem_WebApp.Models.Objects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Team1_ABCPublishingProblem_WebAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class SectionController : Controller
    {
        private IJSONParser parser = new JSONParser();
        private IDictionary<string, Section> dict;

        // GET: api/<SectionController>/preface
        [HttpGet]
        [Route("api/[controller]/Preface")]
        public Section GetBookPreface()
        {
            IDictionary<string, Section> dict = parser.LoadJSON();
            Section preface = dict["preface"];

            return preface;
        }

        [HttpGet]
        [Route("api/[controller]/Section/{id}")]
        public Section GetSection(string id)
        {
            IDictionary<string, Section> dict = parser.LoadJSON();
            Section tableOfContents = dict[id];

            return tableOfContents;
        }
    }
}
