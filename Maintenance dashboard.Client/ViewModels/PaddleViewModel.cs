using MaintenanceDashboard.Data.Domain;
using MaintenanceDashboard.Library;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class PaddleViewModel: ViewModel
    {
        private readonly PaddleContext context;
        public ICollection<Paddle> Paddles { get; private set; }

        public string PaddleNumber { get; set; }
        public string PaddleComments { get; set; }

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


        public PaddleViewModel() : this(new PaddleContext()) { }

        public PaddleViewModel(PaddleContext context)
        {
            this.context = context;
          
            Paddles = new ObservableCollection<Paddle>();
        }

        public ActionCommand AddPaddleCommand
        {
            get
            {
                return new ActionCommand(p => AddPaddle(PaddleNumber, PaddleComments),
                                         p => !String.IsNullOrWhiteSpace(PaddleNumber));
            }
        }

        private void AddPaddle(string paddleNumber, string comments)
        {

            using (var api = new PaddleContext())
            {
                var paddle = new Paddle
                {
                    PaddleNumber = paddleNumber,
                    Model = "VW380 T1/T2 Base/High",
                    AddedDate = DateTime.Now,
                    CommentsPaddle = comments
                };

                api.AddNewPaddle(paddle);

                Paddles.Add(paddle);
            }

            PaddleNumber = string.Empty;
            PaddleComments = string.Empty;
        }
    }
}
