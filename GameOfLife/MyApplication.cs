using Microsoft.Extensions.Logging;

namespace GameOfLife
{
    public class MyApplication
    {
        private readonly ILogger<MyApplication> _logger;
        private readonly ILogger<UniverseGenerator> _universeGeneratorLogger;
        private ILogger<GameController> _gameControllerLogger;

        public MyApplication(ILogger<MyApplication> logger, ILogger<UniverseGenerator> universeGeneratorLogger, ILogger<GameController> gameControllerLogger)
        {
            _logger = logger;
            _universeGeneratorLogger = universeGeneratorLogger;
            _gameControllerLogger = gameControllerLogger;
        }
        internal void Run()
        {
            // _logger.LogInformation("Start to run");
            var output = new ConsoleOutput();
            var grid = new Universe();
            var input = new ConsoleInput();
            var game = new GameController(grid, output, _gameControllerLogger);
            input.ConsoleCancelKeyPress();
            var generator = new UniverseGenerator(output, grid, input, game, _universeGeneratorLogger);
            generator.PrintGrid += GridPrintEvent.HandlePrintGrid;
            generator.RunGame();
            // _logger.LogInformation("Finish running");
        }
    }
}