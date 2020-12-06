namespace GameOfLife
{
    public interface IRules
    {
        public bool CheckRules(int row, int col);
    }
}