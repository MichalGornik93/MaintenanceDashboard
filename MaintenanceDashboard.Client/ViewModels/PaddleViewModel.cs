using MaintenanceDashboard.Data.Models;
using MaintenanceDashboard.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using MaintenanceDashboard.Data.API;
using MaintenanceDashboard.Client.Interfaces;
using Zebra.Sdk.Printer;
using Zebra.Sdk.Comm;
using MaintenanceDashboard.Common.Properties;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class PaddleViewModel : ViewModel, IRegisterCompontent
    {
        private readonly PaddleContext context;
        public ICollection<Paddle> Paddles { get; private set; }
        
        public string BarcodeNumber { get; set; }
        public string Comments { get; set; }
        public string Model { get; set; } = Resources.PaddleModelPattern;
        public string AddedDate { get; set; } = DateTime.Now.ToString(Resources.DateTimePattern);

        private bool _connectedSuccessfully;
        public bool ConnectedSuccessfully
        {
            get { return _connectedSuccessfully; }
            set
            {
                _connectedSuccessfully = value;
                NotifyPropertyChanged();
            }
        }

        private Paddle _selectedPaddle;
        public Paddle SelectedPaddle
        {
            get { return _selectedPaddle; }
            set
            {
                _selectedPaddle = value;
                NotifyPropertyChanged();
            }
        }

        public PaddleViewModel(PaddleContext context)
        {
            this.context = context;
            Paddles = new ObservableCollection<Paddle>();
            BarcodeNumber = context.GetFirstFreeBarcodeNumber();
            GetAll();
        }

        public ActionCommand CreateCommand
        {
            get
            {
                return new ActionCommand(p => Create(),
                    p => IsValidPaddle());
            }
        }

        public ActionCommand UpdateCommand
        {
            get
            {
                return new ActionCommand(p => Update());
            }
        }

        public void Create()
        {
            var paddle = new Paddle
            {
                BarcodeNumber = BarcodeNumber,
                Model = Model,
                AddedDate = AddedDate,
                LastPreventionDate = DateTime.Now.ToString(Resources.DateTimePattern),
                Comments = Comments
            };

            context.Create(paddle);
            ConnectedSuccessfully = true;
            PrintLabel("192.168.1.4");
        }

        public void Update()
        {
            if (SelectedPaddle != null)
                context.Update(SelectedPaddle);
        }

        public void GetAll()
        {
            Paddles.Clear();
            SelectedPaddle = null;

            foreach (var item in context.GetAll())
                Paddles.Add(item);
        }

        public void PrintLabel(string theIpAddress)
        {
            string ZPL_STRING = Resources.HeadBarcode + "^FS^FO250,50^A0,25,25^FD" + "Baza paletek" + "^FS^FO230,90^BCN,100,Y,N,N^FD" + BarcodeNumber + "^FS^XZ";

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

        public bool IsValidPaddle()
        {
            if (OnValidate(BarcodeNumber) != null)
                return false;
            return true;
        }

        protected override string OnValidate(string propertyName)
        {
            if (String.IsNullOrEmpty(BarcodeNumber))
                return "Pole musi być wypełnione";
            else if (!Regex.IsMatch(BarcodeNumber, Resources.PaddleBarcodePattern))
                return "Niepoprawna składnia ciągu {Pal...}";
            else if (context.CheckIfExistInDb(BarcodeNumber))
                return "Paletka istnieje już w bazie danych";
            return base.OnValidate(propertyName);
        }
    }
}
