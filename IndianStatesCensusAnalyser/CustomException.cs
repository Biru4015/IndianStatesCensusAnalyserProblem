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
        // ExceptionType variable declared
        ExceptionType exception;

        // enum declaration to give constant values
        public enum ExceptionType
        {
            FILE_NOT_FOUND,
            INVALID_EXTENSION_OF_FILE,
            INCORRECT_DELIMETER,
            INVALID_HEADER_ERROR
        }

        public CensusAnalyserException(ExceptionType exception, string exceptionMessage) : base(exceptionMessage)
        {
            this.exception = exception;
        }
    }
}