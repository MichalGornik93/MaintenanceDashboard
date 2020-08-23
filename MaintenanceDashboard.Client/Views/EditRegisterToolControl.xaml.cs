using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.Api;
using MaintenanceDashboard.Data.Domain;
using System.Windows.Controls;

namespace MaintenanceDashboard.Client.Views
{
    public partial class EditRegisterToolControl : UserControl
    {      
        public EditRegisterToolControl()
        {
            InitializeComponent();
            var _registerToolViewModel= new RegisterToolViewModel(new RegisterToolContext());
            this.DataContext = _registerToolViewModel;
            _registerToolViewModel.GetRegisterToolList();
        }
    }
}
