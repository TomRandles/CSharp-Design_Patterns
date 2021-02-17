using System;

namespace State.ApplianceStateManagement
{
    public class StartProgrammeState : ApplianceOperationalState
    {
        public StartProgrammeState()
        {
            CurrentStateName = "Appliance programme start";
        }

        public override void StartProgramme(ApplianceContext appliance)
        {
            Console.WriteLine($"Start programme illegal in \"{CurrentStateName}\" state. Request ignored.");

        }

        public override void StopProgramme(ApplianceContext appliance)
        {
            appliance.TransitionToState(new StopProgrammeState());
        }

        public override void TurnOffAppliance(ApplianceContext appliance)
        {
            appliance.TransitionToState(new ApplianceOffState());
        }

        public override void TurnOnAppliance(ApplianceContext appliance)
        {
            Console.WriteLine($"Turn on appliance illegal in \"{CurrentStateName}\" state. Request ignored.");
        }
    }
}