using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailspin.Surveys.Data.DataModels;

namespace Tailspin.Surveys.Data.DesignTimeFactory
{
    public class DesignTimeFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            //           IConfigurationRoot configuration = new ConfigurationBuilder()
            //                .SetBasePath(Directory.GetCurrentDirectory())
            //                .AddJsonFile("appsettings.json")
            //                .Build();
            //            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            //            var SurveysConnectionString = configuration.GetConnectionString("DefaultConnection");
            ////          builder.UseSqlServer(SurveysConnectionString, b => b.MigrationsAssembly("Tailspin.Surveys.Data"));

            //            builder.UseNpgsql(SurveysConnectionString, b => b.MigrationsAssembly("Tailspin.Surveys.Data"));

            //  return new ApplicationDbContext("SurveysConnectionString": "Server=localhost;Database=citus;Port=2001;User Id=citus;Password=12345;");



            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseNpgsql( "Server=localhost;Database=citus;Port=2001;User Id=citus;Password=12345;");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }

}
  
        




    

