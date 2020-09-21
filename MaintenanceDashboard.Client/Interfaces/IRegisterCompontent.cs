using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceDashboard.Client.Interfaces
{
    interface IRegisterCompontent
    {
        string BarcodeNumber { get; set; }
        string Comments { get; set; }
        string Model { get; set; }
        string AddedDate { get; set; }
        bool ConnectedSuccessfully { get; set; }

        void Create();
        void Update();
        void GetAll();
    }
}
