using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Team1_ABCPublishingProblem_WebApp.Models.Interfaces;
using Team1_ABCPublishingProblem_WebApp.Models.Objects;
using Team1_ABCPublishingProblem_WebApp.Constants;

namespace Team1_ABCPublishingProblem_WebApp.BusinessLogic
{
    public class JSONParser : IJSONParser
    {
        public IDictionary<string, Section> LoadJSON()
        {
            IDictionary<string, Section> sectionDictionary = new Dictionary<string, Section>();

            string fullFilePath = Path.GetFullPath(JSONContstants.JSONFilePath);
            using (StreamReader reader = new StreamReader(fullFilePath))
            {
                string json = reader.ReadToEnd();
                JObject section = JObject.Parse(json);

                foreach (JProperty property in section.Properties())
                {
                    Section newSection = ParseJsonToSectionObject(property);

                    sectionDictionary.Add(property.Name, newSection);
                }
            }

            return sectionDictionary;
        }

        private Section ParseJsonToSectionObject(JProperty property)
        {
            JObject sectionObj = (JObject)property.Value;

            Section newSection = new Section();

            newSection.Name = property.Name;
            newSection.Title = (string)sectionObj[JSONContstants.TitleKey];

            JArray sectionContent = (JArray)sectionObj[JSONContstants.Contentkey];
            newSection.Content = sectionContent.ToObject<string[]>();

            List<Navigation> navigationList = ParseNavigationObject(sectionObj);
            newSection.Navigation = navigationList.ToArray();

            return newSection;
        }

        private List<Navigation> ParseNavigationObject(JObject sectionObj)
        {
            JArray sectionNavigation = (JArray)sectionObj[JSONContstants.NavigationKey];
            List<Navigation> navigationList = new List<Navigation>();
            foreach (JObject navItem in sectionNavigation)
            {
                Navigation navigation = new Navigation();
                navigation.Text = (string)navItem[JSONContstants.TextKey];
                navigation.Section = (string)navItem[JSONContstants.SectionKey];
                navigationList.Add(navigation);
            }

            return navigationList;
        }
    }
}