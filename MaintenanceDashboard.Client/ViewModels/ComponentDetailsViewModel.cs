using MaintenanceDashboard.Common;
using MaintenanceDashboard.Data;
using System;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class ComponentDetailsViewModel:ViewModel
    {
        public SelectedComponent SelectedComponent { get; set; }

        public string Date { get; set; } = DateTime.Now.ToString();

        public ComponentDetailsViewModel()
        {
            SelectedComponent = new SelectedComponent();
        }

    }
}
