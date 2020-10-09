using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Client.Views;
using MaintenanceDashboard.Data.API;
using MaintenanceDashboard.Data.Models;

namespace MaintenanceDashboard.Client
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            using (var context = new DataContext())
            {
                var IsSomePaddleToReview = context.Paddles
                    .ToList()
                    .Where(c => (DateTime.Now - DateTime.ParseExact(c.LastPrevention, "yyyy-MM-dd", CultureInfo.InvariantCulture)).TotalDays > 60)
                    .Any();

                var IsSomeThermostatToWash = context.Thermostats
                    .ToList()
                    .Where(c => (DateTime.Now - DateTime.ParseExact(c.LastWashDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)).TotalDays > 30)
                    .Any();

                if (IsSomePaddleToReview || IsSomeThermostatToWash)
                {
                    DisplayAlarm();
                }
                else
                    PreventionListViewItem.Background = new SolidColorBrush(Colors.Transparent);
            }
        }

        private void DisplayAlarm()
        {
            ColorAnimation animation;
            animation = new ColorAnimation();
            animation.From = Colors.Red;
            animation.To = Colors.Transparent;
            animation.AutoReverse = true;
            animation.Duration = new Duration(TimeSpan.FromSeconds(1));
            this.PreventionListViewItem.Background = new SolidColorBrush(Colors.Transparent);
            this.PreventionListViewItem.Background.BeginAnimation(SolidColorBrush.ColorProperty, animation);
        }


        private void btnCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MoveCursorMenu(ListViewMenu.SelectedIndex);

            switch (ListViewMenu.SelectedIndex)
            {
                case 0:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new HomeControl());
                    break;
                case 1:
                    GridPrincipal.Children.Clear();   
                    GridPrincipal.Children.Add(new ManagerEmployeeControl());
                    break;
                case 2:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new ManagerPaddleControl());
                    break;
                case 3:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new ManagerThermostatControl());
                    break;
                case 4:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new BuiltFunctionControl());
                    break;
                case 5:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new BuiltFunctionControl());
                    break;
                case 6:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new PreventionControl());
                    break;
                default:
                    break;
            }
        }

        private void MoveCursorMenu(int index)
        {
            TrainsitioningContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (10 + (60*index)), 0, 0);
        }

        private void btnSavePassword_Click(object sender, RoutedEventArgs e)
        {
            var DateTimeNow = DateTime.Now.ToString("ddMM");
            if (DateTimeNow.ToLower() == PasswordBox.Password.ToLower())
            {
                itemEmployee.IsEnabled = true;
            }
            else
                MessageBox.Show("Błędne hasło", "Logowanie", MessageBoxButton.OK, MessageBoxImage.Information);
            PasswordBox.Clear();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            itemEmployee.IsEnabled = false;
            GridPrincipal.Children.Clear();
            GridCursor.Margin = new Thickness(0, 10, 0, 0);
            GridPrincipal.Children.Add(new HomeControl());
        }
    }
}
