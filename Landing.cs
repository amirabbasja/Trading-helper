using CryptoExchange.Net.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Threading;
using Kucoin.Net;
using Kucoin.Net.Objects;
using Binance.Net;
using Trading_Helper.Properties;
using System.Collections.Specialized;
using System.IO;
using System.Configuration;
using Binance.Net.Clients;
using Kucoin.Net.Clients;

namespace Trading_Helper
{
    public partial class Landing : Form
    {
        public Landing()
        {
            InitializeComponent();
        }

        #region globalVariables

        struct userProperties
        {
            // The structure keeping the user's setting. This will help us save the properties more efficiently
            public float accountSize;
            public float leverage;
            public float risk;
            public float SL;
            public string client;
        }

        public string apiKey;
        public string secretKey;
        //public BinanceClient restClientBinance;
        public KucoinClient restClientKucoin;
        public BinanceClient restClientBinance;
        public bool _UPDATE_APP = false; //The main loop will continue working if this is true
        #endregion

        #region Account GroupBox
        //This part is for actions that are related to account GroupBox
        private void button2_Click(object sender, EventArgs e)
        {
            apiKey = txtAPIKEY.Text;
            secretKey = txtSECRETKEY.Text;

            //Update the binance client
            //restClient = new BinanceClient();
            //restClient.SetApiCredentials(apiKey, secretKey);

            //unchecked the checkbox and disable textboxes
            chkAccountGroupeBoxENableEditing.Checked = false;
            txtSECRETKEY.Enabled = false;
            txtAPIKEY.Enabled = false;

        }

        private void AccountGroupeBoxENableEditing_CheckedChanged(object sender, EventArgs e)
        {
            //Chnages APIKEY and SECRETKEY textbox enable propertie
            if (chkAccountGroupeBoxENableEditing.Checked == true)
            {
                //Enable the Account groupbox textboxes
                txtAPIKEY.Enabled = true;
                txtSECRETKEY.Enabled = true;
                btnUpdateAccountInfo.Enabled = true;
            }
            else
            {
                //Disable the Account groupbox textboxes
                txtAPIKEY.Enabled = false;
                txtSECRETKEY.Enabled = false;
                btnUpdateAccountInfo.Enabled = false;
            }
        }
        #endregion

        #region Used methods

        #region Save user's settings
        private void saveUserProperties()
        {
            // This method saves the users properties in the default settings of the application.
            // So in the next run, the program starts up with the previouse settings.
            // Returns:
            //  None

            // Redundant 
            TextBox[] txtArray = { txtAccSize, txtLeverage, txtRiskPerTrade, txtStopLoss };

            Settings.Default["accountSize"] = txtAccSize.Text;
            Settings.Default["leverage"] = txtLeverage.Text;
            Settings.Default["risk"] = txtRiskPerTrade.Text;
            Settings.Default["SL"] = txtStopLoss.Text;
            Settings.Default["client"] = new StringCollection();

            // Save the settings
            Settings.Default.Save();
        }
        #endregion

        #region Assign user's settings
        private void assignUserProperties()
        {
            // This method updates the user's properties in the application.
            // Returns:
            //  None

            // Redundant 
            TextBox[] txtArray = { txtAccSize, txtLeverage, txtRiskPerTrade, txtStopLoss };

            txtAccSize.Text = Settings.Default["accountSize"].ToString();
            txtLeverage.Text = Settings.Default["leverage"].ToString();
            txtRiskPerTrade.Text = Settings.Default["risk"].ToString();
            txtStopLoss.Text = Settings.Default["SL"].ToString();
            //Settings.Default["client"] = new StringCollection();
        }
        #endregion

