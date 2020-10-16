using System.Windows;
using System.Windows.Controls;

namespace MaintenanceDashboard.Client.Views
{
    public partial class ComponentFormInfoControl : Window
    {
        public ComponentFormInfoControl()
        {
            InitializeComponent();
        }

        private void btnCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

      
        private void btnPrinter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "invoice");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }
    }
}
