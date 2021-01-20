using System.Collections.Generic;
using System.IO;

namespace GameOfLife
{
    public class FileReader : IReader
    {
        public string FileExists(string filePath)
        {
            if(File.Exists(filePath)) return filePath;
            return "File does not exist.";
        }

        public string[] ReadFile(string filePath)
        { 
            using(StreamReader file = new StreamReader(filePath)) 
            {    
                string[] lines = File.ReadAllLines(filePath);
                file.Close();   
                return lines;
            }  
        }
    }
}