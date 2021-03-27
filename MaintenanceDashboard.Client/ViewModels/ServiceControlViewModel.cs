using MaintenanceDashboard.Common;
using MaintenanceDashboard.Common.Properties;
using MaintenanceDashboard.Common.PlcService;
using System;
using Zebra.Sdk.Comm;
using Zebra.Sdk.Printer;
using MaintenanceDashbord.Common.PlcService;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class ServiceControlViewModel : ViewModel
    {
        SmartWorkshopPlcHelper _smartWorkshopPlcHelper;
        RobotToolsPlcHelper _robotToolsPlcHelper;
        public ServiceControlViewModel()
        {
            _smartWorkshopPlcHelper = new SmartWorkshopPlcHelper();

            _robotToolsPlcHelper = new RobotToolsPlcHelper();
            

            OnPlcServiceValuesRefreshed(null, null);
            _smartWorkshopPlcHelper.ValuesRefreshed += OnPlcServiceValuesRefreshed;
            _robotToolsPlcHelper.ValuesRefreshed += OnPlcServiceValuesRefreshed;

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
            if(PlcIpAddress=="192.168.1.1")
                _smartWorkshopPlcHelper.Connect(PlcIpAddress, 0, 0);
            else if (PlcIpAddress == "192.168.1.7")
                _robotToolsPlcHelper.Connect(PlcIpAddress, 0, 0);

        }

        private void Disconnect()
        {
            if (PlcIpAddress == "192.168.1.1")
                _smartWorkshopPlcHelper.Disconnect();
            else if (PlcIpAddress == "192.168.1.7")
                _robotToolsPlcHelper.Disconnect();
        }

        private void OnPlcServiceValuesRefreshed(object sender, EventArgs e)
        {
            if (PlcIpAddress == "192.168.1.1")
            {
                ConnectionState = _smartWorkshopPlcHelper.ConnectionState;
                ScanTime = _smartWorkshopPlcHelper.ScanTime;
            }
            else if (PlcIpAddress == "192.168.1.7")
            {
                ConnectionState = _robotToolsPlcHelper.ConnectionState;
                ScanTime = _robotToolsPlcHelper.ScanTime;
            }
        }
        #endregion
    }
}