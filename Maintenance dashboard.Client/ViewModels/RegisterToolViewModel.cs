using MaintenanceDashboard.Data.Domain;
using MaintenanceDashboard.Library;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class RegisterToolViewModel : ViewModel
    {
        private readonly WorkshopContext context;
        public ICollection<RegisterTool> RegisterTools { get; private set; } //definicja Obserwowanej kolekcji klientów

        private RegisterTool selectedRegisterTool;

        public RegisterTool SelectedRegisterTool
        {
            get { return selectedRegisterTool; }
            set
            {
                selectedRegisterTool = value;
                NotifyPropertyChanged();
            }
        }

        public string ToolName { get; set; }
        public string UidCode { get; set; }

        public RegisterToolViewModel() : this(new WorkshopContext())
        {

        }

        public RegisterToolViewModel(WorkshopContext context)
        {
            this.context = context;
            RegisterTools = new ObservableCollection<RegisterTool>(); //Inicjalizacja Obserwowanej kolekcji klientów
        }



        public ActionCommand AddRegisterToolCommand
        {
            get
            {
                return new ActionCommand(p => AddRegisterTool(ToolName, UidCode),
                                         p => !String.IsNullOrWhiteSpace(ToolName));
            }
        }
        public ActionCommand SaveRegisterToolCommand
        {
            get
            {
                return new ActionCommand(p => SaveRegisterTool(),
                                         p => IsValid);
            }
        }

        public ICommand DeleteRegisterToolCommand
        {
            get
            {
                return new ActionCommand(p => DeleteRegisterTool(),
                    p => IsValid);
            }
        }


        public ICommand GetRegisterToolListCommand
        {
            get
            {
                return new ActionCommand(p => GetRegisterToolList());
            }
        }


        public bool IsValid //Zwraca true, Jest sprawdzone jesli
        {
            get
            {
                return SelectedRegisterTool == null || //Nie jest zaznczaczony lub
                !String.IsNullOrWhiteSpace(SelectedRegisterTool.ToolName); //zaznaczony toolname nie jest pusty 
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

                api.AddNewRegisterTool(registerTool);

                RegisterTools.Add(registerTool);
            }
        }

        private void GetRegisterToolList()
        {
            RegisterTools.Clear();

            foreach (var item in context.GetRegisterToolList())
                RegisterTools.Add(item);
        }

        private void SaveRegisterTool()
        {
            if (SelectedRegisterTool != null)
            {
                context.UpdateRegisterTool(SelectedRegisterTool);
            }
        }

        private void DeleteRegisterTool()
        {
            if (SelectedRegisterTool != null)
            {
                context.DataContext.RegisterTools.Remove(SelectedRegisterTool);
                context.DataContext.SaveChanges();
                RegisterTools.Remove(SelectedRegisterTool);

            }
        }
    }
}
