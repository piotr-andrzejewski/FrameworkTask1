using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace FrameworkTask1
{
    public class WebDriverManager
    {
        private IWebDriver? driver;

        public IWebDriver GetDriver()
        {
            if (driver is null)
            {
                driver = new EdgeDriver();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }

            return driver;
        }

        public void QuitDriver()
        {
            if (driver is not null)
            {
                driver.Quit();
                driver = null;
            }
        }
    }
}
