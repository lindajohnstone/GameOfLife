using System.Linq;
using GameOfLife;
using Xunit;

namespace tests.GameOfLife
{
    public class ValidationTests
    {
        [Fact]
        public void Should_Test_File_Input_Line_One_Is_Valid_Format()//\d{1,2} \d{1,2}
        {
            // arrange
            IReader fileInput = new FileReader();
            var setUp = fileInput.ReadFile();
            var validator = new DimensionSetUp();
            var expected = true;
            // act
            var result = validator.CorrectFormat(setUp);
            // assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Should_Test_File_Input_Line_Two_Plus_Is_Valid_Format() // TODO: method name??
        {
            // arrange
            IReader fileInput = new FileReader();
            var setUp = fileInput.ReadFile();
            setUp.Skip(1).ToArray();
            var validator = new GridSetUp();
            var expected = true;
            // act
            var result = validator.CorrectFormat(setUp);
            // assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Should_Test_File_GridLength_Equals_Grid_Set_Number_of_Rows()
        {
            // arrange
            IReader fileInput = new FileReader();
            var grid = new Universe(fileInput);
            var setUp = fileInput.ReadFile();
            var validator = new RowCount(grid);
            var expected = true;
            // act
            var result = validator.CorrectFormat(setUp);
            // assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Should_Test_File_GridWidth_Equals_Grid_Set_Number_of_Columns()
        {
            // arrange
            IReader fileInput = new FileReader();
            var grid = new Universe(fileInput);
            var setUp = fileInput.ReadFile();
            var validator = new ColumnCount(grid);
            var expected = true;
            // act
            var result = validator.CorrectFormat(setUp);
            // assert
            Assert.Equal(expected, result);
        }
    }
}