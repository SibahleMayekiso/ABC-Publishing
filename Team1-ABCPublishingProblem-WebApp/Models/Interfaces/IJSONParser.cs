using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team1_ABCPublishingProblem_WebApp.Models.Objects;

namespace Team1_ABCPublishingProblem_WebApp.Models.Interfaces
{
    public interface IJSONParser
    {
        public IDictionary<string, Section> LoadJSON();
    }
}
