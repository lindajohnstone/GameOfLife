using System;
using System.IO;
using Microsoft.Extensions.Logging;

namespace GameOfLife
{
    public class MyApplication
    {
        private readonly ILogger<MyApplication> _logger;
        private readonly ILogger<UniverseGenerator> _universeGeneratorLogger;
        private ILogger<GameController> _gameControllerLogger;  
        private IReader _fileInput;
        public MyApplication(ILogger<MyApplication> logger, 
            ILogger<UniverseGenerator> universeGeneratorLogger, 
            ILogger<GameController> gameControllerLogger, 
            IReader fileInput
            )// TODO: use dependency injection instead of using NEW
        {
            _logger = logger;
            _universeGeneratorLogger = universeGeneratorLogger;
            _gameControllerLogger = gameControllerLogger;
        }
        internal void Run()
        {
            var output = new ConsoleOutput();
            var grid = new Universe(_fileInput);
            var input = new ConsoleInput();
            var game = new GameController(grid, output, _gameControllerLogger, _fileInput);
            input.ConsoleCancelKeyPress();
            var generator = new UniverseGenerator(output, grid, input, game, _universeGeneratorLogger, _fileInput);

            generator.PrintGrid += GridPrintEvent.HandlePrintGrid;
            generator.RunGame();
            _logger.LogInformation("Game of Life has been stopped"); //TODO: change message
        }
    }
}