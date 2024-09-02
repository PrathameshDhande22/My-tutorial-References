using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQTOSQL
{
    class _02_Delete_Update_insert
    {
        public static void DMLStatements()
        {
            //insertOperation();
            //DeleteOperation();
            UpdateOperation();

        }

        public static void insertOperation()
        {
            // Get the instance of datacontext
            DataClasses1DataContext dc = new DataClasses1DataContext();

            // Insert changes
            Employee employee = new Employee() { ID = 10, FirstName = "John", LastName = "Dev", Gender = "Male", DepartmentId = 2, Salary = 23000 };

            // Inserting Multiple employees
            Employee emp2 = new Employee() { FirstName = "timbers", LastName = "Lee", Gender = "Female", DepartmentId = 2, Salary = 45000 };

            //dc.Employees.InsertOnSubmit(employee);
            dc.Employees.InsertAllOnSubmit(new List<Employee>() { employee, emp2 });
            // submit the changes
            dc.SubmitChanges();
        }

        public static void DeleteOperation()
        {
            // Delete Operation
            DataClasses1DataContext dc = new DataClasses1DataContext();

            // Select the employee which you want to delete using single method of 
            var employeedelete = dc.Employees.Single(emp => emp.ID == 9);
            // delete the employee using delete on submit method
            dc.Employees.DeleteOnSubmit(employeedelete);
            dc.SubmitChanges();
        }

        public static void UpdateOperation()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();

            // Select an employee from the results
            var employeedata = from emp in dc.Employees
                               where emp.ID == 10 || emp.ID == 11
                               select emp;

            // employees selected for updating
            foreach (var emp in employeedata)
            {
                Console.WriteLine($"id={emp.ID} first_name={emp.FirstName} last_name={emp.LastName} gender={emp.Gender}");
                // changing their salary
                emp.Salary = 40000;
            }

            dc.SubmitChanges();

        }
    }
}
