namespace GameOfLife
{
    public interface IRules
    {
        public bool Calculate(int row, int col);
    }
}