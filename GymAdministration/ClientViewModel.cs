using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymAdministration.DataBase;
using System.ComponentModel;
using System.Windows;

namespace GymAdministration
{
    class ClientViewModel : INotifyPropertyChanged
    {
        private bool addOrEdit;

        private Client _client;
        public Client Client
        {
            get { return _client; }
            set
            {
                _client = value;
                OnPropertyChanged("Client");
            }

        }


        private ObservableCollection<Coach> _coaches;
        private Manager _selectedCoach;

        public ObservableCollection<Coach> Coaches
        {
            get { return _coaches; }
            set
            {
                _coaches = value;
                OnPropertyChanged("Coaches");
            }
        }
        public Manager SelectedCoach
        {
            get
            {
                return _selectedCoach;
            }
            set
            {
                _selectedCoach = value;
                OnPropertyChanged("SelectedCoach");
            }
        }


        private ObservableCollection<Manager> _managers;
        private Manager _selectedManager;

        public ObservableCollection<Manager> Managers
        {
            get { return _managers; }
            set
            {
                _managers = value;
                OnPropertyChanged("Managers");
            }
        }
        public Manager SelectedManager
        {
            get
            {
                return _selectedManager;
            }
            set
            {
                _selectedManager = value;
                OnPropertyChanged("SelectedManager");
            }
        }


        private bool _isEnabled1;
        public bool IsEnabled1
        {
            get { return _isEnabled1; }

            set
            {
                if (_isEnabled1 == value)
                {
                    return;
                }
                _isEnabled1 = value;
                OnPropertyChanged("IsEnabled1");
            }
        }

        private bool _isEnabled2;
        public bool IsEnabled2
        {
            get { return _isEnabled2; }

            set
            {
                if (_isEnabled2 == value)
                {
                    return;
                }
                _isEnabled2 = value;
                OnPropertyChanged("IsEnabled2");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }



        public ClientViewModel(Client client)
        {
            _client = new Client();
            if (client != null)
            {
                Client = client;
                IsEnabled1 = false;
                IsEnabled2 = true;
                addOrEdit = false;
            }
            else
            {
                //если был нажат Add

                addOrEdit = true;
                LoadData();
            }
        }


        private void LoadData()
        {
            //var repo = new Repository();
            //var managersData = repo.AllManagers();
            //Managers = new ObservableCollection<Manager>(managersData);

            //var coachesData = repo.AllCoaches();
            //Coaches = new ObservableCollection<Coach>(coachesData);

            IsEnabled2 = false;
            IsEnabled1 = true;
            Client.BirthDate= new DateTime(2000, 1, 1);
            Client.DateOfValidityFinish = new DateTime(2000, 1, 1);
            Client.DateOfValidityStart = new DateTime(2000, 1, 1);


        }


        public void Edit()
        {
            //З
            LoadData();


        }

        public void Save()
        {
            
            var repo = new Repository();
           
            if (addOrEdit)
            {
                repo.AddNewClient(_client);

               
            }
            else
            {
                repo.EditClient(_client);
            }

            // Нужна проверка, что заполнены все обязательные поля
        }

    }
}

