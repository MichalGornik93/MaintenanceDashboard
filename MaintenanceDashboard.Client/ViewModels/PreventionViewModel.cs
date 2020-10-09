using MaintenanceDashboard.Common;
using MaintenanceDashboard.Data.API;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class PreventionViewModel : ViewModel
    {
        private readonly PreventionContext context;
        public ObservableCollection<string> Alarms { get; set; }
           
        public PreventionViewModel(PreventionContext context)
        {
            this.context = context;
            Alarms = new ObservableCollection<string>();
            GetReviewPaddles();
        }

        private void GetReviewPaddles()
        {
            Alarms.Clear();

            foreach (var item in context.GetReviewPaddles())
            {
                Alarms.Add("Wykonać przegląd: "+item.BarcodeNumber);
            }

            foreach (var item in context.GetToWashThermostat())
            {
                Alarms.Add("Wykonać płukanie: " + item.BarcodeNumber);
            }

        }
    }
}
