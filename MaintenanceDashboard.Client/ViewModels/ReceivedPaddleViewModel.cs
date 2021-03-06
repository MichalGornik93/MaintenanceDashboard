﻿ using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using MaintenanceDashboard.Data.API;
using MaintenanceDashboard.Data.Models;
using MaintenanceDashboard.Common;
using MaintenanceDashboard.Client.Interfaces;
using MaintenanceDashboard.Common.Properties;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class ReceivedPaddleViewModel : ViewModel, IReceivedComponent
    {
        private readonly ReceivedPaddleContext context;
        public ICollection<ReceivedPaddle> ReceivedPaddles { get; private set; }
        public EmployeeViewModel EmployeeViewModel { get; }
        public PaddleViewModel PaddleViewModel { get; }

        public string BarcodeNumber { get; set; }
        public string DescriptionIntervention { get; set; }
        public DateTime RepairDate { get; set; } = DateTime.Now;
        public string ActivityPerformed { get; set; }
        public DateTime ReceivedDate { get; set; } = DateTime.Now;

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

        private ReceivedPaddle _selectedReceivedPaddle;
        public ReceivedPaddle SelectedReceivedPaddle
        {
            get { return _selectedReceivedPaddle; }
            set
            {
                _selectedReceivedPaddle = value;
                NotifyPropertyChanged();
            }
        }

        public ReceivedPaddleViewModel(ReceivedPaddleContext context)
        {
            this.context = context;
            ReceivedPaddles = new ObservableCollection<ReceivedPaddle>();

            EmployeeViewModel = new EmployeeViewModel(new EmployeeContext());
            PaddleViewModel = new PaddleViewModel(new PaddleContext());
            
            EmployeeViewModel.GetAll();
            GetAll();

        }

        public ActionCommand ReceiveCommand
        {
            get
            {
                return new ActionCommand(p => Receive(),
                    p => IsValidReceivedPaddle());
            }
        }

        public ActionCommand SpendCommand
        {
            get
            {
                return new ActionCommand(p => Spend(),
                    p => IsValidSpendedPaddle());
            }
        }

      
        public void Receive()
        {
            var receivedPaddle = new ReceivedPaddle
            {
                ReceivingEmployee = String.Format("{0} {1}", EmployeeViewModel.SelectedEmployee.FirstName, EmployeeViewModel.SelectedEmployee.LastName),
                PaddleId = context.GetId(BarcodeNumber),
                ReceivedDate = ReceivedDate,
                ActivityPerformed = ActivityPerformed,
                DescriptionIntervention = DescriptionIntervention
            };
            context.Receive(receivedPaddle);
            ConnectedSuccessfully = true;
        }

        public void Spend()
        {
            var spendedPaddle = new SpendedPaddle
            {
                PaddleId = SelectedReceivedPaddle.PaddleId,
                ReceivedDate = SelectedReceivedPaddle.ReceivedDate,
                ActivityPerformed = SelectedReceivedPaddle.ActivityPerformed,
                RepairDate = RepairDate,
                DescriptionIntervention = SelectedReceivedPaddle.DescriptionIntervention,
                ReceivingEmployee = SelectedReceivedPaddle.ReceivingEmployee,
                SpendingEmployee = String.Format("{0} {1}", EmployeeViewModel.SelectedEmployee.FirstName, EmployeeViewModel.SelectedEmployee.LastName)
            };
            context.Spend(spendedPaddle);
            context.SetLastPreventionDate(SelectedReceivedPaddle);

            if (SelectedReceivedPaddle != null)
            {
                context.Remove(SelectedReceivedPaddle);
                ReceivedPaddles.Remove(SelectedReceivedPaddle);
                SelectedReceivedPaddle = null;
            }
            ConnectedSuccessfully = true;
        }

        public void GetAll()
        {
            ReceivedPaddles.Clear();

            foreach (var item in context.GetAll())
                ReceivedPaddles.Add(item);
        }


        protected override string OnValidate(string propertyName)
        {
            if (String.IsNullOrEmpty(BarcodeNumber))
                return "Pole musi być wypełnione";
            else if (!Regex.IsMatch(BarcodeNumber, Resources.PaddleBarcodePattern))
                return "Niepoprawna składnia ciągu {Pal...}";
            else if (context.IsExistInDb(BarcodeNumber))
                return "Paletka nie istnieje w bazie danych";
            else if (context.IsAccepted(BarcodeNumber))
                return "Paletka jest już przyjęta";
            return base.OnValidate(propertyName);
        }


        private bool IsValidReceivedPaddle()
        {
            if (OnValidate(BarcodeNumber) == null
                && EmployeeViewModel.SelectedEmployee != null
                && ReceivedDate != null
                && ActivityPerformed != null)
                return true;
            return false;
        }

        private bool IsValidSpendedPaddle()
        {
            if (SelectedReceivedPaddle != null
                && EmployeeViewModel.SelectedEmployee != null
                && !String.IsNullOrWhiteSpace(SelectedReceivedPaddle.DescriptionIntervention))
                return true;
            return false;

        }

    }
}
