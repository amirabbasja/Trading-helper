using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Trading_Helper
{
    internal class Database
    {
        public SQLiteConnection mainConnection;

        public Database(string path)
        {
            /*
             * Database class's cosntructor. Makes a new sql connection and if there
             * is no file named database.dv in the path, it makes a new one. It also 
             * makes a table for saving the trades.
             * 
             * Args: 
             *      path (string): The path of the database file.
             * Returns: 
             *      None
             */
            
            mainConnection = new SQLiteConnection($"Data source={path}/database.db");

            if (!File.Exists($"{path}/database.db"))
            {
                MessageBox.Show("No database file, making a new database file.");
                SQLiteConnection.CreateFile($"{path}/database.db");

                // Make the table for saving the trades.
                string query = "CREATE TABLE IF NOT EXISTS Trades( " +
                    "Id    INTEGER," +
                    "trade    INTEGER," + // number of trade
                    "updateNo    INTEGER," + // number of update. A trade can have multiple updates, even after its completely closed
                    "type  TEXT NOT NULL," + // open, close, add, reduce, update
                    "symbol    TEXT NOT NULL," +
                    "state TEXT NOT NULL," + // open, closed
                    "side  TEXT," + // long, short
                    "date  TEXT," + // execution date
                    "volume REAL," + // execution volume
                    "price REAL," + // execution price
                    "rRatio    REAL," + // only not null for trades which type == open
                    "description    TEXT," +
                    "PRIMARY KEY(Id AUTOINCREMENT)" +
                    ")";

                SQLiteCommand cmd = new SQLiteCommand(query, mainConnection);

                mainConnection.Open();
                var results = cmd.ExecuteNonQuery();
                mainConnection.Close();

            }
        }

        public void openConnection()
        {
            // Open a connection if there are no open connections. Else do nothing.
            if (mainConnection.State != System.Data.ConnectionState.Open)
            {
                mainConnection.Open();
            }
        }

        public void closeConnection()
        {
            // Close the connection if it is open. Else do nothing.
            if (mainConnection.State != System.Data.ConnectionState.Closed)
            {
                mainConnection.Close();
            }
        }
    }
}
