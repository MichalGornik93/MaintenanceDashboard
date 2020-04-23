using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Maintenance_dashboard.DashbordViewModel.AddEmployee
{
    public partial class AddEmployeeControl : UserControl
    {
        private WorkshopDbContext _context = new WorkshopDbContext();
        public AddEmployeeControl()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            _context.Employees.Add(new Employee
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                UidCode = "1111"
            });
            _context.SaveChanges();

            gridInfoAddToDataBase.Visibility = Visibility.Visible;
            test.Visibility = Visibility.Hidden;
            btnAddEmployee.Visibility = Visibility.Hidden;
        }

    }
}

