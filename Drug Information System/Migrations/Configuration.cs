using System.IO;
using System.Reflection;
using System.Text;
using CsvHelper;
using Drug_Information_System.Models;

namespace Drug_Information_System.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Drug_Information_System.Context.DrugInformationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            
        }

        protected override void Seed(Drug_Information_System.Context.DrugInformationContext context)
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


            //Assembly assembly = Assembly.GetExecutingAssembly();
            //string resourceName = "Drug_Information_System.Domain.SeedData.PharmaCompanies.csv";
            //using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            //{
            //    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            //    {
            //        CsvReader csvReader = new CsvReader(reader);
            //        csvReader.Configuration.WillThrowOnMissingField = false;
            //        var pharma = csvReader.GetRecords<PharmaCompany>().ToArray();
            //        context.PharmaCompanies.AddOrUpdate(c => c.PharmaName, pharma);
            //    }
            //}

        }
    }
}
