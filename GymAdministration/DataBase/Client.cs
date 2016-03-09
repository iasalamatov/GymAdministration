using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Object;
//using System.Windows.Controls;
using GymAdministration.DataBase;
using System.ComponentModel.DataAnnotations;

namespace GymAdministration
{
     public class Client
    {
        public int id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public DateTime DateOfValidityStart { get; set; }
        [Required]
        public DateTime DateOfValidityFinish { get; set; }
        public bool IsHere { get; set; }
     //   [Required]
     //   public Image Photo { get; set; }
        public Manager Manager { get; set; }
        public Coach Coach { get; set; }
    }
}
