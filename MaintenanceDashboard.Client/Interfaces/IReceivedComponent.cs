using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceDashboard.Client.Interfaces
{
    interface IReceivedComponent
    {
        string BarcodeNumber { get; set; }
        string DescriptionIntervention { get; set; }
        string Comments { get; set; }
        string IsOrder { get; set; }
        string RepairDate { get; set; }
        string ActivityPerformed { get; set; }
        DateTime ReceivedDate { get; set; }
        DateTime PlannedRepairDate { get; set; }
        bool ConnectedSuccessfully { get; set; }

        void Acceptance();
        void Spend();
        void GetList();
    }
}
