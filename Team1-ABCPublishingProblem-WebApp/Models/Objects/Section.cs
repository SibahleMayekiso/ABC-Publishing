using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team1_ABCPublishingProblem_WebApp.Models.Objects
{
    public class Section
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string[] Content { get; set; }
        public Navigation[] Navigation { get; set; }
    }
}
