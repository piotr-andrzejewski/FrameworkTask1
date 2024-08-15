using OpenQA.Selenium;

namespace FrameworkTask1.Utils
{
    public static class ScreenshotHelper
    {
        private const string basePath = "C:\\Users\\Lenovo\\source\\repos\\FrameworkTask1\\FrameworkTask1\\Utils\\";

        public static void TakeScreenshot(IWebDriver driver, string testName)
        {
            try
            {
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string screenshotPath = Path.Combine(basePath, "Screenshots");

                if (!Directory.Exists(screenshotPath))
                {
                    Directory.CreateDirectory(screenshotPath);
                }

                string fileName = $"{testName}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                screenshot.SaveAsFile(Path.Combine(screenshotPath, fileName));
            }
            catch (Exception e)
            {
                Console.WriteLine("Screenshot capture failed: " + e.Message);
            }
        }
    }
}
