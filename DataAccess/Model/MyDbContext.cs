using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Marks> Marks { get; set; }
        public DbSet<Dalykas> Dalykas { get; set; }
        public DbSet<Programm> Programm { get; set; }



    }
}
