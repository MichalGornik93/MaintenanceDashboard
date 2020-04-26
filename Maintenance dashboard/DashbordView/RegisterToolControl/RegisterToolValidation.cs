using System;
using System.ComponentModel;

namespace Maintenance_dashboard.DashbordView.RegisterToolControl
{
    public class RegisterToolValidation : IDataErrorInfo
    { 
        public string RegisterToolName { get; set; }

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                var message = String.Empty;

                switch (columnName)
                {
                    case "RegisterToolName":
                        if (string.IsNullOrEmpty(RegisterToolName))
                            message = "Pole musi być wypełnione";
                        else if (RegisterToolName.Length < 2)
                            message = "Nazwa jest zbyt krótka";
                        else if (RegisterToolName.Length > 12)
                            message = "Nazwa jest zbyt długa";
                        break;
                };
                return message;
            }
        }
    }
}
