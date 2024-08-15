using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Text;

namespace FrameworkTask1.Pages
{
    public class EstimateSummaryPage
    {
        private readonly IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//label[@class='gN5n4 MyvX5d D0aEmf']")]
        private readonly IWebElement totalEstimatedCost;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Open estimate summary')]")]
        private readonly IWebElement summaryButton;

        private readonly By summaryText = By.XPath("//div/span/span[1]/span[2]");

        public EstimateSummaryPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public string GetTotalEstimatedCost()
        {
            return totalEstimatedCost.Text;
        }

        public void ClickOpenEstimateSummary()
        {
            summaryButton.Click();
        }

        public string GetCostEstimateSummary(bool addGpus)
        {
            // Switch to the new tab
            var tabs = driver.WindowHandles;
            driver.SwitchTo().Window(tabs[1]);

            // Find the summary element and get the text
            var summary = driver.FindElements(summaryText);
            var result = new StringBuilder();

            foreach (var item in summary)
            {
                result.Append(item.Text);
            }

            return result.ToString();
        }
    }
}
