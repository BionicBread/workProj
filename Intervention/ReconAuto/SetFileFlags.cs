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
                    case "Neccton Sup":
                        _fileFlag = value;
                        
                        break;
                    case "Neccton Int":
                        _fileFlag = value;

                        break;
                    case "UPAM":
                        _fileFlag = value;
                        
                        break;

                    case "SFMC Sup":
                        _fileFlag = value;

                        break;
                    case "SFMC Int":
                        _fileFlag = value;
                        
                        break;
                    case "SFMC":
                        _fileFlag = value;

                        break;
                    case "DWH":
                        _fileFlag = value;
                        break;
                    case "test":
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
                return "rec1";
            }
            else if (fileFlag == "Neccton Int" && fileFlag2 == "SFMC Int" || fileFlag == "SFMC Int" && fileFlag2 == "Neccton Int")
            {
                return "rec2";
            }
            else if (fileFlag == "Neccton Sup" && fileFlag2 == "SFMC Sup" || fileFlag == "SFMC Sup" && fileFlag2 == "Neccton Sup")
            {
                return "rec2";
            }
            else if (fileFlag == "SFMC" && fileFlag2 == "DWH" || fileFlag == "DWH" && fileFlag2 == "SFMC")
            {
                return "rec4";
            }
            else if (fileFlag == "test" && fileFlag2 == "test" || fileFlag == "test" && fileFlag2 == "test")
            {
                return "test";
            }

            return "File Flags incorrect";
        }
    }
}