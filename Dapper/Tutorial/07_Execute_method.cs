

namespace Tutorial
{
    class _07_Execute_method
    {
        public static void ExecuteMethodOfDapper()
        {
            string connection = "Server=localhost;Database=sampleDB;Trusted_Connection=true;TrustServerCertificate=True;Data Source=SS-2024-05-015\\PRATHAMESH";
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            Console.WriteLine("connected to Database : {0}", conn.Database);

            // executing the update statement
            string udeQuery1 = "update student set name=@new_name where name=@old_name";
            int rowsAffected = conn.Execute(udeQuery1, new { new_name = "Tim", old_name = "name1" });
            Console.WriteLine(rowsAffected);

            // executing the insert statement
            string insQuery1 = "insert into student values (@id,@name,@branchid,@age)";
            // passing the null values in the age column of the student table.
            int rowsAffected2 = conn.Execute(insQuery1, new { id = 212, name = "Tommy", branchid = 2, age = (int?)null });
            Console.WriteLine(rowsAffected2);

            // executing the delete statement
            string delQuery = "delete from student where id=@id";
            int rowsAffected3 = conn.Execute(delQuery, new { id = 433 });
            Console.WriteLine(rowsAffected3);

            // You can also execute query with multiple times using array of parameter in the execute method
            string insQuery3 = "insert into student values (@id,@name,@branchid,@age)";
            int rowsAffected4 = conn.Execute(insQuery1, new[]
            {
                new{id=348,name="rambo",branchid=4,age=23},
                new{id=436,name="lee",branchid=2,age=12}
            });
            Console.WriteLine(rowsAffected4); // returns 4

        }
    }
}
