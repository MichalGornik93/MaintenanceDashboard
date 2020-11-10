using System;
using System.Text;
using System.Threading;
using Zebra.Sdk.Comm;
using Zebra.Sdk.Printer;

namespace MaintenanceDashbord.Common
{
    public class ZebraPrintHelper 
    {
        public static bool CheckStatusAfter(ZebraPrinter printer)
        {
            PrinterStatus printerStatus = null;

            try
            {
                VerifyConnection(printer);
                printerStatus = printer.GetCurrentStatus();

                while ((printerStatus.numberOfFormatsInReceiveBuffer > 0) && (printerStatus.isReadyToPrint))
                {
                    Thread.Sleep(500);
                    printerStatus = printer.GetCurrentStatus();
                }
            }
            catch (ConnectionException e)
            {
                throw new ConnectionException($"Error getting status from printer: {e.Message}");
            }

            if (printerStatus.isReadyToPrint)
            {
                Console.WriteLine($"Ready To Print");
                return true;
            }
            else if (printerStatus.isPaused)
            {
                throw new NotSupportedException($"Cannot Print because the printer is paused.");
            }
            else if (printerStatus.isHeadOpen)
            {
                throw new NotSupportedException($"Cannot Print because the printer head is open.");
            }
            else if (printerStatus.isPaperOut)
            {
                throw new NotSupportedException($"Cannot Print because the paper is out.");
            }
            else
            {
                throw new NotSupportedException($"Cannot Print.");
            }
            return false;
        }

        public static bool Print(ZebraPrinter printer, string printstring)
        {
            bool sent = false;
            try
            {
                VerifyConnection(printer);
                printer.Connection.Write(Encoding.UTF8.GetBytes(printstring));
                sent = true;
            }
            catch (ConnectionException e)
            {
                Console.WriteLine($"Unable to write to printer: {e.Message}");
            }
            return sent;
        }


        public static bool CheckStatus(ZebraPrinter printer) //Zwraca flage 
        {
            PrinterStatus printerStatus = null;
            try
            {
                VerifyConnection(printer); //Sprawdz czy nie utraciłeś połaczenia

                printerStatus = printer.GetCurrentStatus(); //Jesli nie utraciłeś połaczenia zwróć status drukarki
            }
            catch (ConnectionException e)
            {
                throw new NotSupportedException($"Error getting status from printer: {e.Message}");
            }

            if (null == printerStatus)
            {
                throw new NotSupportedException($"Unable to get status.");
            }
            else if (printerStatus.isReadyToPrint) //Jesli gotowy do druku zwróć true
            {
                Console.WriteLine($"Ready To Print");
                return true;
            }
            else if (printerStatus.isPaused)
            {
                throw new NotSupportedException($"Cannot Print because the printer is paused.");
            }
            else if (printerStatus.isHeadOpen)
            {
                throw new NotSupportedException($"Cannot Print because the printer head is open.");
            }
            else if (printerStatus.isPaperOut)
            {
                throw new NotSupportedException($"Cannot Print because the paper is out.");
            }
            else
            {
                throw new NotSupportedException($"Cannot Print.");
            }
            return false; //Jesli niegotowy do druku zwróć false
        }


        public static bool VerifyConnection(ZebraPrinter printer)
        {
            bool ok = false;
            try
            {
                if (!printer.Connection.Connected)
                {
                    printer.Connection.Open();
                    if (printer.Connection.Connected)
                        ok = true;
                }
                else ok = true;
            }
            catch (ConnectionException e)
            {
                throw new ConnectionException($"Unable to connect to printer: {e.Message}");
            }
            return ok;
        }


        public static ZebraPrinter Connect(Connection connection, PrinterLanguage language) //Zwraca objekt połączenia
        {
            ZebraPrinter printer = null;

            try
            {
                connection.Open();
                if (connection.Connected)
                {
                    printer = ZebraPrinterFactory.GetInstance(language, connection);
                    Console.WriteLine($"Printer Connected");
                }
                else Console.WriteLine($"Printer Not Connected!");
            }
            catch (ConnectionException e)
            {
                throw new ConnectionException($"Error connecting to printer: {e.Message}");
            }
            return printer;
        }


        public static ZebraPrinter Disconnect(ZebraPrinter printer)
        {
            try
            {
                printer.Connection.Close();
                Console.WriteLine($"Printer Disconnected");
            }
            catch (ConnectionException e)
            {
                throw new ConnectionException($"Error disconnecting from printer: {e.Message}");
            }
            return printer;
        }
    }
}
