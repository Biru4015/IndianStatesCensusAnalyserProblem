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
        public string filepath;
        public char delimiter = ',';
        /// <summary>
        /// Constructor
        /// </summary>
        public StateCensusAnalyser(string filepath)
        {
            this.filepath = filepath;
        }
        public StateCensusAnalyser(string filepath, char delimiter)
        {
            this.filepath = filepath;
            this.delimiter = delimiter;
        }

        /// <summary>
        /// This is main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to India state census Analyzer");
        }
        public static object records(string filepath)
        {
            string[] a = File.ReadAllLines(filepath);
            return a.Length-1;
        }

        public Object numberOfRecords()
        {
            try
            {
                if (Path.GetExtension(filepath) != ".csv")
                {
                    throw new CustomException("File format Incorrect", CustomException.Exception.File_format_Incorrect);
                }
                if (filepath != @"C:\Users\Birendra Kumar\source\repos\CensusData\StateCensusData.csv")
                {
                    throw new CustomException("File not found", CustomException.Exception.File_not_found);
                }

                string[] data = File.ReadAllLines(filepath);

                foreach (var element in data)
                {
                    if (!element.Contains(delimiter))
                    {
                        throw new CustomException("Delimiter Incorrect", CustomException.Exception.Delimiter_Incorrect);
                    }
                }
                return data.Length-1;
            }
            catch (CustomException e)
            {
                return e.Message;
            }
        }

        public Object headerIncorrect()
        {
            try
            {
                string[] data = File.ReadAllLines(filepath);
                if (data[0] != "State,Population,AreaInSqKm,DensityPerSqKm")
                {
                    throw new CustomException("Header Incorrect", CustomException.Exception.Header_Incorrect);
                }
                return data.Length - 1;
            }
            catch(CustomException e)
            {
                return e.Message;
            }
        }
    }
}
