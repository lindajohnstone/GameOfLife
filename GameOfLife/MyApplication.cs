using GameOfLife;
using Microsoft.Extensions.Logging;

public class MyApplication
{
    private readonly ILogger<MyApplication> _logger;

    public MyApplication(ILogger<MyApplication> logger)
    {
        _logger = logger;
    }

    public void Run()
    {
        _logger.LogInformation("Start to run MyApplication.");
        var output = new ConsoleOutput();
        var grid = new Universe(output);
        grid.RunGame();
        _logger.LogInformation("Finish running MyApplication.");
    }
}