using MaintenanceDashboard.Common;
using MaintenanceDashboard.Data.Models;
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
                 .Where(c =>
                 {
                     try
                     {
                         return (DateTime.Now - DateTime.ParseExact(c.LastPreventionDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)).TotalDays > 60;
                     }
                     catch
                     {
                         throw new ArgumentException("Bład rzutowania string na typ Date Time dbo.Paddle, LastPrevention");
                     }
                 })
                 .Any();

                var IsSomeThermostatToWash = context.Thermostats
                    .Where(d => d.CurrentLocation == "Warsztat" && d.CurrentStatus != "Awaria")
                    .ToList()
                    .Where(c =>
                    {

                    try
                    {
                        return (DateTime.Now - DateTime.ParseExact(c.LastWashDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)).TotalDays > 30;
                    }
                    catch
                    {
                        throw new ArgumentException("Bład rzutowania string na typ Date Time dbo.Thermostat, LastWashDate");
                    }
                    })
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
