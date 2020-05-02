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
            Assert.AreEqual("File_not_found",(string)StateCensusAnalyser.numberOfRecords(actualPath));
        }

        /// <summary>
        ///Test case 1.3
        ///When csv file is correct but type is incorrect
        /// </summary>
        [Test]
        public void givenIncorrectFileFormat_whenCheckingFileFormat_shouldReturnsCustomException()
        {
            string actualpath = @"C:\Users\Birendra Kumar\source\repos\CensusData\StateCensusData.txt";
            Assert.AreEqual("File_format_Incorrect",StateCensusAnalyser.numberOfRecords(actualpath));
        }
    }
}