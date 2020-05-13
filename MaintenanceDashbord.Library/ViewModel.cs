using System.ComponentModel;

namespace MaintenanceDashbord.Library
{
    public abstract class ViewModel : IDataErrorInfo
    {
        public string this[string columnName] => throw new System.NotImplementedException();

        public string Error => throw new System.NotImplementedException();
    }
}
