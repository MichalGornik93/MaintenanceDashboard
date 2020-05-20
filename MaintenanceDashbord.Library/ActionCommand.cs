using System;
using System.Windows.Input;

namespace MaintenanceDashbord.Library
{
    public class ActionCommand:ICommand
    {
        private readonly Action<Object> action;

        public ActionCommand(Action<Object> action) :this(action, null)
        {
        }

        public ActionCommand(Action<Object> action, Predicate<Object> predicate)
        {
            if (action == null)
                throw new ArgumentNullException("action", "You must specify an Action<T>");

            this.action = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            action(parameter);
        }

        public void Execute()
        {
            Execute(null);
        }
    }
}
