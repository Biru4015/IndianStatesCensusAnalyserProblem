using System;
using System.Collections.Generic;
using System.Text;
using IndianStatesCensusAnalyser;

namespace CensusAnalyserProblem
{
    /// <summary>
    /// This class contains the code of CSVException
    /// </summary>
    public class CSVException : Exception
    {
        //// exception variable declared
        ExceptionType exception;

        /// <summary>
        /// Enum declaration to give constant value
        /// </summary>
        public enum ExceptionType
        {
            FILE_IS_EMPTY
        }

        /// <summary>
        /// This  method is created for exception method
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        public CSVException(ExceptionType exception, string message) : base(message)
        {
            this.exception = exception;
        }
    }
}