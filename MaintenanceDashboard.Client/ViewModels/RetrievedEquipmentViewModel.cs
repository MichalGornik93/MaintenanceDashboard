using MaintenanceDashboard.Common;
using MaintenanceDashboard.Data.API;
using MaintenanceDashboard.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MaintenanceDashboard.Client.ViewModels
{
    class RetrievedEquipmentViewModel : ViewModel
    {
        private readonly RetrievedEquipmentContext context;
        public ICollection<RetrievedEquipment> RetrievedEquipments { get; private set; }
        public string Name { get; set; }

        public RetrievedEquipmentViewModel(RetrievedEquipmentContext context)
        {
            this.context = context;
            RetrievedEquipments = new ObservableCollection<RetrievedEquipment>();
        }

        public ActionCommand GetAllCommand
        {
            get
            {
                return new ActionCommand(p => GetAll());
            }
        }
        public ActionCommand GetFiltredListCommand
        {
            get
            {
                return new ActionCommand(p => GetFiltredList());
            }
        }

        public void GetAll()
        {
            RetrievedEquipments.Clear();

            foreach (var item in context.GetAll())
                RetrievedEquipments.Add(item);
        }
        public void GetFiltredList()
        {
            RetrievedEquipments.Clear();

            foreach (var item in context.GetFiltredList(Name))
                RetrievedEquipments.Add(item);
        }

    }
}
