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
using System.Windows.Shapes;

namespace GymAdministration
{
    /// <summary>
    /// Логика взаимодействия для SettingWindow.xaml
    /// </summary>
    public partial class SettingWindow : Window
    {
        SettingViewModel _viewModel = new SettingViewModel();

        public SettingWindow()
        {
            InitializeComponent();
            this.DataContext = _viewModel;
        }

        private void ButtonAddClient_Click(object sender, RoutedEventArgs e)
        {
            var window = new ClientWindow(null);
            window.ShowDialog();
        }

        private void ButtonEditClient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonRemoveManager_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonEditManager_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonAddManager_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSaveManager_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonRemoveVisit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
