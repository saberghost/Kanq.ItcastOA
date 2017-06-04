namespace Kanq.ItcastOA.Model.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Kanq.ItcastOA.Model.OAEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Kanq.ItcastOA.Model.OAEntities";
        }

        protected override void Seed(Kanq.ItcastOA.Model.OAEntities context)
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
            context.UserInfo.AddOrUpdate(
                new Model.UserInfo() { ID = 1, UName = "admin", UPwd = "admin" ,DelFlag=0,ModifiedOn=DateTime.Now,SubTime=DateTime.Now,Remark="≤‚ ‘"}
                );
        }
    }
}
