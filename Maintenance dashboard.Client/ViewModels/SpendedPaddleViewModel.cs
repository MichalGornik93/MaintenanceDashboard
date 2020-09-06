using MaintenanceDashboard.Data.API;
using MaintenanceDashboard.Data.Domain;
using MaintenanceDashboard.Library;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class SpendedPaddleViewModel : ViewModel
    {
        private readonly ISpendedPaddleContext context;

        public ICollection<SpendedPaddle> SpendedPaddles { get; set; }

        public string PaddleNumber { get; set; }
        public string ActivitiesPerformed { get; set; }


        public SpendedPaddleViewModel(ISpendedPaddleContext context)
        {
            this.context = context;
            SpendedPaddles = new ObservableCollection<SpendedPaddle>();
        }

        public ActionCommand GetFiltredSpendedPaddleListCommand
        {
            get
            {
                return new ActionCommand(p => GetFiltredSpendedPaddleList());
            }
        }

        public ActionCommand GetSpendedPaddleListCommand
        {
            get
            {
                return new ActionCommand(p => GetSpendedPaddleList());
            }
        }

        private void GetFiltredSpendedPaddleList()
        {
            SpendedPaddles.Clear();

            foreach (var item in context.GetFiltredSpendedPaddleList(PaddleNumber))
                SpendedPaddles.Add(item);
        }

        public void GetSpendedPaddleList()
        {
            SpendedPaddles.Clear();

            foreach (var item in context.GetSpendedPaddleList())
                SpendedPaddles.Add(item);
        }
    }
}
