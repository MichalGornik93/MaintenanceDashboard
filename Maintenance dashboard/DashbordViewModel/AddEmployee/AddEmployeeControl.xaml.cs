using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Maintenance_dashboard;

namespace Maintenance_dashboard.DashbordViewModel.AddEmployee
{
    public partial class AddEmployeeControl : UserControl
    {
        private WorkshopDbContext _context = new WorkshopDbContext();
        private PlcNetInterface plcNetInterface = new PlcNetInterface("192.168.0.1",0,0);
        public AddEmployeeControl()
        {
            InitializeComponent();
            plcNetInterface.Connect();
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            _context.Employees.Add(new Employee
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                UidCode = "1111"
            }) ;
            await Task.Run(()=>_context.SaveChanges());

            gridInfoAddToDataBase.Visibility = Visibility.Visible;
            test.Visibility = Visibility.Hidden;
            btnAddEmployee.Visibility = Visibility.Hidden;
        }

    }
}

