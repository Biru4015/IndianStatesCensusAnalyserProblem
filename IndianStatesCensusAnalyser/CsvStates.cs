using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using IndianStatesCensusAnalyser;
namespace IndianStatesCensusAnalyser
{
    public class CsvStateCensus
    {
        public string filePath;
        public char delimiter = ',';

        /// <summary>
        /// Constructor
        /// </summary>
        public CsvStateCensus(string filePath)
        {
            this.filePath = filePath;
        }
        public CsvStateCensus(string filepath, char delimiter)
        {
            this.filePath = filepath;
            this.delimiter = delimiter;
        }

        public static object GettingRecords(string filepath)
        {
            string[] a = File.ReadAllLines(filepath);
            return a.Length - 1;
        }

        public Object GettingNumberOfRecords()
        {
            try
            {
                if (Path.GetExtension(filePath) != ".csv")
                {
                    throw new CustomException("File format Incorrect", CustomException.Exception.File_format_Incorrect);
                }
                if (filePath != @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCode.csv")
                {
                    throw new CustomException("File not found", CustomException.Exception.File_not_found);
                }

                string[] data = File.ReadAllLines(filePath);
                return data.Length - 1;
            }
            catch (CustomException e)
            {
                return e.Message;
            }
        }
    }
}