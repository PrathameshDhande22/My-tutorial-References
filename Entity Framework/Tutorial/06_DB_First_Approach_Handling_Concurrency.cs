namespace Tutorial
{
    class _06_DB_First_Approach_Handling_Concurrency
    {
        public static void HandleConcurrency()
        {
            // These is the user 1
            using (databasesettings user1 = new databasesettings())
            {
                // Accessing the same data which is primary key as 33
                StudentCheck student1 = user1.StudentChecks.Find(33);

                // Updating its school
                student1.school = "User1School";

                // Saving the Changes
                user1.SaveChanges();
            }

            // These is the User 2
            using (databasesettings user2 = new databasesettings())
            {
                // Accessing the same data which is primary key as 33
                StudentCheck student1 = user2.StudentChecks.Find(33);

                // Updating its school
                student1.school = "User2School";

                // Saving the Changes
                user2.SaveChanges();
            }
        }
    }
}
