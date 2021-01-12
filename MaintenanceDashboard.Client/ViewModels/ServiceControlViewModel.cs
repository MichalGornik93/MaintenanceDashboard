using MaintenanceDashboard.Common;
using MaintenanceDashboard.Common.Properties;
using MaintenanceDashboard.Common.PlcService;
using System;
using Zebra.Sdk.Comm;
using Zebra.Sdk.Printer;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class ServiceControlViewModel : ViewModel
    {
        smartWorkshopPlcHelper _eCmmsPlcHelper;

        public ServiceControlViewModel()
        {
            _eCmmsPlcHelper = new smartWorkshopPlcHelper();

            OnPlcServiceValuesRefreshed(null, null);
            _eCmmsPlcHelper.ValuesRefreshed += OnPlcServiceValuesRefreshed;
        }

        #region Zebra printer
        private string barcodeDescription;
        public string BarcodeDescription
        {
            get { return barcodeDescription; }
            set
            {
                barcodeDescription = value;
                NotifyPropertyChanged();
            }
        }

        private string barcodeNamber;
        public string BarcodeNumber
        {
            get { return barcodeNamber; }
            set
            {
                barcodeNamber = value;
                NotifyPropertyChanged();
            }
        }

        private string zebraIpAddress = "192.168.1.4";
        public string ZebraIpAddress
        {
            get { return zebraIpAddress; }
            set
            {
                zebraIpAddress = value;
                NotifyPropertyChanged();
            }
        }


        public ActionCommand PrintLabelCommand
        {
            get
            {
                return new ActionCommand(p => PrintLabel(ZebraIpAddress));
            }
        }

        private void PrintLabel(string theIpAddress)
        {
            string ZPL_STRING = Resources.HeadBarcode + "^FS^FO250,50^A0,25,25^FD" + BarcodeDescription + "^FS^FO230,90^BCN,100,Y,N,N^FD" + BarcodeNumber + "^FS^XZ";

            ZebraPrinter zebraPrinter = ZebraPrintHelper.Connect(new TcpConnection(theIpAddress, TcpConnection.DEFAULT_ZPL_TCP_PORT), PrinterLanguage.ZPL);

            if (ZebraPrintHelper.CheckStatus(zebraPrinter))
            {
                ZebraPrintHelper.Print(zebraPrinter, ZPL_STRING);

                if (ZebraPrintHelper.CheckStatusAfter(zebraPrinter))
                {
                    Console.WriteLine($"Label Printed");
                }
            }
            zebraPrinter = ZebraPrintHelper.Disconnect(zebraPrinter);
        }
        #endregion

        #region S7Plc
        private string plcIpAddress = "192.168.1.1";
        public string PlcIpAddress
        {
            get { return plcIpAddress; }
            set
            {
                plcIpAddress = value;
                NotifyPropertyChanged();
            }
        }

        private ConnectionStates connectionState;
        public ConnectionStates ConnectionState
        {
            get { return connectionState; }
            set 
            { 
                connectionState = value;
                NotifyPropertyChanged();
            }
        }

        private int counter;
        public int Counter
        {
            get { return counter; }
            set
            {
                counter = value;
                NotifyPropertyChanged();
            }
        }

        private TimeSpan scanTime;
        public TimeSpan ScanTime
        {
            get { return scanTime; }
            set 
            { 
                scanTime = value;
                NotifyPropertyChanged();
            }
        }

        public ActionCommand ConnectCommand
        {
            get
            {
                return new ActionCommand(p => Connect());
            }
        }


        public ActionCommand DisconnectCommand
        {
            get
            {
                return new ActionCommand(p => Disconnect());
            }
        }


        private void Connect()
        {
            _eCmmsPlcHelper.Connect(PlcIpAddress, 0, 0);
            
        }

        private void Disconnect()
        {
            _eCmmsPlcHelper.Disconnect();
        }

        private void OnPlcServiceValuesRefreshed(object sender, EventArgs e)
        {
            ConnectionState = _eCmmsPlcHelper.ConnectionState;
            ScanTime = _eCmmsPlcHelper.ScanTime;
        }
        #endregion
    }
}
