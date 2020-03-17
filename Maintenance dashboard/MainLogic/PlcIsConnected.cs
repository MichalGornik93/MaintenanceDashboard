using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maintenance_dashboard
{
    class PlcIsConnected
    {
        public bool OnPlcConnected(object source, EventArgs args)
        {
            return true;
        }
    }
}
