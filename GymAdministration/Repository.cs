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
            }
        }

        public void FinishVisitTime(Client client)
        {
            using (var c = new Context())
            {
                //   var lastVisit = from item in client.Visits
                //                   where (item.id == client.Visits.Count - 1)
                //                   select item;

                var lastVisit = client.Visits.LastOrDefault();

                lastVisit.FinishTime = DateTime.Now;
                c.SaveChanges();
            }
        }

        public void SaveStatisticsToTxt()
        {
            using (var c = new Context())
            {
                string filename = "stat_" + DateTime.Now.ToLongDateString();
                string str = "..//..//" + filename + ".txt";
                string path = @str;

                if (!File.Exists(path))
                {
                    string createText = "Statistics for:" + DateTime.Now.ToLongDateString() + Environment.NewLine;
                    File.WriteAllText(path, createText, Encoding.UTF8);
                }

                string info;
                foreach (var item in c.Visits)
                {
                    if (item.StartTime >= DateTime.Today)
                    {
                        info = item.Client.LastName + " " + item.Client.FirstName + ": " + item.StartTime.ToString() + " " + item.FinishTime.ToString();
                        File.AppendAllText(path, info, Encoding.UTF8);
                    }
                }
            }

        }

        public void RemoveManager(Manager manager)
        {

            using (var c = new Context())
            {
                c.Managers.Remove(manager);
                c.SaveChanges();
            }
        }

        public void RemoveCoach(Coach coach)
        {

            using (var c = new Context())
            {
                c.Coaches.Remove(coach);
                c.SaveChanges();
            }
        }

    }
}


