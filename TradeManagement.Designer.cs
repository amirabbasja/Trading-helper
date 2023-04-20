namespace Trading_Helper
{
    partial class TradeManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TradeManagement));
            this.txtTradeHistoryDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnBrowsFolder = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtClosePrice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCloseDate = new System.Windows.Forms.TextBox();
            this.txtVolume = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRmImage = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAddTrade = new System.Windows.Forms.Button();
            this.txtOpenPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdoStateClose = new System.Windows.Forms.RadioButton();
            this.rdoStateOpen = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoSideShort = new System.Windows.Forms.RadioButton();
            this.rdoSideLong = new System.Windows.Forms.RadioButton();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.picTrade = new System.Windows.Forms.PictureBox();
            this.txtOpenDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txttradeRRatio = new System.Windows.Forms.TextBox();
            this.txtTradeSym = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnDeleteTrade = new System.Windows.Forms.Button();
            this.btnUpdateTrade = new System.Windows.Forms.Button();
            this.btnRef = new System.Windows.Forms.Button();
            this.lstTrades = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.chkEditTrade = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTrade)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTradeHistoryDir
            // 
            this.txtTradeHistoryDir.Enabled = false;
            this.txtTradeHistoryDir.Location = new System.Drawing.Point(111, 21);
            this.txtTradeHistoryDir.Name = "txtTradeHistoryDir";
            this.txtTradeHistoryDir.Size = new System.Drawing.Size(131, 22);
            this.txtTradeHistoryDir.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Trades Folder";
            // 
            // btnBrowsFolder
            // 
            this.btnBrowsFolder.Location = new System.Drawing.Point(248, 21);
            this.btnBrowsFolder.Name = "btnBrowsFolder";
            this.btnBrowsFolder.Size = new System.Drawing.Size(75, 23);
            this.btnBrowsFolder.TabIndex = 2;
            this.btnBrowsFolder.Text = "Browse";
            this.btnBrowsFolder.UseVisualStyleBackColor = true;
            this.btnBrowsFolder.Click += new System.EventHandler(this.btnBrowsFolder_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtClosePrice);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtCloseDate);
            this.groupBox1.Controls.Add(this.txtVolume);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnRmImage);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnAddTrade);
            this.groupBox1.Controls.Add(this.txtOpenPrice);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnAddImage);
            this.groupBox1.Controls.Add(this.picTrade);
            this.groupBox1.Controls.Add(this.txtOpenDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txttradeRRatio);
            this.groupBox1.Controls.Add(this.txtTradeSym);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(329, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 526);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add trade";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 16);
            this.label9.TabIndex = 27;
            this.label9.Text = "Close Price";
            // 
            // txtClosePrice
            // 
            this.txtClosePrice.Location = new System.Drawing.Point(83, 60);
            this.txtClosePrice.Name = "txtClosePrice";
            this.txtClosePrice.Size = new System.Drawing.Size(100, 22);
            this.txtClosePrice.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(186, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 16);
            this.label8.TabIndex = 25;
            this.label8.Text = "Close Date";
            // 
            // txtCloseDate
            // 
            this.txtCloseDate.Location = new System.Drawing.Point(264, 59);
            this.txtCloseDate.Name = "txtCloseDate";
            this.txtCloseDate.Size = new System.Drawing.Size(89, 22);
            this.txtCloseDate.TabIndex = 24;
            // 
            // txtVolume
            // 
            this.txtVolume.Location = new System.Drawing.Point(83, 151);
            this.txtVolume.Name = "txtVolume";
            this.txtVolume.Size = new System.Drawing.Size(100, 22);
            this.txtVolume.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 16);
            this.label7.TabIndex = 22;
            this.label7.Text = "Volume";
            // 
            // btnRmImage
            // 
            this.btnRmImage.Location = new System.Drawing.Point(10, 494);
            this.btnRmImage.Name = "btnRmImage";
            this.btnRmImage.Size = new System.Drawing.Size(113, 29);
            this.btnRmImage.TabIndex = 21;
            this.btnRmImage.Text = "Remove image";
            this.btnRmImage.UseVisualStyleBackColor = true;
            this.btnRmImage.Click += new System.EventHandler(this.btnRmImage_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(10, 214);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(368, 84);
            this.txtDescription.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "Description";
            // 
            // btnAddTrade
            // 
            this.btnAddTrade.Location = new System.Drawing.Point(294, 494);
            this.btnAddTrade.Name = "btnAddTrade";
            this.btnAddTrade.Size = new System.Drawing.Size(88, 29);
            this.btnAddTrade.TabIndex = 18;
            this.btnAddTrade.Text = "Add trade";
            this.btnAddTrade.UseVisualStyleBackColor = true;
            this.btnAddTrade.Click += new System.EventHandler(this.btnAddTrade_Click);
            // 
            // txtOpenPrice
            // 
            this.txtOpenPrice.Location = new System.Drawing.Point(83, 30);
            this.txtOpenPrice.Name = "txtOpenPrice";
            this.txtOpenPrice.Size = new System.Drawing.Size(100, 22);
            this.txtOpenPrice.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Open Price";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdoStateClose);
            this.groupBox3.Controls.Add(this.rdoStateOpen);
            this.groupBox3.Location = new System.Drawing.Point(189, 141);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(174, 49);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "State";
            // 
            // rdoStateClose
            // 
            this.rdoStateClose.AutoSize = true;
            this.rdoStateClose.Location = new System.Drawing.Point(78, 22);
            this.rdoStateClose.Name = "rdoStateClose";
            this.rdoStateClose.Size = new System.Drawing.Size(63, 20);
            this.rdoStateClose.TabIndex = 1;
            this.rdoStateClose.TabStop = true;
            this.rdoStateClose.Text = "Close";
            this.rdoStateClose.UseVisualStyleBackColor = true;
            this.rdoStateClose.CheckedChanged += new System.EventHandler(this.rdoStateClose_CheckedChanged);
            // 
            // rdoStateOpen
            // 
            this.rdoStateOpen.AutoSize = true;
            this.rdoStateOpen.Location = new System.Drawing.Point(6, 20);
            this.rdoStateOpen.Name = "rdoStateOpen";
            this.rdoStateOpen.Size = new System.Drawing.Size(61, 20);
            this.rdoStateOpen.TabIndex = 0;
            this.rdoStateOpen.TabStop = true;
            this.rdoStateOpen.Text = "Open";
            this.rdoStateOpen.UseVisualStyleBackColor = true;
            this.rdoStateOpen.CheckedChanged += new System.EventHandler(this.rdoStateOpen_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoSideShort);
            this.groupBox2.Controls.Add(this.rdoSideLong);
            this.groupBox2.Location = new System.Drawing.Point(189, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(176, 48);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Side";
            // 
            // rdoSideShort
            // 
            this.rdoSideShort.AutoSize = true;
            this.rdoSideShort.Location = new System.Drawing.Point(78, 21);
            this.rdoSideShort.Name = "rdoSideShort";
            this.rdoSideShort.Size = new System.Drawing.Size(59, 20);
            this.rdoSideShort.TabIndex = 1;
            this.rdoSideShort.TabStop = true;
            this.rdoSideShort.Text = "Short";
            this.rdoSideShort.UseVisualStyleBackColor = true;
            // 
            // rdoSideLong
            // 
            this.rdoSideLong.AutoSize = true;
            this.rdoSideLong.Location = new System.Drawing.Point(9, 21);
            this.rdoSideLong.Name = "rdoSideLong";
            this.rdoSideLong.Size = new System.Drawing.Size(58, 20);
            this.rdoSideLong.TabIndex = 0;
            this.rdoSideLong.TabStop = true;
            this.rdoSideLong.Text = "Long";
            this.rdoSideLong.UseVisualStyleBackColor = true;
            this.rdoSideLong.CheckedChanged += new System.EventHandler(this.rdoSideLong_CheckedChanged);
            // 
            // btnAddImage
            // 
            this.btnAddImage.Location = new System.Drawing.Point(129, 494);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(99, 29);
            this.btnAddImage.TabIndex = 13;
            this.btnAddImage.Text = "Add image";
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // picTrade
            // 
            this.picTrade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picTrade.Location = new System.Drawing.Point(10, 313);
            this.picTrade.Name = "picTrade";
            this.picTrade.Size = new System.Drawing.Size(368, 178);
            this.picTrade.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTrade.TabIndex = 12;
            this.picTrade.TabStop = false;
            // 
            // txtOpenDate
            // 
            this.txtOpenDate.Location = new System.Drawing.Point(264, 31);
            this.txtOpenDate.Name = "txtOpenDate";
            this.txtOpenDate.Size = new System.Drawing.Size(89, 22);
            this.txtOpenDate.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(186, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Open Date";
            // 
            // txttradeRRatio
            // 
            this.txttradeRRatio.Location = new System.Drawing.Point(83, 121);
            this.txttradeRRatio.Name = "txttradeRRatio";
            this.txttradeRRatio.Size = new System.Drawing.Size(100, 22);
            this.txttradeRRatio.TabIndex = 9;
            // 
            // txtTradeSym
            // 
            this.txtTradeSym.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTradeSym.Location = new System.Drawing.Point(83, 91);
            this.txtTradeSym.Name = "txtTradeSym";
            this.txtTradeSym.Size = new System.Drawing.Size(100, 22);
            this.txtTradeSym.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "R-Ratio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Symbol";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkEditTrade);
            this.groupBox4.Controls.Add(this.btnDeleteTrade);
            this.groupBox4.Controls.Add(this.btnUpdateTrade);
            this.groupBox4.Controls.Add(this.btnRef);
            this.groupBox4.Controls.Add(this.lstTrades);
            this.groupBox4.Location = new System.Drawing.Point(12, 54);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(311, 493);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Open Trades";
            // 
            // btnDeleteTrade
            // 
            this.btnDeleteTrade.Location = new System.Drawing.Point(187, 307);
            this.btnDeleteTrade.Name = "btnDeleteTrade";
            this.btnDeleteTrade.Size = new System.Drawing.Size(67, 27);
            this.btnDeleteTrade.TabIndex = 3;
            this.btnDeleteTrade.Text = "Delete";
            this.btnDeleteTrade.UseVisualStyleBackColor = true;
            this.btnDeleteTrade.Click += new System.EventHandler(this.btnDeleteTrade_Click);
            // 
            // btnUpdateTrade
            // 
            this.btnUpdateTrade.Location = new System.Drawing.Point(106, 307);
            this.btnUpdateTrade.Name = "btnUpdateTrade";
            this.btnUpdateTrade.Size = new System.Drawing.Size(75, 27);
            this.btnUpdateTrade.TabIndex = 2;
            this.btnUpdateTrade.Text = "Update";
            this.btnUpdateTrade.UseVisualStyleBackColor = true;
            this.btnUpdateTrade.Click += new System.EventHandler(this.btnUpdateTrade_Click);
            // 
            // btnRef
            // 
            this.btnRef.Location = new System.Drawing.Point(260, 307);
            this.btnRef.Name = "btnRef";
            this.btnRef.Size = new System.Drawing.Size(45, 27);
            this.btnRef.TabIndex = 1;
            this.btnRef.Text = "REF";
            this.btnRef.UseVisualStyleBackColor = true;
            this.btnRef.Click += new System.EventHandler(this.btnRef_Click);
            // 
            // lstTrades
            // 
            this.lstTrades.FormattingEnabled = true;
            this.lstTrades.ItemHeight = 16;
            this.lstTrades.Location = new System.Drawing.Point(7, 25);
            this.lstTrades.Name = "lstTrades";
            this.lstTrades.Size = new System.Drawing.Size(298, 276);
            this.lstTrades.TabIndex = 0;
            this.lstTrades.SelectedIndexChanged += new System.EventHandler(this.lstTrades_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 548);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(725, 26);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(128, 20);
            this.toolStripStatusLabel1.Text = "Waitning for entry";
            // 
            // chkEditTrade
            // 
            this.chkEditTrade.AutoSize = true;
            this.chkEditTrade.Location = new System.Drawing.Point(7, 311);
            this.chkEditTrade.Name = "chkEditTrade";
            this.chkEditTrade.Size = new System.Drawing.Size(52, 20);
            this.chkEditTrade.TabIndex = 4;
            this.chkEditTrade.Text = "Edit";
            this.chkEditTrade.UseVisualStyleBackColor = true;
            this.chkEditTrade.CheckedChanged += new System.EventHandler(this.chkEditTrade_CheckedChanged);
            // 
            // TradeManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 574);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBrowsFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTradeHistoryDir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TradeManagement";
            this.Text = "Trades";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TradeManagement_FormClosing);
            this.Load += new System.EventHandler(this.TradeManagement_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTrade)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTradeHistoryDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnBrowsFolder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddTrade;
        private System.Windows.Forms.TextBox txtOpenPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdoStateClose;
        private System.Windows.Forms.RadioButton rdoStateOpen;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoSideShort;
        private System.Windows.Forms.RadioButton rdoSideLong;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.PictureBox picTrade;
        private System.Windows.Forms.TextBox txtOpenDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txttradeRRatio;
        private System.Windows.Forms.TextBox txtTradeSym;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox lstTrades;
        private System.Windows.Forms.Button btnRmImage;
        private System.Windows.Forms.Button btnRef;
        private System.Windows.Forms.TextBox txtVolume;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCloseDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtClosePrice;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnDeleteTrade;
        private System.Windows.Forms.Button btnUpdateTrade;
        private System.Windows.Forms.CheckBox chkEditTrade;
    }
}