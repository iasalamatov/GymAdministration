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
    /// Interaction logic for ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        ClientViewModel _viewModel;

        public ClientWindow(Client client)
        {
            InitializeComponent();
            _viewModel = new ClientViewModel(client);
            this.DataContext = _viewModel;
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Edit();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
