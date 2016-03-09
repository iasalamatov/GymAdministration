using GymAdministration.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace GymAdministration
{
    class Repository
    {
        public Client FindClient(int id)
        {
            using (var c = new Context())
            {
                var clnt = c.Clients.FirstOrDefault(cl => cl.id == id);
                return clnt;
            }
        }
        
        public void AddNewClient(string firstName, string lastName, DateTime birthDate, DateTime dateOfValidityStart, DateTime dateOfValidityFinish)
        {
            using (var c = new Context())
            {
                c.Clients.AddOrUpdate(cl => cl.LastName,
                    new Client { FirstName = firstName, LastName = lastName, BirthDate = birthDate, DateOfValidityStart = dateOfValidityStart, DateOfValidityFinish = dateOfValidityFinish });
                c.SaveChanges();
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
        public List<Manager> AllManagers()
       {
            using (var c = new Context())
            {
                var managers = c.Managers.ToList();
                return managers;
            }
       }

        // Все тренеры
        public List<Coach> AllCoaches()
        {
            using (var c = new Context())
            {
                var coaches = c.Coaches.ToList();
                return coaches;
            }
        }
     
        // внести изменения в клиента
        public void EditClient(Client client, string firstName, string lastName, DateTime birthDate, DateTime dateOfValidityStart, DateTime dateOfValidityFinish, string phoneNumber)
        {
            using (var c = new Context())
            {
                client.FirstName = firstName;
                client.LastName = lastName;
                client.BirthDate = birthDate;
                client.DateOfValidityStart = dateOfValidityStart;
                client.DateOfValidityFinish = dateOfValidityFinish;
                client.PhoneNumber = phoneNumber;
                c.Clients.AddOrUpdate(p => p.id,
                    client);
                c.SaveChanges();
            }
        }
    }
}
