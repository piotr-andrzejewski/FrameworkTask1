using FrameworkTask1.Pages;
using FrameworkTask1.Utils;
using OpenQA.Selenium;

namespace FrameworkTask1.Tests
{
    public class EstimateTest
    {
        private readonly IWebDriver driver;
        private readonly WebDriverManager webDriverManager;

        public EstimateTest()
        {
            webDriverManager = new WebDriverManager();
            driver = webDriverManager.GetDriver();
        }

        [Theory]
        [InlineData("Development")]
        [InlineData("QA")]
        [InlineData("Staging")]
        public void VerifyCostEstimateSummary(string environment)
        {
            var helper = new TestDataHelper(environment);
            var testData = helper.TestData;

            try
            {
                // Arrange
                var homePage = new HomePage(driver);
                var calculatorPage = new PricingCalculatorPage(driver);
                var summaryPage = new EstimateSummaryPage(driver);

                // Act
                homePage.Open();
                homePage.AcceptCookies();
                homePage.ClickAddToEstimate();
                calculatorPage.SelectComputeEngine();
                calculatorPage.FillOutForm(testData);
                calculatorPage.ClickShareButton();
                summaryPage.ClickOpenEstimateSummary();

                // Assert
                var estimatedCost = summaryPage.GetTotalEstimatedCost();
                var summaryText = summaryPage.GetCostEstimateSummary(testData.AddGpus);

                if (testData.AddGpus)
                {
                    Assert.Contains(testData.GpuModel, summaryText);
                    Assert.Contains(testData.NumberOfGpus.ToString(), summaryText);
                }

                Assert.Contains(testData.MachineType, summaryText);
                Assert.Contains(testData.LocalSsd, summaryText);
                Assert.Contains(testData.NumberOfInstances.ToString(), summaryText);
                Assert.Contains(testData.OperatingSystem, summaryText);
                Assert.Contains(testData.ProvisioningModel, summaryText);
                Assert.Contains(testData.AddGpus.ToString().ToLower(), summaryText);
                Assert.Contains(testData.Region, summaryText);
                Assert.Equal(testData.EstimatedCost, estimatedCost);
            }
            catch (Exception)
            {
                ScreenshotHelper.TakeScreenshot(driver, nameof(VerifyCostEstimateSummary));
                throw;
            }
        }
    }
}