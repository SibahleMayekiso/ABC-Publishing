using Microsoft.AspNetCore.Mvc;
using Team1_ABCPublishingProblem_WebApp.BusinessLogic;
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
using Team1_ABCPublishingProblem_WebApp.Models.Interfaces;
>>>>>>> 95ee584cce7218059b6b6ca881813ca5d4e7d3f7
>>>>>>> ef11b0b6eea89d82d6a67d501e4f7fd229d57ba6
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
			Section tableOfContents = dict["table-of-contents"];

			return tableOfContents;
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
		[Route("api/[controller]/a-scandal-in-bohemia")]
		public Section GetBook()
		{
			IDictionary<string, Section> dict = parser.LoadJSON();
			Section bookContent = dict["a-scandal-in-bohemia"];

			return bookContent;
		}

		// GET api/<SectionController>/bohemia-chapter-1
		[HttpGet]
		[Route("api/[controller]/bohemia-chapter-1")]
		public Section GetBohemiaChapter1()
		{
			IDictionary<string, Section> dict = parser.LoadJSON();
			Section chapter = dict["bohemia-chapter-1"];

			return chapter;
		}

		// GET api/<SectionController>/bohemia-chapter-2
		[HttpGet]
		[Route("api/[controller]/bohemia-chapter-2")]
		public Section GetBohemiaChapter2()
		{
			IDictionary<string, Section> dict = parser.LoadJSON();
			Section chapter = dict["bohemia-chapter-2"];

			return chapter;
		}

		// GET api/<SectionController>/bohemia-chapter-3
		[HttpGet]
		[Route("api/[controller]/bohemia-chapter-3")]
		public Section GetBohemiaChapter3()
		{
			IDictionary<string, Section> dict = parser.LoadJSON();
			Section chapter = dict["bohemia-chapter-3"];

			return chapter;
		}
	}
}
