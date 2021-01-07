using MaintenanceDashboard.Data.API;
using MaintenanceDashboard.Data.Models;
using System;

namespace MaintenanceDashboard.Common.PlcService
{
    public class eCmmsPlc
    {
        S7PlcHelper _s7PlcHelper;
        private readonly RetrievedEquipmentContext context;
        public eCmmsPlc()
        {
            _s7PlcHelper = new S7PlcHelper();
            _s7PlcHelper.Connect("192.168.1.1", 0, 0);
            context = new RetrievedEquipmentContext();

            OnPlcValuesRefreshed(null, null);
            _s7PlcHelper.ValuesRefreshed += OnPlcValuesRefreshed;
        }


        private void OnPlcValuesRefreshed(object sender, EventArgs e)
        {
            var retrievedEquipment = new RetrievedEquipment
            {
                Name = _s7PlcHelper.EmployeeName,
                Employee = _s7PlcHelper.GettingEquipment,
                Action = _s7PlcHelper.Action,
                Date = DateTime.Now
            };

            if (_s7PlcHelper.Req == true)
            {
                context.Create(retrievedEquipment);
            }
        }
    }
}
