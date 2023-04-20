using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trading_Helper.Properties;
using Microsoft.Data.Analysis;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Data;
using System.Drawing;

namespace Trading_Helper
{
    internal class methods
    {
        #region Save user's settings
        public void saveUserProperties(List<KeyValuePair<string, string>> lst)
        {
            /*
             * This method saves the users properties in the default settings of the application.
             * So in the next run, the program starts up with the previouse settings.
             * Args:
             *      lst: List<KeyValuePair<string, string>>: A pair of two strings. The first one is the name of the setting and the second one is the value of the setting.
             * Returns:
             *      None
             */

            foreach (var pair in lst)
            {
                Settings.Default[pair.Key] = pair.Value;
            }

            // Save the settings
            Settings.Default.Save();
        }
        #endregion

        #region Assign user's settings
        public void assignUserProperties(List<KeyValuePair<TextBox, string>> lst)
        {
            /*
             * This method updates the user's properties in the application.
             * Args:
             *      lst: List<KeyValuePair<TextBox, string>>: A pair. The first one is the Textbox to be updated, and the second one is the value of the setting.
             * Returns:
             *      None
             */

            foreach (var pair in lst)
            {
                pair.Key.Text = pair.Value;
            }
        }
        #endregion

        #region Selected dataset to dataframe
        public DataFrame sqliteResultToDataframe(SQLiteDataReader data)
        {
            /*
             * Iterates through the SQLiteDataReader and converts it to a DataFrame.
             * 
             * Args:
             *      data (SQLiteDataReader): The data selected form the database.
             * Returns:
             *      df (Dataframe): The dataframe containing the data.
             */

            if (data.HasRows)
            {
                // The dataframe structure. Refer to trades table in the database.
                DataFrameColumn[] columns = {
                    new PrimitiveDataFrameColumn<int>("id"),
                    new StringDataFrameColumn("symbol"),
                    new StringDataFrameColumn("state"),
                    new StringDataFrameColumn("side"),
                    new StringDataFrameColumn("openDate"),
                    new StringDataFrameColumn("colseDate"),
                    new PrimitiveDataFrameColumn<double>("volume"),
                    new PrimitiveDataFrameColumn<double>("openPrice"),
                    new PrimitiveDataFrameColumn<double>("closePrice"),
                    new PrimitiveDataFrameColumn<double>("rRatio"),
                    new StringDataFrameColumn("description"),
                };
                DataFrame df = new DataFrame(columns);

                // The row structure of the dataframe.
                List<KeyValuePair<string, object>> newRowData;

                while (data.Read())
                {
                    newRowData = new List<KeyValuePair<string, object>>()
                    {
                        new KeyValuePair<string, object>("id", data["id"]),
                        new KeyValuePair<string, object>("symbol", data["symbol"]),
                        new KeyValuePair<string, object>("state", data["state"]),
                        new KeyValuePair<string, object>("side", data["side"]),
                        new KeyValuePair<string, object>("openDate", data["openDate"]),
                        new KeyValuePair<string, object>("colseDate", data["colseDate"]),
                        new KeyValuePair<string, object>("volume", data["volume"]),
                        new KeyValuePair<string, object>("openPrice", data["openPrice"]),
                        new KeyValuePair<string, object>("closePrice", data["closePrice"]),
                        new KeyValuePair<string, object>("rRatio", data["rRatio"]),
                        new KeyValuePair<string, object>("description", data["description"]),
                    };

                    df.Append(newRowData);
                }

                return df;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region Selected dataset to datatable
        public DataTable sqliteResultToDataTable(SQLiteDataReader data)
        {
            /*
             * Gets the SQLiteDataReader output and converts it to a Datatable.
             * 
             * Args:
             *      data (SQLiteDataReader): The data selected form the database.
             * Returns:
             *      dt (DataTable): The dataframe containing the data.
             */
            DataTable dt = new DataTable();
            dt.Load(data);
            return dt;
        }
        #endregion

        #region Update status strip
        public void updateAppStatus(string msg, ToolStripStatusLabel label, Color? c = null)
        {
            /*
             * This method updates the status strip
             * Args:
             *      msg (string): The message to be displayed.
             *      label (ToolStripStatusLabel): The label to be updated
             *      c (Color): The color of the text (Optional)
             *  Returns:
             *      Void
             */

            if (c == null) { c = Color.Black; }

            if (msg == null)
            {
                label.Text = "Waiting for command";
                label.ForeColor = (Color)c;
            }
            else
            {
                label.Text = msg;
                label.ForeColor = (Color)c;
            }
        }
        #endregion
    }
}
