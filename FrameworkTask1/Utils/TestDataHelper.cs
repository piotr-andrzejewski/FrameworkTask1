using FrameworkTask1.Models;
using Microsoft.Extensions.Configuration;

namespace FrameworkTask1.Utils
{
    public class TestDataHelper
    {
        private readonly string basePath = "C:\\Users\\Lenovo\\source\\repos\\FrameworkTask1\\FrameworkTask1\\Utils\\";
        private IConfiguration Configuration { get; }
        public PricingCalculatorModel TestData { get; }

        public TestDataHelper(string environment)
        {
            if (!File.Exists(Path.Combine(basePath + $"appsettings.{environment}.json")))
            {
                TestData = new PricingCalculatorModel()
                {
                    NumberOfInstances = 1,
                    OperatingSystem = "Free: Debian, CentOS, CoreOS, Ubuntu or BYOL (Bring Your Own License)",
                    ProvisioningModel = "Regular",
                    MachineFamily = "General Purpose",
                    Series = "N1",
                    MachineType = "n1-standard-4",
                    AddGpus = false,
                    GpuModel = "",
                    NumberOfGpus = 0,
                    LocalSsd = "0",
                    Region = "Iowa (us-central1)",
                    EstimatedCost = "$138.70 / month"
                };

                return;
            }

            Configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile($"appsettings.{environment}.json", optional: false, reloadOnChange: true)
                .Build();

            TestData = Configuration.GetSection("PricingCalculator").Get<PricingCalculatorModel>()!;
        }
    }
}
