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
        public string ID { get; set; }

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
                var repo = new Repository();

                _client = repo.FindClient(Int32.Parse(ID));
                if (_client != null)
                {
                    var window = new ClientWindow(_client);
                    window.ShowDialog();
                    MessageBox.Show(ID);
                }
                else
                {
                    MessageBox.Show("Not found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        public void Setting()
        {
            var window = new SettingWindow();
            window.ShowDialog();
        }
    }
}

