using System;
using System.Linq;
using GameOfLife;
using Xunit;

namespace tests.GameOfLife
{
    public class ValidationTests
    {
        [Fact]
        public void Should_Throw_When_GridSetUp_FileInput_Is_Not_Zero_One_Or_Space()
        {
            // arrange
            var filePath = "TestFiles/InvalidGridSetUp.txt";
            IReader fileInput = new FileReader();
            var setUp = fileInput.ReadFile(filePath);
            var validator = new FileInputValidation();
            // act
            var result = Assert.Throws<ArgumentException>(() => validator.Validate(setUp));
            // assert
            Assert.Equal("Error: File input for GridSetUp should contain 0, 1 or space only.", result.Message);
        }
        [Fact]
        public void Should_Not_Throw_When_GridSetUp_FileInput_Is_Zero_Or_One()
        {
            // arrange
            var filePath = "TestFiles/TestFile.txt";
            IReader fileInput = new FileReader();
            var setUp = fileInput.ReadFile(filePath);
            var validator = new FileInputValidation();
            // act & assert
            try 
            {
                validator.Validate(setUp);
            }
            catch
            {
                Assert.True(false, "Validation does work.");
            }
        }
        [Fact]
        public void Should_Throw_When_Dimensions_Incorrect_Format()
        {
            // arrange
            var filePath = "TestFiles/InvalidDimensions.txt";
            IReader fileInput = new FileReader();
            var setUp = fileInput.ReadFile(filePath);
            var validator = new FileInputValidation();
            // act
            var result = Assert.Throws<ArgumentException>(() => validator.Validate(setUp));
            // assert
            Assert.Equal("Error: Dimensions (line 1 of file) should be 2 numbers, each not less than 3, with a space between.", result.Message);
        }
        [Fact]
        public void Should_Not_Throw_When_Dimensions_Correct_Format()
        {
            // arrange
            var filePath = "TestFiles/TestFile.txt";
            IReader fileInput = new FileReader();
            var setUp = fileInput.ReadFile(filePath);
            var validator = new FileInputValidation();
            // act & assert
            try
            {
                validator.Validate(setUp);
            }
            catch
            {
                Assert.True(false, "Validation does work.");
            }
        }
        [Fact]
        public void Should_Throw_When_Number_Of_Rows_Does_Not_Match_RowCount()
        {
            // arrange
            var filePath = "TestFiles/InvalidRowCount.txt";
            IReader fileInput = new FileReader();
            var setUp = fileInput.ReadFile(filePath);
            var validator = new FileInputValidation();
            // act
            var result = Assert.Throws<ArgumentException>(() => validator.Validate(setUp));
            // assert
            Assert.Equal("Error: Number of rows does not match RowCount.", result.Message);
        }
        [Fact]
        public void Should_Not_Throw_When_Number_Of_Rows_Matches_RowCount()
        {
            // arrange
            var filePath = "TestFiles/TestFile.txt";
            IReader fileInput = new FileReader();
            var setUp = fileInput.ReadFile(filePath);
            var validator = new FileInputValidation();
            // act & assert
            try
            {
                validator.Validate(setUp);
            }
            catch
            {
                Assert.True(false, "Validation does work.");
            }
        }
        [Fact]
        public void Should_Throw_When_Number_Of_Rows_Less_Than_Three()
        {
            // arrange
            var filePath = "TestFiles/RowCountLessThanThree.txt";
            IReader fileInput = new FileReader();
            var setUp = fileInput.ReadFile(filePath);
            var validator = new FileInputValidation();
            // act
            var result = Assert.Throws<ArgumentException>(() => validator.Validate(setUp));
            // assert
            Assert.Equal("Error: RowCount should be greater than 3.", result.Message);
        }
        [Fact]
        public void Should_Throw_When_Number_Of_Columns_Does_Not_Match_ColumnCount()
        {
            // arrange
            var filePath = "TestFiles/InvalidColumnCount.txt";
            IReader fileInput = new FileReader();
            var setUp = fileInput.ReadFile(filePath);
            var validator = new FileInputValidation();
            // act
            var result = Assert.Throws<ArgumentException>(() => validator.Validate(setUp));
            // assert
            Assert.Equal("Error: Number of columns does not match ColumnCount.", result.Message);
        }
        [Fact]
        public void Should_Not_Throw_When_Number_Of_Columns_Matches_ColumnCount()
        {
            // arrange
            var filePath = "TestFiles/TestFile.txt";
            IReader fileInput = new FileReader();
            var setUp = fileInput.ReadFile(filePath);
            var validator = new FileInputValidation();
            // act & assert
            try
            {
                validator.Validate(setUp);
            }
            catch
            {
                Assert.True(false, "Validation does work.");
            }
        }
        [Fact]
        public void Should_Throw_When_Number_Of_Columns_Less_Than_Three()
        {
            // arrange
            var filePath = "TestFiles/ColumnCountLessThanThree.txt";
            IReader fileInput = new FileReader();
            var setUp = fileInput.ReadFile(filePath);
            var validator = new FileInputValidation();
            // act
            var result = Assert.Throws<ArgumentException>(() => validator.Validate(setUp));
            // assert
            Assert.Equal("Error: ColumnCount should be greater than 3.", result.Message);
        }
    }
}