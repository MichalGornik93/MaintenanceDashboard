using MaintenanceDashboard.Common;
using MaintenanceDashboard.Data;
using System;
using System.Linq;
using System.Windows.Threading;
using MaintenanceDashboard.Common.Properties;


namespace MaintenanceDashboard.Client.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private bool blinkingPreventionControlItem;
        public bool BlinkingPreventionControlItem
        {
            get { return blinkingPreventionControlItem; }
            set
            {
                blinkingPreventionControlItem = value;
                NotifyPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(30);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            IsAnyPreventionToDo();
        }

        private void IsAnyPreventionToDo()
        {
            using (var context = new DataContext())
            {
                var IsSomePaddleToReview = context.Paddles
                 .ToList()
                 .Where(c=> (DateTime.Now- c.LastPreventionDate).TotalDays > Settings.Default.PaddleInspectionInterval)
                 .Any();

                var IsSomeThermostatToWash = context.Thermostats
                    .ToList()
                    .Where(d => d.CurrentLocation == "Warsztat" && d.CurrentStatus != "Awaria")
                    .Where(c => (DateTime.Now - c.LastWashDate).TotalDays > Settings.Default.ThermostatWashInterval)
                   .Any();

                var IsSomeRobotToolsToReview = context.SpendedRobotTools
                .ToList()
                .Where(d => (DateTime.Now - d.Date).TotalDays > Settings.Default.RobotToolInspectionInterval)
                .GroupBy(c => c.Number)
                .Select(x => x.FirstOrDefault())
                .Any();

                if (IsSomePaddleToReview || IsSomeThermostatToWash || IsSomeRobotToolsToReview)
                {
                    BlinkingPreventionControlItem = true;
                }
                else
                    BlinkingPreventionControlItem = false;
            }
        }
    }
}
