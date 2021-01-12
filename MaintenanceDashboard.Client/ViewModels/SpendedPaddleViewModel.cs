using MaintenanceDashboard.Data.Models;
using MaintenanceDashboard.Common;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MaintenanceDashboard.Data.API;
using MaintenanceDashboard.Client.Interfaces;
using MaintenanceDashboard.Client.Views;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class SpendedPaddleViewModel : ViewModel, ISpendedComponent
    {
        private readonly SpendedPaddleContext context;
        private ComponentDetailsViewModel childViewModel;
        public ICollection<SpendedPaddle> SpendedPaddles { get; set; }
        public string BarcodeNumber { get; set; }

        private SpendedPaddle selectedSpenedPaddle;
        public SpendedPaddle SelectedSpendedPaddle
        {
            get { return selectedSpenedPaddle; }
            set 
            { 
                selectedSpenedPaddle = value;
                NotifyPropertyChanged();
            }
        }

        public SpendedPaddleViewModel(SpendedPaddleContext context)
        {
            this.context = context;
            SpendedPaddles = new ObservableCollection<SpendedPaddle>();
            childViewModel = new ComponentDetailsViewModel();
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

        public ActionCommand ShowDetailsCommand
        {
            get
            {
                return new ActionCommand(p => ShowDetails(),
                                         p => SelectedSpendedPaddle != null);
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

        public void ShowDetails()
        {
            ComponentDetailsWindow componentFormInfoControl = new ComponentDetailsWindow()
            {
                DataContext =childViewModel
            };
            childViewModel.SelectedComponent.BarcodeNumber = SelectedSpendedPaddle.Paddle.BarcodeNumber;
            childViewModel.SelectedComponent.ActivityPerformed = SelectedSpendedPaddle.ActivityPerformed;
            childViewModel.SelectedComponent.RepairDate = SelectedSpendedPaddle.RepairDate;
            childViewModel.SelectedComponent.ReceivedDate = SelectedSpendedPaddle.ReceivedDate;
            childViewModel.SelectedComponent.ReceivingEmployee = SelectedSpendedPaddle.ReceivingEmployee;
            childViewModel.SelectedComponent.SpendingEmployee = SelectedSpendedPaddle.SpendingEmployee;
            childViewModel.SelectedComponent.DescriptionIntervention = SelectedSpendedPaddle.DescriptionIntervention;
            childViewModel.SelectedComponent.SerialNumber = "----";
            childViewModel.SelectedComponent.LastLocation = "-----";
            
            componentFormInfoControl.Show();
        }
    }
}
