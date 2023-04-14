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
		private string Baseurl = "https://localhost:7033/";

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

					var prefaceResponse = Res.Content.ReadAsStringAsync().Result;
					preface = JsonConvert.DeserializeObject<Section>(prefaceResponse);
				}
                else
                {
                    return RedirectToAction("NotFound");
                }
                return View("Preface", preface);
			}
		}

		public async Task<IActionResult> GetBookContent(string id)
		{
			Section bookContent = new Section();
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(Baseurl);
				client.DefaultRequestHeaders.Clear();

				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				HttpResponseMessage Res = await client.GetAsync("api/Section/" + id);

				if (Res.IsSuccessStatusCode)
				{

					var bookResponse = Res.Content.ReadAsStringAsync().Result;
					bookContent = JsonConvert.DeserializeObject<Section>(bookResponse);
				}

				else
				{
					return RedirectToAction("NotFound");
				}

				return View("BookContent", bookContent);
			}
		}

		public IActionResult NotFound()
		{
			return View();
		}
	}
}

