﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BetterJoyForCemu {
    public partial class MainForm : Form {
        public bool allowCalibration = Boolean.Parse(ConfigurationManager.AppSettings["AllowCalibration"]);
        public List<Button> con, loc;
        public bool calibrate;
        public List<KeyValuePair<string, float[]>> caliData;
        private Timer countDown;
        private int count;
        public List<int> xG, yG, zG, xA, yA, zA;
        public bool shakeInputEnabled = Boolean.Parse(ConfigurationManager.AppSettings["EnableShakeInput"]);
        public float shakeSesitivity = float.Parse(ConfigurationManager.AppSettings["ShakeInputSensitivity"]);
        public float shakeDelay = float.Parse(ConfigurationManager.AppSettings["ShakeInputDelay"]);

        public enum NonOriginalController : int {
            Disabled = 0,
            DefaultCalibration = 1,
            ControllerCalibration = 2,
        }

        public MainForm() {
            xG = new List<int>(); yG = new List<int>(); zG = new List<int>();
            xA = new List<int>(); yA = new List<int>(); zA = new List<int>();
            caliData = new List<KeyValuePair<string, float[]>> {
                new KeyValuePair<string, float[]>("0", new float[6] {0,0,0,-710,0,0})
            };

            InitializeComponent();

            if (!allowCalibration)
                AutoCalibrate.Hide();

            con = new List<Button> { con1, con2, con3, con4 };
            loc = new List<Button> { loc1, loc2, loc3, loc4 };

            //list all options
            string[] myConfigs = ConfigurationManager.AppSettings.AllKeys;
            settingsTable.RowCount = myConfigs.Length;
            for (int i = 0; i != myConfigs.Length; i++) {
                settingsTable.Controls.Add(new Label() { Text = myConfigs[i], Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, AutoEllipsis = true }, 0, i);

                // 固定行高
                var style = new RowStyle { SizeType = SizeType.Absolute, Height = 40 };
                settingsTable.RowStyles.Add(style);

                var value = ConfigurationManager.AppSettings[myConfigs[i]];
                Control childControl;
                if (value == "true" || value == "false") {
                    childControl = new CheckBox() { Checked = Boolean.Parse(value), Dock = DockStyle.Fill };
                } else {
                    childControl = new TextBox() { Text = value, Margin = new Padding(4, 6, 4, 6) };
                }

                childControl.MouseClick += cbBox_Changed;
                settingsTable.Controls.Add(childControl, 1, i);
            }
        }

        private void HideToTray() {
            this.WindowState = FormWindowState.Minimized;
            notifyIcon.Visible = true;
            notifyIcon.BalloonTipText = "Double click the tray icon to maximise!";
            notifyIcon.ShowBalloonTip(0);
            this.ShowInTaskbar = false;
            this.Hide();
        }

        private void ShowFromTray() {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Icon = Properties.Resources.betterjoyforcemu_icon;
            notifyIcon.Visible = false;
        }

        private void MainForm_Resize(object sender, EventArgs e) {
            if (this.WindowState == FormWindowState.Minimized) {
                HideToTray();
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e) {
            ShowFromTray();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            Config.Init(caliData);

            Program.Start();

            passiveScanBox.Checked = Config.IntValue("ProgressiveScan") == 1;
            startInTrayBox.Checked = Config.IntValue("StartInTray") == 1;

            if (Config.IntValue("StartInTray") == 1) {
                HideToTray();
            } else {
                ShowFromTray();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            try {
                Program.Stop();
                Environment.Exit(0);
            } catch { }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) { // this does not work, for some reason. Fix before release
            try {
                Program.Stop();
                Close();
                Environment.Exit(0);
            } catch { }
        }

        private void passiveScanBox_CheckedChanged(object sender, EventArgs e) {
            Config.SetValue("ProgressiveScan", passiveScanBox.Checked ? "1" : "0");
            Config.Save();
        }

        public void AppendTextBox(string value) { // https://stackoverflow.com/questions/519233/writing-to-a-textbox-from-another-thread
            if (InvokeRequired) {
                this.Invoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }
            console.AppendText(value);
        }

        readonly bool toRumble = Boolean.Parse(ConfigurationManager.AppSettings["EnableRumble"]);
        readonly bool showAsXInput = Boolean.Parse(ConfigurationManager.AppSettings["ShowAsXInput"]);
        readonly bool showAsDS4 = Boolean.Parse(ConfigurationManager.AppSettings["ShowAsDS4"]);

        public async void locBtnClickAsync(object sender, EventArgs e) {
            Button bb = sender as Button;

            if (bb.Tag.GetType() == typeof(Button)) {
                Button button = bb.Tag as Button;

                if (button.Tag.GetType() == typeof(Joycon)) {
                    Joycon v = (Joycon)button.Tag;
                    v.SetRumble(160.0f, 320.0f, 1.0f);
                    await Task.Delay(300);
                    v.SetRumble(160.0f, 320.0f, 0);
                }
            }
        }

        readonly bool doNotRejoin = Boolean.Parse(ConfigurationManager.AppSettings["DoNotRejoinJoycons"]);

        public void conBtnClick(object sender, EventArgs e) {
            Button button = sender as Button;

            if (button.Tag.GetType() == typeof(Joycon)) {
                Joycon v = (Joycon)button.Tag;

                if (v.other == null && !v.isPro) { // needs connecting to other joycon (so messy omg)
                    bool succ = false;

                    if (Program.mgr.j.Count == 1 || doNotRejoin) { // when want to have a single joycon in vertical mode
                        v.other = v; // hacky; implement check in Joycon.cs to account for this
                        succ = true;
                    } else {
                        foreach (Joycon jc in Program.mgr.j) {
                            if (!jc.isPro && jc.isLeft != v.isLeft && jc != v && jc.other == null) {
                                v.other = jc;
                                jc.other = v;

                                if (v.out_xbox != null) {
                                    v.out_xbox.Disconnect();
                                    v.out_xbox = null;
                                }

                                if (v.out_ds4 != null) {
                                    v.out_ds4.Disconnect();
                                    v.out_ds4 = null;
                                }

                                // setting the other joycon's button image
                                foreach (Button b in con)
                                    if (b.Tag == jc)
                                        b.BackgroundImage = jc.isLeft ? Properties.Resources.jc_left : Properties.Resources.jc_right;

                                succ = true;
                                break;
                            }
                        }
                    }

                    if (succ)
                        foreach (Button b in con)
                            if (b.Tag == v)
                                b.BackgroundImage = v.isLeft ? Properties.Resources.jc_left : Properties.Resources.jc_right;
                } else if (v.other != null && !v.isPro) { // needs disconnecting from other joycon
                    ReenableViGEm(v);
                    ReenableViGEm(v.other);

                    button.BackgroundImage = v.isLeft ? Properties.Resources.jc_left_s : Properties.Resources.jc_right_s;

                    foreach (Button b in con)
                        if (b.Tag == v.other)
                            b.BackgroundImage = v.other.isLeft ? Properties.Resources.jc_left_s : Properties.Resources.jc_right_s;

                    v.other.other = null;
                    v.other = null;
                }
            }
        }

        private void startInTrayBox_CheckedChanged(object sender, EventArgs e) {
            Config.SetValue("StartInTray", startInTrayBox.Checked ? "1" : "0");
            Config.Save();
        }

        private void btn_open3rdP_Click(object sender, EventArgs e) {
            _3rdPartyControllers partyForm = new _3rdPartyControllers();
            partyForm.ShowDialog();
        }

        private void settingsApply_Click(object sender, EventArgs e) {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            for (int row = 0; row < ConfigurationManager.AppSettings.AllKeys.Length; row++) {
                var valCtl = settingsTable.GetControlFromPosition(1, row);
                var KeyCtl = settingsTable.GetControlFromPosition(0, row).Text;

                if (valCtl.GetType() == typeof(CheckBox) && settings[KeyCtl] != null) {
                    settings[KeyCtl].Value = ((CheckBox)valCtl).Checked.ToString().ToLower();
                } else if (valCtl.GetType() == typeof(TextBox) && settings[KeyCtl] != null) {
                    settings[KeyCtl].Value = ((TextBox)valCtl).Text.ToLower();
                }
            }

            try {
                configFile.Save(ConfigurationSaveMode.Modified);
            } catch (ConfigurationErrorsException) {
                AppendTextBox("寫入應用程序設置時出錯。\r\n");
            }

            ConfigurationManager.AppSettings["AutoPowerOff"] = "false";  // Prevent joycons poweroff when applying settings
            Application.Exit();
        }

        void ReenableViGEm(Joycon v) {
            if (showAsXInput && v.out_xbox == null) {
                v.out_xbox = new Controller.OutputControllerXbox360();

                if (toRumble)
                    v.out_xbox.FeedbackReceived += v.ReceiveRumble;
                v.out_xbox.Connect();
            }

            if (showAsDS4 && v.out_ds4 == null) {
                v.out_ds4 = new Controller.OutputControllerDualShock4();

                if (toRumble)
                    v.out_ds4.FeedbackReceived += v.Ds4_FeedbackReceived;
                v.out_ds4.Connect();
            }
        }

        private void foldLbl_Click(object sender, EventArgs e) {
            rightPanel.Visible = !rightPanel.Visible;
            foldLbl.Text = rightPanel.Visible ? "<" : ">";
        }

        private void cbBox_Changed(object sender, EventArgs e) {
            var coord = settingsTable.GetPositionFromControl(sender as Control);

            var valCtl = settingsTable.GetControlFromPosition(coord.Column, coord.Row);
            var KeyCtl = settingsTable.GetControlFromPosition(coord.Column - 1, coord.Row).Text;

            try {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (valCtl.GetType() == typeof(CheckBox) && settings[KeyCtl] != null) {
                    settings[KeyCtl].Value = ((CheckBox)valCtl).Checked.ToString().ToLower();
                } else if (valCtl.GetType() == typeof(TextBox) && settings[KeyCtl] != null) {
                    settings[KeyCtl].Value = ((TextBox)valCtl).Text.ToLower();
                }

                if (KeyCtl == "HomeLEDOn") {
                    bool on = settings[KeyCtl].Value.ToLower() == "true";
                    foreach (Joycon j in Program.mgr.j) {
                        j.SetHomeLight(on);
                    }
                }

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            } catch (ConfigurationErrorsException) {
                AppendTextBox("寫入應用程序設置時出錯。\r\n");
                Trace.WriteLine(String.Format("rw {0}, column {1}, {2}, {3}", coord.Row, coord.Column, sender.GetType(), KeyCtl));
            }
        }

        private string lastLog = string.Empty;
        private void StartCalibrate(object sender, EventArgs e) {
            lastLog = console.Text;
            if (Program.mgr.j.Count == 0) {
                AppendTextBox("請先連接控制器後再試一次。\r\n");
                return;
            }
            if (Program.mgr.j.Count > 1) {
                AppendTextBox("請先斷開連接其餘設備，同時間僅能校準單只控制器。\r\n");
                return;
            }
            this.AutoCalibrate.Enabled = false;
            countDown = new Timer();
            this.count = 4;
            this.CountDown(null, null);
            countDown.Tick += new EventHandler(CountDown);
            countDown.Interval = 1000;
            countDown.Enabled = true;
        }

        private void StartGetData() {
            this.xG.Clear(); this.yG.Clear(); this.zG.Clear();
            this.xA.Clear(); this.yA.Clear(); this.zA.Clear();
            countDown = new Timer();
            this.count = 3;
            this.calibrate = true;
            countDown.Tick += new EventHandler(CalcData);
            countDown.Interval = 1000;
            countDown.Enabled = true;
        }

        private void btn_reassign_open_Click(object sender, EventArgs e) {
            Reassign mapForm = new Reassign();
            mapForm.ShowDialog();
        }

        private void link_gamepad_test_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            string path = Environment.CurrentDirectory + "\\GamepadTest.html";
            if (!File.Exists(path)) return;
            Process.Start(path);
        }

        private async void btn_auto_pair_Click(object sender, EventArgs e) {
            var path = Environment.CurrentDirectory + "\\btpair.exe";
            var unpair = new ProcessStartInfo() { FileName = path, Arguments = "-u -n\"Pro Controller\"", WindowStyle = ProcessWindowStyle.Hidden };
            var repair = new ProcessStartInfo() { FileName = path, Arguments = "-p -n\"Pro Controller\"", WindowStyle = ProcessWindowStyle.Hidden };
            if (File.Exists(path)) {
                string lastLog = console.Text;
                console.Text = "正在嘗試斷開連接...\r\n";
                await Task.Run(Process.Start(unpair).WaitForExit);
                AppendTextBox("即將開始配對手柄，請確保設備處於配對模式...\r\n");
                await Task.Run(Process.Start(repair).WaitForExit);
                AppendTextBox("命令執行完畢，請在彈出窗口確認操作。\r\n");
                await Task.Delay(3000);
                console.Text = lastLog;
            } else {
                AppendTextBox("無法找到 \"btpair.exe\"，請嘗試重新下載軟件或自行替換！\r\n");
            }
        }

        private void CountDown(object sender, EventArgs e) {
            if (this.count > 0) {
                this.console.Text = "請將控制器放置於平坦桌面。" + "\r\n";
                this.console.Text += "即將於 " + this.count + " 秒後開始校準。" + "\r\n";
                this.count--;
            } else {
                AppendTextBox("校準中...\r\n");
                countDown.Stop();
                this.StartGetData();
            }
        }
        private void CalcData(object sender, EventArgs e) {
            if (this.count >= 0) {
                if (--this.count > 0) return;
            }
            if (this.count == 0) {
                this.calibrate = false;
                string serNum = Program.mgr.j.First().serial_number;
                int serIndex = this.findSer(serNum);
                float[] Arr = new float[6] { 0, 0, 0, 0, 0, 0 };
                if (serIndex == -1) {
                    this.caliData.Add(new KeyValuePair<string, float[]>(serNum, Arr));
                } else {
                    Arr = this.caliData[serIndex].Value;
                }
                Random rnd = new Random();
                Arr[0] = (float)quickselect_median(this.xG, rnd.Next);
                Arr[1] = (float)quickselect_median(this.yG, rnd.Next);
                Arr[2] = (float)quickselect_median(this.zG, rnd.Next);
                Arr[3] = (float)quickselect_median(this.xA, rnd.Next);
                Arr[4] = (float)quickselect_median(this.yA, rnd.Next);
                Arr[5] = (float)quickselect_median(this.zA, rnd.Next) - 4010; //Joycon.cs acc_sen 16384
                AppendTextBox("校準完成！\r\n");
                Config.SaveCaliData(this.caliData);
                Program.mgr.j.First().getActiveData();
                this.AutoCalibrate.Enabled = true;
                return;
            } else {
                countDown.Stop();
                console.Text = lastLog;
            }
        }
        private double quickselect_median(List<int> l, Func<int, int> pivot_fn) {
            int ll = l.Count;
            if (ll % 2 == 1) {
                return this.quickselect(l, ll / 2, pivot_fn);
            } else {
                return 0.5 * (quickselect(l, (ll / 2) - 1, pivot_fn) + quickselect(l, ll / 2, pivot_fn));
            }
        }

        private int quickselect(List<int> l, int k, Func<int, int> pivot_fn) {
            if (l.Count == 1 && k == 0) {
                return l[0];
            }
            int pivot = l[pivot_fn(l.Count)];
            List<int> lows = l.Where(x => x < pivot).ToList();
            List<int> highs = l.Where(x => x > pivot).ToList();
            List<int> pivots = l.Where(x => x == pivot).ToList();
            if (k < lows.Count) {
                return quickselect(lows, k, pivot_fn);
            } else if (k < (lows.Count + pivots.Count)) {
                return pivots[0];
            } else {
                return quickselect(highs, k - lows.Count - pivots.Count, pivot_fn);
            }
        }

        public float[] activeCaliData(string serNum) {
            for (int i = 0; i < this.caliData.Count; i++) {
                if (this.caliData[i].Key == serNum) {
                    return this.caliData[i].Value;
                }
            }
            return this.caliData[0].Value;
        }

        private int findSer(string serNum) {
            for (int i = 0; i < this.caliData.Count; i++) {
                if (this.caliData[i].Key == serNum) {
                    return i;
                }
            }
            return -1;
        }
    }
}
