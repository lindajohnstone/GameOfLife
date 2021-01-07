using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace GameOfLife
{
    public class FileInputValidation // TODO: all methods updated (after tests written) to return error or string
    {
        public bool Dimensions(string[] line)
        {
            var regex = new Regex(@"\d{1,2} \d{1,2}");
            return regex.IsMatch(line[0]);
        }
        public bool GridSetUp(string[] setUp)
        {
            var regex = new Regex(@"\d ");
            var lines = setUp.Skip(1).ToArray();
            var count = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (!regex.IsMatch(lines[i])) count++;
            }
            if (count > 0) return false;
            return true;
        }
        public bool ColumnCount(string[] setUp)
        {
            var gridSetup = setUp[0].Split(" ");
            var gridWidth = Int32.TryParse(gridSetup[1], out var numberColumns) ;
            var populateGrid = setUp.Skip(1).ToArray();
            var singleRow = populateGrid[0].Split(" ");
            if (numberColumns == singleRow.Length && numberColumns > Constants.ColumnMin) return true;
            return false;
        }
        public bool RowCount(string[] setUp)
        {
            var gridSetup = setUp[0].Split(" ");
            var gridLength = Int32.TryParse(gridSetup[0], out var numberRows) ;
            if (numberRows == setUp.Length - 1 && numberRows > Constants.RowMin) return true;
            return false;
        }

        public bool GetZeroOrOneToSetUpUniverse(string[] setUp)
        {
            var regex = new Regex(@"\d{3,} {3,}");
            var gridSetUp = setUp.Skip(1).ToArray();
            // loop through each row checking regex
            // find no error return true
            // return false
            foreach(var row in gridSetUp)
            {
                if(regex.IsMatch(row)) return true;
            }
            return false;
        }
    }
}