using LeagueBackEndChallenge;
using System;
using Xunit;

namespace Tests
{
    public class FileServiceTest
    {
        [Fact]
        public void ShouldLoadFileSucess()
        {
            FileService.LoadFile("matrix.csv");
            Assert.True(FileService.NumberOfColumns == 3);
            Assert.True(FileService.NumberOfRows == 3);
        }

        [Fact]
        public void ShouldLoadFileInvalidFileName()
        {
            var ex = Assert.Throws<Exception>(() => FileService.LoadFile("invalidfilepath"));

            Assert.Contains("File doesn't exist, press enter to return to main menu.", ex.Message);
        }

        [Fact]
        public void ShouldLoadFileInvalidFileContent()
        {
            var ex = Assert.Throws<Exception>(() => FileService.LoadFile("matrixInvalid.csv"));

            Assert.Contains("File is not valid, must be a csv with same number of columns and rows.", ex.Message);
        }

        [Fact]
        public void ShouldLoadFileInvalidFileContentNotNumbers()
        {
            var ex = Assert.Throws<Exception>(() => FileService.LoadFile("matrixInvalidNotNumbers.csv"));

            Assert.Contains("Not all elements of the file are numbers, must be csv with only numbers.", ex.Message);
        }

        [Fact]
        public void ShouldPrintRowAsMatrixSuccess()
        {
            FileService.LoadFile("matrix.csv");
            var result = FileService.GetRow();
            Assert.Equal(result, $"1,2,3\n4,5,6\n7,8,9\n");
        }

        [Fact]
        public void ShouldPrintRowsAsMatrixInvertedSuccess()
        {
            FileService.LoadFile("matrix.csv");
            var result = FileService.GetInvert();
            Assert.Equal(result, $"1,4,7\n2,5,8\n3,6,9\n");
        }

        [Fact]
        public void ShouldPrintRowsAsMatrixFlattenSuccess()
        {
            FileService.LoadFile("matrix.csv");
            var result = FileService.GetFlatten();
            Assert.Equal(result, $"1,2,3,4,5,6,7,8,9");
        }

        [Fact]
        public void ShouldPrintSumOfMatrixElements()
        {
            FileService.LoadFile("matrix.csv");
            var result = FileService.GetSum();
            Assert.Equal(45, result);
        }

        [Fact]
        public void ShouldPrintMultiplyOfMatrixElements()
        {
            FileService.LoadFile("matrix.csv");
            var result = FileService.GetMultiply();
            Assert.Equal(362880, result);
        }
    }
}
