using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebDriverTask3
{
    public class PricingCalculatorPage
    {
        private readonly IWebDriver driver;

        // Locators
        private readonly By computeEngineTab = By.XPath("//h2[text()='Compute Engine']");
        private readonly By numberOfInstances = By.XPath("//input[@id='c13']");
        private readonly By operatingSystem = By.XPath("//div[@aria-labelledby='c21 c23']");
        private readonly By chosenOperatingSystem = By.XPath("//li[@data-value='free-debian-centos-coreos-ubuntu-or-byol-bring-your-own-license']");
        private readonly By provisioningModel = By.XPath("//input[@value='regular']");
        private readonly By machineFamily = By.XPath("//div[@aria-labelledby='c25 c27']");
        private readonly By chosenMachineFamily = By.XPath("//li[@data-value='general-purpose']");
        private readonly By series = By.XPath("//div[@aria-labelledby='c29 c31']");
        private readonly By chosenSeries = By.XPath("//li[@data-value='n1']");
        private readonly By machineType = By.XPath("//div[@aria-labelledby='c33 c35']");
        private readonly By chosenMachineType = By.XPath("//li[@data-value='n1-standard-8']");
        private readonly By addGpusButton = By.XPath("//button[@aria-label='Add GPUs']");
        private readonly By gpuModel = By.XPath("//*[@id='ow5']/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[23]/div/div[1]/div/div/div/div[1]");
        private readonly By chosenGpuModel = By.XPath("//li[@data-value='nvidia-tesla-v100']");
        private readonly By numberOfGpus = By.XPath("//*[@id='ow5']/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[24]/div/div[1]/div/div/div/div[1]");
        private readonly By chosenNumberOfGpus = By.XPath("//li[@data-value='1']");
        private readonly By localSsd = By.XPath("//div[@aria-labelledby='c41 c43']");
        private readonly By chosenLocalSsd = By.XPath("//*[@id='ow5']/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[27]/div/div[1]/div/div/div/div[2]/ul/li[3]");
        private readonly By region = By.XPath("//div[@aria-labelledby='c45 c47']");
        private readonly By chosenRegion = By.XPath("//li[@data-value='europe-west4']");
        private readonly By updatedCostConfirmation = By.XPath("//*[@id='ucj-1']/div/div/div/div/div/div/div/div[1]/div/div[1]/div[4]");
        private readonly By shareButton = By.XPath("//button[@aria-label='Open Share Estimate dialog']");

        public PricingCalculatorPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SelectComputeEngine()
        {
            driver.FindElement(computeEngineTab).Click();
        }

        public void FillOutForm()
        {
            var instancesCount = driver.FindElement(numberOfInstances);
            instancesCount.Clear();
            instancesCount.SendKeys("4");

            driver.FindElement(operatingSystem).Click();
            driver.FindElement(chosenOperatingSystem).Click();

            if (!driver.FindElement(provisioningModel).Selected)
            {
                driver.FindElement(provisioningModel).Click();
            }

            driver.FindElement(machineFamily).Click();
            driver.FindElement(chosenMachineFamily).Click();
            driver.FindElement(series).Click();
            driver.FindElement(chosenSeries).Click();
            driver.FindElement(machineType).Click();
            driver.FindElement(chosenMachineType).Click();
            driver.FindElement(addGpusButton).Click();
            driver.FindElement(gpuModel).Click();
            driver.FindElement(chosenGpuModel).Click();
            driver.FindElement(numberOfGpus).Click();
            driver.FindElement(chosenNumberOfGpus).Click();
            driver.FindElement(localSsd).Click();
            driver.FindElement(chosenLocalSsd).Click();
            driver.FindElement(region).Click();
            driver.FindElement(chosenRegion).Click();
        }

        public void ClickShareButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            if (wait.Until(ExpectedConditions.TextToBePresentInElementLocated(updatedCostConfirmation, "Service cost updated")))
            {
                driver.FindElement(shareButton).Click();
            }
        }
    }
}
