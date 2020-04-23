using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Maintenance_dashboard.DashbordViewModel.AddUser
{
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

    public class ViewModel : IDataErrorInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                var message = String.Empty;

                switch (columnName)
                {
                    case "FirstName":
                        if (string.IsNullOrEmpty(FirstName))
                            message = "Pole musi być wypełnione";
                        else if (FirstName.Length < 2)
                            message = "Nazwa jest zbyt krótka";
                        break;
                    case "LastName":
                        if (string.IsNullOrEmpty(LastName))
                            message = "Pole musi być wypełnione";
                        else if (LastName.Length < 2)
                            message = "Nazwa jest zbyt krótka";
                        break;
                };
                return message;
            }
        }
    }

}
}
