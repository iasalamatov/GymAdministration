using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymAdministration.DataBase
{
    public class Context : DbContext
    {
        public DbSet<Manager> Managers { get; set; }

        public DbSet<Coach> Coaches { get; set; } 

        public DbSet<Client>  Clients{ get; set; }

        public Context() : base("GymAdmin")
        {

        }
    }
}
