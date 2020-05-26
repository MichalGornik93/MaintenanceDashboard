using System;
using System.ComponentModel;

namespace MaintenanceDashboard.Client
{
    public class EmployeeValidation : IDataErrorInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                var message = String.Empty;

                switch (columnName)
                {
                    case "FirstName":
                        if (string.IsNullOrEmpty(FirstName))
                            message = "Pole musi być wypełnione";
                        else if (FirstName.Length < 3)
                            message = "Nazwa jest zbyt krótka";
                        else if (FirstName.Length > 12)
                            message = "Nazwa jest zbyt długa";
                        break;
                    case "LastName":
                        if (string.IsNullOrEmpty(LastName))
                            message = "Pole musi być wypełnione";
                        else if (LastName.Length < 2)
                            message = "Nazwa jest zbyt krótka";
                        else if (LastName.Length > 12)
                            message = "Nazwa jest zbyt długa";
                        break;
                };
                return message;
            }
        }
    }
}
