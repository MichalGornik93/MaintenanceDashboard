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
        public ICollection<RegisterTool> RegisterTools { get; private set; } 
        public string ToolName { get; set; }
        public string UidCode { get; set; }

        public RegisterToolViewlModel() 
        {
            RegisterTools = new ObservableCollection<RegisterTool>(); 
        }

        private string tool;
        [Required]
        [StringLength(32, MinimumLength = 2)]
        public string Tool
        {
            get { return tool; }
            set
            {
                tool = value;
                NotifyPropertyChanged();
            }
        }



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
                    api.AddNewRegisterTool(registerTool); 
                }
                catch (Exception ex)
                {
                    // TODO:
                    return;
                }

                RegisterTools.Add(registerTool);
            }
        }
    }
}
