namespace GameOfLife
{
    public interface IRules
    {
        public bool Calculate(int cellX, int cellY);
    }
}