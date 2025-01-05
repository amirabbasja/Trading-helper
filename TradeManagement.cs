using CryptoExchange.Net.CommonObjects;
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
        private void updateOpenTradesList(Database dbObject, bool deliverAll = false)
        {
            /*
             * Update the listbox with the open trades.
             * Args:
             *      path: string: The path of the folder
             *      deliverAll: bool: If true, loads all of the trades, if false, only open trades are listed
             * Returns:
             *      Void
             */

            // Get the open trades
            string sql = "";

            if (deliverAll)
            {
                sql = "SELECT * FROM Trades ORDER BY trade";
            }
            else
            {
                sql = "SELECT * FROM Trades WHERE state = 'Open' ORDER BY trade";
            }

            dbObject.openConnection();
            SQLiteCommand cmd = new SQLiteCommand(sql, dbObject.mainConnection);
            SQLiteDataReader data = cmd.ExecuteReader(CommandBehavior.SingleResult);
            DataTable dt = methodsClass_.sqliteResultToDataTable(data);
            dbObject.closeConnection();

            // Add the open trades to the listbox
            lstTrades.Items.Clear();

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["state"].ToString().Trim() == "Closed")
                {
                    // Adding closed trades
                    lstTrades.Items.Add($"{dt.Rows[i]["trade"]}-{dt.Rows[i]["updateNo"]}   {dt.Rows[i]["symbol"]} ({dt.Rows[i]["type"]})      [Closed]");
                }
                else
                {
                    // Adding open trades
                    lstTrades.Items.Add($"{dt.Rows[i]["trade"]}-{dt.Rows[i]["updateNo"]}   {dt.Rows[i]["symbol"]} ({dt.Rows[i]["type"]})");
                }
            }
        }

        private void updateTextboxesFromSelectedTrade(Database dbObject, int tradeNo, int updateNo)
        {
            /*
             * Updates the encessary textboxes when a trade in the tradelist is selected.
             * 
             * Args:
             *      dbObject: Database: The database object to search the trades in.
             *      tradeNo: int: The number of the trade to get the data from.
             *      updateNo: int: The update number of the trade.
             */

            string sql = $"SELECT * FROM Trades WHERE trade = {tradeNo} AND updateNo = {updateNo}";
            dbObject.openConnection();
            SQLiteCommand cmd = new SQLiteCommand(sql, dbObject.mainConnection);
            SQLiteDataReader data = cmd.ExecuteReader(CommandBehavior.SingleResult);
            DataTable dt = methodsClass_.sqliteResultToDataTable(data);
            dbObject.closeConnection();

            txtDescription.Text = dt.Rows[0]["description"].ToString();
            txtUpdateDate.Text = dt.Rows[0]["date"].ToString();
            txtUpdatePrice.Text = dt.Rows[0]["price"].ToString();
            txtOpenDate.Text = dt.Rows[0]["date"].ToString();
            txtOpenPrice.Text = dt.Rows[0]["price"].ToString();
            txtVolume.Text = dt.Rows[0]["volume"].ToString();
            txttradeRRatio.Text = dt.Rows[0]["rRatio"].ToString();
            txtTradeSym.Text = dt.Rows[0]["symbol"].ToString();

            string fileName = $"{tradeNo}-{updateNo}-{txtTradeSym.Text}-{dt.Rows[0]["type"]}";

            // Try to load image
            try
            {
                picPrevTradeDisplay.Image = methodsClass_.LoadBitmap(txtTradeHistoryDir.Text + "\\" + $"{fileName}" + ".png");
            }
            catch
            {
                // Picture may be deleted or unavalible
                picPrevTradeDisplay.Image = null;
            }
        }

        private void clearInput(bool radio)
        {
            /*
             * Clears the trade entry fields 
             * 
             * Args:
             *  radio: bool: Uncheck radio buttunso aswell
             */

            // Clear all the text boxes
            txtVolume.Clear();
            txtTradeSym.Clear();
            txttradeRRatio.Clear();
            txtOpenPrice.Clear();
            txtOpenDate.Clear();
            txtDescription.Clear();
            txtUpdatePrice.Clear();
            txtUpdateDate.Clear();

            // Clear the input image
            picTrade.Image = null;

            if (radio)
            {
                // Uncheck the radio buttons
                rdoActionClose.Checked = false;
                rdoActionOpen.Checked = false;
                rdoActionUpdateAdd.Checked = false;
                rdoActionUpdate.Checked = false;
                rdoActionUpdateReduce.Checked = false;
                rdoSideBuy.Checked = false;
                rdoSideSell.Checked = false;
            }
        }

        private void enableInputs()
        {
            /*
             * Enables trade entry fields 
             * 
             * Args:
             * 
             */

            txtTradeSym.Enabled = true;
            txtOpenDate.Enabled = true;
            txtOpenPrice.Enabled = true;
            txtVolume.Enabled = true;
            txttradeRRatio.Enabled = true;
            txtDescription.Enabled = true;
            txtUpdateDate.Enabled = true;
            txtUpdatePrice.Enabled = true;

        }

        private int getLastTradeNumber(Database dbObject)
        {
            /*
             * Get the last trade's number. Note that the table has to have the name "Trades"
             * 
             * Args: 
             *      dbObject (Database): The database object to connect to.
             * Returns:
             *      lastTradeId (int): Self explainatory.
             */
            string sql = "SELECT * FROM Trades ORDER BY trade DESC LIMIT 1";
            dbObject.openConnection();
            SQLiteCommand cmd = new SQLiteCommand(sql, dbObject.mainConnection);
            SQLiteDataReader data = cmd.ExecuteReader(CommandBehavior.SingleResult);
            DataTable dt = methodsClass_.sqliteResultToDataTable(data);

            int lastTradeId = 0;
            if (dt.Rows.Count > 0)
            {
                lastTradeId = int.Parse(dt.Rows[0]["trade"].ToString());
            }
            
            dbObject.closeConnection();

            return lastTradeId;
        }

        private int getlastTradeUpdateNo(Database dbObject, int tradeNo)
        {
            /*
             * Get the desired trade's last update number. Note that the table
             *  has to have the name "Trades"
             * 
             * Args: 
             *      dbObject (Database): The database object to connect to.
             *      tradeNo (Database): The number of the desired trade.
             * Returns:
             *      lastTradeId (int): Self explainatory.
             */
            string sql = "SELECT * FROM Trades WHERE trade = @tradeNo";
            dbObject.openConnection();
            SQLiteCommand cmd = new SQLiteCommand(sql, dbObject.mainConnection);
            cmd.Parameters.AddWithValue("@tradeNo", tradeNo);
            SQLiteDataReader data = cmd.ExecuteReader(CommandBehavior.SingleResult);
            DataTable dt = methodsClass_.sqliteResultToDataTable(data);

            int lastTradeUpdate= 0;
            if (dt.Rows.Count > 0)
            {
                //lastTradeUpdate = int.Parse(dt.Rows[0].ItemArray[0].ToString());
                lastTradeUpdate = Convert.ToInt32(dt.AsEnumerable().Max(row => row["updateNo"]));
            }

            dbObject.closeConnection();

            return lastTradeUpdate;
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

                // Close the current form, then make a new form
                this.Hide();
                TradeManagement frmTradeManagement = new TradeManagement();
                frmTradeManagement.Show();
                this.Close();
            }
        }

        private void TradeManagement_Load(object sender, EventArgs e)
        {
            btnUpdateTrade.Enabled = false;
            txtUpdateDate.Enabled = false;
            txtUpdatePrice.Enabled = false;
            rdoActionOpen.Enabled = true;

            // Update the fields for UX improvements
            var properties = new List<KeyValuePair<TextBox, string>>() {
                new KeyValuePair<TextBox, string>(txtTradeHistoryDir, Settings.Default["tradeHistoryDir"].ToString()),
                };

            methodsClass_.assignUserProperties(properties);

            // Initiate starting folder of folder browser dialogue
            if (txtTradeHistoryDir.Text != null)
            {
                folderBrowserDialog1.SelectedPath = txtTradeHistoryDir.Text;

                // Also update the session name (which is the directory name of txtTradeHistoryDir)
                lblSessionName.Text = txtTradeHistoryDir.Text.Split('\\').Last();
            }

            // Add today's date to txtTradeDate textbox
            txtOpenDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

            // Get the number amount of count in the folder
            tradeCount = getLastTradeNumber(dbObject);

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
            if (rdoActionClose.Checked == true)
            {
                txtOpenDate.Enabled = false;
                txttradeRRatio.Enabled = false;
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
                txtUpdateDate.Enabled = false;
                txtUpdatePrice.Enabled = false;
            }
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            // Adding the image from clipboard
            if (Clipboard.ContainsImage())
            {
                picTrade.Image = Clipboard.GetImage();

                // Clear the picPrevTradeDisplay image when we are adding a new image.
                // If we add a new image means that we are opening/closing a trade and
                // if there is an image in picPrevTradeDisplay, might be confusing for
                // the user.
                picPrevTradeDisplay.Image = null;
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
            // Getting the last trade number
            tradeCount = getLastTradeNumber(dbObject);


            // Check trade details
            if (
                (rdoSideBuy.Checked || rdoSideSell.Checked) &&
                (rdoActionClose.Checked || rdoActionOpen.Checked || rdoActionUpdate.Checked || rdoActionUpdateAdd.Checked || rdoActionUpdateReduce.Checked) &&
                txtTradeSym.Text.Trim(' ') != null &&
                txtOpenDate.Text.Trim(' ') != null &&
                txttradeRRatio.Text.Trim(' ') != null &&
                txtVolume.Text.Trim(' ') != null &&
                txtOpenPrice.Text.Trim(' ') != null
                ) 
            {
                string side_ = rdoSideBuy.Checked ? "Buy" : "Sell";

                string action_;
                if (rdoActionUpdate.Checked == true || rdoActionUpdateAdd.Checked == true || rdoActionUpdateReduce.Checked == true)
                {
                    action_ = "Update";
                }
                else
                {
                    action_ = rdoActionOpen.Checked ? "Open" : "Close";
                }
                

                string fileName = $"{tradeCount+1}-{1}-{txtTradeSym.Text}-{"open"}";

                if (action_ == "Open")
                {
                    if (picTrade.Image != null)
                    {
                        // Getting the latest trade number
                        int tradeNo = getLastTradeNumber(dbObject);
                        fileName = $"{tradeNo + 1}-{1}-{txtTradeSym.Text}-{"open"}";

                        string sql = "INSERT INTO trades ('trade', 'updateNo', 'type', 'symbol', 'state', 'side', 'date', 'volume', 'price', 'rRatio', 'description') " +
                        "VALUES (@trade, @updateNo, @type, @symbol, @state, @side, @date, @volume, @price, @rRatio, @description)";

                        dbObject.openConnection();
                        SQLiteCommand cmd = new SQLiteCommand(sql, dbObject.mainConnection);
                        cmd.Parameters.AddWithValue("@trade", tradeNo + 1);
                        cmd.Parameters.AddWithValue("@updateNo", 1); // If adding a new trade, update number starts from 1
                        cmd.Parameters.AddWithValue("@type", action_);
                        cmd.Parameters.AddWithValue("@symbol", txtTradeSym.Text);
                        cmd.Parameters.AddWithValue("@state", "Open");
                        cmd.Parameters.AddWithValue("@side", side_);
                        cmd.Parameters.AddWithValue("@date", txtOpenDate.Text);
                        cmd.Parameters.AddWithValue("@volume", txtVolume.Text.Replace(",", ""));
                        cmd.Parameters.AddWithValue("@price", double.Parse(txtOpenPrice.Text));
                        cmd.Parameters.AddWithValue("@rRatio", double.Parse(txttradeRRatio.Text));
                        cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                        var results = cmd.ExecuteNonQuery();
                        dbObject.closeConnection();
                        picTrade.Image.Save(txtTradeHistoryDir.Text + "//" + $"{fileName}" + ".png", ImageFormat.Png);

                        // Update the open trades list
                        updateOpenTradesList(dbObject);

                        // Clear the trade entry input to prevent adding trades more than once
                        clearInput(true);

                        // Update app status
                        methodsClass_.updateAppStatus("Trade added", toolStripStatusLabel1, Color.Green);
                    }
                    else
                    {
                        MessageBox.Show("Can't open a trade without an image");
                    }
                }
                else if (action_ == "Close")
                {
                    // Closing a trade
                    if(lstTrades.SelectedIndex == -1)
                    {
                        // If no open trades have been chosen from the listbox, dont let the user to close trades.
                        MessageBox.Show("Please select an open tarde from the listbox first.");
                        rdoActionOpen.Checked = true;
                    }
                    else
                    {
                        // Set the default date
                        txtUpdateDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        int tradeNo = int.Parse(lstTrades.SelectedItem.ToString().Split('-')[0]);
                        int updateNo = getlastTradeUpdateNo(dbObject, tradeNo);
                        fileName = $"{tradeNo}-{updateNo + 1}-{txtTradeSym.Text}-{action_}";


                        if (
                            txtUpdateDate.Text.Trim() != null &&
                            txtUpdatePrice.Text.Trim() != null &&
                            picTrade.Image != null
                            )
                        {
                            //string sql = "UPDATE trades SET closePrice = @cPrice, state = @state, closeDate = @cDate, description = @desc, volume = @vol WHERE Id = @tradeNo";
                            // Get the trade number and update number

                            string sql = "INSERT INTO trades ('trade', 'updateNo', 'type', 'symbol', 'state', 'side', 'date', 'volume', 'price', 'rRatio', 'description') " +
                            "VALUES (@trade, @updateNo, @type, @symbol, @state, @side, @date, @volume, @price, @rRatio, @description)";

                            dbObject.openConnection();
                            SQLiteCommand cmd = new SQLiteCommand(sql, dbObject.mainConnection);
                            cmd.Parameters.AddWithValue("@trade", tradeNo);
                            cmd.Parameters.AddWithValue("@updateNo", updateNo + 1);
                            cmd.Parameters.AddWithValue("@type", action_);
                            cmd.Parameters.AddWithValue("@symbol", txtTradeSym.Text);
                            cmd.Parameters.AddWithValue("@state", "Closed");
                            cmd.Parameters.AddWithValue("@side", side_);
                            cmd.Parameters.AddWithValue("@date", txtUpdateDate.Text);
                            cmd.Parameters.AddWithValue("@volume", "all");
                            cmd.Parameters.AddWithValue("@price", double.Parse(txtUpdatePrice.Text));
                            cmd.Parameters.AddWithValue("@rRatio", double.Parse(txttradeRRatio.Text));
                            cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                            var results = cmd.ExecuteNonQuery();
                            dbObject.closeConnection();


                            // Change the open trades' state to closed
                            sql = "UPDATE trades SET state = @state WHERE trade = @tradeNo AND state = @stateNew";
                            dbObject.openConnection();
                            cmd = new SQLiteCommand(sql, dbObject.mainConnection);
                            cmd.Parameters.AddWithValue("@tradeNo", tradeNo);
                            cmd.Parameters.AddWithValue("@state", "Closed");
                            cmd.Parameters.AddWithValue("@stateNew", "Open");
                            cmd.ExecuteNonQuery();
                            dbObject.closeConnection();

                            // Update the open trades list
                            updateOpenTradesList(dbObject);

                            // Save the trade's image
                            picTrade.Image.Save(txtTradeHistoryDir.Text + "//" + $"{fileName}" + ".png", ImageFormat.Png);

                            // Clear the input
                            clearInput(true);

                            // Update spplication status
                            methodsClass_.updateAppStatus("Trade closed", toolStripStatusLabel1, Color.Green);
                        }
                        else
                        {
                            MessageBox.Show("Some fields are missing");
                        }
                    }
                }
                else
                {
                    // action_ = Update
                    // Add an update to the previous trade. Can be adding or reducing from position.
                    // Or a simple chart update.


                    if (rdoActionUpdateAdd.Checked)
                    {
                        // Adding to a position
                        action_ = "add";

                    }
                    else if (rdoActionUpdateReduce.Checked)
                    {
                        // Reducing from a position
                        action_ = "reduce";
                    }
                    else
                    {
                        // Simple chart update
                        action_ = "update";
                    }

                    if (lstTrades.SelectedIndex != -1)
                    {
                        // Get the trade number and update number
                        int tradeNo = int.Parse(lstTrades.SelectedItem.ToString().Split('-')[0]);
                        int updateNo = getlastTradeUpdateNo(dbObject, tradeNo);
                        string state = lstTrades.SelectedItem.ToString().Contains("(Open)") ? "Open" : lstTrades.SelectedItem.ToString().Contains("[Closed]") ? "Closed" : "nan";
                        fileName = $"{tradeNo}-{updateNo + 1}-{txtTradeSym.Text}-{action_}";


                        string sql = "INSERT INTO trades ('trade', 'updateNo', 'type', 'symbol', 'state', 'side', 'date', 'volume', 'price', 'rRatio', 'description') " +
                        "VALUES (@trade, @updateNo, @type, @symbol, @state, @side, @date, @volume, @price, @rRatio, @description)";

                        dbObject.openConnection();
                        SQLiteCommand cmd = new SQLiteCommand(sql, dbObject.mainConnection);
                        cmd.Parameters.AddWithValue("@trade", tradeNo);
                        cmd.Parameters.AddWithValue("@updateNo", updateNo + 1);
                        cmd.Parameters.AddWithValue("@type", action_);
                        cmd.Parameters.AddWithValue("@symbol", txtTradeSym.Text);
                        cmd.Parameters.AddWithValue("@state", state);
                        cmd.Parameters.AddWithValue("@side", side_);
                        cmd.Parameters.AddWithValue("@date", txtUpdateDate.Text);
                        cmd.Parameters.AddWithValue("@volume", txtVolume.Text.Replace(",", ""));
                        cmd.Parameters.AddWithValue("@price", double.Parse(txtUpdatePrice.Text));
                        cmd.Parameters.AddWithValue("@rRatio", double.Parse(txttradeRRatio.Text));
                        cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                        var results = cmd.ExecuteNonQuery();
                        dbObject.closeConnection();

                        picTrade.Image.Save(txtTradeHistoryDir.Text + "//" + $"{fileName}" + ".png", ImageFormat.Png);

                        // Update the open trades list
                        updateOpenTradesList(dbObject);

                        // Clear the trade entry input to prevent adding trades more than once
                        clearInput(true);

                        // Update app status
                        methodsClass_.updateAppStatus("Trade update added", toolStripStatusLabel1, Color.Green);
                    }
                    else
                    {
                        MessageBox.Show("No trades selected to update");
                        clearInput(true);
                    }
                }

                // Add today's date to txtTradeDate textbox for the next trade
                txtOpenDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                // reset all fields
                clearInput(true);

                txtUpdateDate.Enabled = true;
                txtOpenDate.Enabled = true;
                txtVolume.Enabled = true;
                txtDescription.Enabled = true;
                txttradeRRatio.Enabled = true;
                txtTradeSym.Enabled = true;
                txtUpdatePrice.Enabled = true;
                txtOpenPrice.Enabled = true;
            }
            else
            {
                MessageBox.Show("Some field are invalid");
            }

        }

        private void lstTrades_SelectedIndexChanged(object sender, EventArgs e)
        {
            //getlastTradeUpdateNo(dbObject, 1);
            if (lstTrades.SelectedIndex != -1)
            {
                // If we are not editing closed trades, when we select a trade to update, the selected item in the list box will change to the opening trade
                if (chkShowClosedTrades.Checked == false)
                {
                    var selectedtext = lstTrades.Items[lstTrades.SelectedIndex].ToString();
                    var i = 0;
                    foreach (var trade in lstTrades.Items)
                    {
                        if (trade.ToString().Contains(selectedtext.Split('-')[0].ToString() + "-1"))
                        {
                            lstTrades.SelectedIndex = i;
                            break;
                        }
                        i++;
                    }
                }


                

                // Enable trade close parameters
                txtUpdatePrice.Enabled = true;
                txtUpdateDate.Enabled = true;

                // Clear textboxes
                clearInput(true);

                // Update the default close date
                txtUpdateDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                string tradeName = lstTrades.SelectedItem.ToString();
                var temp_ = tradeName.Split('-');
                int tradeNo = int.Parse(temp_[0].Trim());
                int updateNo = int.Parse(temp_[1].Split(' ')[0].Trim());
                
                // Update the text boxes and the image box
                updateTextboxesFromSelectedTrade(dbObject, tradeNo, updateNo);

                // Disable the open price and open date. Also disable symbol and rRatio fields
                txtOpenPrice.Enabled = false;
                txtOpenDate.Enabled = false;
                txtTradeSym.Enabled = false;
                txttradeRRatio.Enabled = false;

            }

        }

        private void rdoStateOpen_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoActionOpen.Checked == true)
            {
                lstTrades.ClearSelected();

                // Enable fields necessary for opening a trade and disable the ones for closing a trade
                txtTradeSym.Enabled = true;
                txtOpenDate.Enabled = true;
                txtOpenPrice.Enabled = true;
                txtVolume.Enabled = true;
                txttradeRRatio.Enabled = true;
                txtDescription.Enabled = true;

                txtUpdateDate.Enabled = false;
                txtUpdatePrice.Enabled = false;
            }
        }
      
        private void btnRef_Click(object sender, EventArgs e)
        {
            bool tmpBool = false;
            // Update the listbox
            if (chkShowClosedTrades.Checked == true) { tmpBool = true; } else { tmpBool = false; }
            updateOpenTradesList(dbObject, tmpBool);
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
                int tradeNo = int.Parse(temp_[0].Trim());
                int updateNo = int.Parse(temp_[1].Split(' ')[0].Trim());
                string side_ = rdoSideBuy.Checked ? "Buy" : "Sell";
                string action_ = tradeName.Split('(')[1].Split(')')[0];
                string fileName = $"{tradeNo}-{updateNo}-{txtTradeSym.Text}-{action_}";

                string sql = "UPDATE Trades SET price = @price, date = @date, description = @desc, volume = @vol WHERE trade = @tradeNo AND updateNo = @updateNo";
                dbObject.openConnection();
                SQLiteCommand cmd = new SQLiteCommand(sql, dbObject.mainConnection); ;
                cmd.Parameters.AddWithValue("@price", double.Parse(txtOpenPrice.Text));
                cmd.Parameters.AddWithValue("@date", txtOpenDate.Text);
                cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                cmd.Parameters.AddWithValue("@vol", double.Parse(txtVolume.Text));
                cmd.Parameters.AddWithValue("@rRatio", double.Parse(txttradeRRatio.Text));
                cmd.Parameters.AddWithValue("@side", side_);
                cmd.Parameters.AddWithValue("@tradeNo", tradeNo);
                cmd.Parameters.AddWithValue("@updateNo", updateNo);
                var results = cmd.ExecuteNonQuery();
                dbObject.closeConnection();

                // Update the image (Delete the old one and add the new one)
                if (picTrade.Image != null)
                {
                    if (File.Exists(txtTradeHistoryDir.Text + "//" + $"{fileName}" + ".png"))
                    {
                        File.Delete(txtTradeHistoryDir.Text + "//" + $"{fileName}" + ".png");
                    }
                    picTrade.Image.Save(txtTradeHistoryDir.Text + "//" + $"{fileName}" + ".png", ImageFormat.Png);
                }

                

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
                    int tradeNo = int.Parse(temp_[0].Trim());
                    int updateNo = getlastTradeUpdateNo(dbObject, tradeNo);
                    string action_ = tradeName.Split('(')[1].Split(')')[0];
                    string fileName = $"{tradeNo}-{updateNo}-{txtTradeSym.Text}-{action_}";

                    // Delete the trade image
                    if (File.Exists(txtTradeHistoryDir.Text + "//" + $"{fileName}" + ".png"))
                    {
                        File.Delete(txtTradeHistoryDir.Text + "//" + $"{fileName}" + ".png");
                    }
                    else
                    {
                        MessageBox.Show("Couldn't find the trade image to delete  "+ txtTradeHistoryDir.Text + "//" + $"{fileName}" + ".png");
                    }

                    picPrevTradeDisplay.Image = null;

                    // Delete the record from database
                    string sql = "DELETE FROM trades WHERE trade = @tradeNo AND updateNo = @updateNo";
                    dbObject.openConnection();
                    SQLiteCommand cmd = new SQLiteCommand(sql, dbObject.mainConnection);
                    cmd.Parameters.AddWithValue("@tradeNo", tradeNo);
                    cmd.Parameters.AddWithValue("@updateNo", updateNo);
                    cmd.ExecuteNonQuery();
                    dbObject.closeConnection();

                    // Update app status
                    methodsClass_.updateAppStatus("Trade deleted", toolStripStatusLabel1, Color.Red);

                    // Update open trades listbox
                    updateOpenTradesList(dbObject);

                    // Disable the checkbox
                    chkShowClosedTrades.Checked = false;
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
                    btnDeleteTrade.Enabled = false;
                    btnAddTrade.Enabled = false;
                    btnRmImage.Enabled = false;
                    txtUpdatePrice.Enabled = false;
                    txtUpdateDate.Enabled = false;
                    txtTradeSym.Enabled = false;
                    rdoActionClose.Enabled = false;
                    rdoActionOpen.Enabled = false;

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
                txtUpdatePrice.Enabled = true;
                txtUpdateDate.Enabled = true;
                txtTradeSym.Enabled = true;
                rdoActionClose.Enabled = true;
                rdoActionOpen.Enabled = true;

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

        private void rdoActionUpdateAdd_CheckedChanged(object sender, EventArgs e)
        {
            // An item from listbox has to be selected
            if (lstTrades.SelectedIndex != -1)
            {
                // Update app status
                methodsClass_.updateAppStatus("Waiting for update entry: Fill update date, description and add an image.", toolStripStatusLabel1, Color.Black);

                // Update the text boxes
                txtUpdatePrice.Text = string.Empty;
                txtDescription.Text = string.Empty;
                txtVolume.Text = string.Empty;
                picPrevTradeDisplay.Image = null;

                txtUpdateDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                if(rdoActionUpdate.Checked != false  || rdoActionUpdateAdd.Checked != false || rdoActionUpdateReduce.Checked != false)
                {
                    MessageBox.Show("First select a trade from the open trades list");
                }
            }
        }

        private void rdoActionUpdateReduce_CheckedChanged(object sender, EventArgs e)
        {
            // An item from listbox has to be selected
            if (lstTrades.SelectedIndex != -1)
            {
                // Update app status
                methodsClass_.updateAppStatus("Waiting for update entry: Fill update date, description and add an image.", toolStripStatusLabel1, Color.Black);

                // Update the text boxes
                txtUpdatePrice.Text = string.Empty;
                txtDescription.Text = string.Empty;
                txtVolume.Text = string.Empty;
                picPrevTradeDisplay.Image = null;

                txtUpdateDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                if (rdoActionUpdate.Checked != false || rdoActionUpdateAdd.Checked != false || rdoActionUpdateReduce.Checked != false)
                {
                    MessageBox.Show("First select a trade from the open trades list");
                }
            }
        }

        private void rdoActionUpdate_CheckedChanged(object sender, EventArgs e)
        {
            // An item from listbox has to be selected
            if (lstTrades.SelectedIndex != -1)
            {
                // Update app status
                methodsClass_.updateAppStatus("Waiting for update entry: Fill update date, description and add an image.", toolStripStatusLabel1, Color.Black);

                // Disable all of the text boxs except description
                txtOpenDate.Enabled=false;
                txtOpenPrice.Enabled=false;
                txttradeRRatio.Enabled=false;
                txtTradeSym.Enabled=false;
                txtVolume.Enabled = false;
                txtUpdatePrice.Enabled = false;

                txtOpenDate.Text = "";
                txtOpenPrice.Text = "0";
                txttradeRRatio.Text = "0";
                txtVolume.Text = "0";
                txtUpdatePrice.Text = "0";

                // Enable update date
                txtUpdateDate.Enabled = true;

                txtUpdateDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                if (rdoActionUpdate.Checked != false || rdoActionUpdateAdd.Checked != false || rdoActionUpdateReduce.Checked != false)
                {
                    MessageBox.Show("First select a trade from the open trades list");
                }
            }

        }

        private void chkShowClosedTrades_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowClosedTrades.Checked == true)
            {
                // Activates if we want to show closed trades as well

                // Clear all inputs
                clearInput(true);

                // Update the listbox
                updateOpenTradesList(dbObject, true);

                // Enable inputs
                enableInputs();

                // Enable delete button
                btnDeleteTrade.Enabled = true;
            }
            else
            {
                // Activates if we want to show open trades only (default)

                // Clear all inputs
                clearInput(true);

                // Update the listbox
                updateOpenTradesList(dbObject, false);

                // Enable inputs
                enableInputs();
            }
        }

        private void btnAddNowDate1_Click(object sender, EventArgs e)
        {
            // Add Now's date to the textbox
            txtOpenDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void btnAddNowDate2_Click(object sender, EventArgs e)
        {
            // Add Now's date to the textbox
            if (txtUpdateDate.Enabled == true)
            {
                txtUpdateDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        private void btnExportDB_Click(object sender, EventArgs e)
        {
            methods.ExportToExcel(Settings.Default["tradeHistoryDir"].ToString(), "export.xlsx");
        }
    }
}
