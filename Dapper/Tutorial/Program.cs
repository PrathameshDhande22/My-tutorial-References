
using Tutorial;

class Program
{
    static void Main(string[] args)
    {
        // Basic for connecting the sql server with the dapper
        //_01_Connection.ConnectionString();

        // Querying the rows in Database tables
        //_02_Querying.Querying();

        // Querying Multi Mapping or one-to-many relationship
        //_03_MultiMapping_Querying.MultiQuerying();

        // Dapper has the methods like QueryFirst and many in these method implemented
        //_04_Querying_Types.QueryingTypes();

        // to see how much powerfull is the query method of the dapper 
        //_05_Querying_Practice.QueryingPractice();

        // Sending the parameter of the sql query to be prevent SQL Injection Attack
        //_06_Parameterized_Query.ParameterizedQuery();

        // Execute Method of Dapper
        //_07_Execute_method.ExecuteMethodOfDapper();

        // Executing the stored procedure using execute method
        //_08_Execute_StoredProcedure.ExecuteStoredProcedure();

        // ExecuteReader Method of Dapper implmentation
        //_09_ExecuteReader.ExecuteReaderMethodofDapper();

        // ExecuteSalar method of Dapper Implmentation
        //_10_ExecuteScalar.ExecuteScalarmethodofDapper();

        // Parameters types in Dapper
        //_11_Parameters.ParametersTypesinDapper();

        // Executing the stored procedure with output parameter
        //_12_StoredProcedure_Outputparameter.ExecuteStoredProcedureWithOutput();

        // Async Methods of Dapper
        //_13_Async_Methods.AsyncMethodsofDapper().Wait();

        // Buffered and Non-Buffered Approach
        //_14_Buffered_NonBuffered.NonBufferedQueries();

        // Transactions in Dapper
        //_15_Transactions.TransactionsinDapper();

        // Inserting the data in bulk
        //_16_BulkInsert.InsertinBulkinSQL();

        // Practicing Dapper
        _17_DapperPractice.PracticingDapper();

    }
}