using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial
{
    class _03_DB_First_Check_Entity_State
    {
        public static databasesettings db = new databasesettings();
        public static databasesettings db2 = new databasesettings();
        public static void CheckTheEntityState()
        {
            StudentCheck st = new StudentCheck() { id = 4343523, name = "mark", rollno = 23, school = "AJK School" };
            StudentCheck st2 = new StudentCheck() { id = 37567, name = "denver", rollno = 12, school = "Pillai" };

            // Three methods to check the Entity state

            // using Entry method of DbContext
            // Adding the disconnected entity and not adding the second entity
            db.Entry(st); // Entry method provides the information of a specified entity it returns the DbEntityEntry

            // Checking the entity state
            Console.WriteLine(db.Entry(st).State); // Returns Detached
            Console.WriteLine(db.Entry(st2).State); // Returns Detached
            Console.WriteLine();

            // Changing the entity of its
            db.Entry(st).State = System.Data.Entity.EntityState.Added; // setting its entity property

            // ReChecking the entity state
            Console.WriteLine(db.Entry(st).State);  // Returns Added
            Console.WriteLine(db.Entry(st2).State); // Returns Detached

            Console.WriteLine("State for anohter context object");
            Console.WriteLine(db2.Entry(st).State);
            Console.WriteLine(db2.Entry(st2).State);
            Console.WriteLine();

            // using the Add method of DbSet to add the entity
            db.StudentChecks.Add(st);

            // ReChecking the entity state
            Console.WriteLine(db.Entry(st).State);  // Returns Added
            Console.WriteLine(db.Entry(st2).State); // Returns Detached
            Console.WriteLine();


            Console.WriteLine("Checking the Attach State");
            db.StudentChecks.Attach(st2); // Attach method to add the entities 
            Console.WriteLine(db.Entry(st2).State);
            db.SaveChanges();
            Console.WriteLine(db.Entry(st2).State);
            // ReChecking the entity state
            Console.WriteLine(db.Entry(st).State);  // Returns Added
            Console.WriteLine(db.Entry(st2).State); // Returns Unchanged
            Console.WriteLine();


           /* // Modifiying the class
            st2.school = "BMS School";
            db.StudentChecks.Add(st2);
            Console.WriteLine("Checking before adding");
            Console.WriteLine(db.Entry(st).State);
            //db.Students.Attach(st2);
            //db.SaveChanges();
            // ReChecking the entity state
            Console.WriteLine("\trechecking the entity");
            Console.WriteLine(db.Entry(st).State);  // Returns Added
            Console.WriteLine(db.Entry(st2).State); // Returns Unchanged
            Console.WriteLine();

            StudentCheck stnew = new StudentCheck() { id = 29 }; // The id is assigned is from the database data.
            Console.WriteLine(db.Entry(stnew).State); // Returns Detached
            db.Entry(stnew).State = System.Data.Entity.EntityState.Deleted; // Assigning the state as deleted
            db.Database.Log = Console.Write;

            Console.WriteLine(db.Entry(stnew).State); // Returns Deleted
            //db.SaveChanges(); // Saving the changes deletes that particular id from the tables.
            Console.WriteLine(db.Entry(stnew).State); // Returns Detached



*/





        }
    }
}
