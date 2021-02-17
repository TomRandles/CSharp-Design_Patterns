namespace State.ApplianceStateManagement
{
    public abstract class ApplianceOperationalState
    {
        public string CurrentStateName { get; protected set; }
        
        public abstract void TurnOffAppliance(ApplianceContext appliance);

        public abstract void TurnOnAppliance(ApplianceContext appliance);

        public abstract void StartProgramme(ApplianceContext appliance);

        public abstract void StopProgramme(ApplianceContext appliance);
    }
}