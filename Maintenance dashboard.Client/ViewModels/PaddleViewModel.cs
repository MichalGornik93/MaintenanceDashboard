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

        public string PaddleNumber { get; set; }
        public string PaddleComments { get; set; }
        public string Model = "VW380 T1/T2 Base/High";


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

        public PaddleViewModel(IPaddleContext context)
        {
            this.context = context;
            Paddles = new ObservableCollection<Paddle>();
        }

        public ActionCommand CreatePaddleCommand
        {
            get
            {
                return new ActionCommand(p => CreatePaddle(PaddleNumber, PaddleComments),
                                         p => !String.IsNullOrWhiteSpace(PaddleNumber));
            }
        }

        private void CreatePaddle(string paddleNumber, string comments)
        {
            var paddle = new Paddle
            {
                PaddleNumber = paddleNumber,
                Model = "VW380 T1/T2 Base/High",
                AddedDate = DateTime.Now,
                CommentsPaddle = comments
            };

            context.CreatePaddle(paddle);

            Paddles.Add(paddle);

            PaddleNumber = string.Empty;
            PaddleComments = string.Empty;
        }
    }
}
