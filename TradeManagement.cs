using Microsoft.Data.Analysis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using Trading_Helper.Properties;

namespace Trading_Helper
{
    public partial class TradeManagement : Form
    {
        #region Variables
        // Using the metghods class in the highest scope possible
        methods methodsClass_ = new methods();

        // Starting the database
        Database dbObject = new Database(Settings.Default["tradeHistoryDir"].ToString());
        int tradeCount = 0;
        #endregion

        public TradeManagement()
        {
            InitializeComponent();
        }

        #region Methods
        private void updateOpenTradesList(Database dbObject)
        {
            /*
             * Update the listbox with the open trades.
             * Args:
             *      path (string): The path of the folder
             * Returns:
             *      Void
             */

            // Get the open trades
            string sql = "SELECT * FROM Trades WHERE state = 'Open'";
            dbObject.openConnection();
            SQLiteCommand cmd = new SQLiteCommand(sql, dbObject.mainConnection);
            SQLiteDataReader data = cmd.ExecuteReader(CommandBehavior.SingleResult);
            DataTable dt = methodsClass_.sqliteResultToDataTable(data);
            dbObject.closeConnection();

            // Add the open trades to the listbox
            lstTrades.Items.Clear();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                lstTrades.Items.Add($"{dt.Rows[i]["Id"]} - {dt.Rows[i]["symbol"]}({dt.Rows[i]["side"]})");
            }
        }

        private void clearInput()
        {
            /*
             * Clears the trade entry fields 
             */

            // Clear all the text boxes
            txtVolume.Clear();
            txtTradeSym.Clear();
            txttradeRRatio.Clear();
            txtOpenPrice.Clear();
            txtOpenDate.Clear();
            txtDescription.Clear();
            txtClosePrice.Clear();
            txtCloseDate.Clear();

            // Clear the input image
            picTrade.Image = null;
        }

        private int getLastTradeID(Database dbObject)
        {
            /*
             * Get the last trade's id. Note that the table has to have the name "Trades"
             * 
             * Args: 
             *      dbObject (Database): The database object to connect to.
             * Returns:
             *      lastTradeId (int): Self explainatory.
             */
            string sql = "SELECT * FROM Trades ORDER BY Id DESC LIMIT 1";
            dbObject.openConnection();
            SQLiteCommand cmd = new SQLiteCommand(sql, dbObject.mainConnection);
            SQLiteDataReader data = cmd.ExecuteReader(CommandBehavior.SingleResult);
            DataTable dt = methodsClass_.sqliteResultToDataTable(data);

            int lastTradeId = 0;
            if (dt.Rows.Count > 0)
            {
                lastTradeId = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            }
            
            dbObject.closeConnection();

            return lastTradeId;
        }
        #endregion

        #region Events
        private void btnBrowsFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtTradeHistoryDir.Text = folderBrowserDialog1.SelectedPath;

