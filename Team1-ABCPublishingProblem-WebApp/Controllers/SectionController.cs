using Microsoft.AspNetCore.Mvc;

namespace Team1_ABCPublishingProblem_WebApp.Controllers
{
    public class SectionController : Controller
    {
        public IActionResult Index()
        {
            return View("TableOfContents");
        }

        public IActionResult Book()
        {
            return View();
        }

		public IActionResult BookContent()
		{
			return View();
		}

        public IActionResult ChapterContent()
        {
			return View();
		}
	}
}
