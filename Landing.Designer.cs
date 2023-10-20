
namespace Trading_Helper
{
    partial class Landing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Landing));
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.applicationStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.AccountGroupeBox = new System.Windows.Forms.GroupBox();
            this.btnUpdateAccountInfo = new System.Windows.Forms.Button();
            this.chkAccountGroupeBoxENableEditing = new System.Windows.Forms.CheckBox();
            this.txtSECRETKEY = new System.Windows.Forms.TextBox();
            this.txtAPIKEY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstHoldings = new System.Windows.Forms.ListBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.orderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pair = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.average = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.side = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioOrderFutures = new System.Windows.Forms.RadioButton();
            this.radioOrderSpot = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtError = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioPlatformBinance = new System.Windows.Forms.RadioButton();
            this.radioPlatformKucoin = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblPositionSizeTotal = new System.Windows.Forms.Label();
            this.lblSIze = new System.Windows.Forms.Label();
            this.lblPositionLoss = new System.Windows.Forms.Label();
            this.lblLoss = new System.Windows.Forms.Label();
            this.btnGetAccSize = new System.Windows.Forms.Button();
            this.btnCalculatePositionSize = new System.Windows.Forms.Button();
            this.txtStopLoss = new System.Windows.Forms.TextBox();
            this.txtRiskPerTrade = new System.Windows.Forms.TextBox();
            this.txtLeverage = new System.Windows.Forms.TextBox();
            this.txtAccSize = new System.Windows.Forms.TextBox();
            this.lblSL = new System.Windows.Forms.Label();
            this.lblRisk = new System.Windows.Forms.Label();
            this.lblLev = new System.Windows.Forms.Label();
            this.lblaccSize = new System.Windows.Forms.Label();
            this.lblUnleveraged = new System.Windows.Forms.Label();
            this.lblPositionSize = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnDtgTopMoversStart = new System.Windows.Forms.Button();
            this.rdiDtgTopMoversKucoin = new System.Windows.Forms.RadioButton();
            this.rdiDtgTopMoversBinance = new System.Windows.Forms.RadioButton();
            this.dtgTopMovers = new System.Windows.Forms.DataGridView();
            this.symbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTrades = new System.Windows.Forms.Button();
            this.btnProtfolio = new System.Windows.Forms.Button();
            this.MainStatusStrip.SuspendLayout();
            this.AccountGroupeBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTopMovers)).BeginInit();
            this.SuspendLayout();
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationStatus});
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 630);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(1101, 26);
            this.MainStatusStrip.TabIndex = 1;
            this.MainStatusStrip.Text = "statusStrip1";
            // 
            // applicationStatus
            // 
            this.applicationStatus.Name = "applicationStatus";
            this.applicationStatus.Size = new System.Drawing.Size(154, 20);
            this.applicationStatus.Text = "Waiting for command";
            // 
            // AccountGroupeBox
            // 
            this.AccountGroupeBox.Controls.Add(this.btnUpdateAccountInfo);
            this.AccountGroupeBox.Controls.Add(this.chkAccountGroupeBoxENableEditing);
            this.AccountGroupeBox.Controls.Add(this.txtSECRETKEY);
            this.AccountGroupeBox.Controls.Add(this.txtAPIKEY);
            this.AccountGroupeBox.Controls.Add(this.label2);
            this.AccountGroupeBox.Controls.Add(this.label1);
            this.AccountGroupeBox.Location = new System.Drawing.Point(837, 12);
            this.AccountGroupeBox.Name = "AccountGroupeBox";
            this.AccountGroupeBox.Size = new System.Drawing.Size(251, 100);
            this.AccountGroupeBox.TabIndex = 2;
            this.AccountGroupeBox.TabStop = false;
            this.AccountGroupeBox.Text = "Account";
            // 
            // btnUpdateAccountInfo
            // 
            this.btnUpdateAccountInfo.Enabled = false;
            this.btnUpdateAccountInfo.Location = new System.Drawing.Point(170, 56);
            this.btnUpdateAccountInfo.Name = "btnUpdateAccountInfo";
            this.btnUpdateAccountInfo.Size = new System.Drawing.Size(75, 33);
            this.btnUpdateAccountInfo.TabIndex = 3;
            this.btnUpdateAccountInfo.Text = "Update";
            this.btnUpdateAccountInfo.UseVisualStyleBackColor = true;
            this.btnUpdateAccountInfo.Click += new System.EventHandler(this.button2_Click);
            // 
            // chkAccountGroupeBoxENableEditing
            // 
            this.chkAccountGroupeBoxENableEditing.AutoSize = true;
            this.chkAccountGroupeBoxENableEditing.Location = new System.Drawing.Point(170, 21);
            this.chkAccountGroupeBoxENableEditing.Name = "chkAccountGroupeBoxENableEditing";
            this.chkAccountGroupeBoxENableEditing.Size = new System.Drawing.Size(70, 20);
            this.chkAccountGroupeBoxENableEditing.TabIndex = 6;
            this.chkAccountGroupeBoxENableEditing.Text = "Editing";
            this.chkAccountGroupeBoxENableEditing.UseVisualStyleBackColor = true;
            this.chkAccountGroupeBoxENableEditing.CheckedChanged += new System.EventHandler(this.AccountGroupeBoxENableEditing_CheckedChanged);
            // 
            // txtSECRETKEY
            // 
            this.txtSECRETKEY.Enabled = false;
            this.txtSECRETKEY.Location = new System.Drawing.Point(75, 61);
            this.txtSECRETKEY.Name = "txtSECRETKEY";
            this.txtSECRETKEY.Size = new System.Drawing.Size(70, 22);
            this.txtSECRETKEY.TabIndex = 5;
            // 
            // txtAPIKEY
            // 
            this.txtAPIKEY.Enabled = false;
            this.txtAPIKEY.Location = new System.Drawing.Point(75, 23);
            this.txtAPIKEY.Name = "txtAPIKEY";
            this.txtAPIKEY.Size = new System.Drawing.Size(70, 22);
            this.txtAPIKEY.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "SECRET";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "API";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstHoldings);
            this.groupBox1.Location = new System.Drawing.Point(837, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 171);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Holdings";
            // 
            // lstHoldings
            // 
            this.lstHoldings.FormattingEnabled = true;
            this.lstHoldings.ItemHeight = 16;
            this.lstHoldings.Location = new System.Drawing.Point(10, 24);
            this.lstHoldings.Name = "lstHoldings";
            this.lstHoldings.Size = new System.Drawing.Size(235, 132);
            this.lstHoldings.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(992, 600);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderId,
            this.pair,
            this.size,
            this.average,
            this.side});
            this.dataGridView1.Location = new System.Drawing.Point(6, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(499, 255);
            this.dataGridView1.TabIndex = 5;
            // 
            // orderId
            // 
            this.orderId.HeaderText = "order Id";
            this.orderId.MinimumWidth = 6;
            this.orderId.Name = "orderId";
            this.orderId.Width = 90;
            // 
            // pair
            // 
            this.pair.HeaderText = "Pair";
            this.pair.MinimumWidth = 6;
            this.pair.Name = "pair";
            this.pair.Width = 90;
            // 
            // size
            // 
            this.size.HeaderText = "Size";
            this.size.MinimumWidth = 6;
            this.size.Name = "size";
            this.size.Width = 125;
            // 
            // average
            // 
            this.average.HeaderText = "Average";
            this.average.MinimumWidth = 6;
            this.average.Name = "average";
            this.average.Width = 125;
            // 
            // side
            // 
            this.side.HeaderText = "Side";
            this.side.MinimumWidth = 6;
            this.side.Name = "side";
            this.side.Width = 50;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioOrderFutures);
            this.groupBox2.Controls.Add(this.radioOrderSpot);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(12, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(511, 309);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Open positions";
            // 
            // radioOrderFutures
            // 
            this.radioOrderFutures.AutoSize = true;
            this.radioOrderFutures.Location = new System.Drawing.Point(70, 282);
            this.radioOrderFutures.Name = "radioOrderFutures";
            this.radioOrderFutures.Size = new System.Drawing.Size(72, 20);
            this.radioOrderFutures.TabIndex = 7;
            this.radioOrderFutures.TabStop = true;
            this.radioOrderFutures.Text = "Futures";
            this.radioOrderFutures.UseVisualStyleBackColor = true;
            // 
            // radioOrderSpot
            // 
            this.radioOrderSpot.AutoSize = true;
            this.radioOrderSpot.Checked = true;
            this.radioOrderSpot.Location = new System.Drawing.Point(6, 281);
            this.radioOrderSpot.Name = "radioOrderSpot";
            this.radioOrderSpot.Size = new System.Drawing.Size(56, 20);
            this.radioOrderSpot.TabIndex = 6;
            this.radioOrderSpot.TabStop = true;
            this.radioOrderSpot.Text = "Spot";
            this.radioOrderSpot.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtError);
            this.groupBox3.Location = new System.Drawing.Point(12, 397);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(511, 204);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Logs";
            // 
            // txtError
            // 
            this.txtError.Location = new System.Drawing.Point(15, 21);
            this.txtError.Multiline = true;
            this.txtError.Name = "txtError";
            this.txtError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtError.Size = new System.Drawing.Size(490, 177);
            this.txtError.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioPlatformBinance);
            this.groupBox4.Controls.Add(this.radioPlatformKucoin);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(511, 52);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Platform";
            // 
            // radioPlatformBinance
            // 
            this.radioPlatformBinance.AutoSize = true;
            this.radioPlatformBinance.Enabled = false;
            this.radioPlatformBinance.Location = new System.Drawing.Point(123, 20);
            this.radioPlatformBinance.Name = "radioPlatformBinance";
            this.radioPlatformBinance.Size = new System.Drawing.Size(77, 20);
            this.radioPlatformBinance.TabIndex = 1;
            this.radioPlatformBinance.Text = "Binance";
            this.radioPlatformBinance.UseVisualStyleBackColor = true;
            // 
            // radioPlatformKucoin
            // 
            this.radioPlatformKucoin.AutoSize = true;
            this.radioPlatformKucoin.Checked = true;
            this.radioPlatformKucoin.Location = new System.Drawing.Point(7, 22);
            this.radioPlatformKucoin.Name = "radioPlatformKucoin";
            this.radioPlatformKucoin.Size = new System.Drawing.Size(68, 20);
            this.radioPlatformKucoin.TabIndex = 0;
            this.radioPlatformKucoin.TabStop = true;
            this.radioPlatformKucoin.Text = "Kucoin";
            this.radioPlatformKucoin.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblPositionSizeTotal);
            this.groupBox5.Controls.Add(this.lblSIze);
            this.groupBox5.Controls.Add(this.lblPositionLoss);
            this.groupBox5.Controls.Add(this.lblLoss);
            this.groupBox5.Controls.Add(this.btnGetAccSize);
            this.groupBox5.Controls.Add(this.btnCalculatePositionSize);
            this.groupBox5.Controls.Add(this.txtStopLoss);
            this.groupBox5.Controls.Add(this.txtRiskPerTrade);
            this.groupBox5.Controls.Add(this.txtLeverage);
            this.groupBox5.Controls.Add(this.txtAccSize);
            this.groupBox5.Controls.Add(this.lblSL);
            this.groupBox5.Controls.Add(this.lblRisk);
            this.groupBox5.Controls.Add(this.lblLev);
            this.groupBox5.Controls.Add(this.lblaccSize);
            this.groupBox5.Controls.Add(this.lblUnleveraged);
            this.groupBox5.Controls.Add(this.lblPositionSize);
            this.groupBox5.Location = new System.Drawing.Point(837, 295);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(245, 299);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Position size Calculator";
            // 
            // lblPositionSizeTotal
            // 
            this.lblPositionSizeTotal.AutoSize = true;
            this.lblPositionSizeTotal.Location = new System.Drawing.Point(140, 208);
            this.lblPositionSizeTotal.Name = "lblPositionSizeTotal";
            this.lblPositionSizeTotal.Size = new System.Drawing.Size(15, 16);
            this.lblPositionSizeTotal.TabIndex = 21;
            this.lblPositionSizeTotal.Text = "--";
            // 
            // lblSIze
            // 
            this.lblSIze.AutoSize = true;
            this.lblSIze.Location = new System.Drawing.Point(7, 208);
            this.lblSIze.Name = "lblSIze";
            this.lblSIze.Size = new System.Drawing.Size(124, 16);
            this.lblSIze.TabIndex = 20;
            this.lblSIze.Text = "Total Position Size: ";
            // 
            // lblPositionLoss
            // 
            this.lblPositionLoss.AutoSize = true;
            this.lblPositionLoss.Location = new System.Drawing.Point(55, 233);
            this.lblPositionLoss.Name = "lblPositionLoss";
            this.lblPositionLoss.Size = new System.Drawing.Size(15, 16);
            this.lblPositionLoss.TabIndex = 19;
            this.lblPositionLoss.Text = "--";
            // 
            // lblLoss
            // 
            this.lblLoss.AutoSize = true;
            this.lblLoss.Location = new System.Drawing.Point(9, 233);
            this.lblLoss.Name = "lblLoss";
            this.lblLoss.Size = new System.Drawing.Size(39, 16);
            this.lblLoss.TabIndex = 18;
            this.lblLoss.Text = "Loss:";
            // 
            // btnGetAccSize
            // 
            this.btnGetAccSize.Enabled = false;
            this.btnGetAccSize.Location = new System.Drawing.Point(9, 261);
            this.btnGetAccSize.Name = "btnGetAccSize";
            this.btnGetAccSize.Size = new System.Drawing.Size(106, 32);
            this.btnGetAccSize.TabIndex = 17;
            this.btnGetAccSize.Text = "Get acc size";
            this.btnGetAccSize.UseVisualStyleBackColor = true;
            this.btnGetAccSize.Click += new System.EventHandler(this.btnGetAccSize_Click);
            // 
            // btnCalculatePositionSize
            // 
            this.btnCalculatePositionSize.Location = new System.Drawing.Point(155, 261);
            this.btnCalculatePositionSize.Name = "btnCalculatePositionSize";
            this.btnCalculatePositionSize.Size = new System.Drawing.Size(75, 32);
            this.btnCalculatePositionSize.TabIndex = 16;
            this.btnCalculatePositionSize.Text = "Claculate";
            this.btnCalculatePositionSize.UseVisualStyleBackColor = true;
            this.btnCalculatePositionSize.Click += new System.EventHandler(this.btnCalculatePositionSize_Click);
            // 
            // txtStopLoss
            // 
            this.txtStopLoss.Location = new System.Drawing.Point(106, 139);
            this.txtStopLoss.Name = "txtStopLoss";
            this.txtStopLoss.Size = new System.Drawing.Size(124, 22);
            this.txtStopLoss.TabIndex = 15;
            // 
            // txtRiskPerTrade
            // 
            this.txtRiskPerTrade.Location = new System.Drawing.Point(130, 103);
            this.txtRiskPerTrade.Name = "txtRiskPerTrade";
            this.txtRiskPerTrade.Size = new System.Drawing.Size(100, 22);
            this.txtRiskPerTrade.TabIndex = 14;
            // 
            // txtLeverage
            // 
            this.txtLeverage.Location = new System.Drawing.Point(106, 70);
            this.txtLeverage.Name = "txtLeverage";
            this.txtLeverage.Size = new System.Drawing.Size(124, 22);
            this.txtLeverage.TabIndex = 13;
            // 
            // txtAccSize
            // 
            this.txtAccSize.Location = new System.Drawing.Point(106, 35);
            this.txtAccSize.Name = "txtAccSize";
            this.txtAccSize.Size = new System.Drawing.Size(124, 22);
            this.txtAccSize.TabIndex = 12;
            // 
            // lblSL
            // 
            this.lblSL.AutoSize = true;
            this.lblSL.Location = new System.Drawing.Point(7, 139);
            this.lblSL.Name = "lblSL";
            this.lblSL.Size = new System.Drawing.Size(81, 16);
            this.lblSL.TabIndex = 11;
            this.lblSL.Text = "Stop loss %:";
            // 
            // lblRisk
            // 
            this.lblRisk.AutoSize = true;
            this.lblRisk.Location = new System.Drawing.Point(7, 103);
            this.lblRisk.Name = "lblRisk";
            this.lblRisk.Size = new System.Drawing.Size(109, 16);
            this.lblRisk.TabIndex = 10;
            this.lblRisk.Text = "Risk % per trade:";
            // 
            // lblLev
            // 
            this.lblLev.AutoSize = true;
            this.lblLev.Location = new System.Drawing.Point(6, 70);
            this.lblLev.Name = "lblLev";
            this.lblLev.Size = new System.Drawing.Size(68, 16);
            this.lblLev.TabIndex = 3;
            this.lblLev.Text = "Leverage:";
            // 
            // lblaccSize
            // 
            this.lblaccSize.AutoSize = true;
            this.lblaccSize.Location = new System.Drawing.Point(6, 35);
            this.lblaccSize.Name = "lblaccSize";
            this.lblaccSize.Size = new System.Drawing.Size(90, 16);
            this.lblaccSize.TabIndex = 2;
            this.lblaccSize.Text = "Account Size: ";
            // 
            // lblUnleveraged
            // 
            this.lblUnleveraged.AutoSize = true;
            this.lblUnleveraged.Location = new System.Drawing.Point(7, 181);
            this.lblUnleveraged.Name = "lblUnleveraged";
            this.lblUnleveraged.Size = new System.Drawing.Size(172, 16);
            this.lblUnleveraged.TabIndex = 1;
            this.lblUnleveraged.Text = "Unleveraged Position Size: ";
            // 
            // lblPositionSize
            // 
            this.lblPositionSize.AutoSize = true;
            this.lblPositionSize.Location = new System.Drawing.Point(186, 181);
            this.lblPositionSize.Name = "lblPositionSize";
            this.lblPositionSize.Size = new System.Drawing.Size(15, 16);
            this.lblPositionSize.TabIndex = 0;
            this.lblPositionSize.Text = "--";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnDtgTopMoversStart);
            this.groupBox6.Controls.Add(this.rdiDtgTopMoversKucoin);
            this.groupBox6.Controls.Add(this.rdiDtgTopMoversBinance);
            this.groupBox6.Controls.Add(this.dtgTopMovers);
            this.groupBox6.Location = new System.Drawing.Point(529, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(302, 582);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Top Gainers and losers";
            // 
            // btnDtgTopMoversStart
            // 
            this.btnDtgTopMoversStart.Location = new System.Drawing.Point(192, 21);
            this.btnDtgTopMoversStart.Name = "btnDtgTopMoversStart";
            this.btnDtgTopMoversStart.Size = new System.Drawing.Size(94, 23);
            this.btnDtgTopMoversStart.TabIndex = 3;
            this.btnDtgTopMoversStart.Text = "Start";
            this.btnDtgTopMoversStart.UseVisualStyleBackColor = true;
            this.btnDtgTopMoversStart.Click += new System.EventHandler(this.btnDtgTopMoversStart_Click);
            // 
            // rdiDtgTopMoversKucoin
            // 
            this.rdiDtgTopMoversKucoin.AutoSize = true;
            this.rdiDtgTopMoversKucoin.Location = new System.Drawing.Point(92, 24);
            this.rdiDtgTopMoversKucoin.Name = "rdiDtgTopMoversKucoin";
            this.rdiDtgTopMoversKucoin.Size = new System.Drawing.Size(68, 20);
            this.rdiDtgTopMoversKucoin.TabIndex = 2;
            this.rdiDtgTopMoversKucoin.Text = "Kucoin";
            this.rdiDtgTopMoversKucoin.UseVisualStyleBackColor = true;
            // 
            // rdiDtgTopMoversBinance
            // 
            this.rdiDtgTopMoversBinance.AutoSize = true;
            this.rdiDtgTopMoversBinance.Checked = true;
            this.rdiDtgTopMoversBinance.Location = new System.Drawing.Point(6, 26);
            this.rdiDtgTopMoversBinance.Name = "rdiDtgTopMoversBinance";
            this.rdiDtgTopMoversBinance.Size = new System.Drawing.Size(77, 20);
            this.rdiDtgTopMoversBinance.TabIndex = 1;
            this.rdiDtgTopMoversBinance.TabStop = true;
            this.rdiDtgTopMoversBinance.Text = "Binance";
            this.rdiDtgTopMoversBinance.UseVisualStyleBackColor = true;
            // 
            // dtgTopMovers
            // 
            this.dtgTopMovers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTopMovers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.symbol,
            this.percentage,
            this.volume});
            this.dtgTopMovers.Location = new System.Drawing.Point(6, 58);
            this.dtgTopMovers.Name = "dtgTopMovers";
            this.dtgTopMovers.RowHeadersWidth = 51;
            this.dtgTopMovers.RowTemplate.Height = 24;
            this.dtgTopMovers.Size = new System.Drawing.Size(290, 518);
            this.dtgTopMovers.TabIndex = 0;
            // 
            // symbol
            // 
            this.symbol.HeaderText = "Symbol";
            this.symbol.MinimumWidth = 6;
            this.symbol.Name = "symbol";
            this.symbol.ReadOnly = true;
            this.symbol.Width = 60;
            // 
            // percentage
            // 
            this.percentage.HeaderText = "Percentage";
            this.percentage.MinimumWidth = 6;
            this.percentage.Name = "percentage";
            this.percentage.Width = 40;
            // 
            // volume
            // 
            this.volume.HeaderText = "Volume";
            this.volume.MinimumWidth = 6;
            this.volume.Name = "volume";
            this.volume.Width = 125;
            // 
            // btnTrades
            // 
            this.btnTrades.Location = new System.Drawing.Point(893, 600);
            this.btnTrades.Name = "btnTrades";
            this.btnTrades.Size = new System.Drawing.Size(75, 23);
            this.btnTrades.TabIndex = 11;
            this.btnTrades.Text = "Journal";
            this.btnTrades.UseVisualStyleBackColor = true;
            this.btnTrades.Click += new System.EventHandler(this.btnTrades_Click);
            // 
            // btnProtfolio
            // 
            this.btnProtfolio.Location = new System.Drawing.Point(812, 600);
            this.btnProtfolio.Name = "btnProtfolio";
            this.btnProtfolio.Size = new System.Drawing.Size(75, 23);
            this.btnProtfolio.TabIndex = 12;
            this.btnProtfolio.Text = "Protfolio";
            this.btnProtfolio.UseVisualStyleBackColor = true;
            this.btnProtfolio.Click += new System.EventHandler(this.btnProtfolio_Click);
            // 
            // Landing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 656);
            this.Controls.Add(this.btnProtfolio);
            this.Controls.Add(this.btnTrades);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.AccountGroupeBox);
            this.Controls.Add(this.MainStatusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Landing";
            this.Text = "Trading helper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainStatusStrip.ResumeLayout(false);
            this.MainStatusStrip.PerformLayout();
            this.AccountGroupeBox.ResumeLayout(false);
            this.AccountGroupeBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTopMovers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel applicationStatus;
        private System.Windows.Forms.GroupBox AccountGroupeBox;
        private System.Windows.Forms.Button btnUpdateAccountInfo;
        private System.Windows.Forms.CheckBox chkAccountGroupeBoxENableEditing;
        private System.Windows.Forms.TextBox txtSECRETKEY;
        private System.Windows.Forms.TextBox txtAPIKEY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ListBox lstHoldings;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioOrderFutures;
        private System.Windows.Forms.RadioButton radioOrderSpot;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn pair;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewTextBoxColumn average;
        private System.Windows.Forms.DataGridViewTextBoxColumn side;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtError;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioPlatformBinance;
        private System.Windows.Forms.RadioButton radioPlatformKucoin;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnCalculatePositionSize;
        private System.Windows.Forms.TextBox txtStopLoss;
        private System.Windows.Forms.TextBox txtRiskPerTrade;
        private System.Windows.Forms.TextBox txtLeverage;
        private System.Windows.Forms.TextBox txtAccSize;
        private System.Windows.Forms.Label lblSL;
        private System.Windows.Forms.Label lblRisk;
        private System.Windows.Forms.Label lblLev;
        private System.Windows.Forms.Label lblaccSize;
        private System.Windows.Forms.Label lblUnleveraged;
        private System.Windows.Forms.Label lblPositionSize;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnGetAccSize;
        private System.Windows.Forms.Label lblPositionLoss;
        private System.Windows.Forms.Label lblLoss;
        private System.Windows.Forms.Label lblPositionSizeTotal;
        private System.Windows.Forms.Label lblSIze;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dtgTopMovers;
        private System.Windows.Forms.DataGridViewTextBoxColumn symbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn percentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn volume;
        private System.Windows.Forms.Button btnDtgTopMoversStart;
        private System.Windows.Forms.RadioButton rdiDtgTopMoversKucoin;
        private System.Windows.Forms.RadioButton rdiDtgTopMoversBinance;
        private System.Windows.Forms.Button btnTrades;
        private System.Windows.Forms.Button btnProtfolio;
    }
}

