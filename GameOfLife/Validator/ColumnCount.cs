using System.Linq;
using GameOfLife;

namespace GameOfLife
{
    public class ColumnCount : IValidator
    {
        private Universe _grid;

        public ColumnCount(Universe grid)
        {
            _grid = grid;
        }

        public bool CorrectFormat(string[] setUp)
        {
            var gridSetup = _grid.GetGridDimensions(setUp);
            var gridWidth = gridSetup[1];
            var populateGrid = setUp.Skip(1).ToArray();
            var singleRow = populateGrid[0].Split(" ");
            if (gridWidth == singleRow.Length && gridWidth > 3) return true;
            return false;
        }
    }
}