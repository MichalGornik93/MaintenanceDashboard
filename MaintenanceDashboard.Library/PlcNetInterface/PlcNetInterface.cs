using System.Timers;
using Sharp7;

namespace MaintenanceDashboard.Library
{
    public class PlcNetInterface //:IPlcNetLibrariesBaseInterface
    {
        private const int _plsTellMeWhatDoesItMean = 2;
        
        private readonly S7Client _s7Plc;
        
        private readonly Timer _dataReadTimer;
        
        private byte[] _inBuffer = new byte[_plsTellMeWhatDoesItMean];
        
        public PlcNetInterface(string ipAddress, int rack, int slot)
        {
            IpAddress = ipAddress;
            Rack = rack;
            Slot = slot;
            _s7Plc = new S7Client();
        }
        
        public string IpAddress { get; set; }
        
        public int Rack { get; set; }
        
        public int Slot { get; set; }
        
        public string PlcLastErrorMessage { get; set; }

        public delegate void ConnectedEventHendler();
        public event ConnectedEventHendler Connected;

        public delegate void DisconnectEventHendler();
        public event DisconnectEventHendler Disconected;


        public void Connect()
        {
            var connectionResult = _s7Plc.ConnectTo(IpAddress, Rack, Slot);
            PlcLastErrorMessage = _s7Plc.ErrorText(connectionResult);

            if (connectionResult > 0)
                OnIsDisonnected();
            else
                OnIsConnected();
        }

        protected virtual void OnIsConnected() => Connected?.Invoke();
        
        protected virtual void OnIsDisonnected() => Disconected?.Invoke();
    }
}
