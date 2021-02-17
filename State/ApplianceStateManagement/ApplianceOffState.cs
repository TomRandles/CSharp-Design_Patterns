using System;

namespace State.ApplianceStateManagement
{
    public class ApplianceOffState : ApplianceOperationalState
    {
        public ApplianceOffState()
        {
            CurrentStateName = "Appliance Off";
        }

        public override void TurnOnAppliance(ApplianceContext appliance)
        {
            appliance.TransitionToState(new ApplianceOnState());
        }

        public override void StartProgramme(ApplianceContext appliance)
        {
            Console.WriteLine($"Start programme illegal in \"{CurrentStateName}\" state. Request ignored.");   
        }

        public override void StopProgramme(ApplianceContext appliance)
        {
            Console.WriteLine($"Stop programme illegal in \"{CurrentStateName}\" state. Request ignored.");
        }

        public override void TurnOffAppliance(ApplianceContext appliance)
        {
            Console.WriteLine($"Turn off appliance illegal in \"{CurrentStateName}\" state. Request ignored.");
        }
    }
}
