using System;
using System.ComponentModel;

namespace MaintenanceDashboard.Client
{
    public class RegisterToolValidation : IDataErrorInfo
    { 
        public string RegisterTool { get; set; }

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                var message = String.Empty;

                switch (columnName)
                {
                    case "RegisterTool":
                        if (string.IsNullOrEmpty(RegisterTool))
                            message = "Pole musi być wypełnione";
                        else if (RegisterTool.Length < 2)
                            message = "Nazwa jest zbyt krótka";
                        else if (RegisterTool.Length > 12)
                            message = "Nazwa jest zbyt długa";
                        break;
                };
                return message;
            }
        }
    }
}
