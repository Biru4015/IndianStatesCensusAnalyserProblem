using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStatesCensusAnalyser
{
    public interface CSVBuilder
    {
        public int NumberOfRecords(string filepath, char delimiter = ',', string header = "State,Population,AreaInSqKm,DensityPerSqKm");
        public int GetDataFromCSVFile(string statecode, char delimiter = ',', string header = "SrNo,State,TIN,StateCode");
    }

}
