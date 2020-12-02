using MaintenanceDashboard.Client.Interfaces;
using MaintenanceDashboard.Client.Views;
using MaintenanceDashboard.Common;
using MaintenanceDashboard.Data.API;
using MaintenanceDashboard.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class SpendedThermostatViewModel : ViewModel, ISpendedComponent
    {
        private readonly SpendedThermostatContext context;
        private ComponentDetailsViewModel childViewModel;
        public ICollection<SpendedThermostat> SpendedThermostats { get; set; }
        public string BarcodeNumber { get; set; }

        private SpendedThermostat selectedSpendedThermostat;
        public SpendedThermostat SelectedSpendedThermostat
        {
            get { return selectedSpendedThermostat; }
            set { selectedSpendedThermostat = value; }
        }


        public SpendedThermostatViewModel(SpendedThermostatContext context)
        {
            this.context = context;
            SpendedThermostats = new ObservableCollection<SpendedThermostat>();
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
                                         p => SelectedSpendedThermostat != null);
            }
        }

        public void GetFiltredList()
        {
            SpendedThermostats.Clear();

            foreach (var item in context.GetFiltredList(BarcodeNumber))
                SpendedThermostats.Add(item);
        }

        public void GetAll()
        {
            SpendedThermostats.Clear();

            foreach (var item in context.GetAll())
                SpendedThermostats.Add(item);
        }

        public void ShowDetails()
        {
            ComponentDetailsWindow componentFormInfoControl = new ComponentDetailsWindow()
            {
                DataContext = childViewModel
            };
            childViewModel.SelectedComponent.BarcodeNumber = SelectedSpendedThermostat.Thermostat.BarcodeNumber;
            childViewModel.SelectedComponent.ActivityPerformed = SelectedSpendedThermostat.ActivityPerformed;
            childViewModel.SelectedComponent.RepairDate = SelectedSpendedThermostat.RepairDate;
            childViewModel.SelectedComponent.ReceivedDate = SelectedSpendedThermostat.ReceivedDate;
            childViewModel.SelectedComponent.DescriptionIntervention = SelectedSpendedThermostat.DescriptionIntervention;
            childViewModel.SelectedComponent.ReceivingEmployee = SelectedSpendedThermostat.ReceivingEmployee;
            childViewModel.SelectedComponent.SpendingEmployee = SelectedSpendedThermostat.SpendingEmployee;
            childViewModel.SelectedComponent.DescriptionIntervention = SelectedSpendedThermostat.DescriptionIntervention;
            childViewModel.SelectedComponent.SerialNumber = SelectedSpendedThermostat.Thermostat.SerialNumber;
            childViewModel.SelectedComponent.LastLocation = SelectedSpendedThermostat.LastLocation;

            componentFormInfoControl.Show();
        }
    }
}
