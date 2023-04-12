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
            string title = "table-of-contents";
            bool expectedResult = true;

            //Action
            bool actualResult = bookInformationLoader.CheckIfBookTitleExists(title);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GIVEN_InvalidTitle_WHEN_DeterminingIfTitleExists_THEN_ReturnFalse()
        {
            //Arrange
            string title = "the-red-headed-league";
            bool expectedResult = false;

            //Action
            bool actualResult = bookInformationLoader.CheckIfBookTitleExists(title);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GIVEN_BookName_WHEN_GettingBookContent_THEN_ReturnBookContent()
        {
            //Arrange
            string bookName = "a-scandal-in-bohemia";
            string[] expectedResult = {
                "Chapter I",
                "Chapter II",
                "Chapter III"
            };

            //Action
            string[] actualResult = bookInformationLoader.GetBookContentFromName(bookName);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GIVEN_BookName_WHEN_GettingButtonText_THEN_ReturnButtonText()
        {
            //Arrange
            string bookName = "bohemia-chapter-2";
            string[] expectedResult = {
                "Chapter III",
                "Return to Chapter I"
            };

            //Action
            string[] actualResult = bookInformationLoader.GetButtonNames(bookName);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GIVEN_BookName_WHEN_GettingButtonSections_THEN_Return()
        {
            //Arrange
            string bookName = "bohemia-chapter-3";
            string[] expectedResult = {
                "bohemia-chapter-2",
                "table-of-contents"
            };

            //Action
            string[] actualResult = bookInformationLoader.GetButtonSections(bookName);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
