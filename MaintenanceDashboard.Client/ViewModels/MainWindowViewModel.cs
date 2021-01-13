using MaintenanceDashboard.Common;
using MaintenanceDashboard.Data;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Threading;

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
                 .Where(c=> (DateTime.Now- c.LastPreventionDate).TotalDays > 60)
                 .Any();

                var IsSomeThermostatToWash = context.Thermostats
                    .ToList()
                    .Where(d => d.CurrentLocation == "Warsztat" && d.CurrentStatus != "Awaria")
                    .Where(c => (DateTime.Now - c.LastWashDate).TotalDays > 30)
                   .Any();

                if (IsSomePaddleToReview || IsSomeThermostatToWash)
                {
                    BlinkingPreventionControlItem = true;
                }
                else
                    BlinkingPreventionControlItem = false;
            }
        }
    }
}
