using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Team1_ABCPublishingProblem_WebApp.Models.Interfaces;
using Team1_ABCPublishingProblem_WebApp.Models.Objects;

namespace Team1_ABCPublishingProblem
{
    public class JSONParser : IJSONParser
    {
        public IDictionary<string, Section> LoadJSON()
        {
            IDictionary<string, Section> sectionDictionary = new Dictionary<string, Section>();

            string fullFilePath = Path.GetFullPath("the-adventures-of-sherlock-holmes-sample.json");
            using (StreamReader reader = new StreamReader(fullFilePath))
            { 
                string json = reader.ReadToEnd();
                JObject section = JObject.Parse(json);

                foreach(JProperty property in section.Properties())
                {
                    Section newSection = ParseJsonToSectionObject(property);

                    sectionDictionary.Add(property.Name, newSection);
                }
            }

            foreach(var section in sectionDictionary)
            {
                string content = ""; 
                if (section.Value.Content.Length > 0)
                {
                    content = section.Value.Content[0];
                }
                Console.WriteLine("Section Name: " + section.Value.Name + ", Section Content:" + content + ", First Navigation: " + section.Value.Navigation[0].Text);
            }

            return sectionDictionary;
        }

        private Section ParseJsonToSectionObject(JProperty property)
        {
            JObject sectionObj = (JObject)property.Value;

            Section newSection = new Section();

            newSection.Name = property.Name;
            newSection.Title = (string)sectionObj["title"];

            JArray sectionContent = (JArray)sectionObj["content"];
            newSection.Content = sectionContent.ToObject<string[]>();

            List<Navigation> navigationList = ParseNavigationObject(sectionObj);
            newSection.Navigation = navigationList.ToArray();

            return newSection;
        }

        private List<Navigation> ParseNavigationObject(JObject sectionObj)
        {
            JArray sectionNavigation = (JArray)sectionObj["navigation"];
            List<Navigation> navigationList = new List<Navigation>();
            foreach (JObject navItem in sectionNavigation)
            {
                Navigation navigation = new Navigation();
                navigation.Text = (string)navItem["text"];
                navigation.Section = (string)navItem["section"];
                navigationList.Add(navigation);
            }

            return navigationList;
        }
    }
}