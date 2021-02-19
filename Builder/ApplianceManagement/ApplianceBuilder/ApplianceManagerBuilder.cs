using Builder.ApplianceManagement.Appliance;
using System;
using System.Text;

namespace Builder.ApplianceManagement.ApplianceBuilder
{
    public class ApplianceManagerBuilder : IApplianceManagerBuilder
    {
        protected ICommonAppliance _applianceManager { get; private set; }

        public ApplianceManagerBuilder(ApplianceType applianceType)
        {
            Reset(applianceType);
        }

        private void Reset(ApplianceType applianceType)
        {
            switch(applianceType)
            {
                case ApplianceType.HeatPump:
                    _applianceManager = new HeatPumpManager();
                    break;
                case ApplianceType.FanCoilUnit:
                    _applianceManager = new FanCoilUnitManager();
                    break;
                default:
                    throw new InvalidOperationException("Appliance manager type not recognised");
            }
        }

        public IApplianceManagerBuilder AddApplianceManagerIdentifiers(string applianceDeploymentID, string applianceID)
        {
            _applianceManager.ApplianceDeploymentID = applianceDeploymentID;
            _applianceManager.ApplianceID = applianceID;

            return this;
        }

        public IApplianceManagerBuilder AddAppServerConfiguration(uint timeout, byte slaveID)
        {
            _applianceManager.ApplianceServerTimeout = timeout;
            _applianceManager.ApplianceSlaveID = slaveID;
            
            return this;
        }

        public IApplianceManagerBuilder AddIPConfiguration(string ipAddress, ushort ipPortNumber)
        {
            _applianceManager.ApplianceServerIPAddress = ipAddress;
            _applianceManager.ApplianceServerIPPortNumber = ipPortNumber;

            return this;
        }



        public ICommonAppliance GetApplianceManager()
        {
            return _applianceManager;
        }
    }
}