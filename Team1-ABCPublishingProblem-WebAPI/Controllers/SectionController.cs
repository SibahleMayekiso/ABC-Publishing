﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Team1_ABCPublishingProblem_WebAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        // GET: api/<SectionController>/preface
        [HttpGet]
        [Route("api/[controller]/Preface")]
        public string GetBookPreface()
        {
            return "Book Preface Page";
        }

        // GET api/<SectionController>/TableOfContents
        [HttpGet]
        [Route("api/[controller]/TableOfContents")]
        public string GetTableOfContents()
        {
            return "Table of Contents";
        }

        // GET api/<SectionController>/a-scandal-in-bohemia
        [HttpGet]
        [Route("api/[controller]/a-scandal-in-bohemia")]
        public string GetBook()
        {
            return "A-scandal-in-bohemia";
        }

        // GET api/<SectionController>/bohemia-chapter-1
        [HttpGet]
        [Route("api/[controller]/bohemia-chapter-1")]
        public string GetBohemiaChapter1()
        {
            return "bohemia-chapter-1";
        }

        // GET api/<SectionController>/bohemia-chapter-2
        [HttpGet]
        [Route("api/[controller]/bohemia-chapter-2")]
        public string GetBohemiaChapter2()
        {
            return "bohemia-chapter-2";
        }

        // GET api/<SectionController>/bohemia-chapter-3
        [HttpGet]
        [Route("api/[controller]/bohemia-chapter-3")]
        public string GetBohemiaChapter3()
        {
            return "bohemia-chapter-3";
        }
    }
}
