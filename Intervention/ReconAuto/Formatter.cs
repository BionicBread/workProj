using System;
using System.Text;

namespace ReconAuto
{
    public class Formatter
    {

        public string RemoveExtraSemiColon(string input) // remove semi colons in a string
        {
            StringBuilder sb = new StringBuilder();

            bool lastCharWasSemicolon = false;
            foreach (char c in input)
            {
                if (c == ';')
                {
                    if (!lastCharWasSemicolon)
                    {
                        sb.Append(c);
                        lastCharWasSemicolon = true;
                    }
                }
                else
                {
                    sb.Append(c);
                    lastCharWasSemicolon = false;
                }
            }

            string output = sb.ToString();
            return output;
        } // no need to use this

        public Dictionary<int,string> ConvertToDictionary(List<string> dataList) 
        {
            int keyCounter = 1;
            Dictionary<int,string> targetDictionary = new Dictionary<int,string>();
            foreach (string n in dataList) 
            {
                
                targetDictionary.Add(keyCounter, RemoveExtraSemiColon(n));
                keyCounter++;
            }

            return targetDictionary;
        }
    } 
}