using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml;
using Excel = Microsoft.Office.Interop.Excel;


namespace ReconAuto
{
    public class ListMethod
    {

        public (List<string> headerValues, List<string> dataValues) ReadExcelData(string filePath) // read data function returns two List objects of string type
        {
            // init the list
            var headerValues = new List<string>();
            var dataValues = new List<string>();
            
            // int the formatter
            Formatter formatter = new Formatter();

            // Start Excel and get Application object. Keep objects in scope by declaring outside of try catch
            var excelApp = new Excel.Application();
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;
            Excel.Range range = null;

            try
            {
                workbook = excelApp.Workbooks.Open(filePath);
                worksheet = workbook.Sheets[1]; // Assuming the data is in the first sheet
                range = worksheet.UsedRange; // Get the used range of the worksheet

                int rowCount = range.Rows.Count;
                for (int i = 1; i <= 1; i++) // capture first row of headers
                {
                    var cellA = range.Cells[i, 1] as Excel.Range;
                    
                    string textValueA = cellA.Value2?.ToString() ?? "Empty"; // Handle null cells in column A
           

                    // Debug: Print the values
                    //Console.WriteLine(textValueA + " " + textValueB);

                    // Put into list
                    headerValues.Add(textValueA);

                }

                for (int i = 2; i <= rowCount; i++) // capture data in the remaining rows starting at row 2
                {

                    var cellB = range.Cells[i, 1] as Excel.Range;
                    string textValueB = cellB.Value2?.ToString() ?? "Empty"; // Handle null cells in column B by using the text EMPTY

                    // Put into list
                    
                    dataValues.Add(textValueB);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                // Clean up
                if (range != null) Marshal.ReleaseComObject(range);
                if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                if (workbook != null)
                {
                    workbook.Close(false);
                    Marshal.ReleaseComObject(workbook);
                }
                excelApp.Quit();
                Marshal.ReleaseComObject(excelApp);
            }
            return (headerValues, dataValues);
        }

        public List<string> SplitHeaders(List<string> data)
        {
            // Split the first element using ';' as the delimiter
            string[] splitValues = data[0].Split(';');

            // Remove the original first element
            data.RemoveAt(0);

            // Add the split values to the list
            data.AddRange(splitValues);
            return data;
        }

        public List<string> SplitData(List<string> data)
        {
            // Split the first element using ';' as the delimiter
            var dataLength = data.Count;
            string[] splitValues;
            List<string> resultValues = new List<string>();
            for (int i = 0; i < dataLength; i++)
            {
                splitValues = data[i].Split(';');
                resultValues.AddRange(splitValues);
            }
            
            // Remove the original first element
            //data.RemoveAt(0);

            // Add the split values to the list
            
            return resultValues;
        }
    }
}