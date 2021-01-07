using System.Linq;
using GameOfLife;
using Xunit;

namespace tests.GameOfLife
{
    public class ValidationTests
    {
        [Fact]
        public void Should_Test_File_Input_Line_One_Is_Valid_Format()
        {
            // arrange
            var filePath = "TestFiles/testFile.txt";
            IReader fileInput = new FileReader();
            var setUp = fileInput.ReadFile(filePath);
            var validator = new FileInputValidation();
            var expected = true;
            // act
            var result = validator.Dimensions(setUp);
            // assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Should_Test_File_Input_Line_Two_Plus_Is_Valid_Format() // TODO: method name??
        {
            // arrange
            var filePath = "TestFiles/testFile.txt";
            IReader fileInput = new FileReader();
            var setUp = fileInput.ReadFile(filePath);
            setUp.Skip(1).ToArray();
            var validator = new FileInputValidation();
            var expected = true;
            // act
            var result = validator.GridSetUp(setUp);
            // assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Should_Test_File_GridLength_Equals_Grid_Set_Number_of_Rows()
        {
            // arrange
            IReader fileInput = new FileReader();
            var filePath = "TestFiles/testFile.txt";
            var setUp = fileInput.ReadFile(filePath);
            var validator = new FileInputValidation();
            var expected = true;
            // act
            var result = validator.RowCount(setUp);
            // assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Should_Test_File_GridWidth_Equals_Grid_Set_Number_of_Columns()
        {
            // arrange
            var filePath = "TestFiles/testFile.txt";
            IReader fileInput = new FileReader();
            var setUp = fileInput.ReadFile(filePath);
            var validator = new FileInputValidation();
            var expected = true;
            // act
            var result = validator.ColumnCount(setUp);
            // assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Should_Test_GridSetUp_FileInput_Is_Zero_Or_One()
        {
            // arrange
            var filePath = "TestFiles/testFile.txt";
            IReader fileInput = new FileReader();
            var setUp = fileInput.ReadFile(filePath);
            var validator = new FileInputValidation();
            var expected = false;
            // act
            var result = validator.GetZeroOrOneToSetUpUniverse(setUp);
            // assert
            Assert.Equal(expected, result);
        }
        // TODO: fact tests using files with invalid data to check errors thrown
    }
}