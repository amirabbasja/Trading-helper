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
using System.IO;
using OfficeOpenXml;

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

        public static void ExportToExcel(string sqliteDbPath, string excelOutputPath, string tableName = null)
        {
            // Set EPPlus license context
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var connection = new SQLiteConnection($"Data source={sqliteDbPath}/database.db"))
            {
                connection.Open();

                // Get list of tables if no specific table is provided
                var tables = new List<string>();
                if (string.IsNullOrEmpty(tableName))
                {
                    using (var command = new SQLiteCommand(
                        "SELECT name FROM sqlite_master WHERE type='table' AND name NOT LIKE 'sqlite_%'",
                        connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tables.Add(reader.GetString(0));
                            }
                        }
                    }
                }
                else
                {
                    tables.Add(tableName);
                }

                using (var excelPackage = new ExcelPackage(new FileInfo($"{sqliteDbPath}/{excelOutputPath}")))
                {
                    foreach (var table in tables)
                    {
                        // Create worksheet for each table
                        var worksheet = excelPackage.Workbook.Worksheets.Add(table);

                        // Get table data
                        using (var command = new SQLiteCommand($"SELECT * FROM {table}", connection))
                        {
                            using (var adapter = new SQLiteDataAdapter(command))
                            {
                                var dataTable = new DataTable();
                                adapter.Fill(dataTable);

                                // Write headers
                                for (int i = 0; i < dataTable.Columns.Count; i++)
                                {
                                    worksheet.Cells[1, i + 1].Value = dataTable.Columns[i].ColumnName;
                                    // Make headers bold
                                    worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                                }

                                // Write data
                                for (int row = 0; row < dataTable.Rows.Count; row++)
                                {
                                    for (int col = 0; col < dataTable.Columns.Count; col++)
                                    {
                                        worksheet.Cells[row + 2, col + 1].Value = dataTable.Rows[row][col];
                                    }
                                }

                                // Auto-fit columns
                                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                            }
                        }
                    }

                    // Save the Excel file
                    excelPackage.Save();
                }
            }
        }

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

        #region Load image
        public Bitmap LoadBitmap(string path)
        {
            /*
             * This method loads the image to a bitmap file. Using this method avoids
             * exceptions when we want to delete a previously loaded image (File in use exception).
             * 
             * Args:
             *      path (string): The path to the desired image
             *  Returns:
             *      A new bitmap file 
             */

            if (File.Exists(path))
            {
                // open file in read only mode
                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                // get a binary reader for the file stream
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    // copy the content of the file into a memory stream
                    var memoryStream = new MemoryStream(reader.ReadBytes((int)stream.Length));
                    // make a new Bitmap object the owner of the MemoryStream
                    return new Bitmap(memoryStream);
                }
            }
            else
            {
                MessageBox.Show("Error Loading File.", "Error!", MessageBoxButtons.OK);
                return null;
            }
        }
        #endregion
    }
}
