using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Data;

namespace MaintenanceDashboard.Library
{
    public abstract class ViewModel : ObservableObject, IDataErrorInfo
    {
        public string this[string columnName]
        {
            get { return OnValidate(columnName); }
        }


        public string Error =>  throw new NotSupportedException();

        protected virtual string OnValidate(string propertyName)
        {
            var context = new ValidationContext(this)
            {
                MemberName = propertyName
            };

            var results = new Collection<ValidationResult>();
            var isValid = Validator.TryValidateObject(this, context, results, true); 
        
            string result = null;
            if(!isValid)
            {
                result = results.SingleOrDefault(p => p.MemberNames.Any(memberName => memberName == propertyName))?.ErrorMessage;
            }

            return result;
        }
    }
}
