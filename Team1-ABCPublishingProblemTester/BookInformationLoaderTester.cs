using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Team1_ABCPublishingProblem_WebApp.BusinessLogic;
using Team1_ABCPublishingProblem_WebApp.Controllers;

namespace Team1_ABCPublishingProblem.Tests
{
    [TestFixture]
    public class BookInformationLoaderTester
    {
        BookInformationLoader bookInformationLoader;
        [SetUp]
        public void SetUp()
        {
            bookInformationLoader = new BookInformationLoader(new JSONParser());
        }

        [Test]
        public void GIVEN_ValidTitle_WHEN_DeterminingIfTitleExists_THEN_ReturnTrue()
        {
            //Arrange
            const string key = "table-of-contents";
            const bool expectedResult = true;

            //Action
            bool actualResult = bookInformationLoader.CheckIfKeyExists(key);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GIVEN_InvalidTitle_WHEN_DeterminingIfTitleExists_THEN_ReturnFalse()
        {
            //Arrange
            const string key = "the-red-headed-league";
            const bool expectedResult = false;

            //Action
            bool actualResult = bookInformationLoader.CheckIfKeyExists(key);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GIVEN_InvalidTitle_WHEN_GettingBookContent_THEN_ThrowException()
        {
            //Arrange
            const string key = "the-red-headed-league";

            //Action
            Exception result = Assert.Throws<Exception>(() => bookInformationLoader.GetSectionContentByKey(key));

            //Assert
            Assert.AreEqual("That title was not found", result.Message);
        }

        [Test]
        public void GIVEN_BookName_WHEN_GettingBookContent_THEN_ReturnBookContent()
        {
            //Arrange
            const string key = "a-scandal-in-bohemia";
            string[] expectedResult = 
            {
                "Chapter I",
                "Chapter II",
                "Chapter III"
            };

            //Action
            string[] actualResult = bookInformationLoader.GetSectionContentByKey(key);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GIVEN_BookSeries_WHEN_GettingSeriesContent_THEN_ReturnSeriesContent()
        {
            //Arrange
            const string title = "A Scandal in Bohemia";
            string[] expectedResult =
            {
                "Chapter I",
                "Chapter II",
                "Chapter III"
            };

            //Action
            string[] actualResult = bookInformationLoader.GetContentByTitle(title);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GIVEN_BohemiaChapter1_WHEN_GettingChapterContent_THEN_ReturnChapterContent()
        {
            //Arrange
            const string key = "bohemia-chapter-1";
            string[] expectedResult =
            {
              "To Sherlock Holmes she is always the woman. I have seldom heard him mention her under any other name. In his eyes she eclipses and predominates the whole of her sex. It was not that he felt any emotion akin to love for Irene Adler. All emotions, and that one particularly, were abhorrent to his cold, precise but admirably balanced mind. He was, I take it, the most perfect reasoning and observing machine that the world has seen, but as a lover he would have placed himself in a false position. He never spoke of the softer passions, save with a gibe and a sneer. They were admirable things for the observer--excellent for drawing the veil from men's motives and actions. But for the trained reasoner to admit such intrusions into his own delicate and finely adjusted temperament was to introduce a distracting factor which might throw a doubt upon all his mental results. Grit in a sensitive instrument, or a crack in one of his own high-power lenses, would not be more disturbing than a strong emotion in a nature such as his. And yet there was but one woman to him, and that woman was the late Irene Adler, of dubious and questionable memory.",
              "..."
            };

            //Action
            string[] actualResult = bookInformationLoader.GetSectionContentByKey(key);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GIVEN_BohemiaChapter2_WHEN_GettingChapterContent_THEN_ReturnChapterContent()
        {
            //Arrange
            const string key = "bohemia-chapter-2";
            string[] expectedResult =
            {
              "At three o'clock precisely I was at Baker Street, but Holmes had not yet returned. The landlady informed me that he had left the house shortly after eight o'clock in the morning. I sat down beside the fire, however, with the intention of awaiting him, however long he might be. I was already deeply interested in his inquiry, for, though it was surrounded by none of the grim and strange features which were associated with the two crimes which I have already recorded, still, the nature of the case and the exalted station of his client gave it a character of its own. Indeed, apart from the nature of the investigation which my friend had on hand, there was something in his masterly grasp of a situation, and his keen, incisive reasoning, which made it a pleasure to me to study his system of work, and to follow the quick, subtle methods by which he disentangled the most inextricable mysteries. So accustomed was I to his invariable success that the very possibility of his failing had ceased to enter into my head.",
              "..."
            };

            //Action
            string[] actualResult = bookInformationLoader.GetSectionContentByKey(key);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GIVEN_BohemiaChapter3_WHEN_GettingChapterContent_THEN_ReturnChapterContent()
        {
            //Arrange
            const string key = "bohemia-chapter-3";
            string[] expectedResult =
            {
              "I slept at Baker Street that night, and we were engaged upon our toast and coffee in the morning when the King of Bohemia rushed into the room.",
              "..."
            };

            //Action
            string[] actualResult = bookInformationLoader.GetSectionContentByKey(key);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GIVEN_BookName_WHEN_GettingButtonText_THEN_ReturnButtonText()
        {
            //Arrange
            const string key = "bohemia-chapter-2";
            string[] expectedResult = {
                "Chapter III",
                "Return to Chapter I"
            };

            //Action
            string[] actualResult = bookInformationLoader.GetButtonNamesByKey(key);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GIVEN_ChapterName_WHEN_GettingButtonSections_THEN_ReturnButtonSections()
        {
            //Arrange
            const string key = "bohemia-chapter-3";
            string[] expectedResult = {
                "bohemia-chapter-2",
                "table-of-contents"
            };

            //Action
            string[] actualResult = bookInformationLoader.GetButtonSectionsByKey(key);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
