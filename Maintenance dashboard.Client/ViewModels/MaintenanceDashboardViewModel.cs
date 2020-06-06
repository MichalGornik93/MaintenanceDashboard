using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MaintenanceDashboard.Data.Domain;
using MaintenanceDashboard.Library;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class MaintenanceDashboardViewModel : ViewModel
    {
        private readonly MaintenanceDashboardContext context;
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

        public MaintenanceDashboardViewModel() : this(new MaintenanceDashboardContext()) {}

        public MaintenanceDashboardViewModel(MaintenanceDashboardContext context)
        {
            this.context = context;
            RegisterTools = new ObservableCollection<RegisterTool>(); 
        }

        #region RegisterToolViewModel
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

        public bool IsValid
        {
            get
            {
                return SelectedRegisterTool == null ||
                !String.IsNullOrWhiteSpace(SelectedRegisterTool.ToolName);
            }
        }

        private void AddRegisterTool(string toolName, string uidCode)
        {
            using (var api = new MaintenanceDashboardContext())
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

        #endregion


    }
}
