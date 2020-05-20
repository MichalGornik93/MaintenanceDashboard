using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
            var context = new ValidationContext(this) //Describes the context in which validation is performed.
            {
                //MeberName - Gets or sets the name of the member to verify.
                MemberName = propertyName
            };


            var results = new Collection<ValidationResult>(); //ValidationResult- Represents the container for the results of the validation request


            //TryValidateObject - Specifies whether the specified object is valid using a validation context, a collection of validation results, and a value that indicates whether all properties should be verified.
            var isValid = Validator.TryValidateObject(this, context, results, true); //(Object to be verified, Context that describes the object to be verified, Collection to store every failed verification, true if the object will be checked; otherwise false)


        
            if(!isValid)
            {
                ValidationResult result = results.SingleOrDefault(p =>
                                                                  p.MemberNames.Any(memberName =>
                                                                  memberName == propertyName));
                //is this condition true ? yes : no
                return result == null ? null : result.ErrorMessage;
            }

            return null;
        }
    }
}
