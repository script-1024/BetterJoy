namespace BetterJoyForCemu {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.console = new System.Windows.Forms.TextBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.passiveScanBox = new System.Windows.Forms.CheckBox();
            this.conCntrls = new System.Windows.Forms.GroupBox();
            this.loc4 = new System.Windows.Forms.Button();
            this.loc3 = new System.Windows.Forms.Button();
            this.loc2 = new System.Windows.Forms.Button();
            this.loc1 = new System.Windows.Forms.Button();
            this.con4 = new System.Windows.Forms.Button();
            this.con3 = new System.Windows.Forms.Button();
            this.con2 = new System.Windows.Forms.Button();
            this.con1 = new System.Windows.Forms.Button();
            this.btnTip = new System.Windows.Forms.ToolTip(this.components);
            this.foldLbl = new System.Windows.Forms.Label();
            this.startInTrayBox = new System.Windows.Forms.CheckBox();
            this.btn_open3rdP = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.settingsTable = new System.Windows.Forms.TableLayoutPanel();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.settingsApply = new System.Windows.Forms.Button();
            this.AutoCalibrate = new System.Windows.Forms.Button();
            this.btn_reassign_open = new System.Windows.Forms.Button();
            this.link_gamepad_test = new System.Windows.Forms.LinkLabel();
            this.contextMenu.SuspendLayout();
            this.conCntrls.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // console
            // 
            this.console.BackColor = System.Drawing.Color.White;
            this.console.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.console.Location = new System.Drawing.Point(16, 197);
            this.console.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.console.Multiline = true;
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.console.Size = new System.Drawing.Size(348, 216);
            this.console.TabIndex = 2;
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipText = "Double click the tray icon to maximise!";
            this.notifyIcon.BalloonTipTitle = "BetterJoy";
            this.notifyIcon.ContextMenuStrip = this.contextMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "BetterJoy";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // contextMenu
            // 
            this.contextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(103, 28);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // passiveScanBox
            // 
            this.passiveScanBox.AutoSize = true;
            this.passiveScanBox.Checked = true;
            this.passiveScanBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.passiveScanBox.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passiveScanBox.Location = new System.Drawing.Point(16, 421);
            this.passiveScanBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.passiveScanBox.Name = "passiveScanBox";
            this.passiveScanBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.passiveScanBox.Size = new System.Drawing.Size(100, 26);
            this.passiveScanBox.TabIndex = 4;
            this.passiveScanBox.Text = "被動掃描";
            this.passiveScanBox.UseVisualStyleBackColor = true;
            this.passiveScanBox.CheckedChanged += new System.EventHandler(this.passiveScanBox_CheckedChanged);
            // 
            // conCntrls
            // 
            this.conCntrls.Controls.Add(this.loc4);
            this.conCntrls.Controls.Add(this.loc3);
            this.conCntrls.Controls.Add(this.loc2);
            this.conCntrls.Controls.Add(this.loc1);
            this.conCntrls.Controls.Add(this.con4);
            this.conCntrls.Controls.Add(this.con3);
            this.conCntrls.Controls.Add(this.con2);
            this.conCntrls.Controls.Add(this.con1);
            this.conCntrls.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conCntrls.Location = new System.Drawing.Point(16, 14);
            this.conCntrls.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.conCntrls.Name = "conCntrls";
            this.conCntrls.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.conCntrls.Size = new System.Drawing.Size(349, 140);
            this.conCntrls.TabIndex = 0;
            this.conCntrls.TabStop = false;
            this.conCntrls.Text = "已連接的控制器";
            // 
            // loc4
            // 
            this.loc4.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loc4.Location = new System.Drawing.Point(264, 92);
            this.loc4.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.loc4.Name = "loc4";
            this.loc4.Size = new System.Drawing.Size(77, 42);
            this.loc4.TabIndex = 7;
            this.loc4.Text = "定位";
            this.loc4.UseVisualStyleBackColor = true;
            // 
            // loc3
            // 
            this.loc3.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loc3.Location = new System.Drawing.Point(179, 92);
            this.loc3.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.loc3.Name = "loc3";
            this.loc3.Size = new System.Drawing.Size(77, 42);
            this.loc3.TabIndex = 6;
            this.loc3.Text = "定位";
            this.loc3.UseVisualStyleBackColor = true;
            // 
            // loc2
            // 
            this.loc2.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loc2.Location = new System.Drawing.Point(93, 92);
            this.loc2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.loc2.Name = "loc2";
            this.loc2.Size = new System.Drawing.Size(77, 42);
            this.loc2.TabIndex = 5;
            this.loc2.Text = "定位";
            this.loc2.UseVisualStyleBackColor = true;
            // 
            // loc1
            // 
            this.loc1.Cursor = System.Windows.Forms.Cursors.Default;
            this.loc1.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loc1.Location = new System.Drawing.Point(8, 92);
            this.loc1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.loc1.Name = "loc1";
            this.loc1.Size = new System.Drawing.Size(77, 42);
            this.loc1.TabIndex = 4;
            this.loc1.Text = "定位";
            this.loc1.UseVisualStyleBackColor = true;
            // 
            // con4
            // 
            this.con4.BackgroundImage = global::BetterJoyForCemu.Properties.Resources.cross;
            this.con4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.con4.Enabled = false;
            this.con4.Location = new System.Drawing.Point(264, 22);
            this.con4.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.con4.Name = "con4";
            this.con4.Size = new System.Drawing.Size(77, 68);
            this.con4.TabIndex = 3;
            this.con4.TabStop = false;
            this.con4.UseVisualStyleBackColor = true;
            // 
            // con3
            // 
            this.con3.BackgroundImage = global::BetterJoyForCemu.Properties.Resources.cross;
            this.con3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.con3.Enabled = false;
            this.con3.Location = new System.Drawing.Point(179, 22);
            this.con3.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.con3.Name = "con3";
            this.con3.Size = new System.Drawing.Size(77, 68);
            this.con3.TabIndex = 2;
            this.con3.TabStop = false;
            this.con3.UseVisualStyleBackColor = true;
            // 
            // con2
            // 
            this.con2.BackgroundImage = global::BetterJoyForCemu.Properties.Resources.cross;
            this.con2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.con2.Enabled = false;
            this.con2.Location = new System.Drawing.Point(93, 22);
            this.con2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.con2.Name = "con2";
            this.con2.Size = new System.Drawing.Size(77, 68);
            this.con2.TabIndex = 1;
            this.con2.TabStop = false;
            this.con2.UseVisualStyleBackColor = true;
            // 
            // con1
            // 
            this.con1.BackgroundImage = global::BetterJoyForCemu.Properties.Resources.cross;
            this.con1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.con1.Enabled = false;
            this.con1.Location = new System.Drawing.Point(8, 22);
            this.con1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.con1.Name = "con1";
            this.con1.Size = new System.Drawing.Size(77, 68);
            this.con1.TabIndex = 0;
            this.con1.TabStop = false;
            this.btnTip.SetToolTip(this.con1, "Click on Joycons to join/split them");
            this.con1.UseVisualStyleBackColor = true;
            // 
            // foldLbl
            // 
            this.foldLbl.BackColor = System.Drawing.Color.Transparent;
            this.foldLbl.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.foldLbl.Location = new System.Drawing.Point(372, 0);
            this.foldLbl.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.foldLbl.Name = "foldLbl";
            this.foldLbl.Size = new System.Drawing.Size(37, 453);
            this.foldLbl.TabIndex = 12;
            this.foldLbl.Text = ">";
            this.foldLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnTip.SetToolTip(this.foldLbl, "Config");
            this.foldLbl.Click += new System.EventHandler(this.foldLbl_Click);
            // 
            // startInTrayBox
            // 
            this.startInTrayBox.AutoSize = true;
            this.startInTrayBox.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startInTrayBox.Location = new System.Drawing.Point(137, 421);
            this.startInTrayBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.startInTrayBox.Name = "startInTrayBox";
            this.startInTrayBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.startInTrayBox.Size = new System.Drawing.Size(100, 26);
            this.startInTrayBox.TabIndex = 6;
            this.startInTrayBox.Text = "靜默啟動";
            this.startInTrayBox.UseVisualStyleBackColor = true;
            this.startInTrayBox.CheckedChanged += new System.EventHandler(this.startInTrayBox_CheckedChanged);
            // 
            // btn_open3rdP
            // 
            this.btn_open3rdP.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_open3rdP.Location = new System.Drawing.Point(137, 159);
            this.btn_open3rdP.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btn_open3rdP.Name = "btn_open3rdP";
            this.btn_open3rdP.Size = new System.Drawing.Size(107, 34);
            this.btn_open3rdP.TabIndex = 7;
            this.btn_open3rdP.Text = "添加設備";
            this.btn_open3rdP.UseVisualStyleBackColor = true;
            this.btn_open3rdP.Click += new System.EventHandler(this.btn_open3rdP_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.settingsTable);
            this.groupBox1.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(425, 401);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "配置";
            // 
            // settingsTable
            // 
            this.settingsTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsTable.AutoScroll = true;
            this.settingsTable.BackColor = System.Drawing.Color.Transparent;
            this.settingsTable.ColumnCount = 2;
            this.settingsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.settingsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.settingsTable.Location = new System.Drawing.Point(5, 22);
            this.settingsTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.settingsTable.Name = "settingsTable";
            this.settingsTable.RowCount = 1;
            this.settingsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingsTable.Size = new System.Drawing.Size(415, 375);
            this.settingsTable.TabIndex = 1;
            // 
            // rightPanel
            // 
            this.rightPanel.BackColor = System.Drawing.Color.Transparent;
            this.rightPanel.Controls.Add(this.settingsApply);
            this.rightPanel.Controls.Add(this.groupBox1);
            this.rightPanel.Location = new System.Drawing.Point(413, 0);
            this.rightPanel.Margin = new System.Windows.Forms.Padding(3, 2, 16, 2);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(432, 453);
            this.rightPanel.TabIndex = 11;
            this.rightPanel.Visible = false;
            // 
            // settingsApply
            // 
            this.settingsApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsApply.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.settingsApply.Location = new System.Drawing.Point(300, 417);
            this.settingsApply.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.settingsApply.Name = "settingsApply";
            this.settingsApply.Size = new System.Drawing.Size(127, 32);
            this.settingsApply.TabIndex = 10;
            this.settingsApply.Text = "保存並關閉";
            this.settingsApply.UseVisualStyleBackColor = true;
            this.settingsApply.Click += new System.EventHandler(this.settingsApply_Click);
            // 
            // AutoCalibrate
            // 
            this.AutoCalibrate.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoCalibrate.Location = new System.Drawing.Point(259, 159);
            this.AutoCalibrate.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.AutoCalibrate.Name = "AutoCalibrate";
            this.AutoCalibrate.Size = new System.Drawing.Size(107, 34);
            this.AutoCalibrate.TabIndex = 8;
            this.AutoCalibrate.Text = "校準搖桿";
            this.AutoCalibrate.UseVisualStyleBackColor = true;
            this.AutoCalibrate.Click += new System.EventHandler(this.StartCalibrate);
            // 
            // btn_reassign_open
            // 
            this.btn_reassign_open.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reassign_open.Location = new System.Drawing.Point(16, 159);
            this.btn_reassign_open.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btn_reassign_open.Name = "btn_reassign_open";
            this.btn_reassign_open.Size = new System.Drawing.Size(107, 34);
            this.btn_reassign_open.TabIndex = 13;
            this.btn_reassign_open.Text = "映射按鍵";
            this.btn_reassign_open.UseVisualStyleBackColor = true;
            this.btn_reassign_open.Click += new System.EventHandler(this.btn_reassign_open_Click);
            // 
            // link_gamepad_test
            // 
            this.link_gamepad_test.AutoSize = true;
            this.link_gamepad_test.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.link_gamepad_test.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.link_gamepad_test.Location = new System.Drawing.Point(255, 422);
            this.link_gamepad_test.Name = "link_gamepad_test";
            this.link_gamepad_test.Size = new System.Drawing.Size(95, 22);
            this.link_gamepad_test.TabIndex = 14;
            this.link_gamepad_test.TabStop = true;
            this.link_gamepad_test.Text = "測試控制器";
            this.link_gamepad_test.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_gamepad_test_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(845, 453);
            this.Controls.Add(this.link_gamepad_test);
            this.Controls.Add(this.btn_reassign_open);
            this.Controls.Add(this.foldLbl);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.AutoCalibrate);
            this.Controls.Add(this.btn_open3rdP);
            this.Controls.Add(this.startInTrayBox);
            this.Controls.Add(this.conCntrls);
            this.Controls.Add(this.passiveScanBox);
            this.Controls.Add(this.console);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "BetterJoy - 特別版";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.contextMenu.ResumeLayout(false);
            this.conCntrls.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.rightPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox console;
        public System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.CheckBox passiveScanBox;
        private System.Windows.Forms.GroupBox conCntrls;
        private System.Windows.Forms.Button con1;
        private System.Windows.Forms.Button con4;
        private System.Windows.Forms.Button con3;
        private System.Windows.Forms.Button con2;
        private System.Windows.Forms.Button loc4;
        private System.Windows.Forms.Button loc3;
        private System.Windows.Forms.Button loc2;
        private System.Windows.Forms.Button loc1;
        private System.Windows.Forms.ToolTip btnTip;
        private System.Windows.Forms.CheckBox startInTrayBox;
        private System.Windows.Forms.Button btn_open3rdP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel settingsTable;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Button settingsApply;
        private System.Windows.Forms.Label foldLbl;
        private System.Windows.Forms.Button AutoCalibrate;
        private System.Windows.Forms.Button btn_reassign_open;
        private System.Windows.Forms.LinkLabel link_gamepad_test;
    }
}
