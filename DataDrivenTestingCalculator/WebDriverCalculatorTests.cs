using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DataDrivenTestingCalculator
{
    public class WebDriverCalculatorTests

    {
        private ChromeDriver driver;

        IWebElement field1;
        IWebElement field2;
        IWebElement operation;
        IWebElement calculateButton;
        IWebElement resultField;
        IWebElement clearField;

        [OneTimeSetUp]
        public void OpenAndNavigate()
        {
            this.driver = new ChromeDriver();
            driver.Url = "https://number-calculator.nakov.repl.co/";

            field1 = driver.FindElement(By.Id("number1"));
            field2 = driver.FindElement(By.Id("number2"));
            operation = driver.FindElement(By.Id("operation"));
            calculateButton = driver.FindElement(By.Id("calcButton"));
            resultField = driver.FindElement(By.Id("result"));
            clearField = driver.FindElement(By.Id("resetButton"));
        }

        [OneTimeTearDown]

        public void ShutDown()
        {
            driver.Close();
        }


        [TestCase ("5", "6", "+", "Result: 11")]
        [TestCase("15", "6", "-", "Result: 9")]
        [TestCase("2", "6", "*", "Result: 12")]
        [TestCase("18", "3", "/", "Result: 6")]
        [TestCase("0", "0", "/", "Result: invalid calculation")]
        [TestCase("blabla", "alabala", "/", "Result: invalid input")]

        public void Test_Calculator(string num1, string num2, string operatorr, string result)
        {
            //Act
            field1.SendKeys(num1);
            operation.SendKeys(operatorr);
            field2.SendKeys(num2);
            calculateButton.Click();

            Assert.That(result, Is.EqualTo(resultField.Text));

            clearField.Click();
        }
    }
}