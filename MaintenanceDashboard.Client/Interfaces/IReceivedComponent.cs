using System;

namespace MaintenanceDashboard.Client.Interfaces
{
    interface IReceivedComponent
    {
        string BarcodeNumber { get; set; }
        DateTime RepairDate { get; set; }
        string ActivityPerformed { get; set; }
        string DescriptionIntervention { get; set; }
        DateTime ReceivedDate { get; set; }
        bool ConnectedSuccessfully { get; set; }

        void Receive();
        void Spend();
        void GetAll();
    }
}
