using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Sharp7;
using System.ComponentModel;

namespace Maintenance_dashboard
{
    class PlcConnection //:IPlcNetLibrariesBaseInterface
    {
        public string IpAddress { get; set; }
        public int Rack { get; set; }
        public int Slot { get; set; }
        public string PlcLastErrorMessage { get; set; }

        private readonly S7Client _s7Plc;

        private byte[] _inBuffer = new byte[2];
        //Nadawca 
        public event EventHandler ConnectedHandler;
        public event EventHandler ErrorHandler;
        public event EventHandler DisonnectedHandler;
        

        public PlcConnection(string ipAddress, int rack, int slot)
        {
            IpAddress = ipAddress;
            Rack = rack;
            Slot = slot;
            _s7Plc = new S7Client();
        }

        public bool Connect()
        {
            var IsConnect = false;

            var result = _s7Plc.ConnectTo(IpAddress, Rack, Slot);
            PlcLastErrorMessage = _s7Plc.ErrorText(result);
            
            if (result > 0)
            IsConnect = false;
            else 
            IsConnect = true;
            MainWindow.
           return IsConnect;
        }

        protected virtual bool OnIsConnected()
        {
            if (ConnectedHandler != null)
                ConnectedHandler(this, new EventArgs());
            return false;
        }

        public bool Disconnect()
        {
            throw new NotImplementedException();
        }

        public void RaiseInDisonnected()
        {
            throw new NotImplementedException();
        }

        public void RaiseIsConnected()
        {
            throw new NotImplementedException();
        }

        public void RaiseError()
        {
            throw new NotImplementedException();
        }
    }
}
