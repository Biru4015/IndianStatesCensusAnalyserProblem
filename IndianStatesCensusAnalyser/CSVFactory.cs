using System;
using System.Collections.Generic;
using System.Text;
using static IndianStatesCensusAnalyser.StateCensusAnalyser;
using static IndianStatesCensusAnalyser.CsvStateCensus;

namespace IndianStatesCensusAnalyser
{
    public class CSVFactory
    {
        public static StateCensusAnalyser InstanceOfStateCensusAnalyzer()
        {
            return new StateCensusAnalyser();
        }
        public static CsvStateCensus InstanceOfCSVStatesCensus()
        {
            return new CsvStateCensus();
        }

        public static GetCSVCount DelegateofStateCensusAnalyse()
        {
            StateCensusAnalyser csvStateCensus = InstanceOfStateCensusAnalyzer();
            GetCSVCount getCSVCount = new GetCSVCount(StateCensusAnalyser.NumberOfRecords);
            return getCSVCount;
        }
        public static GetCountFromCSVStates DelegateofStatecode()
        {
            CsvStateCensus statesCodeCSV = InstanceOfCSVStatesCensus();
            GetCountFromCSVStates referToCSVSates = new GetCountFromCSVStates(CsvStateCensus.GetDataFromCSVFile);
            return referToCSVSates;
        }
    }
}
