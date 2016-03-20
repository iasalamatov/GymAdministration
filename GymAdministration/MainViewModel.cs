using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace GymAdministration
{
    class MainViewModel : INotifyPropertyChanged
    {

        private Client _client;
        public int ID { get; set; }
        public string LastName { get; set; }

        private ObservableCollection<Client> _foundClients;
        public ObservableCollection<Client> FoundClients
        {
            get { return _foundClients; }
            set
            {
                _foundClients = value;
                OnPropertyChanged("FoundClients");
            }
        }

        private Client _selectedclient;
        public Client SelectedClient
        {
            get { return _selectedclient; }
            set
            {
                _selectedclient = value;
                OnPropertyChanged("SelectedClient");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public MainViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {

            //Будет загружаться всякая инфа
        }

        public void FindById()
        {
            try
            {
                var repo = Factory.GetRepository();

                _client = repo.FindClient(ID);
                if (_client != null)
                {
                    var window = new ClientWindow(_client);
                    window.ShowDialog();
                    
                }
                else
                {
                    MessageBox.Show("Not found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Wrong format of ID", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void FindByLastName()
        {
            var repo = Factory.GetRepository();            
            FoundClients = new ObservableCollection<Client>(repo.FindAllClientsByLastName(LastName));
            if (FoundClients.Count() != 0) SelectedClient = FoundClients[0];
            else MessageBox.Show("Can not find client with this last name.");
        }

        public void Setting()
        {
            var window = new SettingWindow();
            window.ShowDialog();
        }

        public void ShowActiveClient()
        {
            if (SelectedClient != null)
            {
                var window = new ClientWindow(SelectedClient);
                window.ShowDialog();
            }
        }
    }
}

