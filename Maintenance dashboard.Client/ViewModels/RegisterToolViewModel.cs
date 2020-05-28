using MaintenanceDashboard.Data.Domain;
using MaintenanceDashbord.Library;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class RegisterToolViewlModel:ViewModel
    {
        public ICollection<RegisterTool> RegisterTools { get; private set; } //definicja Obserwowanej kolekcji klientów
        public string ToolName { get; set; }
        public string UidCode { get; set; }

        public RegisterToolViewlModel() //Konstruktor
        {
            RegisterTools = new ObservableCollection<RegisterTool>(); //Inicjalizacja Obserwowanej kolekcji klientów
        }

        //private string customerName;
        //[Required]
        //[StringLength(32, MinimumLength = 2)]
        //public string CustomerName
        //{
        //    get { return customerName; }
        //    set
        //    {
        //        customerName = value;
        //        NotifyPropertyChanged();
        //    }
        //}



        public ActionCommand AddRegisterToolCommand
        {
            get
            {
                return new ActionCommand(p => AddRegisterTool(ToolName, UidCode),
                                         p => IsValid);
            }
        }

        public bool IsValid
        {
            get
            {
                return !String.IsNullOrWhiteSpace(ToolName);
            }
        }



        private void AddRegisterTool(string toolName, string uidCode)
        {
            using (var api = new WorkshopContext())
            {
                var registerTool = new RegisterTool
                {
                    ToolName = toolName,
                    UidCode = uidCode
                };

                try
                {
                    api.AddNewRegisterTool(registerTool); //Dodanie do bazy danych
                }
                catch (Exception ex)
                {
                    // TODO: In later session, cover error handling
                    return;
                }

                RegisterTools.Add(registerTool);
            }
        }
    }
}
