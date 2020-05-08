using System;
using System.Collections.Generic;
using System.Text;
using static IndianStatesCensusAnalyser.StateCensusAnalyserDao;
using static IndianStatesCensusAnalyser.CsvStatesDao;

namespace IndianStatesCensusAnalyser
{
    public class CSVFactory
    {
        // Method to creating instance of StateCensusAnalyser
        public static CsvStateCensusDataDao DelegateOfStateCensusAnalyser()
        {
            StateCensusAnalyserDao csvStateCensus = InstanceOfStateCensusAnalyser();
            CsvStateCensusDataDao getStateCensus = new CsvStateCensusDataDao(StateCensusAnalyserDao.CsvStateCensusReadRecord);
            return getStateCensus;
        }

        // Method to creating instance of CsvStates
        public static CsvStateCodeDataDao DelegateOfCsvStates()
        {
            CsvStatesDao csvStateData = InstanceOfCsvStates();
            CsvStateCodeDataDao getStateData = new CsvStateCodeDataDao(CsvStatesDao.CsvStateCodeReadRecord);
            return getStateData;
        }

        private static CsvStatesDao InstanceOfCsvStates()
        {
            return new CsvStatesDao();
        }

        private static StateCensusAnalyserDao InstanceOfStateCensusAnalyser()
        {
            return new StateCensusAnalyserDao();
        }
    }

}
