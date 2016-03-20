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
        private Coach _selectedCoach;

        public ObservableCollection<Coach> Coaches
        {
            get { return _coaches; }
            set
            {
                _coaches = value;
                OnPropertyChanged("Coaches");
            }
        }
        public Coach SelectedCoach
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

        private int _isHereOp;
        public int IsHereOp
        {
            get { return _isHereOp; }

            set
            {
                if (_isHereOp == value)
                {
                    return;
                }
                _isHereOp = value;
                OnPropertyChanged("IsHereOp");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }



        public ClientViewModel(Client cl)
        {
            _client = new Client();
            if (cl != null)
            {
                Client = cl;
                SelectedManager = Client.Manager;
                SelectedCoach = Client.Coach;
                IsEnabled1 = false;
                IsEnabled2 = true;
                IsHereOp = 100;
                addOrEdit = false;
            }
            else
            {
                //если был нажат Add

                addOrEdit = true;
                Client.BirthDate = new DateTime(2000, 1, 1);
                Client.DateOfValidityFinish = new DateTime(2000, 1, 1);
                Client.DateOfValidityStart = new DateTime(2000, 1, 1);               
                LoadData();
            }
        }


        private async void LoadData()
        {
            var rep = new Repository();
            var dataManagers = await rep.AllManagers();
            Managers = new ObservableCollection<Manager>(dataManagers);

            var dataCoaches = await rep.AllCoaches();
            Coaches = new ObservableCollection<Coach>(dataCoaches);

            IsEnabled2 = false;
            IsEnabled1 = true;
            IsHereOp = 0;
            
        }


        public void Edit()
        {            
            LoadData();
        }

        public void Save()
        {
            try
            {
                if (String.IsNullOrEmpty(Client.FirstName) && String.IsNullOrEmpty(Client.LastName)) throw new Exception("First name or Last name can not be empty.");
                
                if (Client.DateOfValidityFinish < Client.DateOfValidityStart && Client.BirthDate > DateTime.Now) throw new ArgumentException("Wrong date.");
                Client.Manager = SelectedManager;
                Client.Coach = SelectedCoach;
                var repo = Factory.GetRepository();

                repo.SaveClient(_client);
                IsEnabled1 = false;
                IsEnabled2 = true;
                IsHereOp = 100;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            // Нужна проверка, что заполнены все обязательные поля
        }

        public void Visit()
        {
            var repo = Factory.GetRepository();
            string s = string.Format("{0}", _client.IsHere);
            MessageBox.Show(s);

            if (_client.IsHere) repo.NewVisitTime(_client);
            else repo.FinishVisitTime(_client);
        }

    }
}

