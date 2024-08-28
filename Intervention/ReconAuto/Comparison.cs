using System.Runtime.InteropServices;
using System.Xml;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
namespace ReconAuto
{
    public class Comparison
    {
        public bool DictionarySizeComparison(Dictionary<int, string> dictionaryOne, Dictionary<int, string> dictionaryTwo)
        {
            if(dictionaryOne.Count == dictionaryTwo.Count) 
            {   
                return true;
            }
            return false;
            
        }

        public void DictionaryDataComparison(Dictionary<int, string> dictionaryOne, Dictionary<int, string> dictionaryTwo, bool IscorrectSize)
        {
            if (IscorrectSize)
            {
                foreach (var key in dictionaryOne.Keys)
                {
                    if (dictionaryOne[key] == dictionaryTwo[key])   // check if the values is the same at a given key 
                    {
                        Console.WriteLine("Entry " + key + " is a match");
                    }
                    else
                    {
                        // Anomaly Detected  
                        Console.WriteLine("Anomaly Detected");
                    }
                }
                Console.WriteLine("Number of entries is " + dictionaryOne.Count);
            }
            else
            Console.WriteLine("Input files are not the correct size");
        }

    }
}