                methodsClass_.saveUserProperties(
                    new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("tradeHistoryDir", txtTradeHistoryDir.Text) }
                    );
            }
        }

        private void TradeManagement_Load(object sender, EventArgs e)
        {
            btnUpdateTrade.Enabled = false;
            txtCloseDate.Enabled = false;
            txtClosePrice.Enabled = false;
            rdoStateOpen.Enabled = true;

            // Update the fields for UX improvements
            var properties = new List<KeyValuePair<TextBox, string>>() {
                new KeyValuePair<TextBox, string>(txtTradeHistoryDir, Settings.Default["tradeHistoryDir"].ToString()),
                };

            methodsClass_.assignUserProperties(properties);

            // Initiate starting folder of folder browser dialogue
            if (txtTradeHistoryDir.Text != null)
            {
                folderBrowserDialog1.SelectedPath = txtTradeHistoryDir.Text;
            }

            // Add today's date to txtTradeDate textbox
            txtOpenDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

            // Get the number amount of count in the folder
            tradeCount = getLastTradeID(dbObject);

            // Add open trades to the listbox
            updateOpenTradesList(dbObject);
        }
        private void TradeManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            var properties = new List<KeyValuePair<string, string>>() {
                new KeyValuePair<string, string>("tradeHistoryDir", txtTradeHistoryDir.Text),
                };

            methodsClass_.saveUserProperties(properties);
        }

        private void rdoStateClose_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoStateClose.Checked == true)
            {
                txtOpenDate.Enabled = false;
                txttradeRRatio.Enabled = false;
                txtVolume.Enabled = false;
                txtTradeSym.Enabled = false;
                txtOpenPrice.Enabled = false;

                if (lstTrades.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select an open trade from the listbox to close it.");
                }
            }
            else
            {
                txttradeRRatio.Enabled = true;
                txtCloseDate.Enabled = false;
                txtClosePrice.Enabled = false;
            }
        }


        private void btnAddImage_Click(object sender, EventArgs e)
        {
            // Adding the image from clipboard
            if (Clipboard.ContainsImage())
            {
                picTrade.Image = Clipboard.GetImage();
            }
            else
            {
                MessageBox.Show("No image in the clipboard!");
            }
        }

        private void btnRmImage_Click(object sender, EventArgs e)
        {
            // Deleting the image
            picTrade.Image = null;
        }

        private void btnAddTrade_Click(object sender, EventArgs e)
        {
            // Checking for duplicate trades
            tradeCount = getLastTradeID(dbObject);

            // Check side of the trade
            if (
                (rdoSideLong.Checked || rdoSideShort.Checked) &&
                (rdoStateClose.Checked || rdoStateOpen.Checked) &&
                txtTradeSym.Text.Trim(' ') != null &&
                txtOpenDate.Text.Trim(' ') != null &&
                txttradeRRatio.Text.Trim(' ') != null &&
                txtVolume.Text.Trim(' ') != null &&
                txtOpenPrice.Text.Trim(' ') != null
                ) 
            {
                string side_ = rdoSideLong.Checked ? "Long" : "Short";
                string state_ = rdoStateOpen.Checked ? "Open" : "Close";
                string fileName = $"{txtTradeSym.Text}_R{txttradeRRatio.Text}_{side_}_{state_}";

                if (state_ == "Open")
                {
                    // Add the trade to the folder
                    tradeCount = getLastTradeID(dbObject);

                    string sql = "INSERT INTO trades ('symbol', 'state', 'side', 'openDate', 'closeDate', 'openPrice', 'closePrice', 'volume', 'rRatio', 'description') " +
                        "VALUES (@sym, @state, @side, @openDate, @closeDate, @openPrice, @closePrice, @volume, @rRatio, @description)";
                    dbObject.openConnection();
                    SQLiteCommand cmd = new SQLiteCommand(sql, dbObject.mainConnection);
                    cmd.Parameters.AddWithValue("@sym", txtTradeSym.Text);
                    cmd.Parameters.AddWithValue("@state", state_);
                    cmd.Parameters.AddWithValue("@side", side_);
                    cmd.Parameters.AddWithValue("@openDate", txtOpenDate.Text);
                    cmd.Parameters.AddWithValue("@closeDate", null);
                    cmd.Parameters.AddWithValue("@volume", txtVolume.Text.Replace(",", ""));
                    cmd.Parameters.AddWithValue("@openPrice", double.Parse(txtOpenPrice.Text));
                    cmd.Parameters.AddWithValue("@closePrice", null);
                    cmd.Parameters.AddWithValue("@rRatio", double.Parse(txttradeRRatio.Text));
                    cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                    var results = cmd.ExecuteNonQuery();
                    dbObject.closeConnection();
                    picTrade.Image.Save(txtTradeHistoryDir.Text + "//" + $"{tradeCount+1}.{fileName}" + ".png", ImageFormat.Png);
                    
                    // Update the open trades list
                    updateOpenTradesList(dbObject);

                    // Clear the trade entry input to prevent adding trades more than once
                    clearInput();

                    // Update app status
                    methodsClass_.updateAppStatus("Trade added", toolStripStatusLabel1, Color.Green);
                }
                else
                {
                    // Closing a trade
                    if(lstTrades.SelectedIndex == -1)
                    {
                        // If no open trades have been chosen from the listbox, dont let the user to close trades.
                        MessageBox.Show("Please select an open tarde from the listbox first.");
                        rdoStateOpen.Checked = true;
                    }
                    else
                    {
                        // Set the default date
                        txtCloseDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                        string tradeName = lstTrades.SelectedItem.ToString();
                        var temp_ = tradeName.Split('-');
                        int id = int.Parse(temp_[0].Trim());

                        if(
                            txtCloseDate.Text.Trim() != null &&
                            txtClosePrice.Text.Trim() != null &&
                            picTrade.Image != null
                            )
                        {
                            // Save the trade's image
                            picTrade.Image.Save(txtTradeHistoryDir.Text + "//" + $"{id}.{fileName}" + ".png", ImageFormat.Png);

                            string sql = "UPDATE trades SET closePrice = @cPrice, state = @state, closeDate = @cDate, description = @desc, volume = @vol WHERE Id = @tradeNo";
                            dbObject.openConnection();
                            SQLiteCommand cmd = new SQLiteCommand(sql, dbObject.mainConnection); ;
                            cmd.Parameters.AddWithValue("@cPrice", double.Parse(txtClosePrice.Text));
                            cmd.Parameters.AddWithValue("@cDate", txtCloseDate.Text);
                            cmd.Parameters.AddWithValue("@desc",txtDescription.Text);
                            cmd.Parameters.AddWithValue("@vol", double.Parse(txtVolume.Text));
                            cmd.Parameters.AddWithValue("@state", "Closed");
                            cmd.Parameters.AddWithValue("@tradeNo", id);
                            var results = cmd.ExecuteNonQuery();
                            dbObject.closeConnection();

                            // Update the open trades list
                            updateOpenTradesList(dbObject);

                            // Clear the input
                            clearInput();

                            // Update spplication status
                            methodsClass_.updateAppStatus("Trade closed", toolStripStatusLabel1, Color.Green);
                        }
                        else
                        {
                            MessageBox.Show("Some fields are missing");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Some field are invalid");
            }
        }

        private void lstTrades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTrades.SelectedIndex != -1)
            {
                // Enable trade close parameters
                txtClosePrice.Enabled = true;
                txtCloseDate.Enabled = true;

                // Clear textboxes
                clearInput();

                // Update the default close date
                txtCloseDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                string tradeName = lstTrades.SelectedItem.ToString();
                var temp_ = tradeName.Split('-');
                int id = int.Parse(temp_[0].Trim());
                string sql = $"SELECT * FROM Trades WHERE Id = {id}";
                dbObject.openConnection();
                SQLiteCommand cmd = new SQLiteCommand(sql, dbObject.mainConnection);
                SQLiteDataReader data = cmd.ExecuteReader(CommandBehavior.SingleResult);
                DataTable dt = methodsClass_.sqliteResultToDataTable(data);
                dbObject.closeConnection();

                txtDescription.Text = dt.Rows[0]["description"].ToString();
                txtOpenDate.Text = dt.Rows[0]["openDate"].ToString();
                txtOpenPrice.Text = dt.Rows[0]["openPrice"].ToString();
                txtVolume.Text = dt.Rows[0]["volume"].ToString();
                txttradeRRatio.Text = dt.Rows[0]["rRatio"].ToString();
                txtTradeSym.Text = dt.Rows[0]["symbol"].ToString();

                if (dt.Rows[0]["side"].ToString() == "Long")
                {
                    rdoSideLong.Checked = true;
                    rdoSideShort.Checked = false;
                }
                else
                {
                    rdoSideLong.Checked = false;
                    rdoSideShort.Checked = true;
                }

                rdoStateClose.Checked = true;

                // Display the trade image
                string side_ = rdoSideLong.Checked ? "Long" : "Short";
                string fileName = $"{txtTradeSym.Text}_R{txttradeRRatio.Text}_{side_}_Open";
                picTradeDisplay.Image = Image.FromFile(txtTradeHistoryDir.Text + "//" + $"{id}.{fileName}" + ".png");
            }

        }

        private void rdoStateOpen_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoStateOpen.Checked == true)
            {
                lstTrades.ClearSelected();

                // Enable fields necessary for opening a trade and disable the ones for closing a trade
                txtTradeSym.Enabled = true;
                txtOpenDate.Enabled = true;
                txtOpenPrice.Enabled = true;
                txtVolume.Enabled = true;
                txttradeRRatio.Enabled = true;
                txtDescription.Enabled = true;

                txtCloseDate.Enabled = false;
                txtClosePrice.Enabled = false;
            }
        }
        private void btnRef_Click(object sender, EventArgs e)
        {
            // Update the listbox
            updateOpenTradesList(dbObject);
        }

        private void rdoSideLong_CheckedChanged(object sender, EventArgs e)
        {
            // Do sth.
        }

        #endregion

        private void btnUpdateTrade_Click(object sender, EventArgs e)
        {
            // Due to the process of the application, this can only be used for editing the open trades.

            if(lstTrades.SelectedIndex == -1)
            {
                MessageBox.Show("No tardes selected!");
            }
            else
            {
                string tradeName = lstTrades.SelectedItem.ToString();
                var temp_ = tradeName.Split('-');
                int id = int.Parse(temp_[0].Trim());
                string side_ = rdoSideLong.Checked ? "Long" : "Short";

                string sql = "UPDATE Trades SET openPrice = @oPrice, openDate = @oDate, description = @desc, volume = @vol WHERE Id = @tradeNo";
                dbObject.openConnection();
                SQLiteCommand cmd = new SQLiteCommand(sql, dbObject.mainConnection); ;
                cmd.Parameters.AddWithValue("@oPrice", double.Parse(txtOpenPrice.Text));
                cmd.Parameters.AddWithValue("@oDate", txtOpenDate.Text);
                cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                cmd.Parameters.AddWithValue("@vol", double.Parse(txtVolume.Text));
                cmd.Parameters.AddWithValue("@rRatio", double.Parse(txttradeRRatio.Text));
                cmd.Parameters.AddWithValue("@side", side_);
                cmd.Parameters.AddWithValue("@tradeNo", id);
                var results = cmd.ExecuteNonQuery();
                dbObject.closeConnection();

                // Update app status
                methodsClass_.updateAppStatus("Trade updated", toolStripStatusLabel1, Color.Red);
            }
        }

        private void btnDeleteTrade_Click(object sender, EventArgs e)
        {
            if (lstTrades.SelectedIndex == -1)
            {
                MessageBox.Show("No tardes selected!");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure?", "Select options", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string tradeName = lstTrades.SelectedItem.ToString();
                    var temp_ = tradeName.Split('-');
                    int id = int.Parse(temp_[0].Trim());

                    // Delete the record from database
                    string sql = "DELETE FROM trades WHERE (Id = @tradeNo)";
                    dbObject.openConnection();
                    SQLiteCommand cmd = new SQLiteCommand(sql, dbObject.mainConnection);
                    cmd.Parameters.AddWithValue("@tradeNo", id);
                    cmd.ExecuteNonQuery();
                    dbObject.closeConnection();

                    // Delete the trade image
                    string side_ = rdoSideLong.Checked ? "Long" : "Short";
                    string state_ = "Open";
                    string fileName = $"{txtTradeSym.Text}_R{txttradeRRatio.Text}_{side_}_{state_}";
                    File.Delete(txtTradeHistoryDir.Text + "//" + $"{id}.{fileName}" + ".png");

                    // Update app status
                    methodsClass_.updateAppStatus("Trade deleted", toolStripStatusLabel1, Color.Red);

                    // Update open trades listbox
                    updateOpenTradesList(dbObject);
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
        }

        private void chkEditTrade_CheckedChanged(object sender, EventArgs e)
        {
            if(chkEditTrade.Checked)
            {
                if(lstTrades.SelectedIndex != -1)
                {
                    // Disable all elements not related to editing
                    btnAddImage.Enabled = false;
                    btnDeleteTrade.Enabled = false;
                    btnAddTrade.Enabled = false;
                    btnRmImage.Enabled = false;
                    txtClosePrice.Enabled = false;
                    txtCloseDate.Enabled = false;
                    txtTradeSym.Enabled = false;
                    rdoStateClose.Enabled = false;
                    rdoStateOpen.Enabled = false;

                    // Enable all elements related to editing
                    txtOpenDate.Enabled = true;
                    txtOpenPrice.Enabled = true;
                    txtVolume.Enabled = true;
                    txttradeRRatio.Enabled = true;
                    btnUpdateTrade.Enabled = true;
                }
                else
                {
                    chkEditTrade.Checked = false;
                    MessageBox.Show("Select an open trade first.");
                }
            }
            else
            {
                // Enable all elements related to editing
                btnAddImage.Enabled = true;
                btnDeleteTrade.Enabled = true;
                btnAddTrade.Enabled = true;
                btnRmImage.Enabled = true;
                txtClosePrice.Enabled = true;
                txtCloseDate.Enabled = true;
                txtTradeSym.Enabled = true;
                rdoStateClose.Enabled = true;
                rdoStateOpen.Enabled = true;

                // Disable all elements related to editing
                btnUpdateTrade.Enabled = false;

                if(lstTrades.SelectedIndex != -1)
                {
                    txtOpenDate.Enabled = false;
                    txttradeRRatio.Enabled = false;
                    txtVolume.Enabled = false;
                    txtTradeSym.Enabled = false;
                    txtOpenPrice.Enabled = false;
                }
            }
        }
    }
}
