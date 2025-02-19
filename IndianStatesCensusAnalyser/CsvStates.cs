﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using IndianStatesCensusAnalyser;
namespace IndianStatesCensusAnalyser
{
    public class CsvStatesDao : ICSVBuilder
    {
        public static string stateCodePath = @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\CSVFiles\StateCode.csv";
        //// variables declaration
        readonly string[] header;
        readonly char delimeter;
        readonly string givenPath;

        /// <summary>
        ///  Default Constructor
        /// </summary>
        public CsvStatesDao()
        {
        }

        /// <summary>
        /// CsvStates parameterised constructor 
        /// </summary>
        /// <param name="header"></param>
        /// <param name="delimeter"></param>
        /// <param name="givenPath"></param>
        public CsvStatesDao(string[] header, char delimeter, string givenPath)
        {
            this.header = header;
            this.delimeter = delimeter;
            this.givenPath = givenPath;
        }

        //// Delegate is a reference type variable that hold the refenence to a method
        public delegate object CsvStateCodeDataDao(string[] header, char delimeter, string givenPath);

        /// <CsvStateCodeReadRecord>
        /// Creating object of class 'StateCensusAnalyser' as 'stateCodePathObject,
        /// return object is returnrd to test case.
        /// </CsvStateCodeReadRecord>
        /// <returns></returnObject>
        public static object CsvStateCodeReadRecord(string[] header, char delimeter, string givenPath)
        {
            CsvStateCensusReadRecord stateCodePathObject = new CsvStateCensusReadRecord(stateCodePath);
            var returnObject = stateCodePathObject.ReadRecords(header, delimeter, givenPath);
            return returnObject;
        }

        private static CsvStatesDao InstanceOfCsvStates()
        {
            throw new NotImplementedException();
        }

        private static StateCensusAnalyserDao InstanceOfStateCensusAnalyser()
        {
            throw new NotImplementedException();
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