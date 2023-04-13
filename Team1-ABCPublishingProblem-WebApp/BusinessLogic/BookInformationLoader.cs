using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Team1_ABCPublishingProblem_WebApp.Models.Interfaces;
using Team1_ABCPublishingProblem_WebApp.Models.Objects;

namespace Team1_ABCPublishingProblem_WebApp.BusinessLogic
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

        public bool CheckIfKeyExists(string key)
        {
            if(!_sections.ContainsKey(key))
            {
                return false;
            }

            return true;
        }

        public void ThrowExceptionIfKeyNotFound(string key)
        {
            if (!CheckIfKeyExists(key))
            {
                throw new Exception("That title was not found");
            }
        }

        public string GetTitleByKey(string key)
        {
            return _sections[key].Title;
        }

        public string[] GetSectionContentByKey(string key)
        {
            ThrowExceptionIfKeyNotFound(key);

            return _sections[key].Content;
        }

        public string[] GetButtonTextByKey(string key)
        {
            ThrowExceptionIfKeyNotFound(key);

            Navigation[] navigationItems = _sections[key].Navigation;

            List<string> buttonNames = new List<string>();
            foreach (Navigation navItem in navigationItems)
            {
                buttonNames.Add(navItem.Text);
            }

            return buttonNames.ToArray();
        }

        public string[] GetButtonSectionsByKey(string key)
        {
            ThrowExceptionIfKeyNotFound(key);

            Navigation[] navigationItems = _sections[key].Navigation;

            List<string> buttonSections = new List<string>();
            foreach (Navigation navItem in navigationItems)
            {
                buttonSections.Add(navItem.Section);
            }

            return buttonSections.ToArray();
        }

        public string[] GetContentByTitle(string title)
        {
            string key = _sections.FirstOrDefault(x => x.Value.Title == title).Key;

            if (key == null || _sections[key].Content == null)
            {
                return new string[0];
            }

            return _sections[key].Content;
        }

        public string[] GetButtonTextByTitle(string title)
        {
            string key = _sections.FirstOrDefault(x => x.Value.Title == title).Key;

            if(key == null)
            {
                return new string[0];
            }

            Navigation[] navigationItems = _sections[key].Navigation;

            List<string> buttonNames = new List<string>();
            foreach (Navigation navItem in navigationItems)
            {
                buttonNames.Add(navItem.Text);
            }

            return buttonNames.ToArray();
        }

        public string[] GetButtonSectionsByTitle(string title)
        {
            string key = _sections.FirstOrDefault(x => x.Value.Title == title).Key;

            if (key == null)
            {
                return new string[0];
            }

            Navigation[] navigationItems = _sections[key].Navigation;

            List<string> buttonSections = new List<string>();
            foreach (Navigation navItem in navigationItems)
            {
                buttonSections.Add(navItem.Section);
            }

            return buttonSections.ToArray();
        }
    }
}
