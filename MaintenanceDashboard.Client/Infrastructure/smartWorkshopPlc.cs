using MaintenanceDashboard.Data.API;
using MaintenanceDashboard.Data.Models;
using MaintenanceDashboard.Common.PlcService;
using System;

namespace MaintenanceDashboard.Client.Infrastructure
{
    public class smartWorkshopPlc
    {
        smartWorkshopPlcHelper _smartWorkshopPlcHelper;
        private readonly RetrievedEquipmentContext context;
        public smartWorkshopPlc()
        {
            _smartWorkshopPlcHelper = new smartWorkshopPlcHelper();
            _smartWorkshopPlcHelper.Connect("192.168.1.1", 0, 0);
            context = new RetrievedEquipmentContext();

            OnPlcValuesRefreshed(null, null);
            _smartWorkshopPlcHelper.ValuesRefreshed += OnPlcValuesRefreshed;
        }


        private void OnPlcValuesRefreshed(object sender, EventArgs e)
        {
            var retrievedEquipment = new RetrievedEquipment
            {
                Name = _smartWorkshopPlcHelper.Employee,
                Employee = _smartWorkshopPlcHelper.Name,
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
