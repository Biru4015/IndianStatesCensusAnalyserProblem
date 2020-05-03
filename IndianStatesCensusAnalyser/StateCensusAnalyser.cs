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
        public char delimiter = ',';

        /// <summary>
        /// Constructor
        /// </summary>
        public StateCensusAnalyser(string filePath)
        {
            this.filePath = filePath;
        }
        public StateCensusAnalyser(string filepath, char delimiter)
        {
            this.filePath = filepath;
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
        public static object Records(string filepath)
        {
            string[] a = File.ReadAllLines(filepath);
            return a.Length-1;
        }

        public Object NumberOfRecords()
        {
            try
            {
                if (Path.GetExtension(filePath) != ".csv")
                {
                    throw new CustomException("File format Incorrect", CustomException.Exception.File_format_Incorrect);
                }
                if (filePath != @"C:\Users\Birendra Kumar\source\repos\IndianStatesCensusAnalyser\Files\StateCensusData.csv")
                {
                    throw new CustomException("File not found", CustomException.Exception.File_not_found);
                }

                string[] data = File.ReadAllLines(filePath);

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

        /// <summary>
        ///This method is for 
        /// </summary>
        /// <returns></returns>
        public Object HeaderIncorrect()
        {
            try
            {
                string[] data = File.ReadAllLines(filePath);
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
