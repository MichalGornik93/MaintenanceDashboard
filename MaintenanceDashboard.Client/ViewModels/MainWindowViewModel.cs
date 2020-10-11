﻿using MaintenanceDashboard.Common;
using MaintenanceDashboard.Data.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Threading;

namespace MaintenanceDashboard.Client.ViewModels
{
    class MainWindowViewModel:ViewModel
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
            IsAnyPreventionToDo();
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
                    .Where(c => (DateTime.Now - DateTime.ParseExact(c.LastPrevention, "yyyy-MM-dd", CultureInfo.InvariantCulture)).TotalDays > 60)
                    .Any();

                var IsSomeThermostatToWash = context.Thermostats
                    .Where(d=>d.CurrentLocation == "Warsztat")
                    .ToList()
                    .Where(c => (DateTime.Now - DateTime.ParseExact(c.LastWashDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)).TotalDays > 30)
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
