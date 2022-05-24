using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NunitWebDriverTests
{
    public class SoftUniTests
    {
        private WebDriver driver;

        [OneTimeSetUp]
        public void OpenBrowserAndNavigate()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");

            this.driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Url = "https://softuni.bg";
        }

        [OneTimeTearDown]

        public void ShutDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test_AssertMainPageTitle()
        {
            //Act
            driver.Url = "https://softuni.bg";
            string expectedTitle = "Обучение по програмиране - Софтуерен университет";

            //Assert
            Assert.AreEqual(expectedTitle, driver.Title);
        }

        [Test]
        public void Test_AssertAboutUsTitle()
        {
            //Act
            driver.Url = "https://softuni.bg";
            //var aboutUsButton = driver.FindElement(By.CssSelector("#header-nav > div.toggle-nav.toggle-holder > ul > li:nth-child(1) > a > span"));
            var aboutUsButton = driver.FindElement(By.LinkText("За нас"));
            aboutUsButton.Click();

            string expectedTitle = "За нас - Софтуерен университет";

            //Assert
            Assert.AreEqual(expectedTitle, driver.Title);
        }

        [Test]
        public void Test_Login_InvalidUsernameAndPassword()
        {
            driver.FindElement(By.CssSelector(".softuni-btn-primary")).Click();

            //IWebElement usernameField = driver.FindElement(By.Id("username"));
            //var usernameField = driver.FindElement(By.Id("username"));

            var usernameField_ByName = driver.FindElement(By.Name("username"));
            var usernameField_CssSelector = driver.FindElement(By.CssSelector("#username"));

            usernameField_CssSelector.Click();
            usernameField_CssSelector.SendKeys("user1");
            //usernameField_CssSelector.Clear();

            //driver.FindElement(By.Id("password-input")).Click();
            usernameField_CssSelector.SendKeys(Keys.Tab);

            driver.FindElement(By.Id("password-input")).SendKeys("user1");
            driver.FindElement(By.CssSelector(".softuni-btn")).Click();
            driver.FindElement(By.CssSelector("li")).Click();

            Assert.That(driver.FindElement(By.CssSelector("li")).Text, Is.EqualTo("Невалидно потребителско име или парола"));
            driver.Close();
        }

        [Test]

        public void Test_Search()
        {
            driver.Url = "https://softuni.bg";

            var searchField = driver.FindElement(By.CssSelector(".header-search-dropdown-link .fa-search"));
            searchField.Click();

            var searchBox = driver.FindElement(By.CssSelector(".container > form #search-input"));
            searchBox.Click();
            searchBox.SendKeys("QA");
            searchBox.SendKeys(Keys.Enter);

            var resultField = driver.FindElement(By.CssSelector(".search-title")).Text;

            var expectedValue = "Резултати от търсене на “QA”";

            Assert.That(resultField, Is.EqualTo(expectedValue));
        }
    }
}