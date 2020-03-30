using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    public partial class MainWindow : Window
    {
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
                    GridPrincipal.Children.Add(new AddUserControl());
                    break;
                case 1:
                    GridPrincipal.Children.Clear();
                    break;
                case 2:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new WindowControl.AddRegisterToolControl());
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
            GridPrincipal.Children.Add(new WindowControl.SettingsControl());
        }      
    }
}
