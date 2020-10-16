using MaintenanceDashboard.Common;
using MaintenanceDashboard.Data;
using System;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class ComponentFormInfoViewModel:ViewModel
    {
        public SelectedComponent SelectedComponent { get; set; }

        public string Date { get; set; } = DateTime.Now.ToString();

        public ComponentFormInfoViewModel()
        {
            SelectedComponent = new SelectedComponent();
        }


    }
}
