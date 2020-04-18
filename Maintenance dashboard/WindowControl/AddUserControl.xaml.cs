using System;
using System.Collections.Generic;
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

namespace Maintenance_dashboard
{
    /// <summary>
    /// Logika interakcji dla klasy AddUserControl.xaml
    /// </summary>
    public partial class AddUserControl : UserControl
    {
        private WorkshopDbContext _context = new WorkshopDbContext();
        public AddUserControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            _context.Employees.Add(new Employee
            {
                Name = txtName.Text,
                Surname = txtSurname.Text,
                Uid = "111"
            });
            _context.SaveChanges();

            gridInfoAddToDataBase.Visibility = Visibility.Visible;
            test.Visibility = Visibility.Hidden;
            btnAddEmployee.Visibility = Visibility.Hidden;

        }
    }
}

