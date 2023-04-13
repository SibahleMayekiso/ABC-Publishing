using Microsoft.AspNetCore.Mvc;
using Team1_ABCPublishingProblem_WebApp.BusinessLogic;
using Team1_ABCPublishingProblem_WebApp.Models.Interfaces;
using Team1_ABCPublishingProblem_WebApp.Models.Objects;

namespace Team1_ABCPublishingProblem_WebAPI.Controllers
{
    public class SectionController : Controller
    {
        private IJSONParser parser = new JSONParser();
        private IDictionary<string, Section> dict;


        // GET: api/<SectionController>/preface
        public IActionResult GetPreface()
        {
            IDictionary<string, Section> dict = parser.LoadJSON();
            Section preface = dict["preface"];

            return View("Preface", preface);
        }

        // GET api/<SectionController>/TableOfContents
        public IActionResult GetTableOfContents()
        {
            IDictionary<string, Section> dict = parser.LoadJSON();
            Section tableOfContents = dict["table-of-contents"];

            return View("TableOfContents", tableOfContents);
        }

        // GET api/<SectionController>/a-scandal-in-bohemia
        public IActionResult GetBookContent()
        {
            IDictionary<string, Section> dict = parser.LoadJSON();
            Section bookContent = dict["a-scandal-in-bohemia"];

            return View("BookContent", bookContent);
        }

        // GET api/<SectionController>/bohemia-chapter-1
        public IActionResult GetBohemiaChapter1()
        {
            IDictionary<string, Section> dict = parser.LoadJSON();
            Section chapter = dict["bohemia-chapter-1"];

            return View("ChapterContent", chapter);
        }

        // GET api/<SectionController>/bohemia-chapter-2
        public IActionResult GetBohemiaChapter2()
        {
            IDictionary<string, Section> dict = parser.LoadJSON();
            Section chapter = dict["bohemia-chapter-2"];

            return View("ChapterContent", chapter);
        }

        // GET api/<SectionController>/bohemia-chapter-3
        public IActionResult GetBohemiaChapter3()
        {
            IDictionary<string, Section> dict = parser.LoadJSON();
            Section chapter = dict["bohemia-chapter-3"];

            return View("ChapterContent", chapter);
        }
    }
}
