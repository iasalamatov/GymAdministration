using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GymAdministration;
using GymAdministration.DataBase;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace GymAdministrationTest
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void FindAllClientsByLastNameTest()
        {
            var repo = new Repository();
            string _lastName = "Ignash";
          //  int count = 0;
            int expectedCount = 1;

            var lst = repo.FindAllClientsByLastName(_lastName);

            int count = lst.Count();
           
            Assert.AreEqual(expectedCount, count);
        }
    }
}
