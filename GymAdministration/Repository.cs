using GymAdministration.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using System.IO;
using System.Windows;

namespace GymAdministration
{
   public class Repository
    {
        public event Action<Client> ClientAdded;
        public event Action<Coach> CoachAdded;
        public event Action<Manager> ManagerAdded;

        public event Action<Coach> CoachRemove;
        public event Action<Manager> ManagerRemove;

        

        public Client FindClient(int id)
        {
            using (var c = new Context())
            {
                var clnt = c.Clients.FirstOrDefault(cl => cl.id == id);
                return clnt;
            }
        }

        public void SaveClient(Client client)
        {
            using (var c = new Context())
            {
                c.Clients.AddOrUpdate(cl => cl.id,
                    client);

                c.SaveChanges();

                if (ClientAdded != null)
                    ClientAdded(client);
            }
        }

        public void AddNewClient(string firstName, string lastName, DateTime birthDate, DateTime dateOfValidityStart, DateTime dateOfValidityFinish, string phoneNumber)
        {
            using (var c = new Context())
            {
                c.Clients.AddOrUpdate(cl => cl.LastName,
                    new Client { FirstName = firstName, LastName = lastName, BirthDate = birthDate, DateOfValidityStart = dateOfValidityStart, DateOfValidityFinish = dateOfValidityFinish, PhoneNumber = phoneNumber });
                c.SaveChanges();
            }

        }

        public List<Client> FindAllClientsByLastName(string lastName)
        {
            using (var c = new Context())
            {
                List<Client> OurClients = new List<Client>();
                foreach (var item in c.Clients)
                {
                    if (item.LastName == lastName)
                        OurClients.Add(item);
                }

                return OurClients;
            }
        }

        // Все манагеры
        public List<Manager> Managers()
        {
            using (var c = new Context())
            {
                var managers = c.Managers.ToList();
                return managers;
            }
        }
        public async Task<IEnumerable<Manager>> AllManagers()
        {
            using (var c = new Context())
            {
                return await c.Managers.ToListAsync();
            }
        }

        public void SaveManager(Manager manager)
        {
            using(var c = new Context())
            {
                c.Managers.AddOrUpdate(cl => cl.id,
                    manager);

                c.SaveChanges();

                if (ManagerAdded != null)
                    ManagerAdded(manager);
            }
        }
        public void SaveCoach(Coach coach)
        {
            using (var c = new Context())
            {
                c.Coaches.AddOrUpdate(cl => cl.id,
                    coach);

                c.SaveChanges();

                if (CoachAdded != null)
                    CoachAdded(coach);
            }
        }

        // Все тренеры
        public List<Coach> Coaches()
        {
            using (var c = new Context())
            {
                var coaches = c.Coaches.ToList();
                return coaches;
            }
        }
        public async Task<IEnumerable<Coach>> AllCoaches()
        {
            using (var c = new Context())
            {
                return await c.Coaches.ToListAsync();
            }
        }

        public async Task<IEnumerable<Client>> AllClients()
        {
            using (var c = new Context())
            {
                return await c.Clients.ToListAsync();
            }
        }
        // внести изменения в клиента
     //   public void SaveClient(Client client)
     //   {
     //       using (var c = new Context())
     //       {
     //
     //           c.Clients.AddOrUpdate(p => p.id,
     //               client);
     //           c.SaveChanges();
     //       }
     //   }

        public void NewVisitTime(Client client)
        {
            int clients = 0;
            using(var c = new Context())
            {
                foreach (var item in c.Clients)
	{
        if (item.IsHere == true)
            clients++;
	}

            }
            if (clients < 2)
            {
                if (client.DateOfValidityStart <= DateTime.Today && client.DateOfValidityFinish >= DateTime.Today)
                {
                    using (var c = new Context())
                    {

                        var visit = new Visit();
                        visit.StartTime = DateTime.Now;
                        visit.FinishTime = new DateTime(2000, 04, 04);
                        visit.Client = c.Clients.FirstOrDefault(p => p.id == client.id);
                        c.Visits.AddOrUpdate(p => p.id,
                            visit);
                        c.Clients.FirstOrDefault(p => p.id == client.id).IsHere = true;
                        
                        c.SaveChanges();
                        MessageBox.Show(visit.Client.LastName.ToString() + " is in the Gym.");
                    }
                }
                else
                {
                    throw new ArgumentException("The card is not active!");
                }
            }
            else
            {
                MessageBox.Show("The Gym is full, waiting for free place.");
            }
        }

        public void FinishVisitTime(Client client)
        {
            using (var c = new Context())
            {
                   var lastVisit = from item in c.Visits
                                   where (item.Client.id == client.id)
                                   select item;
             //   visit.Client = c.Clients.FirstOrDefault(p => p.id == client.id);
             //   var lastVisit = c.Visits.LastOrDefault();
                   int llastVisit = lastVisit.Count();
                 //  MessageBox.Show(llastVisit.ToString());
                   var v = lastVisit.ToList();
                   c.Clients.FirstOrDefault(p => p.id == client.id).IsHere = false;
                v[llastVisit-1].FinishTime = DateTime.Now;
                c.SaveChanges();
                MessageBox.Show(v[llastVisit - 1].Client.LastName.ToString() + " left the Gym.");
            }
        }

        //public void SaveStatisticsToTxt()
        //{
        //    using (var c = new Context())
        //    {
        //        string filename = "stat_" + DateTime.Now.ToLongDateString();
        //        string str = "..//..//" + filename + ".txt";
        //        string path = @str;

        //        if (!File.Exists(path))
        //        {
        //            string createText = "Statistics for:" + DateTime.Now.ToLongDateString() + Environment.NewLine;
        //            File.WriteAllText(path, createText, Encoding.UTF8);
        //        }

        //        string info;
        //        foreach (var item in c.Visits)
        //        {
        //            if (item.StartTime >= DateTime.Today)
        //            {
        //                info = item.Client.LastName + " " + item.Client.FirstName + ": " + item.StartTime.ToString() + " " + item.FinishTime.ToString();
        //                File.AppendAllText(path, info, Encoding.UTF8);
        //            }
        //        }
        //    }

        //}

        public void RemoveManager(Manager manager)
        {

            using (var c = new Context())
            {
                var man = c.Managers.FirstOrDefault(m => m.id == manager.id);
                c.Managers.Remove(man);
                c.SaveChanges();

                if (ManagerRemove != null)
                    ManagerRemove(manager);
            }
        }

        public void RemoveCoach(Coach coach)
        { 

            using (var c = new Context())
            {
                c.Coaches.Remove(coach);
                c.SaveChanges();

                if (CoachRemove != null)
                    CoachRemove(coach);
            }
        }

    }
}


