using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public class DbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            // host turi savybę, servises, o mums reikės vieno iš servisų IConfiguration, tam, kad pasiimtume reikalingą konfigūraciją
            using IHost host = Host.CreateDefaultBuilder(args).Build();

            // pasiimame IConfiguration servisą
            IConfiguration config = host.Services.GetRequiredService<IConfiguration>();

            // naudodami servisą pasiimame ConnectionString
            var connectionString = config.GetValue<string>("ConnectionStrings:Prod");

            // sukuriame optionsBuilder, per options paduosime CoursesDbContext savo connection string
            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            // grąžiname sukonfigūruotą CoursesDboContext
            return new MyDbContext(optionsBuilder.Options);
        }
    }
}
