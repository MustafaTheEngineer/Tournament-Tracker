using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        // private set means just methods in this class can change it.
        public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();
        public static void initializeConnections(bool database, bool textFiles)
        {
            if (database)
            {
                // TODO - Set up the SQL Connector properly.
                SqlConnector sql = new SqlConnector();
                Connections.Add(sql);
            }
            if (textFiles)
            {
                // TODO Create the Text Connection
                TextConnector text = new TextConnector();
                Connections.Add(text);
            }
        }
    }
}
