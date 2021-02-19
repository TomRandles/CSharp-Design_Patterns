using System;
using System.Collections.Generic;
using System.Text;

namespace Builder.ApplianceManagement.Appliance
{
    public interface ICommonAppliance
    {
        string ApplianceDeploymentID { get; set; }
        string ApplianceID { get; set; }
        string ApplianceServerIPAddress { get; set; }
        ushort ApplianceServerIPPortNumber { get; set; }
        uint ApplianceServerTimeout { get; set; }
        byte ApplianceSlaveID { get; set; }

        void StartApplianceAsync();
        void ShutdownApplianceAsync();
        string Debug();
    }
}
