using Xunit;
using GameOfLife;

namespace tests.GameOfLife
{
    public class CellTests
    {
        [Fact]
        public void Should_Test_Cell_State()
        {
            // arrange
            var cell = new Cell();
            // act
            cell.State = StateEnum.Alive;
            // assert
            Assert.Equal(StateEnum.Alive, cell.State);
        }
    }
}