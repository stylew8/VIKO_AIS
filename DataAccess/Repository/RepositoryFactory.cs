using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class RepositoryFactory
    {

        private readonly DbContextOptions<MyDbContext> _options;

        public RepositoryFactory(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            _options = optionsBuilder.Options;
        }

        public StudentRepository CreateStudentRepository()
        {
            var context = new MyDbContext(_options);
            return new StudentRepository(context);
        }
        
        public DalykasRepository CreateDalykasRepository()
        {
            var context = new MyDbContext(_options);
            return new DalykasRepository(context);
        }

        public MarksRepository CreateMarksRepository()
        {
            var context = new MyDbContext(_options);
            return new MarksRepository(context);
        }
        public ProgrammRepository CreateProgrammRepository()
        {
            var context = new MyDbContext(_options);
            return new ProgrammRepository(context);
        }
    }
}
