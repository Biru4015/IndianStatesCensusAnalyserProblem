namespace IndianStateCensusAnalyserTest
{
    using IndianStatesCensusAnalyser;
    using NUnit.Framework;
    using System;
    using static IndianStatesCensusAnalyser.CsvStates;
    using static IndianStatesCensusAnalyser.StateCensusAnalyser;

    /// <summary>
    /// This class contains the code for testing all the use cases
    /// </summary>
    public class CensusAnalyserTest
    {
        //with NameSpace Assembly reference 
        // DeligateMethod -------Object-------Reference to delegate method
        readonly CsvStateCensusData stateCensus = CSVFactory.DelegateOfStateCensusAnalyser();
        readonly CsvStateCodeData stateCode = CSVFactory.DelegateOfCsvStates();

        public string jsonPathstateCensus = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCensusData.json";
        public string jsonPathStateCode = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCode.json";


        /// <summary>
        /// Test case 1.1
        /// For checking number of records in StateCensusData are matches or not
        /// </summary>
        [Test]
        public void GivenNumOfState_WhenCheckingnumberOfRecords_ShouldReturnsNumOfRecords()
        {
            char delimeter = ',';
            string[] header = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
            string path = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCensusData.csv";
            var numberOfRecords = stateCensus(header, delimeter, path);
            Assert.AreEqual(29, numberOfRecords);
        }

        /// <summary>
        /// Test case 1.2
        /// For checking when incorrect file name entered raised exception
        /// </summary>
        [Test]
        public void WhenFileNameIncorect_WhenCheckingFilePath_ShouldReturnsFileNotFoundeException()
        {
            string incorrectPath = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCensusDatas.csv";
            char delimeter = ',';
            string[] header = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
            object exceptionMessage = stateCensus(header, delimeter, incorrectPath);
            Assert.AreEqual("Invalid file", exceptionMessage);
        }

        /// <summary>
        /// Test case 1.3
        /// When comma separated value file is correct but type is incorrect
        /// </summary>
        [Test]
        public void GivenIncorrectFileFormat_WhenCheckingFileFormat_ShouldReturnsCustomException()
        {
            char delimeter = ',';
            string[] header = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
            string inCorrectExtensionPath = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCensusData.txt";
            object exceptionMessage = stateCensus(header, delimeter, inCorrectExtensionPath);
            Assert.AreEqual("Invalid Extension of file", exceptionMessage);
        }

        /// <summary>
        /// Test case 1.4
        /// comma separated value file Correct but delimiter Incorrect
        /// </summary>
        [Test]
        public void WhenDelimeterNotPresent_WhenCkeckingInFile_ShouldReturnsCustomException()
        {
            char userDelimeter = ';';
            string path = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCensusData.csv";
            object exceptionMessage = stateCensus(null, userDelimeter, path);
            Assert.AreEqual("Incorrect Delimeter", exceptionMessage);
        }

        /// <summary>
        /// Test case 1.5
        /// comma separated value file Correct but header name is incorrect in file
        /// </summary>
        [Test]
        public void WhenHeaderIncorrect_WhenAnalyse_ShouldReturnCustomException()
        {
            string[] header = { "State", "InvalidHeader", "AreaInSqKm", "DensityPerSqKm" };
            char userDelimeter = ',';
            string path = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCensusData.csv";
            object exceptionMessage = stateCensus(header, userDelimeter, path);
            Assert.AreEqual("Invalid Header", exceptionMessage);
        }

        /// <summary>
        /// Test case 2.1 
        /// Test for checking number of Records in statecode csv
        /// </summary>
        [Test]
        public void GivenCSVStateCodeFile_WhenAnalyse_ReturnNumberOfRecordsMatch()
        {
            char delimeter = ',';
            string[] header = { "SrNo", "State", "PIN", "StateCode" };
            string path = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCode.csv";
            var numberOfRecords = stateCode(header, delimeter, path);
            Assert.AreEqual(37, numberOfRecords);
        }

        /// <summary>
        /// Test case 2.2
        /// If file incorrect then throw custom exception for statecode csv
        /// </summary>
        [Test]
        public void GivenIncorrectfile_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            char delimeter = ',';
            string[] header = { "SrNo", "State", "PIN", "StateCode" };
            string path = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCodes.csv";
            object exceptionMessage = stateCode(header, delimeter, path);
            Assert.AreEqual("Invalid file", exceptionMessage);
        }

        /// <summary>
        /// Test case 2.3
        /// If file type is incorrect throw custom exception for statecode csv
        /// </summary>
        [Test]
        public void GivenIncorrectfileType_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            char delimeter = ',';
            string[] header = { "SrNo", "State", "PIN", "StateCode" };
            string path = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCode.txt";
            object exceptionMessage = stateCode(header, delimeter, path);
            Assert.AreEqual("Invalid Extension of file", exceptionMessage);
        }

        /// <summary>
        /// Test case 2.4
        /// comma separated file Correct but delimiter Incorrect
        /// </summary>
        [Test]
        public void GivenIncorrectDelimiter_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            char delimeter = ';';
            string[] header = { "SrNo", "State", "PIN", "StateCode" };
            string path = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCode.csv";
            object exceptionMessage = stateCode(header, delimeter, path);
            Assert.AreEqual("Incorrect Delimeter", exceptionMessage);
        }

        /// <summary>
        /// Test case 2.5
        /// csv file Correct but header Incorrect
        /// </summary>
        [Test]
        public void GivenIncorrectHeader_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            char delimeter = ',';
            string[] header = { "SrNo", "InvalidState", "PIN", "StateCode" };
            string path = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCode.csv";
            object exceptionMessage = stateCode(header, delimeter, path);
            Assert.AreEqual("Invalid Header", exceptionMessage);
        }

        /// <summary>
        /// Test case 3.1
        /// Test for StateCensuscsv and json path to add into json after sorting return return first state.
        /// </summary>
        [Test]
        public void CheckStateCensusDataAndAddToJsonPathAndSorting_WhenSorted_ShouldReturnFirstStateAP()
        {
            string expected = "Andhra Pradesh";
            string stateCensusfilePath = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCensusData.csv";
            string lastValue = JSONCensus.SortCsvFileWriteInJsonAndReturnFirstData(stateCensusfilePath, jsonPathstateCensus, "State");
            Assert.AreEqual(expected, lastValue);
        }

        /// <summary>
        /// Test case 3.2
        /// Test for StateCensuscsv and json path to add into json after sorting return return last state.
        /// </summary>
        [Test]
        public void CheckStateCensusDataAndAddToJsonPathAndSorting_WhenSorted__ShouldReturnLastStateWB()
        {
            string expected = "West Bengal";
            string stateCensusfilePath = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCensusData.csv";
            string lastValue = JSONCensus.SortCsvFileWriteInJsonAndReturnLastData(stateCensusfilePath, jsonPathstateCensus, "State");
            Assert.AreEqual(expected, lastValue);
        }

        /// <summary>
        /// Test case 4.1
        /// Test for StateCodeCsv and json path to add into json after sorting return return first stateCode.
        /// </summary>
        [Test]
        public void CheckStateCensusDataAndAddToJsonPathAndSorting_WhenSorted_ShouldReturnsFirstStateCode()
        {
            string expected = "AD";
            string stateCensusfilePath = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCode.csv";
            string lastValue = JSONCensus.SortCsvFileWriteInJsonAndReturnFirstData(stateCensusfilePath, jsonPathStateCode, "StateCode");
            Assert.AreEqual(expected, lastValue);
        }

        /// <summary>
        /// Test case 4.2
        /// Test for StateCodeCsv and json path to add into json after sorting return return last stateCode.
        /// </summary>
        [Test]
        public void CheckStateCensusDataAndAddToJsonPathAndSorting_WhenSorted_ShouldReturnsLatStateCode()
        {
            string expected = "WB";
            string stateCensusfilePath = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCode.csv";
            string lastValue = JSONCensus.SortCsvFileWriteInJsonAndReturnLastData(stateCensusfilePath, jsonPathStateCode, "StateCode");
            Assert.AreEqual(expected, lastValue);
        }
    }
}