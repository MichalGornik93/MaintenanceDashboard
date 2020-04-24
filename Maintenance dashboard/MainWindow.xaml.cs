using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Maintenance_dashboard.DashbordViewModel.RegisterTool;
using Maintenance_dashboard.DashbordViewModel.EmployeeList;
using Maintenance_dashboard.DashbordViewModel.AddEmployee;
using Maintenance_dashboard.DashbordViewModel.AddRegisterTool;

namespace Maintenance_dashboard
{
    public partial class MainWindow : Window
    {
        //Wyłącznie wywołania objektów, metod oraz logika dotycząca interface użytkownika
        public MainWindow()
        {
            InitializeComponent();
            PlcNetInterface plcNetInterface = new PlcNetInterface("192.168.0.1", 0, 0);
            plcNetInterface.Connected += (() => {
                progPlcConnectionStatus.IsIndeterminate = true;
                lblPlcConnectionStatus.Content = "SIMATIC CONNECTED";
                lblPlcConnectionStatus.Foreground = Brushes.Green;  
                progPlcConnectionStatus.Foreground = Brushes.Green;
                ;});
            plcNetInterface.Disconected += (() => {
                progPlcConnectionStatus.IsIndeterminate = false;
                lblPlcConnectionStatus.Content = "SIMATIC NOT CONNECTED";
                lblPlcConnectionStatus.Foreground = Brushes.Red;
                progPlcConnectionStatus.Foreground = Brushes.Red; 
                ;});           
            plcNetInterface.Connect();             
        }

        private void btnCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);

            switch (index)
            {
                case 0:
                    GridPrincipal.Children.Clear();   
                    GridPrincipal.Children.Add(new AddEmployeeControl());
                    break;
                case 1:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new EmployeeList());
                    break;
                case 2:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new AddRegisterToolControl());
                    break;
                case 3:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new RegisterToolList());
                    break;
                default:
                    break;
            }
        }

        private void MoveCursorMenu(int index)
        {
            TrainsitioningContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (10 +(60* index)), 0, 0);
        }
        private void btnHomeWindow_Click(object sender, RoutedEventArgs e)
        {
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new WindowControl.HomeControl());
        }

        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            GridPrincipal.Children.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if
        }
    }
}
