

namespace Tutorial
{
    class Branch
    {
        public int Id { get; set; }
        public string Branchname { get; set; } = string.Empty;
    }

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Branchid { get; set; }
        public int Age { get; set; }
    }

    class _15_Transactions
    {
        public static void TransactionsinDapper()
        {
            string connection = "Server=localhost;Database=sampleDB;Trusted_Connection=true;TrustServerCertificate=True;Data Source=SS-2024-05-015\\PRATHAMESH";
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();

            // you can also use the power of transaction in dapper too.
            SqlTransaction transaction = conn.BeginTransaction();
            int branchid = 7;

            List<Branch> branches = conn.Query<Branch>("select distinct * from branch", transaction: transaction).ToList();
            List<int> branchId = branches.Select<Branch, int>((branch) =>
            {
                return branch.Id;
            }).ToList();
            if (!branchId.Contains(branchid))
            {
                conn.Execute("insert into branch values (@id,@branchname)", new { id = branchid, branchname = "Civil" }, transaction: transaction);
            }

            conn.Execute($"Insert into student values (431,'Rome',{branchid},45)", transaction: transaction);

            //transaction.Rollback();
            transaction.Commit();



        }
    }
}
