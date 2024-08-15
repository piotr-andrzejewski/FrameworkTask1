using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace FrameworkTask1.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//button[@class='UywwFc-LgbsSe UywwFc-LgbsSe-OWXEXe-Bz112c-M1Soyc UywwFc-LgbsSe-OWXEXe-dgl2Hf xhASFc']")]
        private readonly IWebElement addToEstimateButton;

        [FindsBy(How = How.XPath, Using = "//button[@class='glue-cookie-notification-bar__accept']")]
        private readonly IWebElement acceptCookies;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Open()
        {
            driver.Navigate().GoToUrl("https://cloud.google.com/products/calculator/");
        }

        public void AcceptCookies()
        {
            acceptCookies.Click();
        }

        public void ClickAddToEstimate()
        {
            addToEstimateButton.Click();
        }
    }
}
