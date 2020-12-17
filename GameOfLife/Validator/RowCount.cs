namespace GameOfLife
{
    public class RowCount :IValidator
    {
        private Universe _grid;

        public RowCount(Universe grid)
        {
            _grid = grid;
        }

        public bool CorrectFormat(string[] setUp)
        {
            var gridSetup = _grid.GetGridDimensions(setUp);
            var gridLength = gridSetup[0];
            if (gridLength == setUp.Length - 1 && gridLength > 3) return true;
            return false;
        }
    }
}