using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



var driver = new ChromeDriver();

driver.Url = "https://wikipedia.org";

System.Console.WriteLine("CURRENT TITLE: " + driver.Title);

var searchField = driver.FindElement(By.Id("searchInput"));
searchField.Click();
searchField.SendKeys("Quality Assurance" + Keys.Enter);

System.Console.WriteLine("TITLE AFTER SEARCH: " + driver.Title);

driver.Quit();
