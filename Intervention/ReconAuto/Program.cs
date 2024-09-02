using System.Xml;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using System.Data;
using System.Reflection.PortableExecutable;

namespace ReconAuto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // init classes
            ListMethod listMethod = new();
            Formatter converter = new();
            Comparison comparator = new();

            // Set file flags - output is identifier TODO: replaced with WPF handler
            Console.WriteLine("input file source: SFMC, Neccton or UPAM");
            SetFileFlags input = new (Console.ReadLine());
            
            Console.WriteLine("input 2nd file source: SFMC, Neccton or UPAM");
            SetFileFlags input2 = new(Console.ReadLine());

            string? indicator = input.CombinationSelector(input.FileSet, input2.FileSet); // set the indicator string
            Console.WriteLine(indicator); // print the reconcilliation flag

            // read the data from excel 
            (List<string>columnHeaderOut, List<string>columnDataOut) = listMethod.ReadExcelData(@"C:\Users\Chris\Documents\Code\tiQtoQ\Intervention\ReconAuto\dummy data\noAnomaly\testIN.csv");    // read excel and place header and data into a string List
            (List<string>columnHeaderIn, List<string>columnDataIn) = listMethod.ReadExcelData(@"C:\Users\Chris\Documents\Code\tiQtoQ\Intervention\ReconAuto\dummy data\noAnomaly\testOUT.csv");    // read 2nd excel
            // 
            //////////////////////DATA//////////////////////////////////////
            Dictionary<int, string> dataDictionaryOut = converter.ConvertToDictionary(columnDataOut); // convert data from list into a dictionary data structure
            Dictionary<int, string> dataDictionaryIn = converter.ConvertToDictionary(columnDataIn); // convert data from list into a dictionary data structure
            /////////////////////DATA END///////////////////////////////////
      

            /////////////////////HEADER////////////////////////////////////////
            List<string> splitHeadersOut = listMethod.SplitHeaders(columnHeaderOut); // split each header string into a separate elements in a List
            Dictionary<int, string> headerDictionaryOut = converter.ConvertToDictionary(splitHeadersOut); // convert header List into dictionary separate entries

            List<string> splitHeadersIn = listMethod.SplitHeaders(columnHeaderIn); 
            Dictionary<int, string> headerDictionaryIn = converter.ConvertToDictionary(splitHeadersIn);
            /////////////////////HEADER END////////////////////////////////////


            ////////////////////HEADER COMPARISON (SIZE)/////////////////////////
            // bool sizeResults = comparator.DictionarySizeComparison(headerDictionaryOut, headerDictionaryIn); // size comparison no longer valid
            Console.WriteLine("Do headers match??: " + comparator.DictionaryHeaderComparison(headerDictionaryIn, headerDictionaryOut, indicator));
            // TODO: check headers are correct - hard code headers into a dictionary and compare based on type of file.

            ////////////////////HEADER COMPARISON (SIZE) END/////////////////////
     

            ////////////////////DATA COMPARISON/////////////////////////
            // comparator.DictionaryDataComparison(dataDictionaryOut, dataDictionaryIn); // additional rules
            // TODO: Filter out entries where system source something
            // TODO: Remove entries where no longer at risk = True
            // TODO: Remove entries where datetime = yesterday <<< not easy wtf
            // data comparison (above class should work)

            ////////////////////DATA COMPARISON END/////////////////////
            





            /////// DATA TABLE METHOD ////////////////////////// DO NOT USE
            //TableDataRead objectSFMC = new TableDataRead();   // input the file // TODO: make a function to capture files automatic
            //TableDataRead objectDWH = new TableDataRead();   // input the file // TODO: make a function to capture files automatic
            //System.Data.DataTable tableSFMC = objectSFMC.TableDataReader(@"C:\Users\Chris\Documents\Code\tiQtoQ\Intervention\ReconAuto\dummy data\SFMC Suppression File Return.xlsx");    // stores the suppression file into a DataTable object, 
            //System.Data.DataTable tableDWH = objectDWH.TableDataReader(@"C:\Users\Chris\Documents\Code\tiQtoQ\Intervention\ReconAuto\dummy data\DWH Suppression File OUT.xlsx");    // stores the suppression for comparison
            // filter SFMC table
            //DataFilter dataFilter = new DataFilter();
            /////// DATA TABLE END //////////////////////////// DO NOT USE


            // TESTING 
            //foreach (var n in headerDictionaryOut)
            //{
            //    Console.WriteLine(n);
            //}
            //Console.WriteLine(results);

            //DataTesting.DisplayDataTable(tableSFMC);
            // TESTING END
        }
    }
}