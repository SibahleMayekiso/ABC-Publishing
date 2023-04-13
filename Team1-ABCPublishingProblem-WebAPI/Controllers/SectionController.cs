using Microsoft.AspNetCore.Mvc;
using Team1_ABCPublishingProblem_WebApp.BusinessLogic;
using Team1_ABCPublishingProblem_WebApp.Models.Interfaces;
using Team1_ABCPublishingProblem_WebApp.Models.Objects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Team1_ABCPublishingProblem_WebAPI.Controllers
{
	[ApiController]
	public class SectionController : ControllerBase
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

		// GET api/<SectionController>/TableOfContents
		[HttpGet]
		[Route("api/[controller]/TableOfContents")]
		public Section GetTableOfContents()
		{
			IDictionary<string, Section> dict = parser.LoadJSON();
			Section tableOfContents = dict["table-of-contents"];

			return tableOfContents;
		}

		// GET api/<SectionController>/a-scandal-in-bohemia
		[HttpGet]
		[Route("api/[controller]/book/{id}")]
		public Section GetBook(string id)
		{
			IDictionary<string, Section> dict = parser.LoadJSON();
			Section bookContent = new Section();

			if (dict.ContainsKey(id))
			{
				bookContent = dict[id];

				return bookContent;
			}
            else
            {
				//return NotFound();
				return bookContent;
            }
        }

        // GET api/<SectionController>/bohemia-chapter-1
        [HttpGet]
        [Route("api/[controller]/chapter/{id}")]
        public Section GetBookChapter(string id)
        {
            IDictionary<string, Section> dict = parser.LoadJSON();
            Section chapter = dict[id];

            return chapter;
        }
	}
}
