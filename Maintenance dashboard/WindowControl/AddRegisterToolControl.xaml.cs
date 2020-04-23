using System.Windows;
using System.Windows.Controls;

namespace Maintenance_dashboard.WindowControl
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
            _context.RegisterTools.Add(new RegisterTool
            {
                ToolName = txtToolName.Text,
                UidCode = "111"
            }); ;
            _context.SaveChanges();
        }
    }
}
