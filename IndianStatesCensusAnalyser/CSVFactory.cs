using System;
using System.Collections.Generic;
using System.Text;
using static IndianStatesCensusAnalyser.StateCensusAnalyserDao;
using static IndianStatesCensusAnalyser.CsvStatesDao;

namespace IndianStatesCensusAnalyser
{
    /// <summary>
    /// This is CSV Factory class
    /// </summary>
    public class CSVFactory
    {
        /// <summary>
        /// Method to creating instance of StateCensusAnalyser
        /// </summary>
        /// <returns>getStateCensus</returns>
        public static CsvStateCensusDataDao DelegateOfStateCensusAnalyser()
        {
            StateCensusAnalyserDao csvStateCensus = InstanceOfStateCensusAnalyser();
            CsvStateCensusDataDao getStateCensus = new CsvStateCensusDataDao(StateCensusAnalyserDao.CsvStateCensusReadRecord);
            return getStateCensus;
        }

        /// <summary>
        /// Method to creating instance of CsvStates
        /// </summary>
        /// <returns></returns>
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
