using MaintenanceDashboard.Common;
using MaintenanceDashboard.Common.PlcService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class EquipmentAuditViewModel : ViewModel
    {
        SmartWorkshopPlcHelper _smartWorkshopPlcHelper;
        public ICollection<Object> RegisterEquipments { get; set; }
        public EquipmentAuditViewModel()
        {
            _smartWorkshopPlcHelper = new SmartWorkshopPlcHelper();
            _smartWorkshopPlcHelper.Connect("192.168.1.1", 0, 0);

            RegisterEquipments = new ObservableCollection<Object>();

            foreach (var item in _smartWorkshopPlcHelper.GetRegisterEquipment())
            {
                    RegisterEquipments.Add(item);
            }
        }
    }
}
