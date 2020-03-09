using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Sharp7;

namespace Maintenance_dashboard
{
    class PlcConnection:IPlcNetLibrariesBaseInterface
    {
        public string IpAddress { get; set; }
        public int Rack { get; set; }
        public int Slot { get; set; }
        public string PlcLastErrorMessage { get; set; }

        private readonly Timer _dataReadTimer;
        private readonly S7Client _s7Plc;
        private readonly object _lockObject = new object();
        private int _currentReadValue = 0;

        private byte[] _inBuffer = new byte[2];

        public event EventHandler DataReadHandler;
        public event EventHandler ConnectedHandler;
        public event EventHandler DisconnectedHandler;
        public event EventHandler ErrorHandler;

        public PlcConnection(string ipAddress, int rack, int slot)
        {
            IpAddress = ipAddress;
            Rack = rack;
            Slot = slot;

            _s7Plc = new S7Client();


            _dataReadTimer = new Timer(500);
            _dataReadTimer.Elapsed += _dataReadTimer_Elapsed;
            _dataReadTimer.Start();
        }

        private void _dataReadTimer_Elapsed(object sender, ElapsedEventArgs e)
        {

            if (!_s7Plc.Connected)
            {
                RaiseIsDisconnected();
                return;
            }

            // Do the read
            lock (_lockObject)
            {
                var readResult = _s7Plc.DBRead(10, 4, 2, _inBuffer);
                if (readResult > 0)
                {
                    PlcLastErrorMessage = _s7Plc.ErrorText(readResult);
                    RaiseError();
                }

                _currentReadValue = S7.GetIntAt(_inBuffer, 0);
            }

            RaiseDataReaded();
        }

        public void RaiseDataReaded()
        {
            DataReadHandler?.Invoke(this, new EventArgs());
        }

        public void RaiseIsConnected()
        {
            ConnectedHandler?.Invoke(this, new EventArgs());
        }

        public void RaiseIsDisconnected()
        {
            DisconnectedHandler?.Invoke(this, new EventArgs());
        }

        public void RaiseError()
        {
            ErrorHandler?.Invoke(this, new EventArgs());
        }

        public bool Connect()
        {
            var result = _s7Plc.ConnectTo(IpAddress, Rack, Slot);
            PlcLastErrorMessage = _s7Plc.ErrorText(result);

            if (result > 0) RaiseError();
            else RaiseIsConnected();

            _dataReadTimer.Start();

            return result == 0;
        }

        private bool IsPlcConnected()
        {
            if (_s7Plc.Connected) return true;

            PlcLastErrorMessage = "PLC not connected";
            RaiseError();
            RaiseIsDisconnected();

            return false;
        }

        public bool Disconnect()
        {
            if (!IsPlcConnected()) return false;

            _dataReadTimer.Stop();
            _s7Plc.Disconnect();

            RaiseIsDisconnected();
            return true;
        }

        private bool WriteBit(int db, int bytePos, int bitInByte, bool value)
        {
            var inBuff = new byte[1];
            var writeResult = -1;

            lock (_lockObject)
            {
                var readResult = _s7Plc.DBRead(db, bytePos, 1, inBuff);
                if (readResult > 0)
                {
                    PlcLastErrorMessage = _s7Plc.ErrorText(readResult);
                    RaiseError();
                    return false;
                }

                S7.SetBitAt(ref inBuff, 0, bitInByte, value);

                writeResult = _s7Plc.DBWrite(db, bytePos, 1, inBuff);
                if (readResult > 0)
                {
                    PlcLastErrorMessage = _s7Plc.ErrorText(writeResult);
                    RaiseError();
                }
            }

            return writeResult == 0;
        }

        public bool SetStart()
        {
            return WriteBit(10, 0, 0, true);
        }

        public bool SetStop()
        {
            return WriteBit(10, 0, 1, true);
        }

        public bool SetSetPoint(int value)
        {
            var outBuffer = new byte[2];
            var writeResult = -1;

            if (!IsPlcConnected()) return false;

            S7.SetIntAt(outBuffer, 0, (short)value);

            lock (_lockObject)
            {
                writeResult = _s7Plc.DBWrite(10, 2, 2, outBuffer);

                if (writeResult > 0)
                {
                    PlcLastErrorMessage = _s7Plc.ErrorText(writeResult);
                    RaiseError();
                }
            }

            return writeResult > 0;
        }

        public int GetLastReadedValue()
        {
            return _currentReadValue;
        }
    }
}
