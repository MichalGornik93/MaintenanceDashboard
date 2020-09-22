using MaintenanceDashboard.Data.Models;
using MaintenanceDashboard.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using MaintenanceDashbord.Common.Properties;
using MaintenanceDashboard.Data.API;
using MaintenanceDashboard.Client.Interfaces;

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
                LastPrevention = DateTime.Now.ToString(Resources.DateTimePattern),
                Comments = Comments
            };

            context.Create(paddle);
            ConnectedSuccessfully = true;
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
