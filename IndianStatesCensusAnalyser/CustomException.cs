using System;
using IndianStatesCensusAnalyser;
using System.Runtime.Serialization;

namespace IndianStatesCensusAnalyser
{
    /// <summary>
    /// This class contains the code of custom exception
    /// </summary>
    public class CensusAnalyserException : Exception
    {
        //// ExceptionType variable declared
        ExceptionType exception;

        /// <summary>
        ///  Eum declaration to give constant values
        /// </summary>
        public enum ExceptionType
        {
            FILE_NOT_FOUND,
            INVALID_EXTENSION_OF_FILE,
            INCORRECT_DELIMETER,
            INVALID_HEADER_ERROR
        }

        /// <summary>
        /// This method is created for exception messages
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="exceptionMessage"></param>
        public CensusAnalyserException(ExceptionType exception, string exceptionMessage) : base(exceptionMessage)
        {
            this.exception = exception;
        }
    }
}