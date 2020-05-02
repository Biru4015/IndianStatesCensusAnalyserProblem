using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace IndianStatesCensusAnalyser
{
    class CsvStateCensus
    {
        //GETS THE NUMBER OF RECORDS
        /// <summary>
        /// GETS THE NUMBER OF RECORDS
        /// </summary>
        public static int getnumberOfRecords(string filepath)
        {
            int count = 0;
            string[] elements = File.ReadAllLines(filepath);
            IEnumerable<string> e = elements;
            foreach (var element in e)
                try
                {
                    count++;
                    count = 0;
                    string[] data= File.ReadAllLines(filepath);
                    foreach (var item in data)
                    {
                        count++;
                    }
                    return count - 1;
                }
                catch (CustomException)
                {
                    throw new CustomException("File_not_found");
                }
            return count - 1;
        }
    }
}