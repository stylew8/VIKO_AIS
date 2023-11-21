using Dapper;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProgrammRepository : BaseRepository<Programm>
    {
        public ProgrammRepository(MyDbContext context) : base(context)
        {
        }

        public async Task CreateNewProgramm(Programm x)
        {
            using (var connection = new SqlConnection(AppConfig.GetConnectionString()))
            {
                await connection.OpenAsync();

                x.CreatedAt = DateTime.UtcNow;

                string sql = @"insert into Programm(Semestras,Kursas,DalykoId,ProgrammName,CreatedAt)
                               values(@Semestras,@Kursas,@DalykoId,@ProgrammName,@CreatedAt)";

                await connection.QueryAsync(sql, new
                {
                    ProgrammName = x.ProgrammName,
                    Semestras = x.Semestras,
                    Kursas = x.Kursas,
                    DalykoId = x.DalykoId,
                    CreatedAt = x.CreatedAt
                });

            }

        }

        public async Task<List<Dalykas>> GetAllProgramosDalykus(int kursas, int semestras, string programa)
        {
            var x = new List<Programm>();

            using (var connection = new SqlConnection(AppConfig.GetConnectionString()))
            {
                await connection.OpenAsync();

                string sql = @"select * from Programm WHERE Kursas=@kursas AND Semestras = @semestras AND ProgrammName = @programa;";

                x = (await connection.QueryAsync<Programm>(sql, new
                {
                    kursas = kursas,
                    semestras = semestras,
                    programa = programa
                })).ToList();

            }

            var newList = new List<Dalykas>();

            foreach (var item in x)
            {
                using (var connection = new SqlConnection(AppConfig.GetConnectionString()))
                {
                    await connection.OpenAsync();

                    string sql = @"select * from Dalykas WHERE Id=@id;";

                    var h = await connection.QueryFirstOrDefaultAsync<Dalykas>(sql, new
                    {
                        id = item.DalykoId
                    });

                    if (h != null)
                    {
                        newList.Add(h);
                    }

                    await connection.CloseAsync();
                }
            }

            return newList;
            
        } 

        public async Task<string> GetProgrammNameByDalykoId(int id)
        {
            using (var connection = new SqlConnection(AppConfig.GetConnectionString()))
            {
                await connection.OpenAsync();

                string sql = @"select * from Programm WHERE Id=@id;";

                return (await connection.QueryFirstOrDefaultAsync<Programm>(sql, new
                {
                    id = id
                })).ProgrammName??"ddd";

            }
        }
    }
}
