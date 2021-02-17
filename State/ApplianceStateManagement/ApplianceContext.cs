using System;

namespace State.ApplianceStateManagement
{
    public class ApplianceContext
    {
        public string ApplianceDeploymentID { get; set; }

        public string ApplianceType { get; set; }

        private ApplianceOperationalState currentOperationalState;

        public void TransitionToState(ApplianceOperationalState state)
        {
            currentOperationalState = state;
            ShowCurrentState();
        }

        public ApplianceContext(string applianceDeploymentID, string applianceType)
        {
            ApplianceDeploymentID = applianceDeploymentID;
            ApplianceType = applianceType;

            // Appliance state defaults to the off state on programme execution
            Console.WriteLine($"Initialise appliance \"{ApplianceDeploymentID}\" to state: Off.");

            TransitionToState(new ApplianceOffState());
        }

        //public void ShowState(string stateName)
        //{
        //    Console.WriteLine($"Current state for \"{ApplianceDeploymentID}\": {stateName}");
        //}

        public void ShowCurrentState()
        {
             Console.WriteLine($"Current state for \"{ApplianceDeploymentID}\": {currentOperationalState.CurrentStateName}");
        }
        public void TurnApplianceOff()
        {
            Console.WriteLine($"Turn appliance \"{ApplianceDeploymentID}\" off.");
            currentOperationalState.TurnOffAppliance(this);
        }

        public void TurnApplianceOn()
        {
            Console.WriteLine($"Turn appliance \"{ApplianceDeploymentID}\" on.");
            currentOperationalState.TurnOnAppliance(this);
        }

        public void StartApplianceProgramme()
        {
            Console.WriteLine($"Start programme for appliance \"{ApplianceDeploymentID}\".");
            currentOperationalState.StartProgramme(this);
        }

        public void StopApplianceProgramme()
        {
            Console.WriteLine($"Stop programme for appliance \"{ApplianceDeploymentID}\".");
            currentOperationalState.StopProgramme(this);
        }
    }
}