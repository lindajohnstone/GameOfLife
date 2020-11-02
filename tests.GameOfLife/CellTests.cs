using Xunit;
using GameOfLife;

namespace tests.GameOfLife
{
    public class CellTests
    {
        [Theory]
        [InlineData(StateEnum.Alive)]
        [InlineData(StateEnum.Dead)]
        public void Should_Test_Cell_State(StateEnum state) 
        {
            // arrange
            var cell = new Cell(3, 3);
            // act
            cell.State = state;
            // assert
            Assert.Equal(cell.State, state);
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
            var result = cell.NeighbourStateAliveCount(cellX, cellY);
            // assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Should_Test_SwitchState()
        {
            // arrange
            var cell = new Cell(3, 3);
            var cellX = 1;
            var cellY = 1;
            var expected = 1;
            // act
            var result = cell.SwitchState(cellX, cellY);
            // assert
            Assert.Equal(expected, result);
        }
    }
}