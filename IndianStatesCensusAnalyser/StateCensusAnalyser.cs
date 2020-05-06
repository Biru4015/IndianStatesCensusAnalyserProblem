namespace IndianStatesCensusAnalyser
{
    using System;
    using System.IO;
    using IndianStatesCensusAnalyser;

    /// <summary>
    /// This class contains the main method main of Indian states census analyser problem
    /// </summary>
    public class StateCensusAnalyser : ICSVBuilder
    {
        public static string stateCensusPath = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCensusData.csv";
        // variables declaration
        string[] header;
        char delimeter;
        string givenPath;

        // Main Method
        static void Main(string[] args)
        {
        }//end: static void Main(string[] args)

        // Default Constructor
        public StateCensusAnalyser()
        {
        }

        // CsvStates parameterised constructor
        public StateCensusAnalyser(string[] header, char delimeter, string givenPath)
        {
            this.header = header;
            this.delimeter = delimeter;
            this.givenPath = givenPath;
        }

        // Delegate is a reference type variable that hold the refenence to a method
        public delegate object CsvStateCensusData(string[] header, char delimeter, string givenPath);

        /// <CsvStateCodeReadRecord>
        /// Creating object of class 'CensusReadRecord' as 'stateCodePathObject,
        /// return object is returnrd to test case.
        /// </CsvStateCodeReadRecord>
        /// <returns></returnObject>
        public static object CsvStateCensusReadRecord(string[] header, char delimeter, string givenPath)
        {
            CsvStateCensusReadRecord stateCensusPathObject = new CsvStateCensusReadRecord(stateCensusPath);
            var returnObject = stateCensusPathObject.ReadRecords(header, delimeter, givenPath);
            return returnObject;
        }

        object ICSVBuilder.CsvStateCensusReadRecord(string[] header, char delimeter, string givenPath)
        {
            throw new NotImplementedException();
        }

        object ICSVBuilder.CsvStateCodeReadRecord(string[] header, char delimeter, string givenPath)
        {
            throw new NotImplementedException();
        }
    }
}