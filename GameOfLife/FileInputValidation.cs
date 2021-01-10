using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace GameOfLife
{
    public class FileInputValidation 
    {
        public void Dimensions(string[] line)
        {
            var regex = new Regex(@"\d{1,2} \d{1,2}");
            if(!regex.IsMatch(line[0])) throw new ArgumentException("Error: Dimensions (line 1 of file) should be 2 numbers, each not less than 3, with a space between.");
        }
        public void GridSetUp(string[] setUp) // TODO: change method name?
        {
            
            var gridSetUp = setUp.Skip(1).ToArray();
            for (int i = 0; i < gridSetUp.Length; i++)
            {
                if (!Enum.IsDefined(typeof(State), gridSetUp[i])) throw new ArgumentException("Error: File input for GridSetUp should contain 0, 1 or space only.");
            }
        }
        public void ColumnCount(string[] setUp)
        {
            var gridSetup = setUp[0].Split(" ");
            var gridWidth = Int32.TryParse(gridSetup[1], out var numberColumns);
            var populateGrid = setUp.Skip(1).ToArray();
            var singleRow = populateGrid[0].Split(" ");
            if (numberColumns < Constants.ColumnMin) throw new ArgumentException("Error: ColumnCount should be greater than 3.");
            if (numberColumns != singleRow.Length) throw new ArgumentException("Error: Number of columns does not match ColumnCount.");
        }
        public void RowCount(string[] setUp)
        {
            var gridSetup = setUp[0].Split(" ");
            var gridLength = Int32.TryParse(gridSetup[0], out var numberRows) ;
            if (numberRows != setUp.Length - 1)  
            if (numberRows != setUp.Length - 1) throw new ArgumentException("Error: Number of rows does not match RowCount.");
            if (numberRows < Constants.RowMin) throw new ArgumentException("Error: RowCount should be greater than 3");
        }
    }
}