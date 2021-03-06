﻿using System;

namespace MaintenanceDashboard.Data
{
    public class SelectedComponent
    {
        public string BarcodeNumber { get; set; }
        public string SerialNumber { get; set; }
        public string ActivityPerformed { get; set; }
        public DateTime RepairDate { get; set; }
        public string Comments { get; set; }
        public string DescriptionIntervention { get; set; }
        public string ReceivingEmployee { get; set; }
        public string SpendingEmployee { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string LastLocation { get; set; }
    }
}
