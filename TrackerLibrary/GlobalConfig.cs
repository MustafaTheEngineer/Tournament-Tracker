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
        public const string prizesFile = "PrizeModel.csv";
        public const string peopleFile = "PeopleModel.csv";
        public const string teamFile = "TeamModels.csv";
        public const string tournamentFile = "TournamentModels.csv";
        public const string matchupFile = "MatchupModels.csv";
        public const string matchupEntryFile = "MatchupEntryModels.csv";

        // private set means just methods in this class can change it.
        public static IDataConnection Connection { get; private set; }
        public static void initializeConnections(DatabaseType db)
        {
            if (db == DatabaseType.Sql)
            {
                // TODO - Set up the SQL Connector properly.
                SqlConnector sql = new SqlConnector();
                Connection = sql;
            }
            else if (db == DatabaseType.TextFile)
            {
                // TODO Create the Text Connection
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
