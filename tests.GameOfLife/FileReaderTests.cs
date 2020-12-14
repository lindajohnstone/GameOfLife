using System;
using System.IO;
using System.Linq;
using GameOfLife;
using Moq;
using Xunit;

namespace tests.GameOfLife
{
    public class FileReaderTests
    {
        [Fact]
        public void Should_Test_GetFileNameWithoutExtension()
        {
            // arrange
            var filePath = Path.GetFileNameWithoutExtension("../GameOfLife/testFile.txt");  
            // assert
            Assert.Equal("testFile", filePath);
        }
        [Fact]
        public void Should_Test_FileExists_When_File_Exists_Using_Moq()
        {
            // arrange
            var fileName = "../GameOfLife/testFile.txt";
            var mockReader = new Mock<IReader>();
            mockReader
                .Setup(_ => _.FileExists())
                .Returns(fileName); 
            // act
            var result = mockReader.Object.FileExists();
            // assert
            Assert.Equal(fileName, result);
        }
        [Fact]
        public void Should_Test_FileExists_When_File_Exists()
        {
            // arrange
            //var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestFiles", "testFile.txt");
            var path = "InputFiles/testFile.txt";
            var fileInput = new FileReader();
            var expected = path;
            // act
            var result = fileInput.FileExists();
            // assert
            Assert.Equal(expected, result);
        }
          [Fact]
        public void Should_Show_User_Message_When_File_Does_Not_Exist()// Now fails as file is hard coded
        {
            // arrange
            var path = "TestFiles/test.txt";
            var fileInput = new FileReader();
            var message = "File does not exist.";
            var expected = message;
            // act
            var result = fileInput.FileExists();
            // assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Should_Show_User_Message_When_File_Does_Not_Exist_Using_Moq() // passes even if file does exist
        {
            //var fileName = "../GameOfLife/file.txt";
            var message = "File does not exist.";
            var mockReader = new Mock<IReader>();
            mockReader
                .Setup(_ => _.FileExists())
                .Returns(message);
            // act
            var result = mockReader.Object.FileExists();
            // assert
            Assert.Equal(message, result);
        }
        [Fact]
        public void Should_Test_File_Has_Correct_Extension()
        {
            // arrange
            var fileName = "testFile.txt";
            var expected = ".txt";
            // act
            var result = Path.GetExtension(fileName);
            // assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Should_Test_ReadFile_Reads_OneLine()
        {
            // arrange
            IReader fileInput = new FileReader();
            // act
            var result = fileInput.ReadFile();
            // assert
            Assert.Equal("4 5", result[0]);
        }
        [Fact]
        public void Should_Read_File_To_Array()
        {
            // arrange
            IReader fileInput = new FileReader();
            // act
            var result = fileInput.ReadFile();
            // assert
            Assert.Equal(5, result.Length);
        }
        [Fact]
        public void Should_Receive_InputValues_From_File_Line_One()
        {
            // arrange
            IReader fileInput = new FileReader();
            var grid = new Universe(fileInput);
            var setUp = fileInput.ReadFile();
            // act
            var result = grid.GetGridDimensions();
            // assert
            Assert.Equal(4, result[0]);
            Assert.Equal(5, result[1]);
        }
        [Fact]
        public void Should_SetUp_Universe_With_File_Input()
        {
            // arrange
            IReader fileInput = new FileReader();
            var setUp = fileInput.ReadFile();
            var grid = new Universe(fileInput);
            var dimensions = grid.GetGridDimensions();
            var gridLength = dimensions[0];
            var gridWidth = dimensions[1];
            var expected = new Cell[gridLength, gridWidth];
            // act
            grid.SetUpGrid(gridLength, gridWidth);
            // assert
            Assert.Equal(expected.Length, grid.Grid.Length);
        }
        [Fact]
        public void Should_Populate_Universe_From_File_Input()
        {
            // arrange
            var fileInput = new FileReader();
            var grid = new Universe(fileInput);
            var row = 0;
            var col = 0;
            var setUp = fileInput.ReadFile();
            var dimensions = grid.GetGridDimensions();
            var gridLength = dimensions[0];
            var gridWidth = dimensions[1]; 
            grid.SetUpGrid(gridLength, gridWidth);
            // act
            grid.Populate();
            // assert
            Assert.Equal(State.Alive, grid.Grid[row, col].CellState);
        }
    }
}