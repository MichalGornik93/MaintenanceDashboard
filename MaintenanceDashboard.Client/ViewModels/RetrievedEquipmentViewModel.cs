﻿using MaintenanceDashboard.Common;
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
        public string Employee { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Action { get; set; }
        private bool _connectedSuccessfully;
        public bool ConnectedSuccessfully
        {
            get { return _connectedSuccessfully; }
            set
            {
                _connectedSuccessfully = value;
                NotifyPropertyChanged();
            }
        }
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

        public ActionCommand RetriveCommand
        {
            get
            {
                return new ActionCommand(p => Retrive(),
                   p=> IsValidEquipment);
            }
        }
        public void Retrive()
        {
            var retrievedEquipment = new RetrievedEquipment
            {
                Name = Name,
                Employee = Employee,
                Action = Action,
                Date = Date
            };

            context.Create(retrievedEquipment);
            ConnectedSuccessfully = true;

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

        public bool IsValidEquipment
        {
            get
            {
                return (!String.IsNullOrWhiteSpace(Name) && !String.IsNullOrWhiteSpace(Action) &&
                !String.IsNullOrWhiteSpace(Employee));
            }
        }
    }
}
