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
    class PlcNetInterface //:IPlcNetLibrariesBaseInterface
    {
        public string IpAddress { get; set; }
        public int Rack { get; set; }
        public int Slot { get; set; }
        public string PlcLastErrorMessage { get; set; }
        public bool StatusPolaczeniaPole;

        private readonly S7Client _s7Plc;
        private readonly Timer _dataReadTimer;
        private readonly object _lockObject = new object();

        private byte[] _inBuffer = new byte[2];

        public delegate void ConnectedEventHendler();
        public event ConnectedEventHendler Connected;

        public delegate void DisconnectEventHendler();
        public event DisconnectEventHendler Disconected;

        public PlcNetInterface(string ipAddress, int rack, int slot)
        {
            IpAddress = ipAddress;
            Rack = rack;
            Slot = slot;
            _s7Plc = new S7Client();

            _dataReadTimer = new Timer(100);
            _dataReadTimer.Elapsed += StatusPolaczeniaMetoda;
            _dataReadTimer.Start();
        }

        public void Connect()
        {
            var connectionResult = _s7Plc.ConnectTo(IpAddress, Rack, Slot);
            PlcLastErrorMessage = _s7Plc.ErrorText(connectionResult);

            if (connectionResult > 0)
                OnIsDisonnected();
            else
                OnIsConnected();
        }

        protected virtual void OnIsConnected()
        {
            if (Connected != null)
                Connected();
        }
        protected virtual void OnIsDisonnected()
        {
            if (Disconected != null)
                Disconected();
        }
        private void StatusPolaczeniaMetoda(Object source, System.Timers.ElapsedEventArgs e)
        {
            StatusPolaczeniaPole = _s7Plc.Connected;
        }

    }
}
