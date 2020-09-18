﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using MaintenanceDashboard.Data.API;
using MaintenanceDashboard.Data.Models;
using MaintenanceDashboard.Common;
using MaintenanceDashbord.Common.Properties;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class ReceivedPaddleViewModel : ViewModel
    {
        private readonly ReceivedPaddleContext context;
        public ICollection<ReceivedPaddle> ReceivedPaddles { get; private set; }
        public string BarcodeNumber { get; set; }
        public string DescriptionIntervention { get; set; }
        public EmployeeViewModel EmployeeViewModel { get; }
        public PaddleViewModel PaddleViewModel { get; }
        public string Comments { get; set; }
        public string IsOrder { get; set; }
        public DateTime ReceivedDate { get; set; } = DateTime.Now;
        public string RepairDate { get; set; } = DateTime.Now.ToString(Resources.DateTimePattern);
        public DateTime PlannedRepairDate { get; set; } = DateTime.Now.AddDays(2);
        public string ActivityPerformed { get; set; }

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
            EmployeeViewModel.GetEmployeeList();
            GetReceivedPaddleList();
        }

        public ActionCommand AcceptancePaddleCommand
        {
            get
            {
                return new ActionCommand(p => AcceptancePaddle(),
                    p => IsValidReceivedPaddle());
            }
        }

        public ActionCommand SpendPaddleCommand
        {
            get
            {
                return new ActionCommand(p => SpendPaddle(),
                    p => IsValidSpendedPaddle());
            }
        }

        protected override string OnValidate(string propertyName)
        {
            if (String.IsNullOrEmpty(BarcodeNumber))
                return "Pole musi być wypełnione";
            else if (!Regex.IsMatch(BarcodeNumber, Resources.PaddleBarcodePattern))
                return "Niepoprawna składnia ciągu {Pal...}";
            else if (context.CheckIfReceivedPaddleExist(BarcodeNumber))
                return "Paletka nie istnieje w bazie danych";
            else if (context.CheckIfIsAccepted(BarcodeNumber))
                return "Paletka jest już przyjęta";
            return base.OnValidate(propertyName);
        }

        private void AcceptancePaddle()
        {
            var receivedPaddle = new ReceivedPaddle
            {
                ReceivingEmployee = String.Format("{0} {1}", EmployeeViewModel.SelectedEmployee.FirstName, EmployeeViewModel.SelectedEmployee.LastName),
                PaddleId = context.CheckForeignKey(BarcodeNumber),
                ReceivedDate = ReceivedDate.ToString(Resources.DateTimePattern),
                ActivityPerformed = ActivityPerformed,
                PlannedRepairDate = PlannedRepairDate.ToString(Resources.DateTimePattern),
                Comments = Comments,
                IsOrders = IsOrder.ToString()
            };
            context.CreateReceivedPaddle(receivedPaddle);
            ConnectedSuccessfully = true;
        }

        public void SpendPaddle()
        {
            var spendedPaddle = new SpendedPaddle
            {
                PaddleId = SelectedReceivedPaddle.PaddleId,
                ReceivedDate = SelectedReceivedPaddle.ReceivedDate,
                ActivityPerformed = SelectedReceivedPaddle.ActivityPerformed,
                RepairDate = RepairDate,
                Comments = SelectedReceivedPaddle.Comments,
                IsOrders = SelectedReceivedPaddle.IsOrders,
                DescriptionIntervention = DescriptionIntervention,
                ReceivingEmployee = SelectedReceivedPaddle.ReceivingEmployee,
                SpendingEmployee = String.Format("{0} {1}", EmployeeViewModel.SelectedEmployee.FirstName, EmployeeViewModel.SelectedEmployee.LastName)
            };
            context.CreateSpendedPaddle(spendedPaddle);
            context.UpdateLastPreventionDate(SelectedReceivedPaddle);

            if (SelectedReceivedPaddle != null)
            {
                context.DeleteReceivedPaddle(SelectedReceivedPaddle);
                ReceivedPaddles.Remove(SelectedReceivedPaddle);
                SelectedReceivedPaddle = null;
            }
            ConnectedSuccessfully = true;
        }

        public void GetReceivedPaddleList()
        {
            ReceivedPaddles.Clear();

            foreach (var item in context.GetReceivedPaddleList())
                ReceivedPaddles.Add(item);
        }

        private bool IsValidReceivedPaddle()
        {
            if (OnValidate(BarcodeNumber) == null
                && EmployeeViewModel.SelectedEmployee != null
                && PlannedRepairDate != null
                && ReceivedDate != null
                && IsOrder != null
                && ActivityPerformed != null)
                return true;
            return false;
        }

        private bool IsValidSpendedPaddle()
        {
            if (SelectedReceivedPaddle != null
                && !String.IsNullOrWhiteSpace(DescriptionIntervention)
                && EmployeeViewModel.SelectedEmployee != null)
                return true;
            return false;

        }
    }
}
