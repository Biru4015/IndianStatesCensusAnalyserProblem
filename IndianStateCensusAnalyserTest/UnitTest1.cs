using IndianStatesCensusAnalyser;
using NUnit.Framework;
namespace IndianStateCensusAnalyserTest
{
    /// <summary>
    /// This class contains the code for testing all the use cases
    /// </summary>
    public class Tests
    {
        public string filepath = @"C:\Users\Birendra Kumar\source\repos\CensusData\StateCensusData.csv";
        /// <summary>
        /// Test case 1.1
        /// For checking number of records in StateCensusData are matches or not
        /// </summary>
        [Test]
        public void givenNumOfState_whaeCheckingnumberOfRecords_shouldReturnsNumOfRecords()
        {
            int numberofRecords = (int)StateCensusAnalyser.records(filepath);
            Assert.AreEqual(29, numberofRecords);
        }

        /// <summary>
        /// Test case 1.2
        /// For checking when incorrect file name enterd raised exception
        /// </summary>
        [Test]
        public void givenFileNameIncorect_whenCheckingFilePath_shouldReturnsFileNotFoundeException()
        {
            string actualPath = @"C:\Users\Birendra Kumar\source\repos\CensusData\StateCensusDatas.csv";
            StateCensusAnalyser stateCensus = new StateCensusAnalyser(actualPath);
            Assert.AreEqual("File not found", stateCensus.numberOfRecords());
        }

        /// <summary>
        ///Test case 1.3
        ///When csv file is correct but type is incorrect
        /// </summary>
        [Test]
        public void givenIncorrectFileFormat_whenCheckingFileFormat_shouldReturnsCustomException()
        {
            string actualPath = @"C:\Users\Birendra Kumar\source\repos\CensusData\StateCensusData.txt";
            StateCensusAnalyser stateCensus = new StateCensusAnalyser(actualPath);
            Assert.AreEqual("File format Incorrect", stateCensus.numberOfRecords());
        }

        /// <summary>
        ///Test case 1.4
        ///csv file Correct but delimiter Incorrect
        /// </summary>
        [Test]
        public void whenDelimeterNotPresent_whenCkeckingInFile_shouldReturnsCustomException()
        {
            string actualPath = @"C:\Users\Birendra Kumar\source\repos\CensusData\StateCensusData.csv";
            StateCensusAnalyser stateCensus = new StateCensusAnalyser(actualPath);
            Assert.AreEqual("Delimiter Incorrect", stateCensus.numberOfRecords());
        }

        /// <summary>
        ///Test case 1.5
        ///csv file Correct but header name is incorrect in file
        /// </summary>
        [Test]
        public void whenHeaderIncorrect_whenAnalyse_shouldReturnCustomException()
        {
            string actualPath = @"C:\Users\Birendra Kumar\source\repos\CensusData\HeaderWrong\StateCensusData.csv";
            StateCensusAnalyser stateCensus = new StateCensusAnalyser(actualPath);
            Assert.AreEqual("Header Incorrect", stateCensus.headerIncorrect());
        }
    }
}