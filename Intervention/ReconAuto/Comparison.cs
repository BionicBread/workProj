﻿using System.Runtime.InteropServices;
using System.Xml;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
namespace ReconAuto
{
    public class Comparison
    {
        private readonly Dictionary<int, string> necctonUpamHeaderValues = new Dictionary<int, string>() 
        {
            {1, "playerId" }, 
            {2, "riskScore" }, 
            {3, "riskReason" }, 
            {4, "interventionGroup" }, 
            {5, "interventionPhase" }, 
            {6, "suppression-status" }, 
            {7, "wagerCountLimit" }, 
            {8, "depositLimit" }, 
            {9, "noLongerAtRisk" } 
             
        };
        private readonly Dictionary<int, string> upamNecctonHeaderValues = new Dictionary<int, string>()
        {
            {1, "Player ID" },
            {2, "External Risk Score" },
            {3, "Risk Reason" },
            {4, "Risk Group" },
            {5, "Risk Phase" },
            {6, "Suppression-status" },
            {7, "IIWG Wager Count limit" },
            {8, "Deposit limit" },
            {9, "External Risk Score" }
        };
        private readonly Dictionary<int, string> necctonSfmcInterHeaderValues = new Dictionary<int, string>()
        {
            {1, "messageId" },
            {2, "playerId" },
            {3, "riskScore" },
            {4, "nudge" },
            {5, "nudge_code" },
            {6, "intervention" },
            {7, "interventionGroup" },
            {8, "interventionPhase" },
            {9, "riskReason" },
            {10, "No longer at risk" }
        };
        private readonly Dictionary<int, string> sfmcNecctonInterHeaderValues = new Dictionary<int, string>()        
        {
            {1, "messageId" },
            {2, "playerId" },
            {3, "riskScore" },
            {4, "nudge" },
            {5, "nudge_code" },
            {6, "intervention" },
            {7, "interventionGroup" },
            {8, "interventionPhase" },
            {9, "RiskReason" }
        };
        private readonly Dictionary<int, string> necctonSfmcSuppHeaderValues = new Dictionary<int, string>()
        {
            {1, "Player ID" },
            {2, "No longer at risk" },

        };
        private readonly Dictionary<int, string> sfmcNecctonSuppHeaderValues = new Dictionary<int, string>()        
        {
            {1, "Player Identifier" },
            {2, "Source system" },

        };
        private readonly Dictionary<int, string> sfmcDwhSuppHeaderValues = new Dictionary<int, string>()        
        {
            {1, "Player Responsible Gaming Exclusion Identifier" },
            {2, "Player Identifier" },
            {3, "Player Responsible Gaming Exclusion Type Identifier" },
            {4, "Product Vertical Identifier" },
            {5, "Product Identifier" },
            {6, "Duration Period Code" },
            {7, "Exclusion Creation datetime" },
            {8, "Exclusion Update datetime" },
            {9, "Exclusion Deletion datetime" },
            {10, "Reason Text" },
            {11, "Validity Start datetime" },
            {12, "Validity End datetime" },
            {13, "Risky Flag" },
            {14, "Source system" }
        };
        private readonly Dictionary<int, string> dwhSfmcSuppHeaderValues = new Dictionary<int, string>()        
        {
            {1, "Player Responsible Gaming Exclusion Identifier" },
            {2, "Player Identifier" },
            {3, "Player Responsible Gaming Exclusion Type Identifier" },
            {4, "Product Vertical Identifier" },
            {5, "Product Identifier" },
            {6, "Duration Period Code" },
            {7, "Exclusion Creation datetime" },
            {8, "Exclusion Update datetime" },
            {9, "Exclusion Deletion datetime" },
            {10, "Reason Text" },
            {11, "Validity Start datetime" },
            {12, "Validity End datetime" },
            {13, "Risky Flag" }
        };
        private readonly Dictionary<int, string> testOUTHeaderValues = new Dictionary<int, string>()
        {
            {1, "clientId" },
            {2, "customerIdHash" },
            {3, "eventTimestamp" },
            {4, "eventId" },
            {5, "eventType" },
            {6, "birthDate" },
            {7, "registerDate" },
            {8, "registeredLanguage" },
            {9, "country" },
            {10, "customField" }
        };
        private readonly Dictionary<int, string> testINHeaderValues = new Dictionary<int, string>()
        {
            {1, "clientId" },
            {2, "customerIdHash" },
            {3, "eventTimestamp" },
            {4, "eventId" },
            {5, "eventType" },
            {6, "playBreakStart" },
            {7, "playBreakEnd" },
            {8, "durationMinutes" },
            {9, "reason" }
        };

