using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MaintenanceDashboard.Library
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //[CallerMemberName] Calling a method without providing arguments will pass the name of the calling method
        protected void NotifyPropertyChanged([CallerMemberName]string propertyName="")
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
