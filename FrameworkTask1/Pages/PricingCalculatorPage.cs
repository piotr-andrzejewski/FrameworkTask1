using FrameworkTask1.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace FrameworkTask1.Pages
{
    public class PricingCalculatorPage
    {
        private readonly IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//h2[text()='Compute Engine']")]
        private readonly IWebElement computeEngineTab;

        [FindsBy(How = How.XPath, Using = "//input[@id='c13']")]
        private readonly IWebElement numberOfInstances;

        [FindsBy(How = How.XPath, Using = "//div[@aria-labelledby='c21 c23']")]
        private readonly IWebElement operatingSystem;

        [FindsBy(How = How.XPath, Using = "//label[@for='107spot']")]
        private readonly IWebElement provisioningModelSpot;

        [FindsBy(How = How.XPath, Using = "//div[@aria-labelledby='c25 c27']")]
        private readonly IWebElement machineFamily;

        [FindsBy(How = How.XPath, Using = "//div[@aria-labelledby='c29 c31']")]
        private readonly IWebElement series;

        [FindsBy(How = How.XPath, Using = "//div[@aria-labelledby='c33 c35']")]
        private readonly IWebElement machineType;

        [FindsBy(How = How.XPath, Using = "//button[@aria-label='Add GPUs']")]
        private readonly IWebElement addGpusButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='ow5']/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[23]/div/div[1]/div/div/div/div[1]")]
        private readonly IWebElement gpuModel;

        [FindsBy(How = How.XPath, Using = "//*[@id='ow5']/div/div/div/div/div/div/div[1]/div/div[2]/div[3]/div[24]/div/div[1]/div/div/div/div[1]")]
        private readonly IWebElement numberOfGpus;

        [FindsBy(How = How.XPath, Using = "//div[@aria-labelledby='c41 c43']")]
        private readonly IWebElement localSsd;

        [FindsBy(How = How.XPath, Using = "//div[@aria-labelledby='c45 c47']")]
        private readonly IWebElement region;

        [FindsBy(How = How.XPath, Using = "//*[@id='ucj-1']/div/div/div/div/div/div/div/div[1]/div/div[1]/div[4]")]
        private readonly IWebElement updatedCostConfirmation;

        [FindsBy(How = How.XPath, Using = "//button[@aria-label='Open Share Estimate dialog']")]
        private readonly IWebElement shareButton;

        private readonly List<string> lowCO2Regions = new List<string> 
        {
            "Iowa (us-central1)",
            "Belgium (europe-west1)",
            "Oregon (us-west1)",
            "London (europe-west2)",
            "Frankfurt (europe-west3)",
            "Sao Paulo (southamerica-east1)",
            "Montreal (northamerica-northeast1)"
        };

        public PricingCalculatorPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void SelectComputeEngine()
        {
            computeEngineTab.Click();
        }

        public void FillOutForm(PricingCalculatorModel testData)
        {
            numberOfInstances.Clear();
            numberOfInstances.SendKeys(testData.NumberOfInstances.ToString());

            operatingSystem.Click();
            driver.FindElement(By.XPath($"//li[span[2][span[text()='{testData.OperatingSystem}']]]")).Click();

            if (testData.ProvisioningModel == "Spot")
            {
                provisioningModelSpot.Click();
            }

            machineFamily.Click();
            driver.FindElement(By.XPath($"//li[span[2][span[1][text()='{testData.MachineFamily}']]]")).Click();

            series.Click();
            driver.FindElement(By.XPath($"//li[span[2][span[1][text()='{testData.Series}']]]")).Click();

            machineType.Click();
            driver.FindElement(By.XPath($"//li[span[2][span[1][text()='{testData.MachineType}']]]")).Click();

            if (testData.AddGpus)
            {
                addGpusButton.Click();

                gpuModel.Click();
                driver.FindElement(By.XPath($"//li[span[2][span[text()='{testData.GpuModel}']]]")).Click();

                numberOfGpus.Click();
                driver.FindElement(By.XPath($"//li[span[2][span[text()='{testData.NumberOfGpus.ToString()}']]]")).Click();
            }

            localSsd.Click();
            driver.FindElement(By.XPath($"//li[span[2][span[text()='{testData.LocalSsd}']]]")).Click();

            region.Click();
            var selector = 2;

            if (lowCO2Regions.Contains(testData.Region))
            {
                selector = 3;
            }

            driver.FindElement(By.XPath($"//li[span[{selector}][span[text()='{testData.Region}']]]")).Click();
        }

        public void ClickShareButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            if (wait.Until(ExpectedConditions.TextToBePresentInElement(updatedCostConfirmation, "Service cost updated")))
            {
                shareButton.Click();
            }
        }
    }
}
