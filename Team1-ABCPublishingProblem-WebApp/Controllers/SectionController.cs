using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components;
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
        private string Baseurl = "https://localhost:44329/";

        HttpResponseMessage Res = new HttpResponseMessage();
        private async void GetResponseFromAPI(string endpoint, string id)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (id == "")
                {
                    Res = await client.GetAsync("api/Section/" + endpoint);
                }
                else
                {
                    Res = await client.GetAsync("api/Section/" + endpoint + "/" + id);
                }
            }
        }

        // GET: api/<SectionController>/preface
        public async Task<IActionResult> GetPreface()
        {
            Section preface = new Section();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/Section/Preface");

                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    preface = JsonConvert.DeserializeObject<Section>(Response);
                }
            }

            return View("Preface", preface);
        }

        public IActionResult GetTableOfContents()
        {
            string endpoint = "GetTableOfContents";
            Section tableOfContents = new Section();

            GetResponseFromAPI(endpoint, "");

            if (Res.IsSuccessStatusCode)
            {
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                tableOfContents = JsonConvert.DeserializeObject<Section>(EmpResponse);
            }
            return View("TableOfContents", tableOfContents);
        }

        public IActionResult GetBookContent(string id)
        {
            string endpoint = "GetBookContent";
            Section bookContent = new Section();

            GetResponseFromAPI(endpoint, id);

            if (Res.IsSuccessStatusCode)
            {
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                bookContent = JsonConvert.DeserializeObject<Section>(EmpResponse);
            }

            return View("BookContent", bookContent);
        }

        public IActionResult GetChapterContent(string id)
        {
            string endpoint = "GetChpaterContent";
            Section chapter = new Section();

            GetResponseFromAPI(endpoint, id);

            if (Res.IsSuccessStatusCode)
            {
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                chapter = JsonConvert.DeserializeObject<Section>(EmpResponse);
            }

            return View("ChapterContent", chapter);
        }
    }
}
