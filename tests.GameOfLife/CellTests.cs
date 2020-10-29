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
            var cell = new Cell();
            // act
            cell.State = state;
            // assert
            Assert.Equal(cell.State, state);
        }
    }
}