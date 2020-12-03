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
            var grid = new Universe();
            grid.SetUpGrid(3,3);
            grid.Initialise();
            var expected = "* ";
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