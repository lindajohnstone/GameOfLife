namespace GameOfLife
{
    public interface IInput
    {
        string ReadLine();
        char ReadKey(bool value);
    }
}