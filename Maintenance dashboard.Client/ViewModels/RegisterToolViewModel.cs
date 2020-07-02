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
        private readonly IRegisterToolContext context;

        public ICollection<RegisterTool> RegisterTools { get; private set; }


        public string ToolName { get; set; }
        public string UidCode { get; set; }


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

        public RegisterToolViewModel(IRegisterToolContext context)
        {
            this.context = context;
            RegisterTools = new ObservableCollection<RegisterTool>();
        }



        public ActionCommand CreateRegisterToolCommand
        {
            get
            {
                return new ActionCommand(p => CreateRegisterTool(ToolName, UidCode),
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

        private void CreateRegisterTool(string toolName, string uidCode)
        {
            var registerTool = new RegisterTool
            {
                ToolName = toolName,
                UidCode = uidCode
            };

            context.CreateRegisterTool(registerTool);

            RegisterTools.Add(registerTool);

            ToolName = string.Empty;
            UidCode = string.Empty;
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
                context.DeleteRegisterTool(SelectedRegisterTool);
                RegisterTools.Remove(SelectedRegisterTool);
                SelectedRegisterTool = null;

            }
        }


    }
}
