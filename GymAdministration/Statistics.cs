using GymAdministration.DataBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymAdministration
{
    public class Statistics
    {
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
        // Среднее время посещения зала всеми клиентами.
        public double AverageTimeOfVisit()
        {
            double result = 0;
            using (var c = new Context())
            {
                foreach (var item in c.Visits)
                {
                    if(item.Client.IsHere != true)
                    {
                        result += (item.FinishTime - item.StartTime).TotalMinutes;
                    }
                }
                return result;
            }
        }

        //Кол-во человек в зале
        public int TheAmountOfPeopleInTheGym()
        {
            int count = 0;
            using(var c = new Context())
            {
                foreach (var item in c.Clients)
                {
                    if (item.IsHere == true)
                        count++;
                }
                return count;
            }
        }

        

    }
}
