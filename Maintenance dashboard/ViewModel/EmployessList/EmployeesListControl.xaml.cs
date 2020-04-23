using System.ComponentModel;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Maintenance_dashboard.WindowControl
{
    public partial class EmployeeList : UserControl
    {
        private WorkshopDbContext _context = new WorkshopDbContext();
        public EmployeeList()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CollectionViewSource employeeViewSource = ((CollectionViewSource)(this.FindResource("employeeViewSource")));
            // Load is an extension method on IQueryable,
            // defined in the System.Data.Entity namespace.
            // This method enumerates the results of the query,
            // similar to ToList but without creating a list.
            // When used with Linq to Entities this method
            // creates entity objects and adds them to the context.
            _context.Employees.Load();
            // After the data is loaded call the DbSet<T>.Local property
            // to use the DbSet<T> as a binding source.
            employeeViewSource.Source = _context.Employees.Local;
        }

    }
}
