using MaintenanceDashboard.Common;
using MaintenanceDashboard.Common.Properties;
using MaintenanceDashboard.Data.API;
using MaintenanceDashboard.Data.Models;
using MaintenanceDashbord.Common.PlcService;
using System;
using Zebra.Sdk.Comm;
using Zebra.Sdk.Printer;

namespace MaintenanceDashboard.Client.Infrastructure
{
    public class RobotToolsPlc
    {
        RobotToolsPlcHelper _robotToolsPlcHelper;
        private readonly RobotToolsContext context;
        public RobotToolsPlc()
        {
            _robotToolsPlcHelper = new RobotToolsPlcHelper();
            _robotToolsPlcHelper.Connect("192.168.1.7",0,0);

            context = new RobotToolsContext();

            OnPlcValuesRefreshed(null, null);
            _robotToolsPlcHelper.ValuesRefreshed += OnPlcValuesRefreshed;
        }

        private void OnPlcValuesRefreshed(object p1, object p2)
        {
            var spendedRobotTool = new SpendedRobotTool
            {
                Number = _robotToolsPlcHelper.Number,
                Name = _robotToolsPlcHelper.Name,
                Date = DateTime.Now,
                IsDoubler = _robotToolsPlcHelper.IsDoubler,
                SpendingEmployee =_robotToolsPlcHelper.SpendingEmployee
            };

            if (_robotToolsPlcHelper.SendTrigger == true)
            {
                _robotToolsPlcHelper.DbWrite();
                context.Create(spendedRobotTool);
                PrintLabel("192.168.1.4", _robotToolsPlcHelper.Number, _robotToolsPlcHelper.Name);
            }
        }

        public void PrintLabel(string IpAddress, int number, string name)
        {
            string ZPL_STRING = Resources.HeadBarcode + "^FS^FO200,50^A0,25,25^FD" + "Baza narzedzi robotow" + "^FS^FO200,100^A0,25,25^FDNarzedzie numer:" + number+ " ^FS^FO200,150^A0,25,25^FDNazwa narzedzia:"+name+" ^FS^FO200,200^A0,25,25^FDData przegladu:"+DateTime.Now.ToString("MM/dd/yyyy") +" ^FS^XZ";

            ZebraPrinter zebraPrinter = ZebraPrintHelper.Connect(new TcpConnection(IpAddress, TcpConnection.DEFAULT_ZPL_TCP_PORT), PrinterLanguage.ZPL);

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
