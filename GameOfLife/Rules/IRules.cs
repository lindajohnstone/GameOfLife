namespace GameOfLife
{
    public interface IRules
    {
        public bool Check(int row, int col);
    }
}