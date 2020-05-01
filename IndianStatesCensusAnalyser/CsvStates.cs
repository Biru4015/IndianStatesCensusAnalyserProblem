using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyser
{
    /// <summary>
    /// Thhis class contains the code for load the CSV data 
    /// </summary>
    class CsvStates
    {
        /// <summary>
        /// This method is created for finding number of records
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static int getnumberOfRecords(string filepath)
        {
            int count = 0;
            string[] elements = File.ReadAllLines(filepath);
            IEnumerable<string> e = elements;
            foreach (var element in e)
            {
                count++;
            }
            return count - 1;
        }
    }
}