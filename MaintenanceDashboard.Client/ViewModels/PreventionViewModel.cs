using MaintenanceDashboard.Common;
using MaintenanceDashboard.Data.API;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class PreventionViewModel : ViewModel
    {
        private readonly PreventionContext context;
        public ObservableCollection<PreventionPattern> Preventions { get; set; }
           
        public PreventionViewModel(PreventionContext context)
        {
            this.context = context;
            Preventions = new ObservableCollection<PreventionPattern>();
            GetReviewPaddles();
        }

        private void GetReviewPaddles()
        {
            Preventions.Clear();

            foreach (var item in context.GetReviewPaddles())
            {
                Preventions.Add(new PreventionPattern()
                {
                    BarcodeNumber = item.BarcodeNumber,
                    LastPrevention = item.LastPrevention,
                    Model = item.Model,
                    PreventionDescription = "Przegląd paletki"
                });
                    
            }

            foreach (var item in context.GetToWashThermostat())
            {
                Preventions.Add(new PreventionPattern()
                {
                    BarcodeNumber = item.BarcodeNumber,
                    LastPrevention = item.LastWashDate,
                    SerialNumber =item.SerialNumber,
                    Model = item.Model,
                    PreventionDescription = "Płukanie termostatu"
                });

            }

        }
    }

    public class PreventionPattern
    {
        public string BarcodeNumber { get; set; }
        public string SerialNumber { get; set; }
        public string PreventionDescription { get; set; }
        public string LastPrevention { get; set; }
        public string Model { get; set; }
    }
}
