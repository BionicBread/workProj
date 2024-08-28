using System.Data;

namespace ReconAuto
{
    public class DataTesting
    {
        public static void DisplayDataTable(System.Data.DataTable dt)
        {
            // Print the column headers
            foreach (DataColumn column in dt.Columns)
            {
                Console.Write($"{column.ColumnName}\t");
            }
            Console.WriteLine();

            // Print each row's values
            foreach (DataRow row in dt.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write($"{item}\t");
                }
                Console.WriteLine();
            }
        }
    }
}