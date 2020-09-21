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

        public ActionCommand GetFiltredListCommand
        {
            get
            {
                return new ActionCommand(p => GetFiltredList());
            }
        }

        public ActionCommand GetAllCommand
        {
            get
            {
                return new ActionCommand(p => GetAll());
            }
        }

        public void GetFiltredList()
        {
            SpendedPaddles.Clear();

            foreach (var item in context.GetFiltredList(BarcodeNumber))
                SpendedPaddles.Add(item);
        }

        public void GetAll()
        {
            SpendedPaddles.Clear();

            foreach (var item in context.GetAll())
                SpendedPaddles.Add(item);
        }
    }
}
