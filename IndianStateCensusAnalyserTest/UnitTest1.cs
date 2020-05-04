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
            int numberofRecords = (int)StateCensusAnalyser.NumberOfRecords(this.filePath);
            Assert.AreEqual(29, numberofRecords);
        }

        /// <summary>
        /// Test case 1.2
        /// For checking when incorrect file name entered raised exception
        /// </summary>
        [Test]
        public void WhenFileNameIncorect_WhenCheckingFilePath_ShouldReturnsFileNotFoundeException()
        {
            try
            {
                StateCensusAnalyser.NumberOfRecords(@"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCensusDatas.csv");
            }
            catch (CustomException exception)
            {
                Assert.AreEqual("File not found", exception.GetMessage);
            }
           
        }

        /// <summary>
        /// Test case 1.3
        /// When comma separated value file is correct but type is incorrect
        /// </summary>
        [Test]
        public void GivenIncorrectFileFormat_WhenCheckingFileFormat_ShouldReturnsCustomException()
        {
            try
            {
                StateCensusAnalyser.NumberOfRecords(@"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCensusDatas.txt");
            }
            catch(CustomException exception)
            {
                Assert.AreEqual("File format Incorrect", exception.GetMessage);
            }
        }

        /// <summary>
        /// Test case 1.4
        /// comma separated value file Correct but delimiter Incorrect
        /// </summary>
        [Test]
        public void WhenDelimeterNotPresent_WhenCkeckingInFile_ShouldReturnsCustomException()
        {
            try
            {
                StateCensusAnalyser.NumberOfRecords(@"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCensusData_DelimterChecking.csv");
            }
            catch (CustomException exception)
            {
                Assert.AreEqual("Header Incorrect or Delimeter Incorrect", exception.GetMessage);
            }
        }

        /// <summary>
        /// Test case 1.5
        /// comma separated value file Correct but header name is incorrect in file
        /// </summary>
        [Test]
        public void WhenHeaderIncorrect_WhenAnalyse_ShouldReturnCustomException()
        {
            try
            {
                StateCensusAnalyser.NumberOfRecords(@"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCensusData_DelimterChecking.csv");
            }
            catch(CustomException exception)
            {
                Assert.AreEqual("Header Incorrect or Delimeter Incorrect", exception.GetMessage);
            }
        }

        /// <summary>
        /// Test case 2.1 
        /// Test for checking number of Records in statecode csv
        /// </summary>
        [Test]
        public void GivenCSVStateCodeFile_WhenAnalyse_ReturnNumberOfRecordsMatch()
        {
            int actual = (int)CsvStateCensus.GetDataFromCSVFile(stateCode);
            Assert.AreEqual(37, actual);
        }

        /// <summary>
        /// Test case 2.2
        /// If file incorrect then throw custom exception for statecode csv
        /// </summary>
        [Test]
        public void GivenIncorrectfile_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            try
            {
                CsvStateCensus.GetDataFromCSVFile(@"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCodes.csv");
            }
            catch(CustomException exception)
            {
                Assert.AreEqual("File not found", exception.GetMessage);
            }
           
        }

        /// <summary>
        /// Test case 2.3
        /// If file type is incorrect throw custom exception for statecode csv
        /// </summary>
        [Test]
        public void GivenIncorrectfileType_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            try
            {
                CsvStateCensus.GetDataFromCSVFile(@"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCode.txt");
            }
            catch (CustomException exception)
            {
                Assert.AreEqual("File format Incorrect", exception.GetMessage);
            }
           
        }

        /// <summary>
        /// Test case 2.4
        /// comma separated file Correct but delimiter Incorrect
        /// </summary>
        [Test]
        public void GivenIncorrectDelimiter_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            try
            {
                CsvStateCensus.GetDataFromCSVFile(@"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCode_DelimterChecking.csv");
            }
            catch (CustomException exception)
            {
                Assert.AreEqual("Header Incorrect or Delimeter Incorrect", exception.GetMessage);
            }
            
        }

        /// <summary>
        /// Test case 2.5
        /// csv file Correct but header Incorrect
        /// </summary>
        [Test]
        public void GivenIncorrectHeader_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            try
            {
                CsvStateCensus.GetDataFromCSVFile(@"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCode_HeaderChecking.csv");
            }
            catch(CustomException exception)
            {
                Assert.AreEqual("Header Incorrect or Delimeter Incorrect", exception.GetMessage);
            }
        }

    }
}