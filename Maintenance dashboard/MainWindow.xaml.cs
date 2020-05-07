using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Maintenance_dashboard.Views.RegisterToolControl;
using Maintenance_dashboard.Views.EmployeeControl;
using Maintenance_dashboard.Views.AddPaddle;
using Maintenance_dashboard.Views.PaddleControl;
using System;
using Maintenance_dashboard.WindowControl;

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

            switch (ListViewMenu.SelectedIndex)
            {
                case 0:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new WindowControl.HomeControl());
                    break;
                case 1:
                    GridPrincipal.Children.Clear();   
                    GridPrincipal.Children.Add(new EmployeeControl());
                    break;
                case 2:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new RegisterToolControl());
                    break;
                case 3:
                    GridPrincipal.Children.Clear();
                    break;
                case 4:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new PaddleControl());
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



        private void btnSavePassword_Click(object sender, RoutedEventArgs e)
        {
            var DateTimeNow = Convert.ToString(DateTime.Now.DayOfWeek);
            if (DateTimeNow.ToLower() == PasswordBox.Password.ToLower())
            {
                ListViewMenu.IsEnabled = IsEnabled;
                btnCloseWindow.IsEnabled = IsEnabled;
            }
            PasswordBox.Clear();
        }

    }
}
