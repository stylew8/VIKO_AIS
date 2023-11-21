using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MarksRepository : BaseRepository<Marks>
    {
        public MarksRepository(MyDbContext context) : base(context)
        {
        }

        public async Task CreateNewMark(Marks mark, List<Student> ids)
        {

            foreach (Student person in ids)
            {
                using (var connection = new SqlConnection(AppConfig.GetConnectionString()))
                {
                    mark.CreatedAt = DateTime.UtcNow;

                    await connection.OpenAsync();
                    string sql = @"insert into Marks(DalykoId,Description,Procentas,CreatedAt,StudentId)
                        VALUES (@dalykoId,@description,@procentas,@createdAt,@studentId);";
                    await connection.QueryAsync(sql, new
                    {
                        dalykoId = mark.DalykoId,
                        description = mark.Description,
                        procentas = mark.Procentas,
                        createdAt = mark.CreatedAt,
                        studentId = person.Id
                    });
                }
            }
        }

        public async Task<List<Marks>> GetAllMarksByDalykoId(int id)
        {
            using (var connection = new SqlConnection(AppConfig.GetConnectionString()))
            {

                await connection.OpenAsync();
                string sql = @"SELECT * FROM Marks WHERE DalykoId = @id";

                return (await connection.QueryAsync<Marks>(sql, new
                {
                    id = id
                })).ToList();


            }
        }

        public async  Task<List<string>> GetAllUniqDescByDalykoId(int id)
        {
            using (var connection = new SqlConnection(AppConfig.GetConnectionString()))
            {

                await connection.OpenAsync();
                string sql = @"SELECT DISTINCT Description FROM Marks WHERE DalykoId = @id";

                return (await connection.QueryAsync<string>(sql, new
                {
                    id = id
                })).ToList();

                
            }
        }

        public async Task UpdateMarkByStudentByProcentasAndByDalykas(Dalykas dalykas, string uzKa, Student student, int mark)
        {
            using (var connection = new SqlConnection(AppConfig.GetConnectionString()))
            {
                await connection.OpenAsync();
                string sql = @"
                                UPDATE Marks
                                SET Mark = @newMark,
                                    DateOfMark = @date
                                WHERE DalykoId = @id AND Procentas = @uzka AND StudentId = @studentid";

                int affectedRows = await connection.ExecuteAsync(sql, new
                {
                    newMark = mark,
                    id = dalykas.Id,
                    uzka = uzKa,
                    studentid = student.Id,
                    date = DateTime.Now
                });

            }

        }
    }
}
