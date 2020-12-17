using System.Collections.Generic;
using System.IO;

namespace GameOfLife
{
    public class FileReader : IReader
    {
        private string _filePath = "InputFiles/testFile.txt";
        public string FileExists()
        {
            if(File.Exists(_filePath)) return _filePath;
            return "File does not exist.";
        }

        public string[] ReadFile()
        { 
            using(StreamReader file = new StreamReader(_filePath)) 
            {    
                string[] lines = File.ReadAllLines(_filePath);
                file.Close();   
                return lines;
            }  
        }
    }
}