namespace IndianStateCensusAnalyserTest
{
    using IndianStatesCensusAnalyser;
    using NUnit.Framework;
    using System;
    using static IndianStatesCensusAnalyser.CsvStatesDao;
    using static IndianStatesCensusAnalyser.StateCensusAnalyserDao;

    /// <summary>
    /// This class contains the code for testing all the use cases
    /// </summary>
    public class CensusAnalyserTest
    {
        //// with NameSpace Assembly reference 
        //// DeligateMethod -------Object-------Reference to delegate method
        readonly CsvStateCensusDataDao stateCensus = CSVFactory.DelegateOfStateCensusAnalyser();
        readonly CsvStateCodeDataDao stateCode = CSVFactory.DelegateOfCsvStates();

        //// FilePath ,Valid and Invalid Headers of StateCensusData
        public string stateCensusDataPath = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCensusData.csv";
        public string stateCensusDataPathIncorrectName = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCensusDatas.csv";
        public string stateCensusDataPathIncorrectExtension = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCensusData.txt";
        public string[] headerStateCensus = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
        public string[] headerStateCensusInvalid = { "State", "InvalidHeader", "AreaInSqKm", "DensityPerSqKm" };

        //// FilePath ,Valid and Invalid Headers of StateCode
        public string stateCodePath = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCode.csv";
        public string stateCodePathIncorrectName = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCodes.csv";
        public string stateCodePathIncorrectExtension = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCode.txt";
        public string[] headerStateCode = { "SrNo", "State", "PIN", "StateCode" };
        public string[] headerStateCodeInvalid = { "SrNo", "StateInvalid", "PIN", "StateCode" };

        //// Correct and Incorrect Delimeter
        char delimeter = ',';
        char IncorrectDelimeter = ';';

        //// FilePath of JSON files
        public string jsonPathstateCensus = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCensusData.json";
        public string jsonPathStateCode = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCode.json";

        /// <summary>
        /// Test case 1.1
        /// For checking number of records in StateCensusData are matches or not
        /// </summary>
        [Test]
        public void GivenNumOfState_WhenCheckingnumberOfRecords_ShouldReturnsNumOfRecords()
        {
            var numberOfRecords = stateCensus(headerStateCensus, delimeter, stateCensusDataPath);
            Assert.AreEqual(29, numberOfRecords);

        }

        /// <summary>
        /// Test case 1.2
        /// For checking when incorrect file name entered raised exception
        /// </summary>
        [Test]
        public void WhenFileNameIncorect_WhenCheckingFilePath_ShouldReturnsFileNotFoundeException()
        {
            object exceptionMessage = stateCensus(headerStateCensus, delimeter, stateCensusDataPathIncorrectName);
            Assert.AreEqual("Invalid file", exceptionMessage);
        }

        /// <summary>
        /// Test case 1.3
        /// When comma separated value file is correct but type is incorrect
        /// </summary>
        [Test]
        public void GivenIncorrectFileFormat_WhenCheckingFileFormat_ShouldReturnsCustomException()
        {
            object exceptionMessage = stateCensus(headerStateCensus, delimeter, stateCensusDataPathIncorrectExtension);
            Assert.AreEqual("Invalid Extension of file", exceptionMessage);
        }

        /// <summary>
        /// Test case 1.4
        /// comma separated value file Correct but delimiter Incorrect
        /// </summary>
        [Test]
        public void WhenDelimeterNotPresent_WhenCkeckingInFile_ShouldReturnsCustomException()
        {
            object exceptionMessage = stateCensus(headerStateCensus, IncorrectDelimeter, stateCensusDataPath);
            Assert.AreEqual("Incorrect Delimeter", exceptionMessage);
        }

        /// <summary>
        /// Test case 1.5
        /// comma separated value file Correct but header name is incorrect in file
        /// </summary>
        [Test]
        public void WhenHeaderIncorrect_WhenAnalyse_ShouldReturnCustomException()
        {
            object exceptionMessage = stateCensus(headerStateCensusInvalid, delimeter, stateCensusDataPath);
            Assert.AreEqual("Invalid Header", exceptionMessage);
        }

        /// <summary>
        /// Test case 2.1 
        /// Test for checking number of Records in statecode csv
        /// </summary>
        [Test]
        public void GivenCSVStateCodeFile_WhenAnalyse_ReturnNumberOfRecordsMatch()
        {
            var numberOfRecords = stateCode(headerStateCode, delimeter, stateCodePath);
            Assert.AreEqual(37, numberOfRecords);
        }

        /// <summary>
        /// Test case 2.2
        /// If file incorrect then throw custom exception for statecode csv
        /// </summary>
        [Test]
        public void GivenIncorrectfile_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            object exceptionMessage = stateCode(headerStateCode, delimeter, stateCodePathIncorrectName);
            Assert.AreEqual("Invalid file", exceptionMessage);
        }

        /// <summary>
        /// Test case 2.3
        /// If file type is incorrect throw custom exception for statecode csv
        /// </summary>
        [Test]
        public void GivenIncorrectfileType_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            object exceptionMessage = stateCode(headerStateCode, delimeter, stateCodePathIncorrectExtension);
            Assert.AreEqual("Invalid Extension of file", exceptionMessage);
        }

        /// <summary>
        /// Test case 2.4
        /// comma separated file Correct but delimiter Incorrect
        /// </summary>
        [Test]
        public void GivenIncorrectDelimiter_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            object exceptionMessage = stateCode(headerStateCode, IncorrectDelimeter, stateCodePath);
            Assert.AreEqual("Incorrect Delimeter", exceptionMessage);
        }

        /// <summary>
        /// Test case 2.5
        /// csv file Correct but header Incorrect
        /// </summary>
        [Test]
        public void GivenIncorrectHeader_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            object exceptionMessage = stateCode(headerStateCodeInvalid, delimeter, stateCodePath);
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
            string lastValue = JSONCensus.SortCsvFileWriteInJsonAndReturnFirstData(stateCensusDataPath, jsonPathstateCensus, "State");
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
            string lastValue = JSONCensus.SortCsvFileWriteInJsonAndReturnLastData(stateCensusDataPath, jsonPathstateCensus, "State");
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
            string lastValue = JSONCensus.SortCsvFileWriteInJsonAndReturnFirstData(stateCodePath, jsonPathStateCode, "StateCode");
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
            string lastValue = JSONCensus.SortCsvFileWriteInJsonAndReturnLastData(stateCodePath, jsonPathStateCode, "StateCode");
            Assert.AreEqual(expected, lastValue);
        }

        /// <summary>
        /// Test case 5.1
        /// Test case for checking most populous state census state file.
        /// </summary>
        [Test]
        public void CheckingMostPopulousState_WhenSorted_ShouldReturnsTheNumberOfStates()
        {
            string expected = "199812341";
            string mostPopulation = JSONCensus.ReturnDataNumberOfStatesSortCSVFileAndWriteInJson(stateCensusPath, jsonPathstateCensus, "Population");
            Assert.AreEqual(expected, mostPopulation);
        }
    }
}