using Xunit;
using GameOfLife;

namespace tests.GameOfLife
{
    public class CellTests
    {
        [Theory]
        [InlineData(State.Alive)]
        [InlineData(State.Dead)]
        public void Should_Test_Cell_State(State state) 
        {
            // arrange
            var cell = new Cell(3, 3);
            // act
            cell.CellState = state;
            // assert
            Assert.Equal(cell.CellState, state);
        }
        [Fact]
        public void Should_Count_Cell_NeighbourStateAlive()
        {
            // arrange
            var cell = new Cell(3, 3);
            var cellX = 1;
            var cellY = 1;
            var expected = 8;
            // act
            var result = cell.HowManyLiveNeighbours(cellX, cellY);
            // assert 
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(State.Dead, 0)] 
        [InlineData(State.Alive, 1)] 
        public void Should_Test_SwitchState(State state, int expected)
        {
            // arrange
            var cell = new Cell(3, 3);
            var cellX = 1;
            var cellY = 1;
            // act
            cell.SwitchState(cellX, cellY);
            // assert
            //Assert.Equal(expected, result);
        }
    }
}