using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymAdministration.DataBase
{
    public class Visit
    {
        public int id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime FinishTime { get; set; }

        public Client Client { get; set; }
    }
}
