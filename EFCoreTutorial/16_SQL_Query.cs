using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTutorial
{
    internal class _16_SQL_Query : Runner
    {
        public async Task RunAsync()
        {
            var context = new ApplicationDbContext();

            // execute sql query
            var results = context.Students.FromSqlInterpolated($"SELECT * FROM dbo.Students WHERE Id={10}").FirstOrDefault();
            Console.WriteLine(results);

            // Execute sql raw
            var results_raw = context.Students.FromSqlRaw("SELECT * FROM dbo.Students WHERE Id=@id", new SqlParameter("@id", 10)).FirstOrDefault();
            Console.WriteLine(results_raw);

            // Execute commands
            var results_commands = context.Database.ExecuteSql($"UPDATE dbo.Students SET Age={25} WHERE Id={10};");
            Console.WriteLine(results_commands);
        }
    }
}
