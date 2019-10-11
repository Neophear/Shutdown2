using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Management;
using Microsoft.Win32;

namespace Shutdown2
{
    public partial class Form1 : Form
    {
        public int hours = 0;
        public int minutes = 0;
        public int seconds = 0;
        public bool paused = false;

        public DetailedTimer timer = new DetailedTimer();

        public Form1()
        {
            InitializeComponent();

            cmbbxAction.SelectedIndex = 0;

            timer.OnHourChange += timer_OnHourChange;
            timer.OnMinuteChange += timer_OnMinuteChange;
            timer.OnSecondChange += timer_OnSecondChange;
            timer.OnTimerDone += timer_OnTimerDone;
            timer.OnWarning += timer_OnWarning;
        }

        void timer_OnWarning(object sender, EventArgs e)
        {
            Warning();
        }

        void timer_OnHourChange(object sender, EventArgs e)
        {
            lblHours.Text = $"{timer.Hour:00}";
        }

        void timer_OnMinuteChange(object sender, EventArgs e)
        {
            lblMin.Text = $"{timer.Minute:00}";

            if (chkbx5minScreenshot.Checked && timer.Minute % 5 == 0)
                TakeScreenshot();
        }

        void timer_OnSecondChange(object sender, EventArgs e)
        {
            lblSec.Text = $"{timer.Second:00}";
        }

        private void Warning()
        {
            lblHours.ForeColor = Color.Red;
            lblMin.ForeColor = Color.Red;
            lblSec.ForeColor = Color.Red;

            if (chkbxWarning.Checked)
            {
                TopMost = true;
                Focus();
                BringToFront();
                TopMost = false;
                MessageBox.Show("1 minute left!");
            }
        }

        void timer_OnTimerDone(object sender, EventArgs e)
        {
            TimerDone();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!timer.IsRunning)
            {
                if (paused)
                {
                    timer.Start();
                    btnStart.Text = "Pause";
                }
                else
                {
                    string[] strTime = mtxtTime.Text.Split(':');
                    CountdownTime time = new CountdownTime();

                    string strHours = strTime[0].Trim();
                    string strMin = strTime[1].Trim();
                    string strSec = strTime[2].Trim();

                    if (CountdownTime.TryParse(strHours, strMin, strSec, out time))
                    {
                        if (time < (new CountdownTime(0,0,0)))
                            MessageBox.Show("Time cant be less than 1 minute");
                        else
                        {
                            EnableTextBoxes(false);
                            btnStart.Text = "Pause";
                            timer.SetTimes(time);
                            timer.Start();
                        }
                    }
                    else
                        MessageBox.Show("Wrong syntax");
                }
            }
            else
            {
                timer.Stop();
                btnStart.Text = "Start";
                paused = true;
            }
        }

        private void EnableTextBoxes(bool status)
        {
            mtxtTime.Enabled = status;
            cmbbxAction.Enabled = status;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            timer.Stop();
            btnStart.Text = "Start";
            EnableTextBoxes(true);
            paused = false;
            lblHours.Text = "00";
            lblMin.Text = "00";
            lblSec.Text = "00";
            lblHours.ForeColor = Color.Black;
            lblMin.ForeColor = Color.Black;
            lblSec.ForeColor = Color.Black;
        }

        public void TimerDone()
        {
            if (chkbxTakeScreenshot.Checked)
                TakeScreenshot();

            ManagementBaseObject outParameters = null;
            ManagementClass sysOS = new ManagementClass("Win32_OperatingSystem");
            sysOS.Get();
            // enables required security privilege.
            sysOS.Scope.Options.EnablePrivileges = true;
            // get our in parameters
            ManagementBaseObject inParameters = sysOS.GetMethodParameters("Win32Shutdown");
            // The possible flags for controlling the system
            // 0 = Log off the network.
            // 1 = Shut down the system.
            // 2 = Perform a full reboot of the system.
            // 4 = Force any applications to quit instead of prompting the user to close them.
            // 8 = Shut down the system and, if possible, turn the computer off.
            switch (cmbbxAction.SelectedItem.ToString())
            {
                case "Shutdown":
                    inParameters["Flags"] = "1";
                    break;
                case "Restart":
                    inParameters["Flags"] = "2";
                    break;
                default:
                    break;
            }

            inParameters["Reserved"] = "0";
            foreach (ManagementObject manObj in sysOS.GetInstances())
                outParameters = manObj.InvokeMethod("Win32Shutdown", inParameters, null);

            Reset();
        }

        private void Form1_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            MessageBox.Show("Made by Stiig Gade\nScreenshots are saved on your desktop in a folder called Shutdown2.");
        }

        private void TakeScreenshot()
        {
            var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                               Screen.PrimaryScreen.Bounds.Height,
                               PixelFormat.Format32bppArgb);

            // Create a graphics object from the bitmap.
            var gfxScreenshot = Graphics.FromImage(bmpScreenshot);

            // Take the screenshot from the upper left corner to the right bottom corner.
            gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                        Screen.PrimaryScreen.Bounds.Y,
                                        0,
                                        0,
                                        Screen.PrimaryScreen.Bounds.Size,
                                        CopyPixelOperation.SourceCopy);
            string screenshotPath = String.Format("{0}\\Shutdown2\\", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            string screenshotName = String.Format("Shutdown2_screenshot_{0}_{1}.png", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString().Replace(":", ""));

            if (!Directory.Exists(screenshotPath))
                Directory.CreateDirectory(screenshotPath);

            // Save the screenshot to the specified path that the user has chosen.
            bmpScreenshot.Save(screenshotPath + screenshotName, ImageFormat.Png);
        }
    }
}
