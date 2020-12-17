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
        private IOutput _output;
        private Universe _grid;
        private IInput _input;
        private GameController _game;
        private UniverseGenerator _generator;

        public MyApplication(ILogger<MyApplication> logger, 
            ILogger<UniverseGenerator> universeGeneratorLogger, 
            ILogger<GameController> gameControllerLogger, 
            IReader fileInput, 
            IOutput output,
            Universe grid, 
            IInput input,
            GameController game,
            UniverseGenerator generator
            )// TODO: use dependency injection instead of using NEW
        {
            _logger = logger;
            _universeGeneratorLogger = universeGeneratorLogger;
            _gameControllerLogger = gameControllerLogger;
            _fileInput = fileInput;
            _output = output;
            _grid = grid;
            _input = input;
            _game = game;
            _generator = generator;
        }
        internal void Run()
        {
            var game = new GameController(_grid, _output, _gameControllerLogger, _fileInput); // TODO: dependency injection. NB more than one instance of grid
            _input.ConsoleCancelKeyPress();
            var generator = new UniverseGenerator(_output, _grid, _input, game, _universeGeneratorLogger, _fileInput); // TODO: dependency injection
            
            generator.PrintGrid += GridPrintEvent.HandlePrintGrid;
            generator.RunGame();
            _logger.LogInformation("Game of Life has been stopped"); //TODO: change message
        }
    }
}