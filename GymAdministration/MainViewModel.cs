using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GymAdministration
{
    class MainViewModel : INotifyPropertyChanged
    {
        
        private Client _client;

        protected void OnPropertyChanged(string name)
      {
          
          
            if(PropertyChanged!=null)
              PropertyChanged(this, new PropertyChangedEventArgs(name));
          
      }

        public event PropertyChangedEventHandler PropertyChanged;


        public MainViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {
            
           //
        }

        public void FindById()
        {
            
            var repo = new Repository();
            _client = repo.FindClient(5);
            if (_client != null)
            {
                var window = new ClientWindow(_client);
                window.ShowDialog();
            }
            else
            {
                
            }
        }



        public void AddNew()
        {
            _client = null;
            var window = new ClientWindow(_client);
                window.ShowDialog();
        }
    }
}
