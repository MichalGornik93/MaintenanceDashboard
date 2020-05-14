using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceDashbord.Library
{
    public abstract class ViewModel : ObservableObject, IDataErrorInfo
    {
        public string this[string columnName]
        {
            get { return OnValidate(columnName); }
        }

        #region
        //public string this[string columnName]
        //{
        //    get
        //    {
        //        var message = String.Empty;

        //        switch (columnName)
        //        {
        //            case "RegisterTool":
        //                if (string.IsNullOrEmpty(RegisterTool))
        //                    message = "Pole musi być wypełnione";
        //                else if (RegisterTool.Length < 2)
        //                    message = "Nazwa jest zbyt krótka";
        //                else if (RegisterTool.Length > 12)
        //                    message = "Nazwa jest zbyt długa";
        //                break;
        //        };
        //        return message;
        //    }
        //}
        #endregion

        public string Error
        {
            get { throw new NotSupportedException(); }
        }

        protected virtual string OnValidate(string propertyName)
        {
            var context = new ValidationContext(this) //Opisuje kontekst, w którym jest wykonywane sprawdzanie poprawności.
            {
                //MeberName - Pobiera lub ustawia nazwę elementu członkowskiego do zweryfikowania.
                MemberName = propertyName
            };


            var results = new Collection<ValidationResult>(); //ValidationResult- Reprezentuje kontener dla wyników żądania walidacji


            //TryValidateObject - Określa, czy określony obiekt jest prawidłowy przy użyciu kontekstu walidacji, kolekcji wyników walidacji oraz wartości określającej, czy należy zweryfikować wszystkie właściwości.
            var isValid = Validator.TryValidateObject(this, context, results, true); //(Obiekt do zweryfikowania, Kontekst, który opisuje obiekt do zweryfikowania, Kolekcja do przechowywania każdej nieudanej weryfikacji, true, jeśli obiekt zostanie sprawdzony; w przeciwnym razie false)

            //is this condition true ? yes : no
            return isValid==false ? results[0].ErrorMessage : null;
        }
    }
}
