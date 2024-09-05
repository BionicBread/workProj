using System.Reflection;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ReconAuto
{
    public class ErrorFinder
    {
        public string[]? string1; 
        public string[]? string2;

        public string[] SplitString(string data)    // Split the first element using ';' as the delimiter
        {
            string[] splitValues;
            splitValues = data.Split(";");
            
            return splitValues;    // returns a List of string where each element is the string in a column
        }
        public void ErrorDetector(string stringONE, string stringTWO)   // the input string from the dictionary is a ; seperated string with all column data
        {
            string1 = SplitString(stringONE);
            string2 = SplitString(stringTWO);
            if (string1.Length != string2.Length)
            {
                Console.WriteLine("table columns do not match");
                return;
            }
            for (int i = 0; i < string1.Length; i++)
            {
                if (string1[i].Equals(string2[i]))   // if there is data at the same column 
                {
                    Console.WriteLine("Data in matches in column: " + (i + 1) );
                }
                else
                {
                    Console.WriteLine("Anomaly detected in column: " + (i + 1));
                    return;
                }
            }
        }
    }
}