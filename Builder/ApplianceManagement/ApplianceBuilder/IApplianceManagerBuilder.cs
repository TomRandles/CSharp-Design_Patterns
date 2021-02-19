using Builder.ApplianceManagement.Appliance;

namespace Builder.ApplianceManagement.ApplianceBuilder
{
    // Use Fluent Builder pattern
    public interface IApplianceManagerBuilder
    {

        public IApplianceManagerBuilder AddIPConfiguration(string IPAddress, ushort IPPortNumber);

        public IApplianceManagerBuilder AddAppServerConfiguration(uint timeout, byte slaveID);

        public IApplianceManagerBuilder AddApplianceManagerIdentifiers(string applianceDeploymentID, 
                                                                       string applianceID);
        public ICommonAppliance GetApplianceManager();

    }
}
