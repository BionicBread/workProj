using System;
using System.Data;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace ReconAuto
{
    public class DataFilter
    {
        DataTable filtered = null;

        public DataTable FilterOperation(DataTable unfiltered)
        {
            string filterExpression = "Source = 'DWH'";
            // Create a new DataTable to hold the filtered rows
            DataTable filtered = unfiltered.Clone(); // Clones the structure (columns) of the original DataTable

            DataRow[] filteredRows = unfiltered.Select(filterExpression);

            foreach (DataRow row in filteredRows)
            {
                filtered.ImportRow(row);
            }

            return this.filtered;
        }
    }
}