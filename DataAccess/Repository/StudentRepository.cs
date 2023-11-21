using Dapper;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class StudentRepository : BaseRepository<Student>
    {
        public StudentRepository(MyDbContext context) : base(context)
        {
        }

        public async Task<int> CreateAdminAsync(Person x)
        {
            using (var connection = new SqlConnection(AppConfig.GetConnectionString()))
            {

                x.CreatedAt = DateTime.UtcNow;

                await connection.OpenAsync();
                string sql = @"insert into Person (Premissions, Valstybe,Miestas,Gatve,StudPastas,Telefonas,AsmPastas,Fakultetas,Name,Surname, CreatedAt)
                        VALUES (@Premissions, @Valstybe,@Miestas,@Gatve,@StudPastas,@Telefonas,@AsmPastas,@Fakultetas,@Name,@Surname,@CreatedAt);
                        SELECT CAST(SCOPE_IDENTITY() as int);";
                return await connection.QuerySingleAsync<int>(sql, new
                {
                    Premissions = "admin",
                    Valstybe = x.Valstybe,
                    Miestas = x.Miestas,
                    Gatve = x.Gatve,
                    StudPastas = x.StudPastas,
                    Telefonas = x.Telefonas,
                    AsmPastas = x.AsmPastas,
                    Fakultetas = x.Fakultetas,
                    Name = x.Name,
                    Surname = x.Surname,
                    CreatedAt = x.CreatedAt
                }) ;
            }
        }

        public async Task<int> CreateLecturerAsync(Student x)
        {
            using (var connection = new SqlConnection(AppConfig.GetConnectionString()))
            {
                x.CreatedAt = DateTime.UtcNow;

                await connection.OpenAsync();
                string sql = @"insert into Person (Login,Password,Premissions, Valstybe,Miestas,Gatve,StudPastas,Telefonas,AsmPastas,Fakultetas,Name,Surname, CreatedAt)
                        VALUES (@Login,@Password,@Premissions, @Valstybe,@Miestas,@Gatve,@StudPastas,@Telefonas,@AsmPastas,@Fakultetas,@Name,@Surname,@CreatedAt);
                        SELECT CAST(SCOPE_IDENTITY() as int);";
                return await connection.QuerySingleAsync<int>(sql, new
                {
                    Login = x.Name,
                    Password = Encrypt.HashPassword(x.Surname),
                    Premissions = x.Premissions,
                    Valstybe = x.Valstybe,
                    Miestas = x.Miestas,
                    Gatve = x.Gatve,
                    StudPastas = x.StudPastas,
                    Telefonas = x.Telefonas,
                    AsmPastas = x.AsmPastas,
                    Fakultetas = x.Fakultetas,
                    Name = x.Name,
                    Surname = x.Surname,
                    CreatedAt = x.CreatedAt
                });
            }
        }

        public async Task<int> CreateStudentAsync(Student x)
        {
            using (var connection = new SqlConnection(AppConfig.GetConnectionString()))
            {
                x.CreatedAt = DateTime.UtcNow;

                await connection.OpenAsync();
                string sql = @"insert into Person (Premissions, Valstybe,Miestas,Gatve,StudPastas,Telefonas,AsmPastas,Fakultetas,Name,Surname,Grupe, Kursas, Semestras, Programa, CreatedAt)
                        VALUES ( @Premissions, @Valstybe,@Miestas,@Gatve,@StudPastas,@Telefonas,@AsmPastas,@Fakultetas,@Name,@Surname, @Grupe, @Kursas, @Semestras,@Programa, @CreatedAt);
                        SELECT CAST(SCOPE_IDENTITY() as int);";
                return await connection.QuerySingleAsync<int>(sql, new
                {
                    Premissions = "student",
                    Valstybe = x.Valstybe,
                    Miestas = x.Miestas,
                    Gatve = x.Gatve,
                    StudPastas = x.StudPastas,
                    Telefonas = x.Telefonas,
                    AsmPastas = x.AsmPastas,
                    Fakultetas = x.Fakultetas,
                    Name = x.Name,
                    Surname = x.Surname,
                    Grupe = x.Grupe,
                    Kursas = x.Kursas,
                    Semestras = x.Semestras,
                    Programa = x.Programa,
                    CreatedAt = x.CreatedAt
                });
            }
        }

        public async Task<Student> GetPersonByLogin(string login)
        {
            using (var connection = new SqlConnection(AppConfig.GetConnectionString()))
            {
                await connection.OpenAsync();

                string sql = "select * From Person where Login=@login";

                var x = await connection.QueryFirstOrDefaultAsync<Student>(sql, new { login = login });

                return x;
            }
        }

        public async Task<List<Student>> GetAllLecturers()
        {
            using (var connection = new SqlConnection(AppConfig.GetConnectionString()))
            {
                await connection.OpenAsync();

                string name = "lecturer";

                string sql = "select Id,Name,Surname From Person where Premissions=@name";

                var x = await connection.QueryAsync<Student>(sql, new {name});

                return x.ToList();
            }
        }

        public async Task<List<Student>> GetAllStudentsByProgrammName(string grupe)
        {
            using (var connection = new SqlConnection(AppConfig.GetConnectionString()))
            {
                await connection.OpenAsync();

                string sql = "select * From Person where Grupe=@grupe";

                 return (await connection.QueryAsync<Student>(sql, new { grupe = grupe })).ToList();
            }
        }

        public async Task<bool> UpdateStudentAsync(Student student)
        {
            if (student == null || string.IsNullOrEmpty(student.Login))
                throw new ArgumentException("Student or Login cannot be null or empty.");

            using (var connection = new SqlConnection(AppConfig.GetConnectionString()))
            {
                await connection.OpenAsync();

                string sql = @"
                    UPDATE Person SET
                        Login = @Login,
                        Password = @Password,
                        Premissions = @Premissions,
                        Valstybe = @Valstybe,
                        Miestas = @Miestas,
                        Gatve = @Gatve,
                        Telefonas = @Telefonas,
                        AsmPastas = @AsmPastas,
                        Fakultetas = @Fakultetas,
                        Name = @Name,
                        Surname = @Surname,
                        Grupe = @Grupe,
                        Kursas = @Kursas,
                        Semesrtas = @Semestras,
                        Programa = @Programa
                    WHERE Id = @id";

                var result = await connection.ExecuteAsync(sql, new
                {
                    student.Login,
                    student.Password,
                    student.Premissions,
                    student.Valstybe,
                    student.Miestas,
                    student.Gatve,
                    student.Telefonas,
                    student.AsmPastas,
                    student.Fakultetas,
                    student.Name,
                    student.Surname,
                    student.Grupe,
                    student.Kursas,
                    student.Semestras,
                    student.Programa,
                    student.Id
                });

                return result > 0;
            }
        }
    }
}
