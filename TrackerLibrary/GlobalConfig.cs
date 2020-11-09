using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public const string PrizesFile = "PrizeModels.csv";
        public const string PeopleFile = "PersonModels.csv";
        public const string TeamsFile = "TeamModels.csv";
        public const string TournamentsFile = "TournamentModels.csv";
        public const string MatchupsFile = "MatchupModels.csv";
        public const string MatchupEntriesFile = "MatchupEntryModels.csv";

        private static IDataConnection _connection;

        public static IDataConnection Connection
        {
            get { return _connection; }
            private set { _connection = value; }
        }

        public static void InitializeConnections(DatabaseType db)
        {
            if (db == DatabaseType.Sql)
            {
                SqlConnector sql = new SqlConnector();
                Connection = sql;
            }

            else if (db == DatabaseType.TextFile)
            {
                TextConnector text = new TextConnector();
                Connection = text;
            }
        }

        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
