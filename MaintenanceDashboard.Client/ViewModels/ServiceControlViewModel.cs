using MaintenanceDashboard.Common;
using MaintenanceDashbord.Common;
using MaintenanceDashbord.Common.Properties;
using System;
using Zebra.Sdk.Comm;
using Zebra.Sdk.Printer;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class ServiceControlViewModel : ViewModel
    {
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

        private string ipAddress = "192.168.1.1";
        public string IpAddress
        {
            get { return ipAddress; }
            set
            {
                ipAddress = value;
                NotifyPropertyChanged();
            }
        }


        public ActionCommand PrintLabelCommand
        {
            get
            {
                return new ActionCommand(p => PrintLabel(IpAddress));
            }
        }

        private void PrintLabel(string theIpAddress)
        {
            string ZPL_STRING = Resources.HeadBarcode+ "^FS^FO250,50^A0,25,25^FD"+ BarcodeDescription + "^FS^FO230,90^BCN,100,Y,N,N^FD"+BarcodeNumber+"^FS^XZ";

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
    }
}
