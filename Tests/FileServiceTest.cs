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
    }
}