        #region Get Ip address
        public string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(System.Net.Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        #endregion

        #region Update status strip
        public void updateAppStatus(string msg, Color? c = null)
        {
            // This method updates the status strip
            // Args:
            //  msg: string: The message to be displayed in the status strip
            // Returns:
            //  None

            if (c == null) { c = Color.Black;}

            if (msg == null)
            {
                applicationStatus.Text = "Waiting for command";
                applicationStatus.ForeColor = (Color) c;
            }else
            {
                applicationStatus.Text = msg;
                applicationStatus.ForeColor = (Color)c;
            }
        }
        #endregion

        #region check VPN Connection
        public bool CheckForVPNConnection()
        {
            //This Code Gtes the VPN connection, returns True if connected and Flase if not
            //It also automaticly changes the StatusStrip VPN Status
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                NetworkInterface[] interfaces =
                NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface Interface in interfaces)
                {
                    // This is the OpenVPN driver for windows. 
                    if (Interface.Description.Contains("TAP-Windows Adapter")
                      && Interface.OperationalStatus == OperationalStatus.Up)
                    {
                        // VPN Connected, return tru and update Statusstrip
                        updateAppStatus("VPN Connected", Color.Green);
                        return true;
                    }
                }
            }

            // VPN Not Connected, return tru and update Statusstrip
            updateAppStatus("VPN Not Connected", Color.Red);
            return false;
        }
        #endregion

        #region search datagridvew
        //Returns row index if fount, if not, returns -1
        public int searchDatagridVew(DataGridView dg, string columnName, string valueToSearch)
        {
            foreach(DataGridViewRow row in dg.Rows)
            {
                if(row.Cells[columnName].Value.ToString() == valueToSearch)
                {
                    return row.Index;
                }
            }

            return -1;
        }
        #endregion

        #region Update error logs
        public void  updateLog(string text)
        {
            MethodInvoker lstError = () => { txtError.Text += text; };
            if (txtError.InvokeRequired)
            {
                Invoke(lstError);
            }
            else
            {
                lstError.Invoke();
            }
        }
        #endregion

        #region Calculate position size
        private void btnCalculatePositionSize_Click(object sender, EventArgs e)
        {
            double accountSize = double.Parse(txtAccSize.Text);
            double leverage = double.Parse(txtLeverage.Text);
            double riskPerTrade = double.Parse(txtRiskPerTrade.Text);
            double stopLossPercentage = double.Parse(txtStopLoss.Text);

            double PositionSize = accountSize * (riskPerTrade / 100) / (stopLossPercentage / 100) / leverage;
            double positionLoss = PositionSize * leverage * stopLossPercentage / 100;
            lblPositionSize.Text = Math.Round(PositionSize, 2).ToString();
            lblPositionLoss.Text = Math.Round(positionLoss, 2).ToString();
            lblPositionSizeTotal.Text = Math.Round(PositionSize * leverage, 2).ToString();
        }
        #endregion

