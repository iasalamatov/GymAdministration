namespace GymAdministration.Migrations
{
    using GymAdministration.DataBase;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GymAdministration.DataBase.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GymAdministration.DataBase.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
          //  var man = context.Managers.First(m => m.FirstName == "Ilya");
          //  context.Managers.Remove(man);
            //   context.Clients.AddOrUpdate(
            //    p => p.LastName,
            //    new Client { FirstName = "Ilya", LastName = "Salamatov", BirthDate = new DateTime(1994, 4, 4), DateOfValidityStart = new DateTime(2016, 03, 09), DateOfValidityFinish = new DateTime(2017, 03, 09) });
            //context.SaveChanges();
            var v = context.Visits.FirstOrDefault(p => p.id == 9);
            var v1 = context.Visits.FirstOrDefault(p => p.id == 10);
            var v2 = context.Visits.FirstOrDefault(p => p.id == 13);
            var v3 = context.Visits.FirstOrDefault(p => p.id == 15);
            var v4 = context.Visits.FirstOrDefault(p => p.id == 16);
            var v5 = context.Visits.FirstOrDefault(p => p.id == 17);
            var v6 = context.Visits.FirstOrDefault(p => p.id == 18);
            var v7 = context.Visits.FirstOrDefault(p => p.id == 1006);
            var v8 = context.Visits.FirstOrDefault(p => p.id == 1007);
            context.Visits.Remove(v);
            context.Visits.Remove(v1);
            context.Visits.Remove(v2);
            context.Visits.Remove(v3);
            context.Visits.Remove(v4);
            context.Visits.Remove(v5);
            context.Visits.Remove(v6);
            context.Visits.Remove(v7);
            context.Visits.Remove(v8);
            context.SaveChanges();
        }
    }
}