using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymAdministration.DataBase;
using System.Collections.ObjectModel;
using System.Windows;

namespace GymAdministration
{
    class SettingViewModel : INotifyPropertyChanged
    {
        public string ManagerFirstName { get; set; }
        public string ManagerLastName { get; set; }

        public string CoachFirstName { get; set; }
        public string CoachLastName { get; set; }

        private Client _selectesclient;
        public Client SelectedClient
        {
            get { return _selectesclient; }
            set
            {
                _selectesclient = value;
                OnPropertyChanged("SelectedClient");
            }
        }

        private ObservableCollection<Client> _clients;
        public ObservableCollection<Client> Clients
        {
            get { return _clients; }
            set
            {
                _clients = value;
                OnPropertyChanged("Clients");
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

       
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public SettingViewModel()
        {
            LoadData();
        }
        
        private async void LoadData()
        {
            var rep = Factory.GetRepository();

            {
                var dataClient = await rep.AllClients();
                Clients = new ObservableCollection<Client>(dataClient);
            }
            var dataManagers = await rep.AllManagers();
            Managers = new ObservableCollection<Manager>(dataManagers);

            var dataCoaches = await rep.AllCoaches();
            Coaches = new ObservableCollection<Coach>(dataCoaches);

            _isEnabled1 = false;

            rep.ClientAdded += cl => Clients.Add(cl);
            rep.ManagerAdded += mn => Managers.Add(mn);
            rep.CoachAdded += co => Coaches.Add(co);
            rep.CoachRemove += co => Coaches.Remove(co);
            rep.ManagerRemove += mn => Managers.Remove(mn);
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


        public void ShowActiveClient()
        {
            if (SelectedClient != null)
            {
                var window = new ClientWindow(SelectedClient);
                window.ShowDialog();
            }
        }

        public void SaveManager()
        {
            try
            {
                if (String.IsNullOrEmpty(ManagerFirstName)) throw new ArgumentException("First name can not be empty.");
                if (String.IsNullOrEmpty(ManagerLastName)) throw new ArgumentException("Last name can not be empty.");  
                var rep = Factory.GetRepository();
                var manager = new Manager();
                if (_addOrEdit)
                {
                    manager.FirstName = ManagerFirstName;
                    manager.LastName = ManagerLastName;
                }
                else
                {
                    SelectedManager.FirstName = ManagerFirstName;
                    SelectedManager.LastName = ManagerLastName;
                    manager = _selectedManager;
                }
                IsEnabled1 = false;
                rep.SaveManager(manager);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void SaveCoach()
        {
            try
            {
                if (String.IsNullOrEmpty(CoachFirstName)) throw new ArgumentException("First name can not be empty.");
                if (String.IsNullOrEmpty(CoachLastName)) throw new ArgumentException("Last name can not be empty.");
                var rep = Factory.GetRepository();
                var coach = new Coach();
                if (_addOrEdit)
                {
                    coach.FirstName = CoachFirstName;
                    coach.LastName = CoachLastName;
                }
                else
                {
                    SelectedCoach.FirstName = CoachFirstName;
                    SelectedCoach.LastName = CoachLastName;
                    coach = _selectedCoach;
                }
                IsEnabled1 = false;
                rep.SaveCoach(coach);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool _addOrEdit;

        public void Edit()
        {
            _addOrEdit = false;
            IsEnabled1 = true;
        }

        public void Add()
        {
            _addOrEdit = true;
            IsEnabled1 = true;
        }

        public void RemoveManager()
        {
            if (SelectedManager != null)
            {
                var repo = Factory.GetRepository();
                repo.RemoveManager(SelectedManager);
            }

        }

        public void RemoveCoach()
        {
            if (SelectedCoach != null)
            {
                var repo = Factory.GetRepository();
                repo.RemoveCoach(SelectedCoach);
            }

        }

        
    }
}
