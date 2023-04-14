using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Team1_ABCPublishingProblem_WebApp.BusinessLogic;
using Team1_ABCPublishingProblem_WebApp.Models.Interfaces;
using Team1_ABCPublishingProblem_WebApp.Models.Objects;

namespace Team1_ABCPublishingProblem_WebAPI.Controllers
{
    public class PublicationController : Controller
    {
        private IJSONParser parser = new JSONParser();
        private string Baseurl = "https://localhost:7033/";

        public async Task<IActionResult> Section(string? id)
        {
            if (id == null)
            {
                id = "preface";
            }
            Section section;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/Section/" + id);

                if (Res.IsSuccessStatusCode)
                {

                    var prefaceResponse = Res.Content.ReadAsStringAsync().Result;
                    section = JsonConvert.DeserializeObject<Section>(prefaceResponse);
                }
                else
                {
                    return RedirectToAction("NotFound");
                }
                return View(section);
            }
        }

        public IActionResult NotFound()
        {
            return View();
        }
    }
}