using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace WebDriverTask3
{
    public class EstimateTest
    {
        private readonly IWebDriver driver;

        public EstimateTest()
        {
            driver = new EdgeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Fact]
        public void VerifyCostEstimateSummary()
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
            calculatorPage.FillOutForm();
            calculatorPage.ClickShareButton();
            summaryPage.ClickOpenEstimateSummary();

            // Assert
            var estimatedCost = summaryPage.GetTotalEstimatedCost();
            var summaryText = summaryPage.GetCostEstimateSummary();

            Assert.Contains("n1-standard-8, vCPUs: 8, RAM: 30 GB", summaryText);
            Assert.Contains("NVIDIA V100", summaryText);
            Assert.Contains("1", summaryText);
            Assert.Contains("2x375 GB", summaryText);
            Assert.Contains("4", summaryText);
            Assert.Contains("Free: Debian, CentOS, CoreOS, Ubuntu or BYOL (Bring Your Own License)", summaryText);
            Assert.Contains("Regular", summaryText);
            Assert.Contains("true", summaryText);
            Assert.Contains("Netherlands (europe-west4)", summaryText);
            Assert.Equal("$8,935.06 / month", estimatedCost);

            driver.Quit();
        }
    }
}