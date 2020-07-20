using MaintenanceDashboard.Data.Api;
using MaintenanceDashboard.Data.Domain;
using MaintenanceDashboard.Library;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class PaddleViewModel : ViewModel
    {
        private readonly IPaddleContext context;
        
        public ICollection<Paddle> Paddles { get; private set; }

        public string Number { get; set; }
        public string Comments { get; set; }

        private string _Model = "VW380 T1/T2 Base/High";
        public string Model
        {
            get { return _Model; }
            set { _Model = value; }
        }



        private Paddle selectedPaddle;
        public Paddle SelectedPaddle
        {
            get { return selectedPaddle; }
            set
            {
                selectedPaddle = value;
                NotifyPropertyChanged();
            }
        }

        private string _addedData = DateTime.Now.ToString("MM/dd/yyyy");
        public string AddedDate
        {
            get { return _addedData; }
            set { _addedData = value; }
        }


        public PaddleViewModel(IPaddleContext context)
        {
            this.context = context;
            Paddles = new ObservableCollection<Paddle>();
        }

        public ActionCommand CreatePaddleCommand
        {
            get
            {
                return new ActionCommand(p => CreatePaddle(Number, Model, AddedDate, Comments),
                                         p => !String.IsNullOrWhiteSpace(Number));
            }
        }

        private void CreatePaddle(string paddleNumber, string model, string addedDate, string comments)
        {
            var paddle = new Paddle
            {
                Number = paddleNumber,
                Model = model,
                AddedDate = addedDate,
                Comments = comments
            };

            context.CreatePaddle(paddle);

            Paddles.Add(paddle);

            Number = string.Empty;
            Comments = string.Empty;
        }

        public void GetPaddleList()
        {
            Paddles.Clear();

            foreach (var item in context.GetPaddleList())
                Paddles.Add(item);
        }

        private void SavePaddle()
        {
            if (SelectedPaddle != null)
                context.UpdatePaddle(SelectedPaddle);
        }

        private void DeletePaddle()
        {
            if(SelectedPaddle !=null)
            {
                context.DeletePaddle(SelectedPaddle);
                Paddles.Remove(SelectedPaddle);
                SelectedPaddle = null;
            }
        }
    }
}
