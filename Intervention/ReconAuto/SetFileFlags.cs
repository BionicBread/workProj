namespace ReconAuto
{
    class SetFileFlags
    {
        private string? _fileFlag;

        public SetFileFlags(string? fileFlag)
        {
           FileSet = fileFlag;
        }

        public string? FileSet
        {
            get { return _fileFlag; } // get the private member
            set 
            {
                //    if(value == "SFMC" || value == "Neccton" || value == "UPAM")
                //    _fileFlag = value; 
                //    else
                //        Console.WriteLine("Not a valid file type");
                switch (value)
                {
                    case "Neccton":
                        _fileFlag = value;
                        
                        break;
                    case "UPAM":
                        _fileFlag = value;
                        
                        break;

                    case "SFMC":
                        _fileFlag = value;
                        
                        break;
                    case "DWH":
                        _fileFlag = value;
                        break;
                    default:
                        Console.WriteLine("Not defined");
                        break;
                }
            }
        }

        public string CombinationSelector(string fileFlag, string fileFlag2)
        {
            if (fileFlag == "Neccton" &&  fileFlag2 == "UPAM" || fileFlag == "UPAM" && fileFlag2 == "Neccton")
            {
                return "Option 1";
            }
            else if (fileFlag == "Neccton" && fileFlag2 == "SFMC" || fileFlag == "SFMC" && fileFlag2 == "Neccton")
            {
                return "Option 2";
            }
            else if (fileFlag == "SFMC" && fileFlag2 == "DWH" || fileFlag == "DWH" && fileFlag2 == "SFMC")
            {
                return "Option 3";
            }
            return "File Flags incorrect";
        }
    }
}