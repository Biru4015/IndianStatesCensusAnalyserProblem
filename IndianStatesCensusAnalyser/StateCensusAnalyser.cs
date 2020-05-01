using System;
using System.IO;

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
        public static int numberOfRecords(string filepath)
        {
            string[] data = File.ReadAllLines(filepath);
            return data.Length - 1;
        }
    }
}
