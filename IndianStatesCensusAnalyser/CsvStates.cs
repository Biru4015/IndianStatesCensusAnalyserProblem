using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using IndianStatesCensusAnalyser;
namespace IndianStatesCensusAnalyser
{
    public class CsvStateCensus
    {
        public string statecode;

        public delegate int GetCountFromCSVStates(string path, char delimiter = ',', string header = "SrNo,StateName,TIN,StateCode");
        public static int GetDataFromCSVFile(string statecode, char delimiter = ',', string header = "SrNo,StateName,TIN,StateCode")
        {
            try
            {
                bool type = CSVOperations.CheckFileType(statecode, ".csv");
                string[] records = CSVOperations.ReadCSVFile(statecode);
                bool delimit = CSVOperations.CheckForDelimiter(records, delimiter);
                bool head = CSVOperations.CheckForHeader(records, header);
                int count = CSVOperations.CountRecords(records);
                return count;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}