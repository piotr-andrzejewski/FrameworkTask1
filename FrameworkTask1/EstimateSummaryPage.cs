using OpenQA.Selenium;
using System.Text;

namespace WebDriverTask3
{
    public class EstimateSummaryPage
    {
        private readonly IWebDriver driver;

        // Locators for cost and summary
        private readonly By totalEstimatedCost = By.XPath("//label[@class='gN5n4 MyvX5d D0aEmf']");
        private readonly By summaryButton = By.XPath("//a[contains(text(), 'Open estimate summary')]");
        private readonly By summaryMachineType = By.XPath("//*[@id='yDmH0d']/c-wiz[1]/div/div/div/div/div/div[2]/div[2]/div[1]/div/div[2]/div/div[3]/span[2]/span[1]/span[2]");
        private readonly By summaryGpuModel = By.XPath("//*[@id='yDmH0d']/c-wiz[1]/div/div/div/div/div/div[2]/div[2]/div[1]/div/div[2]/div/div[4]/span[2]/span[1]/span[2]");
        private readonly By summaryNumberOfGpus = By.XPath("//*[@id='yDmH0d']/c-wiz[1]/div/div/div/div/div/div[2]/div[2]/div[1]/div/div[2]/div/div[4]/span[3]/span[1]/span[2]");
        private readonly By summaryLocalSsd = By.XPath("//*[@id='yDmH0d']/c-wiz[1]/div/div/div/div/div/div[2]/div[2]/div[1]/div/div[2]/div/div[5]/span/span[1]/span[2]");
        private readonly By summaryNumberOfInstances = By.XPath("//*[@id='yDmH0d']/c-wiz[1]/div/div/div/div/div/div[2]/div[2]/div[1]/div/div[2]/div/div[7]/span/span[1]/span[2]");
        private readonly By summaryOperatingSystem = By.XPath("//*[@id='yDmH0d']/c-wiz[1]/div/div/div/div/div/div[2]/div[2]/div[1]/div/div[2]/div/div[8]/span/span[1]/span[2]");
        private readonly By summaryProvisioningModel = By.XPath("//*[@id='yDmH0d']/c-wiz[1]/div/div/div/div/div/div[2]/div[2]/div[1]/div/div[2]/div/div[9]/span/span[1]/span[2]");
        private readonly By summaryAddGpus = By.XPath("//*[@id='yDmH0d']/c-wiz[1]/div/div/div/div/div/div[2]/div[2]/div[1]/div/div[2]/div/div[13]/span/span[1]/span[2]");
        private readonly By summaryRegion = By.XPath("//*[@id='yDmH0d']/c-wiz[1]/div/div/div/div/div/div[2]/div[2]/div[1]/div/div[2]/div/div[15]/span/span[1]/span[2]");


        public EstimateSummaryPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetTotalEstimatedCost()
        {
            return driver.FindElement(totalEstimatedCost).Text;
        }

        public void ClickOpenEstimateSummary()
        {
            driver.FindElement(summaryButton).Click();
        }

        public string GetCostEstimateSummary()
        {
            // Switch to the new tab
            var tabs = driver.WindowHandles;
            driver.SwitchTo().Window(tabs[1]);

            // Find the summary element and get the text
            var result = new StringBuilder();
            result.Append(driver.FindElement(summaryMachineType).Text);
            result.Append(driver.FindElement(summaryGpuModel).Text);
            result.Append(driver.FindElement(summaryNumberOfGpus).Text);
            result.Append(driver.FindElement(summaryLocalSsd).Text);
            result.Append(driver.FindElement(summaryNumberOfInstances).Text);
            result.Append(driver.FindElement(summaryOperatingSystem).Text);
            result.Append(driver.FindElement(summaryProvisioningModel).Text);
            result.Append(driver.FindElement(summaryAddGpus).Text);
            result.Append(driver.FindElement(summaryRegion).Text);

            return result.ToString();
        }
    }
}
