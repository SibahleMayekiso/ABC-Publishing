using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Team1_ABCPublishingProblem_WebApp.BusinessLogic;
using Team1_ABCPublishingProblem_WebApp.Models.Interfaces;
using Team1_ABCPublishingProblem_WebApp.Models.Objects;

namespace Team1_ABCPublishingProblem_WebAPI.Controllers
{
    public class SectionController : Controller
    {
        private IJSONParser parser = new JSONParser();
        private IDictionary<string, Section> dict;
        private string Baseurl = "https://localhost:44330/";


        // GET: api/<SectionController>/preface
        public async Task<IActionResult> GetPreface()
        {
            Section preface = new Section();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/Section/GetPreface");

                if (Res.IsSuccessStatusCode)
                {

                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    preface = JsonConvert.DeserializeObject<Section>(EmpResponse);
                }

                return View("Preface", preface);
            }
        }

        public IActionResult GetTableOfContents()
        {
            IDictionary<string, Section> dict = parser.LoadJSON();
            Section tableOfContents = dict["table-of-contents"];

            return View("TableOfContents", tableOfContents);
        }

        public IActionResult GetBookContent()
        {
            IDictionary<string, Section> dict = parser.LoadJSON();
            Section bookContent = dict["a-scandal-in-bohemia"];

            return View("BookContent", bookContent);
        }

        public IActionResult GetChapterContent()
        {
            IDictionary<string, Section> dict = parser.LoadJSON();
            Section chapter = dict["bohemia-chapter-1"];

            return View("ChapterContent", chapter);
        }
    }
}
