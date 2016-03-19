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

        private void ButtonShowClient_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.ShowActiveClient();
        }

        private void ButtonRemoveManager_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.RemoveManager();
        }

       
        private void ButtonAddManager_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Add();
        }

        private void ButtonSaveManager_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.SaveManager();
        }

       

        private void ButtonEditManager_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Edit();
        }

        private void ButtonRemoveCoach_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.RemoveCoach();
        }

        private void ButtonEditCoach_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Edit();
        }

        private void ButtonAddCoach_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Add();
        }

        private void ButtonSaveCoach_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.SaveCoach();
        }
    }
}
