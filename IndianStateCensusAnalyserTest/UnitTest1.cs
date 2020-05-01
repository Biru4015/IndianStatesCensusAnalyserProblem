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
            int numberofRecords = (int)StateCensusAnalyser.numberOfRecords(filepath);
            Assert.AreEqual(29, numberofRecords);
        }

        /// <summary>
        /// Test case 1.2
        /// For checking when incorrect file name enterd raised exception
        /// </summary>
        [Test]
        public void fileNameIncorect_whenCheckingFilePath_shouldReturnsFileNotFoundeException()
        {
            string actualPath = @"C:\Users\Birendra Kumar\source\repos\CensusData\StateCensusData.csr";
            Assert.AreEqual("File not found",(string)StateCensusAnalyser.numberOfRecords(actualPath));
        }
    }
}