        #region get user holdings
        public async Task<float> getUserHoldings(string exchange, KucoinClient client)
        {
            //First we clear the holdings listbox
            {
                //Now we update the Holdings Listbox
                MethodInvoker _lstHoldingsClear = () => {
                    lstHoldings.Items.Clear();
                };
                if (txtError.InvokeRequired)
                {
                    Invoke(_lstHoldingsClear);
                }
                else
                {
                    _lstHoldingsClear.Invoke();
                }
            }

            IDictionary<string, float> balancesDict = new Dictionary<string, float>();
            float TotalAccountBalance = 0;

            if (exchange == "kucoin")
            {
                //Get Spot balance
                var callResultSpot = await client.SpotApi.Account.GetAccountsAsync();
                //Get futures balance
                var callResultFutures = await client.FuturesApi.Account.GetAccountOverviewAsync("USDT");

                if (!callResultSpot.Success)
                {
                    // Call failed, check callResult.Error for more info
                    MessageBox.Show("Spot:" + callResultSpot.Error.Message);
                }
                else
                {
                    if (!callResultFutures.Success)
                    {
                        // Call failed, check callResult.Error for more info
                        MessageBox.Show("Futures:" + callResultFutures.Error.Message);
                    }
                    else
                    {
                        //Both calls has been successful
                        //Getting balance for spot
                        foreach (var accData in callResultSpot.Data)
                        {
                            //kucoin has two Margin accounts so to avoid errors, we first check if there are duplicate keys in dictionary
                            if (balancesDict.ContainsKey(accData.Type.ToString()))
                            {
                                balancesDict[accData.Type.ToString()] += float.Parse(accData.Holds.ToString());
                            }
                            else
                            {
                                balancesDict.Add(accData.Type.ToString(), float.Parse(accData.Holds.ToString()));
                            }
                        }

                        //Getting balance for futures
                        balancesDict.Add("Futures Total Equity", float.Parse(callResultFutures.Data.AccountEquity.ToString()));

                        //Fill the listbox
                        foreach( var item in balancesDict)
                        {
                            TotalAccountBalance += item.Value;
                            //Now we update the Holdings Listbox
                            MethodInvoker _lstHoldings = () => { lstHoldings.Items.Add(item.Key + ": " + item.Value.ToString()); };
                            if (txtError.InvokeRequired)
                            {
                                Invoke(_lstHoldings);
                            }
                            else
                            {
                                _lstHoldings.Invoke();
                            }
                        }

                        //Add the total account size to listbox
                        {
                            //Now we update the Holdings Listbox
                            MethodInvoker _lstHoldings = () => {
                                lstHoldings.Items.Add("-------------------------------------------------");
                                lstHoldings.Items.Add("Sum: " + TotalAccountBalance.ToString());
                            };
                            if (txtError.InvokeRequired)
                            {
                                Invoke(_lstHoldings);
                            }
                            else
                            {
                                _lstHoldings.Invoke();
                            }
                        }
                        
                    }

                }
            }
            else if(exchange == "binance") { }

            return TotalAccountBalance;
        }
        #endregion

        #endregion

        #region Events

        public async void BtnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false; //Disable start botton so we wont have multiple threads running simultaniously

            if(radioPlatformBinance.Checked == true)
            {

            }
            else if( radioPlatformKucoin.Checked == true)
            {
                //If user is using KUCOIN this part will be activated
                _ = await getUserHoldings("kucoin", restClientKucoin);
            }
        }

        public async void btnGetAccSize_Click(object sender, EventArgs e)
        {
            float accountEquity = await getUserHoldings("kucoin", restClientKucoin);

            //Now we update the Holdings Listbox
            MethodInvoker AccSize = () => {
                txtAccSize.Text = accountEquity.ToString();
            };
            if (txtError.InvokeRequired)
            {
                Invoke(AccSize);
            }
            else
            {
                AccSize.Invoke();
            }
        }

        private void btnDtgTopMoversStart_Click(object sender, EventArgs e)
        {
            // Start the screener
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Update the user settings before closing the application
            updateAppStatus("Closing");
            saveUserProperties();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath);
            // Assing textBox valeus to the variables
            apiKey = "0"; //txtAPIKEY.Text;
            secretKey = "0"; // txtSECRETKEY.Text;

            // Check for VPN connection
            CheckForVPNConnection();

            // Update the fields for UX improvements
            assignUserProperties();

            if (radioPlatformKucoin.Checked == true)
            {
                //Make Kucoin client
                restClientKucoin = new KucoinClient(new KucoinClientOptions()
                {
                    //// Specify options for the client
                    //ApiCredentials = new KucoinApiCredentials(apiKey, secretKey, "0"),
                    //FuturesApiCredentials = new KucoinApiCredentials("0", "0", "0")

                });
            }
            else if (radioPlatformBinance.Checked == true)
            {
                ////Make Binance client
                //restClientBinance = new BinanceClient();
                //restClientBinance.SetApiCredentials(apiKey, secretKey);
            }
        }
        #endregion
    }
}
