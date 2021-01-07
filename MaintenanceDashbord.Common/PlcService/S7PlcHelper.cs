using PlcService.Sharp7;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace MaintenanceDashboard.Common.PlcService
{
    public class S7PlcHelper
    {
        private readonly S7Client _client;
        private readonly System.Timers.Timer _timer;
        private DateTime _lastScanTime;

        private volatile object _locker = new object();
        public ConnectionStates ConnectionState { get; private set; }

        public string EmployeeName { get; private set; }
        public string GettingEquipment { get; private set; }
        public string Action { get; private set; }
        public bool Req { get; private set; }
        public int Counter { get; private set; }

        public TimeSpan ScanTime { get; private set; }

        public event EventHandler ValuesRefreshed;

        public S7PlcHelper() //Konstruktor
        {
            _client = new S7Client();
            _timer = new System.Timers.Timer();
            _timer.Interval = 100;
            _timer.Elapsed += OnTimerElapsed; //Odpal zdarzenie
        }

        public void Connect(string ipAddress, int rack, int slot) //Metoda połaczenia
        {
            try
            {
                ConnectionState = ConnectionStates.Connecting;
                int result = _client.ConnectTo(ipAddress, rack, slot);
                if (result == 0)
                {
                    ConnectionState = ConnectionStates.Online;
                    _timer.Start();
                }
                else
                {
                    ConnectionState = ConnectionStates.Offline;
                    throw new Exception(" Connection to S7-1200 error: " + _client.ErrorText(result)+" Time: "+ DateTime.Now.ToString("HH:mm:ss"));

                }
                OnValuesRefreshed(); //Metoda odpalajaca event "ValuesRefreshed"
            }
            catch
            {
                ConnectionState = ConnectionStates.Offline;
                OnValuesRefreshed(); //Metoda odpalajaca event "ValuesRefreshed"
                throw;
            }
        }

        public void Disconnect()
        {
            if (_client.Connected)
            {
                _timer.Stop();
                _client.Disconnect();
                ConnectionState = ConnectionStates.Offline;
                OnValuesRefreshed(); //Metoda odpalajaca event "ValuesRefreshed"
            }
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e) //Zdarzenie odpalana synchronicznie
        {
            try
            {
                _timer.Stop();
                ScanTime = DateTime.Now - _lastScanTime;
                DbRead(); //Cykliczne odswiezanie wartosci blokow danych
                OnValuesRefreshed(); //Metoda odpalajaca event "ValuesRefreshed"
            }
            finally
            {
                _timer.Start();
            }
            _lastScanTime = DateTime.Now;
        }

        private void DbRead()
        {
            lock (_locker)
            {
                var buffer = new byte[772]; // nowa tablica [4] byte
                int result = _client.DBRead(17, 0, buffer.Length, buffer); //(odczytaj z DB1, od DB1.DBX0, ile: 4 byte, do tablicy [4] byte)
                if (result == 0) // Jesli nie ma zadnych bledow 
                {
                    //rzutuj tablice na odpowiednie typy
                    EmployeeName = S7.GetStringAt(buffer, 0);
                    GettingEquipment = S7.GetStringAt(buffer, 256);
                    Action = S7.GetStringAt(buffer, 512);
                    Req = S7.GetBitAt(buffer, 768, 0);
                    Counter = S7.GetIntAt(buffer, 770);
                }
                else //Jesli jest jakis blad
                {
                    throw new Exception(" Connection to S7-1200 error: " + _client.ErrorText(result) + " Time: " + DateTime.Now.ToString("HH:mm:ss"));
                }
            }
        }

        private void OnValuesRefreshed()
        {
            ValuesRefreshed?.Invoke(this, new EventArgs());
        }
    }
}
