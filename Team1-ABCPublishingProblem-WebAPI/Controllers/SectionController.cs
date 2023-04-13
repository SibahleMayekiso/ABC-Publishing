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

		// GET api/<SectionController>/TableOfContents
		//[HttpGet]
		//[Route("api/[controller]/TableOfContents")]
		//public Section GetTableOfContents()
		//{
		//	IDictionary<string, Section> dict = parser.LoadJSON();
		//	Section tableOfContents = dict["table-of-contents"];

		//	return tableOfContents;
		//}

		// GET api/<SectionController>/a-scandal-in-bohemia
		//[HttpGet]
		//[Route("api/[controller]/a-scandal-in-bohemia")]
		//public Section GetBookContent(string id)
		//{
		//	IDictionary<string, Section> dict = parser.LoadJSON();
		//	Section bookContent = dict[id];

		//	return bookContent;
		//}

		//// GET api/<SectionController>/bohemia-chapter-1
		//[HttpGet]
		//[Route("api/[controller]/bohemia-chapter-1")]
		//public Section GetChapterContent(string id)
		//{
		//	IDictionary<string, Section> dict = parser.LoadJSON();
		//	Section chapter = dict[id];

		//	return chapter;
		//}

		//// GET api/<SectionController>/bohemia-chapter-2
		//[HttpGet]
		//[Route("api/[controller]/bohemia-chapter-2")]
		//public Section GetBohemiaChapter2()
		//{
		//	IDictionary<string, Section> dict = parser.LoadJSON();
		//	Section chapter = dict["bohemia-chapter-2"];

		//	return chapter;
		//}

		//// GET api/<SectionController>/bohemia-chapter-3
		//[HttpGet]
		//[Route("api/[controller]/bohemia-chapter-3")]
		//public Section GetBohemiaChapter3()
		//{
		//	IDictionary<string, Section> dict = parser.LoadJSON();
		//	Section chapter = dict["bohemia-chapter-3"];

		//	return chapter;
		//}
	}
}
