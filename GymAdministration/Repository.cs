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
            }
        }

        public void AddNewClient(string firstName, string lastName, DateTime birthDate, DateTime dateOfValidityStart, DateTime dateOfValidityFinish, string phoneNumber)
        {
            using (var c = new Context())
            {
                c.Clients.AddOrUpdate(cl => cl.LastName,
                    new Client { FirstName = firstName, LastName = lastName, BirthDate = birthDate, DateOfValidityStart = dateOfValidityStart, DateOfValidityFinish = dateOfValidityFinish, PhoneNumber = phoneNumber });
            }
        }

      //  public List<Client> FindAllClientsByLastName(string lastName)
      //  {
      //      using (var c = new Context())
      //      {
      //          List<Client> clnts = from cl in c.Clients
      //                               where cl.LastName == lastName
      //                               select cl;
      //          return clnts;
      //      }
      //  }
    }
}
