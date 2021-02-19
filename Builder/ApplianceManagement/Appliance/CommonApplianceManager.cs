using System.Text;

namespace Builder.ApplianceManagement.Appliance
{
    public abstract class CommonApplianceManager 
    {
        public string ApplianceDeploymentID { get; set; }
        public string ApplianceID { get; set; }
        public string ApplianceServerIPAddress { get; set; }
        public ushort ApplianceServerIPPortNumber { get; set; }
        public uint ApplianceServerTimeout { get; set; }
        public byte ApplianceSlaveID { get; set; }

        public string Debug()
        {
            var debugReport = new StringBuilder();

            debugReport.AppendLine($"Appliance manager object details:")
                       .AppendLine($"Appliance type: {this.GetType()}")
                       .AppendLine($"IP address: {ApplianceServerIPAddress}," +
                                   $"port number: {ApplianceServerIPPortNumber} ")
                       .AppendLine($"Deployment ID: {ApplianceDeploymentID} ")
                       .AppendLine($"Appliance ID: {ApplianceID} ")
                       .AppendLine($"Server slave ID {ApplianceSlaveID} ")
                       .AppendLine($"Timeout: {ApplianceServerTimeout} ");
            return debugReport.ToString();
        }
    }
}
