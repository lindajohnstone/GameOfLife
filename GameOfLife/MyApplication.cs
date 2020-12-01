using Microsoft.Extensions.Logging;

namespace GameOfLife
{
    public class MyApplication
    {
        private readonly ILogger<MyApplication> _logger;

        public MyApplication(ILogger<MyApplication> logger)
        {
            _logger = logger;
        }
        internal void Run()
        {
            _logger.LogInformation("Start to run");
            var output = new ConsoleOutput();
            var grid = new Universe();
            var input = new ConsoleInput();
            var game = new GameController(grid);
            input.ConsoleCancelKeyPress();
            var generator = new UniverseGenerator(output, grid, input, game);
            generator.PrintGrid += GridPrintEvent.HandlePrintGrid;
            generator.RunGame();
            _logger.LogInformation("Finish running");
        }
    }
}