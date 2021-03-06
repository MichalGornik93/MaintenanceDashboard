﻿using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.API;
using System.Windows.Controls;
using System.Windows.Input;

namespace MaintenanceDashboard.Client.Views
{
    public partial class AcceptanceThermostatControl : UserControl
    {
        public AcceptanceThermostatControl()
        {
            this.DataContext = new ReceivedThermostatViewModel(new ReceivedThermostatContext());
            InitializeComponent();
        }

        private void btnRefreash_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.DataContext = new ReceivedThermostatViewModel(new ReceivedThermostatContext());
            InitializeComponent();
        }
    }
}
