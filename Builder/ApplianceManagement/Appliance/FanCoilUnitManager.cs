using System;

namespace Builder.ApplianceManagement.Appliance
{
    class FanCoilUnitManager : CommonApplianceManager, ICommonAppliance
    {
        public void ShutdownApplianceAsync()
        {
            Console.WriteLine("Shut down Fan Coil Unit appliance");
        }
        public void StartApplianceAsync()
        {
            Console.WriteLine("Start Fan Coil Unit appliance");
        }
    }
}