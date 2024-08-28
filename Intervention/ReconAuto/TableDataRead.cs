using System;
using System.Data;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace ReconAuto
{
    public class TableDataRead
    {

        DataTable dataTable = new DataTable();
        public DataTable TableDataReader(string filePath)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;
            Excel.Range range = null;
            try
            {
                // Open the Excel file
                workbook = excelApp.Workbooks.Open(filePath);
                worksheet = workbook.Sheets[1]; // Get the first sheet (1-based index)
                range = worksheet.UsedRange; 

                // Create columns in DataTable based on the first row (assuming row 1 are headers)
                for (int col = 1; col <= range.Columns.Count; col++)
                {
                    string columnName = range.Cells[1, col].Value2.ToString();
                    dataTable.Columns.Add(columnName);
                }

                // Read rows into DataTable (starting from the second row)
                for (int row = 2; row <= range.Rows.Count; row++)
                {
                    DataRow dataRow = dataTable.NewRow();
                    for (int col = 1; col <= range.Columns.Count; col++)
                    {
                        dataRow[col - 1] = range.Cells[row, col].Value2?.ToString() ?? string.Empty;
                    }
                    dataTable.Rows.Add(dataRow);
                }
            }
            catch { }
            finally
            { // Cleanup

                // Release COM objects to fully kill Excel process from running in the background

                if (range != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(range);
                if (worksheet != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                if (workbook != null)
                {
                    workbook.Close(false);
                    Marshal.ReleaseComObject(workbook);
                }
                excelApp.Quit();
                Marshal.ReleaseComObject(excelApp);

            }
            return dataTable;
        }
    }
}   