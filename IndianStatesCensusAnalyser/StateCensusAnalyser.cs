namespace IndianStatesCensusAnalyser
{
    using System;
    using System.IO;
    using IndianStatesCensusAnalyser;

    /// <summary>
    /// This class contains the main method main of Indian states census analyser problem
    /// </summary>
    public class StateCensusAnalyser
    {
        public string filePath;

        /// <summary>
        /// Constructor
        /// </summary>
        public StateCensusAnalyser(string filePath)
        {
            this.filePath = filePath;
        }

        /// <summary>
        /// This is main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to India state census Analyzer");
        }

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
    }
}