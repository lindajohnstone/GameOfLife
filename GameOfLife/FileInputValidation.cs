using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace GameOfLife
{
    public class FileInputValidation
    {
        // TODO: add public method to combine all methods
        // change other methods to private
        // refactor duplications to create new methods eg split("")
        // TODO: rename all methods
        public void Validate(string[] setUp)
        {
            CheckDimensions(setUp);
            CheckGridSetUp(setUp);
            CheckRowCount(setUp);
            CheckColumnCount(setUp);
        }
    
        private void CheckDimensions(string[] setUp)
        {
            var regex = new Regex(@"\d{1,2} \d{1,2}");
            if(!regex.IsMatch(setUp[0])) throw new ArgumentException("Error: Dimensions (line 1 of file) should be 2 numbers, each not less than 3, with a space between.");
        }
        private string[] SkipFirstRow(string[] value)
        {
            return value.Skip(1).ToArray();
        }
        private void CheckGridSetUp(string[] setUp) // TODO: change method name?
        {
            var gridSetUp = SkipFirstRow(setUp);
            for (int i = 0; i < gridSetUp.Length; i++)
            {
                foreach (var cell in gridSetUp[i].Split(" "))
                {
                    if (!Enum.TryParse(typeof(State), cell, out var _)) throw new ArgumentException("Error: File input for GridSetUp should contain 0, 1 or space only.");
                }
            }
        }
        private string[] SplitArray(string[] value)
        {
            return value[0].Split(" ");
        }
        private void CheckRowCount(string[] setUp)
        {
            var gridSetup = SplitArray(setUp);
            var gridLength = Int32.TryParse(gridSetup[0], out var numberRows);
             
            if (numberRows != setUp.Length - 1) throw new ArgumentException("Error: Number of rows does not match RowCount.");
            if (numberRows < Constants.RowMin) throw new ArgumentException("Error: RowCount should be greater than 3.");
        }
        private void CheckColumnCount(string[] setUp)
        {
            var gridSetup = SplitArray(setUp);
            var gridWidth = Int32.TryParse(gridSetup[1], out var numberColumns);
        
            if (numberColumns != SplitArray(SkipFirstRow(setUp)).Length) throw new ArgumentException("Error: Number of columns does not match ColumnCount.");
            if (numberColumns < Constants.ColumnMin) throw new ArgumentException("Error: ColumnCount should be greater than 3.");
        }
    }
}