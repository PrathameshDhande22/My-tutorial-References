using System;


namespace Tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            // DB First Approach
            //_01_DB_First_Approach.DBFirstApproach();

            // DB First Approach with Querying
            //_02_DB_First_Querying.QueryingInEF();

            // Checking the Entity State of a paraticular entity
            //_03_DB_First_Check_Entity_State.CheckTheEntityState();

            // Asynchronous Programming in Entity Framework
            //_04_DB_First_Asynchronus.AsynchronousProgramming().Wait();

            // Bulk Operations like Insert, Update and Delete
            //_05_DB_First_BULK_Operations.BulkOperations();

            // Handling the Concurrency
            //_06_DB_First_Approach_Handling_Concurrency.HandleConcurrency();

            // Calling the Stored Procedure in EF
            //_07_DB_First_Approach_Stored_Procedure.CallingStoredProcedureinEF();

            // Crud Operation with Stored Procedure in EF
            //_08_DB_First_CRUD_Stored_Procedure.CRUDStored_Procedure();

            // DBChangeTracker to track the entites in the EF.
            //_09_DB_First_DBChange_Tracker.DBChangeTrackerInEF();

            // Enum Support in EF
            //_10_DB_First_Enum.EnumSupport();

            // Views in EF
            //_11_DB_First_Views.ViewsinEf();

            // Calling the Functions in EF
            //_12_DB_First_Functions.SQLFunctioninEF();

            // Transaction supports in EF
            //_13_DB_First_Transactions.TransactionSupportinEF();

            // Many to Many
            _14_DB_First_Many_to_many.ManytoMany();
        }
    }
}
