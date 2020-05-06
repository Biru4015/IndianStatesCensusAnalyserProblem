using System;
using System.IO;
using CensusAnalyserProblem;
using System.Collections.Generic;
using LumenWorks.Framework.IO.Csv;

namespace IndianStatesCensusAnalyser
{
    class CsvStateCensusReadRecord
    {
        // Variables
        string actualPath;
        char delimeter;
        int numberOfRecord;

        // Default Constrructor
        public CsvStateCensusReadRecord()
        {
        }

        //Parameterised constructor
        public CsvStateCensusReadRecord(string filePath = null)
        {
            this.actualPath = filePath;
        }

        // ReadRecords Method
        public object ReadRecords(string[] passHeader = null, char in_delimeter = ',', string filePath = null)
        {
            try
            {
                if (!filePath.Contains(".csv"))
                {
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_EXTENSION_OF_FILE, "Invalid Extension of file");
                }
                else if (!filePath.Contains(actualPath))
                {
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, "Invalid file");
                }

                CsvReader csvRecords = new CsvReader(new StreamReader(filePath), true);
                string[] headers = csvRecords.GetFieldHeaders();
                delimeter = csvRecords.Delimiter;
                while (csvRecords.ReadNextRecord())
                {
                    numberOfRecord++;
                }

                if (numberOfRecord == 0)
                {
                    throw new CSVException(CSVException.ExceptionType.FILE_IS_EMPTY, "File has no data");
                }
                if (!in_delimeter.Equals(delimeter))
                {
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INCORRECT_DELIMETER, "Incorrect Delimeter");
                }
                else if (!IsHeaderSame(passHeader, headers))
                {
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_HEADER_ERROR, "Invalid Header");
                }
                return numberOfRecord;
            }
            catch (CensusAnalyserException file_not_found)
            {
                return file_not_found.Message;
            }
            catch (CSVException emptyFileException)
            {
                return emptyFileException.Message;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }// End of ReadRecords

        //method will compare two headers 
        // if same return true , if not return false
        private bool IsHeaderSame(string[] passHeader, string[] headers)
        {
            if (passHeader.Length != headers.Length)
            {
                return false;
            }
            for (int i = 0; i < headers.Length; i++)
            {
                // ToLower() :- Returns a copy of string converted to lowercase
                if (headers[i].ToLower().CompareTo(passHeader[i].ToLower()) != 0)
                {
                    return false;
                }
            }
            return true;
        }//End of isHeadersame
    }
}