using MaintenanceDashboard.Data.Domain;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace MaintenanceDashboard.Views.RegisterToolControl
{

    public partial class RegisterToolControl : UserControl
    {
        private DataContext _context = new DataContext();
        public RegisterToolControl()
        {
            InitializeComponent();
        }


        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CollectionViewSource registerToolViewSource = ((CollectionViewSource)(this.FindResource("registerToolViewSource")));
            // Load is an extension method on IQueryable,
            // defined in the System.Data.Entity namespace.
            // This method enumerates the results of the query,
            // similar to ToList but without creating a list.
            // When used with Linq to Entities this method
            // creates entity objects and adds them to the context.
            await Task.Run(() => _context.RegisterTools.Load());
            // After the data is loaded call the DbSet<T>.Local property
            // to use the DbSet<T> as a binding source.
            registerToolViewSource.Source = _context.RegisterTools.Local;
        }

        private async void btnAddRegisterTool_Click(object sender, RoutedEventArgs e)
        {
            _context.RegisterTools.Add(new RegisterTool
            {
                ToolName = txtRegisterToolName.Text,
                UidCode = "TestString"
            });
            await Task.Run(() => _context.SaveChanges());
            txtRegisterToolName.Clear();
        }
    }
}
