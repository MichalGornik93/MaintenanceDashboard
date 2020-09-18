using MaintenanceDashboard.Data.Models;
using MaintenanceDashboard.Common;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MaintenanceDashboard.Data.API;
using MaintenanceDashboard.Client.Interfaces;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class SpendedPaddleViewModel : ViewModel, ISpendedComponent
    {
        private readonly SpendedPaddleContext context;
        public ICollection<SpendedPaddle> SpendedPaddles { get; set; }
        public string BarcodeNumber { get; set; }

        public SpendedPaddleViewModel(SpendedPaddleContext context)
        {
            this.context = context;
            SpendedPaddles = new ObservableCollection<SpendedPaddle>();
        }

        public ActionCommand GetFiltredSpendedPaddleListCommand
        {
            get
            {
                return new ActionCommand(p => GetFiltredSpendedList());
            }
        }

        public ActionCommand GetSpendedPaddleListCommand
        {
            get
            {
                return new ActionCommand(p => GetSpendedList());
            }
        }

        public void GetFiltredSpendedList()
        {
            SpendedPaddles.Clear();

            foreach (var item in context.GetFiltredSpendedPaddleList(BarcodeNumber))
                SpendedPaddles.Add(item);
        }

        public void GetSpendedList()
        {
            SpendedPaddles.Clear();

            foreach (var item in context.GetSpendedPaddleList())
                SpendedPaddles.Add(item);
        }
    }
}
