using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using IndianStatesCensusAnalyser;
namespace IndianStatesCensusAnalyser
{
    public class CsvStateCensus
    {
        /// <summary>
        /// Initialize the object
        /// </summary>
        private object filepath;

        /// <summary>
        /// GETS THE NUMBER OF RECORDS
        /// </summary>
        public static Object GetNumberOfRecords(string filepath)
        {
            try
            {
                if (filepath != @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCode.csv")
                {
                    throw new CustomException("File not found",CustomException.Exception.File_not_found);
                }
                string[] data = File.ReadAllLines(filepath);
                return data.Length - 1;
            }
            catch (CustomException e)
            {
                return e.message;
            }
        }
    }
}