﻿using MaintenanceDashboard.Data.API;
using MaintenanceDashboard.Data.Models;
using MaintenanceDashboard.Common.PlcService;
using System;
using System.Threading;

namespace MaintenanceDashboard.Client.Infrastructure
{
    public class SmartWorkshopPlc
    {
        SmartWorkshopPlcHelper _smartWorkshopPlcHelper;
        private readonly RetrievedEquipmentContext context;
        public SmartWorkshopPlc()
        {
            _smartWorkshopPlcHelper = new SmartWorkshopPlcHelper();
            _smartWorkshopPlcHelper.Connect("192.168.1.1", 0, 0);
            context = new RetrievedEquipmentContext();

            OnPlcValuesRefreshed(null, null);
            _smartWorkshopPlcHelper.ValuesRefreshed += OnPlcValuesRefreshed;
        }


        private void OnPlcValuesRefreshed(object sender, EventArgs e)
        {
            var retrievedEquipment = new RetrievedEquipment
            {
                Name = _smartWorkshopPlcHelper.Name,
                Employee = _smartWorkshopPlcHelper.Employee,
                Action = _smartWorkshopPlcHelper.Action,
                Date = DateTime.Now
            };

            if (_smartWorkshopPlcHelper.SendTrigger == true)
            {
                _smartWorkshopPlcHelper.DbWrite();
                context.Create(retrievedEquipment);
            }
        }
    }
}
