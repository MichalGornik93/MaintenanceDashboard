using System.Windows;
using System.Windows.Controls;
using Maintenance_dashboard;

namespace Maintenance_dashboard.DashbordViewModel.AddRegisterTool
{

    public partial class AddRegisterToolControl : UserControl
    {
        private WorkshopDbContext _context = new WorkshopDbContext();
        public AddRegisterToolControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { 
        }
    }
}
