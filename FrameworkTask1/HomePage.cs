using OpenQA.Selenium;

namespace WebDriverTask3
{
    public class HomePage
    {
        private readonly IWebDriver driver;
        private readonly By addToEstimateButton = By.XPath("//button[@class='UywwFc-LgbsSe UywwFc-LgbsSe-OWXEXe-Bz112c-M1Soyc UywwFc-LgbsSe-OWXEXe-dgl2Hf xhASFc']");
        private readonly By acceptCookies = By.XPath("//button[@class='glue-cookie-notification-bar__accept']");

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Open()
        {
            driver.Navigate().GoToUrl("https://cloud.google.com/products/calculator/");
        }

        public void AcceptCookies()
        {
            driver.FindElement(acceptCookies).Click();
        }

        public void ClickAddToEstimate()
        {
            driver.FindElement(addToEstimateButton).Click();
        }
    }
}
