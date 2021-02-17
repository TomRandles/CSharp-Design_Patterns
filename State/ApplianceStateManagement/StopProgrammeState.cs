using System;

namespace State.ApplianceStateManagement
{
    public class StopProgrammeState : ApplianceOperationalState
    {
        public StopProgrammeState()
        {
            CurrentStateName = "Appliance programme stop";
        }

        public override void StartProgramme(ApplianceContext appliance)
        {
            appliance.TransitionToState(new StartProgrammeState());
        }

        public override void StopProgramme(ApplianceContext appliance)
        {
            Console.WriteLine($"Stop programme illegal in \"{CurrentStateName}\" state. Request ignored.");
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