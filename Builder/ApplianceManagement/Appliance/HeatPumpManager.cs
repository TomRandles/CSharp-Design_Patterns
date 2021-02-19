using System;

namespace Builder.ApplianceManagement.Appliance
{
    public class HeatPumpManager : CommonApplianceManager, ICommonAppliance
    {
        public void ShutdownApplianceAsync()
        {
            Console.WriteLine("Shut down Heat Pump appliance");
        }

        public void StartApplianceAsync()
        {
            Console.WriteLine("Start Heat Pump appliance");
        }
    }
}