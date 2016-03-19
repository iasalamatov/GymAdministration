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
        public void FindClientByID()
        {
          var clnt = new Client  { FirstName = "Ilya", LastName = "Salamatov", BirthDate = new DateTime(1994, 4, 4), DateOfValidityStart = new DateTime(2016, 03, 09), DateOfValidityFinish = new DateTime(2017, 03, 09) };
          var repo = new Repository();
            Assert.AreEqual(clnt, repo.FindClient(1));
        }
    }
}
