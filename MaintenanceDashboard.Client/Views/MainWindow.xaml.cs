﻿using System;
using System.Windows;
using System.Windows.Controls;
using MaintenanceDashboard.Client.Infrastructure;
using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Client.Views;
using MaintenanceDashboard.Data.API;

namespace MaintenanceDashboard.Client
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
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
                    GridPrincipal.Children.Add(new ManagerRobotToolsControl());
                    break;
                case 5:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new ManagerRetrievedEquipmentControl());
                    break;
                case 6:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new PreventionControl());
                    break;
                case 7:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new ServiceControl());
                    break;
                case 8:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new SettingsControl());
                    break;
                default:
                    break;
            }
        }

        private void MoveCursorMenu(int index)
        {
            TrainsitioningContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (10 + (60 * index)), 0, 0);
        }

        private void btnSavePassword_Click(object sender, RoutedEventArgs e)
        {
            var DateTimeNow = DateTime.Now.ToString("ddMM");
            if (DateTimeNow.ToLower() == PasswordBox.Password.ToLower())
            {
                itemEmployee.IsEnabled = true;
                itemSettings.IsEnabled = true;
            }
            else
                MessageBox.Show("Błędne hasło", "Logowanie", MessageBoxButton.OK, MessageBoxImage.Information);
            PasswordBox.Clear();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            itemEmployee.IsEnabled = false;
            itemSettings.IsEnabled = false;
            GridPrincipal.Children.Clear();
            GridCursor.Margin = new Thickness(0, 10, 0, 0);
            GridPrincipal.Children.Add(new HomeControl());
        }
    }
}
