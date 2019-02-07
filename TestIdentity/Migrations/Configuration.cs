using System.Data.Entity.Migrations;
using TestIdentity.Model;

namespace TestIdentity.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            // allow delete model fields [INFO]
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "TestIdentity.Model.ApplicationDbContext";
        }

        protected override void Seed(TestIdentity.Model.ApplicationDbContext context)
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
        }
    }
}
