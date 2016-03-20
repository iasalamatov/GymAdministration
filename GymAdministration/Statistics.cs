using GymAdministration.DataBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
                string Time =  "Обновления на время: " + DateTime.Now.ToShortTimeString() + Environment.NewLine;

                File.AppendAllText(path, Time, Encoding.UTF8);

                string ATOV = "Среднее время посещения зала всеми клиентами: " + AverageTimeOfVisit() + Environment.NewLine;

                File.AppendAllText(path, ATOV, Encoding.UTF8);

                string PeopleInTheGym = "Количество человек в зале: " + TheAmountOfPeopleInTheGym().ToString() + Environment.NewLine;

                File.AppendAllText(path, PeopleInTheGym, Encoding.UTF8);


                string PeopleWhoWereAtTheGymToday = "Визитов за сегодня: " + AllPeopleWhoVisitTheGymToday().ToString() + " визитов(а)"+ Environment.NewLine;

                File.AppendAllText(path, PeopleWhoWereAtTheGymToday, Encoding.UTF8);

                //string info;
                //foreach (var item in c.Visits)
                //{
                //    if (item.StartTime >= DateTime.Today)
                //    {
                //        info = item.Client.LastName + " " + item.Client.FirstName + ": " + item.StartTime.ToString() + " " + item.FinishTime.ToString();
                //        File.AppendAllText(path, info, Encoding.UTF8);
                //    }
                //}
                MessageBox.Show("Статистика сохранена в файл!");
            }
        } 
  
        // Среднее время посещения зала всеми клиентами.
        public string AverageTimeOfVisit()
        {
            double result = 0;
            int cnt = 0;
            using (var c = new Context())
            {
                DateTime dt = new DateTime(2000, 04, 04);
                foreach (var item in c.Visits)
                {
                    if(item.FinishTime != dt)
                    {
                        result += (item.FinishTime - item.StartTime).TotalMinutes;
                        cnt++;
                    }
                }

                result = result / cnt;
                int hours = (int)result / 60;
                int minutes = (int)result - (hours * 60);
                string str = hours.ToString() + " " + "часов(а)" + " " + minutes.ToString() + " - " + "минут(ы)";
                return str;
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
        //Кол-во людей поситивших зал за сегодня
        public int AllPeopleWhoVisitTheGymToday()
        {
            int count = 0;
            using (var c = new Context())
            {
                
                foreach (var item in c.Visits)
                {
                    if (item.StartTime >= DateTime.Today)
                        count++;
                }
            }
            return count;
        }

    }
}
