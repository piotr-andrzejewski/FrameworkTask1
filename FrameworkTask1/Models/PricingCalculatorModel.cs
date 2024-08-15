namespace FrameworkTask1.Models
{
    public class PricingCalculatorModel
    {
        public int NumberOfInstances { get; set; }
        public string OperatingSystem { get; set; }
        public string ProvisioningModel { get; set; }
        public string MachineFamily { get; set; }
        public string Series { get; set; }
        public string MachineType { get; set; }
        public bool AddGpus { get; set; }
        public string GpuModel { get; set; }
        public int NumberOfGpus { get; set; }
        public string LocalSsd { get; set; }
        public string Region { get; set; }
        public string EstimatedCost { get; set; }
    }
}