        public bool DictionarySizeComparison(Dictionary<int, string> dictionaryOne, Dictionary<int, string> dictionaryTwo)
        {
            if(dictionaryOne.Count == dictionaryTwo.Count) 
            {   
                return true;
            }
            return false;
            
        }
        public bool DictionaryHeaderComparison(Dictionary<int, string> dictionaryOne, Dictionary<int, string> dictionaryTwo,string identifier)
        {
            switch (identifier)
            {
                case "rec1":

                    foreach (var key in dictionaryOne.Keys)
                    {
                        if (dictionaryOne[key] == necctonUpamHeaderValues[key])   // compare the input headers with the hard coded headers
                        {
                            Console.WriteLine("REC 1: Neccton File Return headers are a match");
                            return true;
                        }
                        else
                        {
                            // Anomaly Detected  
                            Console.WriteLine("REC 1: Anomaly Detected in Neccton HEADERS");
                            return false;
                        }
                    }

                    foreach (var key in dictionaryTwo.Keys)
                    {
                        if (dictionaryOne[key] == upamNecctonHeaderValues[key])   // compare the input headers with the hard coded headers 
                        {
                            Console.WriteLine("REC 1: UPAM File Return headers are a match");
                            return true;
                        }
                        else
                        {
                            // Anomaly Detected  
                            Console.WriteLine("REC 1: Anomaly Detected in UPAM HEADERS");
                            return false;
                        }
                    }
                    break;

                case "rec2":
                    foreach (var key in dictionaryOne.Keys)
                    {
                        if (dictionaryOne[key] == necctonSfmcInterHeaderValues[key])   // compare the input headers with the hard coded headers
                        {
                            Console.WriteLine("REC 1: Neccton File Return headers are a match");
                            return true;
                        }
                        else
                        {
                            // Anomaly Detected  
                            Console.WriteLine("REC 1: Anomaly Detected in Neccton HEADERS");
                            return false;
                        }
                    }

                    foreach (var key in dictionaryTwo.Keys)
                    {
                        if (dictionaryOne[key] == sfmcNecctonInterHeaderValues[key])   // compare the input headers with the hard coded headers 
                        {
                            Console.WriteLine("REC 1: SFMC File Return headers are a match");
                            return true;
                        }
                        else
                        {
                            // Anomaly Detected  
                            Console.WriteLine("REC 1: Anomaly Detected in SFMC HEADERS");
                            return false;
                        }
                    }
                    break;
                case "rec3":
                    foreach (var key in dictionaryOne.Keys)
                    {
                        if (dictionaryOne[key] == necctonSfmcSuppHeaderValues[key])   // compare the input headers with the hard coded headers
                        {
                            Console.WriteLine("REC 1: Neccton File Return headers are a match");
                            return true;
                        }
                        else
                        {
                            // Anomaly Detected  
                            Console.WriteLine("REC 1: Anomaly Detected in Neccton HEADERS");
                            return false;
                        }
                    }

                    foreach (var key in dictionaryTwo.Keys)
                    {
                        if (dictionaryOne[key] == sfmcNecctonSuppHeaderValues[key])   // compare the input headers with the hard coded headers 
                        {
                            Console.WriteLine("REC 1: SFMC File Return headers are a match");
                            return true;
                        }
                        else
                        {
                            // Anomaly Detected  
                            Console.WriteLine("REC 1: Anomaly Detected in SFMC HEADERS");
                            return false;
                        }
                    }
                    break;
                case "rec4":
                    foreach (var key in dictionaryOne.Keys)
                    {
                        if (dictionaryOne[key] == sfmcDwhSuppHeaderValues[key])   // compare the input headers with the hard coded headers
                        {
                            Console.WriteLine("REC 1: SFMC File Return headers are a match");
                            
                        }
                        else
                        {
                            // Anomaly Detected  
                            Console.WriteLine("REC 1: Anomaly Detected in SFMC HEADERS");
                            return false;
                        }
                    }

                    foreach (var key in dictionaryTwo.Keys)
                    {
                        if (dictionaryOne[key] == dwhSfmcSuppHeaderValues[key])   // compare the input headers with the hard coded headers 
                        {
                            Console.WriteLine("REC 1: DWH File Return headers are a match");
                            return true;
                        }
                        else
                        {
                            // Anomaly Detected  
                            Console.WriteLine("REC 1: Anomaly Detected in DWH HEADERS");
                            return false;
                        }
                    }
                    break;
                case "test":
                    foreach (var key in dictionaryOne.Keys)
                    {
                        if (dictionaryOne[key] == testOUTHeaderValues[key])   // compare the input headers with the hard coded headers
                        {
                            Console.WriteLine("test rec: test OUT headers are a match");
                            
                        }
                        else
                        {
                            // Anomaly Detected  
                            Console.WriteLine("REC test: Anomaly Detected in TEST OUT");
                            return false;
                        }
                    }

                    foreach (var key in dictionaryTwo.Keys)
                    {
                        if (dictionaryTwo[key] == testINHeaderValues[key])   // compare the input headers with the hard coded headers 
                        {
                            Console.WriteLine("test rec: test IN headers are a match");
                            
                        }
                        else
                        {
                            // Anomaly Detected  
                            Console.WriteLine("REC test: Anomaly Detected in TEST IN: @ " + testINHeaderValues[key] + " != " + dictionaryTwo[key]);
                            return false;
                        }
                    }
                    return true;
                default:
                    Console.WriteLine(identifier + " unknown scenario");
                    return false;
                    
            }

            return false;
        }

        public void DictionaryDataComparison(Dictionary<int, string> dictionaryOne, Dictionary<int, string> dictionaryTwo)
        {
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
                        Console.WriteLine("Error detector in entry " + key);
                        ErrorFinder errorHandler = new ErrorFinder();
                        errorHandler.ErrorDetector(dictionaryOne[key], dictionaryTwo[key]);
                    }
                }
                Console.WriteLine("Number of entries is " + dictionaryOne.Count);
            }
        }

    }
}