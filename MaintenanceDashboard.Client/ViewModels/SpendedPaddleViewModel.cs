using MaintenanceDashboard.Data.API;
using MaintenanceDashboard.Data.Domain;
using MaintenanceDashboard.Library;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MaintenanceDashboard.Data.Interfaces;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class SpendedPaddleViewModel: ViewModel
    {
        private readonly ISpendedPaddleContext context;

        public ICollection<SpendedPaddle> SpendedPaddles { get; set; }

        public SpendedPaddleViewModel(ISpendedPaddleContext context)
        {
            this.context = context;

            SpendedPaddles = new ObservableCollection<SpendedPaddle>();
        }
    }
}
