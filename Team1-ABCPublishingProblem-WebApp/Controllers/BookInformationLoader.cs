using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team1_ABCPublishingProblem_WebApp.Models.Interfaces;
using Team1_ABCPublishingProblem_WebApp.Models.Objects;

namespace Team1_ABCPublishingProblem
{
    public class BookInformationLoader
    {
        IJSONParser _parser;
        IDictionary<string, Section> _sections;

        public BookInformationLoader(IJSONParser parser)
        {
            _parser = parser;
            _sections = _parser.LoadJSON();
        }

        public string[] GetBookContentFromName(string title)
        {
            return _sections[title].Content;
        }

        public string[] GetButtonNames(string title)
        {
            Navigation[] navigationItems = _sections[title].Navigation;

            List<string> buttonNames = new List<string>();
            foreach(Navigation navItem in navigationItems)
            {
                buttonNames.Add(navItem.Text);
            }

            return buttonNames.ToArray();
        }

        public string[] GetButtonSections(string title)
        {
            Navigation[] navigationItems = _sections[title].Navigation;

            List<string> buttonSections = new List<string>();
            foreach (Navigation navItem in navigationItems)
            {
                buttonSections.Add(navItem.Section);
            }

            return buttonSections.ToArray();
        }
    }
}
