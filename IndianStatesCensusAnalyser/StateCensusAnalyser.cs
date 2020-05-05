namespace IndianStatesCensusAnalyser
{
    using System;
    using System.IO;
    using IndianStatesCensusAnalyser;

    /// <summary>
    /// This class contains the main method main of Indian states census analyser problem
    /// </summary>
    public class StateCensusAnalyser : CSVBuilder
    {
        public string filePath;

        /// <summary>
        /// This is main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to India state census Analyzer");
        }

        public delegate int GetCSVCount(string filepath, char delimiter = ',', string header = "State,Population,AreaInSqKm,DensityPerSqKm");
        public static int NumberOfRecords(string filepath, char delimiter = ',', string header = "State,Population,AreaInSqKm,DensityPerSqKm")
        {
            try
            {
                bool type = CSVOperations.CheckFileType(filepath, ".csv");
                string[] records = CSVOperations.ReadCSVFile(filepath);
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

        int CSVBuilder.NumberOfRecords(string filepath, char delimiter, string header)
        {
            throw new NotImplementedException();
        }

        int CSVBuilder.GetDataFromCSVFile(string statecode, char delimiter, string header)
        {
            throw new NotImplementedException();
        }
    }
}