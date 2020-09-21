using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceDashboard.Client.Interfaces
{
    interface ISpendedComponent
    {
        string BarcodeNumber { get; set; }
        void GetFiltredList();
        void GetAll();
    }
}
