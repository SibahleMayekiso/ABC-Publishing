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
        IJSONParser parser = new JSONParser();
        IDictionary<string, Section> dict;
        
        
        // GET: api/<SectionController>/preface
        [HttpGet]
        [Route("api/[controller]/Preface")]
        public IDictionary<string, Section> GetBookPreface()
        {
            var parser = new JSONParser();

            return parser.LoadJSON();
        }

        // GET api/<SectionController>/TableOfContents
        [HttpGet]
        [Route("api/[controller]/TableOfContents")]
        public IActionResult GetTableOfContents()
        {
            var section = new BookInformationLoader(parser);
			IDictionary<string, Section> dict = parser.LoadJSON();
            //string[] content = section.GetContentByTitle("table-of-contents");
            Section tableOfContents = dict["table-of-contents"];

            return View("TableOfContents", tableOfContents);
        }

        // GET api/<SectionController>/a-scandal-in-bohemia
        [HttpGet]
        [Route("api/[controller]/a-scandal-in-bohemia")]
        public IActionResult Book()
        {
            //IJSONParser parser = new JSONParser();
            IDictionary<string, Section> dict = parser.LoadJSON();
            var section = new BookInformationLoader(parser);

            var newSection = dict["a-scandal-in-bohemia"];

            return View("BookContent", newSection);
        }

        // GET api/<SectionController>/bohemia-chapter-1
        [HttpGet]
        [Route("api/[controller]/bohemia-chapter-1")]
        public string GetBohemiaChapter1()
        {
            return "bohemia-chapter-1";
        }

        // GET api/<SectionController>/bohemia-chapter-2
        [HttpGet]
        [Route("api/[controller]/bohemia-chapter-2")]
        public string GetBohemiaChapter2()
        {
            return "bohemia-chapter-2";
        }

        // GET api/<SectionController>/bohemia-chapter-3
        [HttpGet]
        [Route("api/[controller]/bohemia-chapter-3")]
        public string GetBohemiaChapter3()
        {
            return "bohemia-chapter-3";
        }
    }
}
