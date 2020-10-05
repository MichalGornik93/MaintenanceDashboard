using MaintenanceDashboard.Common;
using MaintenanceDashboard.Data.API;
using System.Collections.ObjectModel;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class AlarmsViewModel : ViewModel
    {
        private readonly AlarmsContext context;
        public ObservableCollection<string> Alarms { get; set; }
           
        public AlarmsViewModel(AlarmsContext context)
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

        }
    }
}
