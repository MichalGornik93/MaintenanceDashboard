using MaintenanceDashboard.Common;
using MaintenanceDashboard.Common.Properties;
using System;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class SettingsViewModel:ViewModel
    {
        public int RobotToolInspectionInterval { get; set; } 
        public int PaddleInspectionInterval { get; set; }
        public int ThermostatWashInterval { get; set; }

        public SettingsViewModel()
        {
            PaddleInspectionInterval = Settings.Default.PaddleInspectionInterval;
            RobotToolInspectionInterval = Settings.Default.RobotToolInspectionInterval;
            ThermostatWashInterval = Settings.Default.ThermostatWashInterval;
        }
        public ActionCommand ChangeSettingsCommand
        {
            get
            {
                return new ActionCommand(p => ChangeSettings());
            }
        }

        private void ChangeSettings()
        {
            Settings.Default.PaddleInspectionInterval = PaddleInspectionInterval;
            Settings.Default.RobotToolInspectionInterval = RobotToolInspectionInterval;
            Settings.Default.ThermostatWashInterval = ThermostatWashInterval;
        }
    }
}
