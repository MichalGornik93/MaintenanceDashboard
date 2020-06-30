using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MaintenanceDashboard.Data.Domain;
using MaintenanceDashboard.Library;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class RegisterToolViewModel : ViewModel
    {
        private readonly RegisterToolContext context;

        public ICollection<RegisterTool> RegisterTools { get; private set; }
       

        public string ToolName { get; set; }
        public string UidCodeRegisterTool { get; set; } 


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


        public RegisterToolViewModel() : this(new RegisterToolContext()) {}

        public RegisterToolViewModel(RegisterToolContext context)
        {
            this.context = context;
            RegisterTools = new ObservableCollection<RegisterTool>();
        }



        public ActionCommand AddRegisterToolCommand
        {
            get
            {
                return new ActionCommand(p => AddRegisterTool(ToolName, UidCodeRegisterTool),
                                         p => !String.IsNullOrWhiteSpace(ToolName));
            }
        }
        public ActionCommand SaveRegisterToolCommand
        {
            get
            {
                return new ActionCommand(p => SaveRegisterTool(),
                                         p => IsValidRegisterTool);
            }
        }

        public ICommand DeleteRegisterToolCommand
        {
            get
            {
                return new ActionCommand(p => DeleteRegisterTool(),
                    p => IsValidRegisterTool);
            }
        }


        public ICommand GetRegisterToolListCommand
        {
            get
            {
                return new ActionCommand(p => GetRegisterToolList());
            }
        }

        public bool IsValidRegisterTool
        {
            get
            {
                return SelectedRegisterTool == null ||
                !String.IsNullOrWhiteSpace(SelectedRegisterTool.ToolName);
            }
        }

        private void AddRegisterTool(string toolName, string uidCode)
        {
            
            using (var api = new RegisterToolContext())
            {
                var registerTool = new RegisterTool
                {
                    ToolName = toolName,
                    UidCode = uidCode
                };

                api.CreateRegisterTool(registerTool);

                RegisterTools.Add(registerTool);
            }

            ToolName = string.Empty;
            UidCodeRegisterTool = string.Empty;
        }

        private void GetRegisterToolList()
        {
            RegisterTools.Clear();
            SelectedRegisterTool = null;

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
