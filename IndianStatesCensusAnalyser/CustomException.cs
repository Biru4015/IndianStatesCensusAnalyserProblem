using System;
using IndianStatesCensusAnalyser;
using System.Runtime.Serialization;

namespace IndianStatesCensusAnalyser
{
    /// <summary>
    /// This class contains the code of custom exception
    /// </summary>
    public class CustomException : Exception
    {
        public string message;

        public string GetMessage 
        { 
            get => this.message; 
        }
        //constructor
        public CustomException(string message)
        {
            this.message = message;
        }
    }
}