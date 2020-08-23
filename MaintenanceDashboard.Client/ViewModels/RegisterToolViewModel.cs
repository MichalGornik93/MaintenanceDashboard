using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MaintenanceDashboard.Data.Api;
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

        private RegisterTool _selectedRegisterTool;
        public RegisterTool SelectedRegisterTool
        {
            get { return _selectedRegisterTool; }
            set
            {
                _selectedRegisterTool = value;
                NotifyPropertyChanged();
            }
        }

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
                return new ActionCommand(p => DeleteRegisterTool());
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
            ConnectedSuccessfully = true;
        }

        public void GetRegisterToolList()
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
