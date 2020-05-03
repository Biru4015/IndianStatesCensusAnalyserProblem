namespace IndianStateCensusAnalyserTest
{
    using IndianStatesCensusAnalyser;
    using NUnit.Framework;
    using System;

    /// <summary>
    /// This class contains the code for testing all the use cases
    /// </summary>
    public class Tests
    {
        /// <summary>
        /// Reading the file path
        /// </summary>
        private string filePath = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCensusData.csv";
        private string stateCode = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCode.csv";

        /// <summary>
        /// Test case 1.1
        /// For checking number of records in StateCensusData are matches or not
        /// </summary>
        [Test]
        public void GivenNumOfState_WhenCheckingnumberOfRecords_ShouldReturnsNumOfRecords()
        {
            int numberofRecords = (int)StateCensusAnalyser.Records(this.filePath);
            Assert.AreEqual(29, numberofRecords);
        }

        /// <summary>
        /// Test case 1.2
        /// For checking when incorrect file name entered raised exception
        /// </summary>
        [Test]
        public void WivenFileNameIncorect_WhenCheckingFilePath_ShouldReturnsFileNotFoundeException()
        {
            string actualPath = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCensusDatas.csv";
            StateCensusAnalyser stateCensus = new StateCensusAnalyser(actualPath);
            Assert.AreEqual("File not found", stateCensus.NumberOfRecords());
        }

        /// <summary>
        /// Test case 1.3
        /// When comma separated value file is correct but type is incorrect
        /// </summary>
        [Test]
        public void GivenIncorrectFileFormat_WhenCheckingFileFormat_ShouldReturnsCustomException()
        {
            string actualPath = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCensusData.txt";
            StateCensusAnalyser stateCensus = new StateCensusAnalyser(actualPath);
            Assert.AreEqual("File format Incorrect", stateCensus.NumberOfRecords());
        }

        /// <summary>
        /// Test case 1.4
        /// comma separated value file Correct but delimiter Incorrect
        /// </summary>
        [Test]
        public void WhenDelimeterNotPresent_WhenCkeckingInFile_ShouldReturnsCustomException()
        {
            string actualPath = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCensusData.csv";
            StateCensusAnalyser stateCensus = new StateCensusAnalyser(actualPath);
            Assert.AreEqual("Delimiter Incorrect", stateCensus.NumberOfRecords());
        }

        /// <summary>
        /// Test case 1.5
        /// comma separated value file Correct but header name is incorrect in file
        /// </summary>
        [Test]
        public void WhenHeaderIncorrect_WhenAnalyse_ShouldReturnCustomException()
        {
            string actualPath = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCensusData_Header.csv";
            StateCensusAnalyser stateCensus = new StateCensusAnalyser(actualPath);
            Assert.AreEqual("Header Incorrect", stateCensus.HeaderIncorrect());
        }

        /// <summary>
        /// Test case 2.1 
        /// Test for checking number of Records in statecode csv
        /// </summary>
        [Test]
        public void GivenCSVStateCodeFile_WhenAnalyse_ReturnNumberOfRecordsMatch()
        {
            int actual =(int)CsvStateCensus.GettingRecords(stateCode);
            Assert.AreEqual(37,actual);
        }

        /// <summary>
        /// Test case 2.2
        /// If file incorrect then throw custom exception for statecode csv
        /// </summary>
        [Test]
        public void GivenIncorrectfile_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            string actualPath = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCodes.csv";
            CsvStateCensus csvState = new CsvStateCensus(actualPath);
            Assert.AreEqual("File not found", (string)csvState.GettingNumberOfRecords());
        }

        /// <summary>
        /// Test case 2.3
        /// If file type is incorrect throw custom exception for statecode csv
        /// </summary>
        [Test]
        public void GivenIncorrectfileType_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            string actualPath= @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCodes.txt";
            CsvStateCensus csvState = new CsvStateCensus(actualPath);
            Assert.AreEqual("File format Incorrect",csvState.GettingNumberOfRecords());
        }

        /// <summary>
        ///Test case 1.4
        /// comma separated file Correct but delimiter Incorrect
        /// </summary>
        [Test]
        public void GivenIncorrectDelimiter_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            string actualPath = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCode.csv";
            CsvStateCensus csvState = new CsvStateCensus(actualPath);
            Assert.AreEqual("Delimiter Incorrect", csvState.GettingNumberOfRecords());
        }

        /// <summary>
        ///TC-1.5:csv file Correct but header Incorrect
        /// </summary>
        [Test]
        public void GivenIncorrectHeader_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            string actualPath = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCode_HeaderChecking.csv";
            CsvStateCensus csvState = new CsvStateCensus(actualPath);
            Assert.AreEqual("Header Incorrect", csvState.HeaderIncorrect());
        }
    }
}