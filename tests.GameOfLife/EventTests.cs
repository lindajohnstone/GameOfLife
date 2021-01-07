using System;
using GameOfLife;
using Xunit;

namespace tests.GameOfLife
{
    public delegate void GridPrintEventHandler(Object sender, GridPrintEventArgs e);
    public class EventTests
    {
        public event GridPrintEventHandler PrintGrid;
        [Fact]
        public void Should_Test_GridPrintEvent()
        {
            // arrange
            var output = new StubOutput();
            var fileInput = new FileReader();
            var grid = new Universe(fileInput);
            var gridLength = 3;
            var gridWidth = 3;
            grid.SetUpGrid(gridLength,gridWidth);
            grid.Initialise();
            var expected = "|";
            PrintGrid += GridPrintEvent.HandlePrintGrid;
            // act
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            grid.Initialise();
            PrintGrid?.Invoke(this, new GridPrintEventArgs(output, grid.Grid)); 
            // assert
            Assert.Equal(expected, output.GetWriteLine());
        }
    }
}