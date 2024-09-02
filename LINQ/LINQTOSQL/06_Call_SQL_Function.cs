using System;


namespace LINQTOSQL
{
    class _06_Call_SQL_Function
    {
        public static void CAllSQLFunction()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();

            // call SQL Function
            int results = dc.fnGetCount("Female")??0;
            Console.WriteLine("Total Count={0}",results);
        }
    }
}
