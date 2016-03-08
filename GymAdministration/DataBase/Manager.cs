using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Controls;
using System.ComponentModel.DataAnnotations;

namespace GymAdministration.DataBase
{
    public class Manager
    {
        public int id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; } 
      //  public Image Photo { get; set; }
        public List<Client> Clients { get; set; }
    }
}
