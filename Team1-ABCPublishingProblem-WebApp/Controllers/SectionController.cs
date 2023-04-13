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

					var EmpResponse = Res.Content.ReadAsStringAsync().Result;
					preface = JsonConvert.DeserializeObject<Section>(EmpResponse);
				}

				return View("Preface", preface);
			}
		}

		public async Task<IActionResult> GetTableOfContents(string id)
		{
			Section tableOfContents = new Section();
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(Baseurl);
				client.DefaultRequestHeaders.Clear();

				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				HttpResponseMessage Res = await client.GetAsync("api/Section/Section/" + id);

				if (Res.IsSuccessStatusCode)
				{

					var EmpResponse = Res.Content.ReadAsStringAsync().Result;
					tableOfContents = JsonConvert.DeserializeObject<Section>(EmpResponse);
				}

				return View("TableOfContents", tableOfContents);
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

				HttpResponseMessage Res = await client.GetAsync("api/Section/Section/" + id);

				if (Res.IsSuccessStatusCode)
				{

					var EmpResponse = Res.Content.ReadAsStringAsync().Result;
					bookContent = JsonConvert.DeserializeObject<Section>(EmpResponse);
				}

				return View("BookContent", bookContent);
			}
		}

		public async Task<IActionResult> GetChapterContent(string id)
		{
			Section chapterContent = new Section();
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(Baseurl);
				client.DefaultRequestHeaders.Clear();

				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				HttpResponseMessage Res = await client.GetAsync("api/Section/Section/" + id);

				if (Res.IsSuccessStatusCode)
				{

					var EmpResponse = Res.Content.ReadAsStringAsync().Result;
					chapterContent = JsonConvert.DeserializeObject<Section>(EmpResponse);
				}

				return View("ChapterContent", chapterContent);
			}
		}
	}
}

