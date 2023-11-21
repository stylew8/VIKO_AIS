using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class DalykasRepository : BaseRepository<Dalykas>
    {
        public DalykasRepository(MyDbContext context) : base(context)
        {
        }

        public async Task CreateNewDalykas(Dalykas x)
        {
            using (var connection = new SqlConnection(AppConfig.GetConnectionString()))
            {
                x.CreatedAt = DateTime.UtcNow;

                await connection.OpenAsync();
                string sql = @"insert into Dalykas (Name,Description,lecturerId,CreatedAt)
                        VALUES (@Name,@Description,@lecturerId, @CreatedAt);";
                await connection.QueryAsync(sql, new
                {
                    Name = x.Name,
                    Description = x.Description,
                    lecturerId = x.lecturerId,
                    CreatedAt = x.CreatedAt,
                });
            }
        }

        public async Task<List<Dalykas>> GetAllDalykus()
        {
            using (var connection = new SqlConnection(AppConfig.GetConnectionString()))
            {
                await connection.OpenAsync();

                string sql = @"select * from Dalykas;";

                var x = await connection.QueryAsync<Dalykas>(sql);

                return x.ToList();
            }
        }

        public async Task<List<Dalykas>> GetDalykaiByLecturerId(int id)
        {
            using (var connection = new SqlConnection(AppConfig.GetConnectionString()))
            {
                await connection.OpenAsync();

                string sql = @"select * from Dalykas";

                var visiDalykai = await connection.QueryAsync<Dalykas>(sql);

                var reikiami = visiDalykai.Where(x => x.lecturerId == id);

                return reikiami.ToList();
            }
        }
    }
}
