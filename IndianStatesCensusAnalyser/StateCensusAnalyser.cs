using System;
using System.IO;
using IndianStatesCensusAnalyser;

namespace IndianStatesCensusAnalyser
{
    /// <summary>
    /// This class contains the main method main of Indian states census analyser problem
    /// </summary>
    public class StateCensusAnalyser
    {
        private object filepath;

        /// <summary>
        /// This is main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to India state census Analyzer");
        }
        public static object numberOfRecords(string filepath)
        {
            try
            {
                if (filepath != @"C:\Users\Birendra Kumar\source\repos\CensusData\StateCensusData.csv")
                {
                    throw new CustomException("File not found");
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
