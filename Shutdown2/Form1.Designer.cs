namespace Shutdown2
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cmbbxAction = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblHours = new System.Windows.Forms.Label();
            this.lblSeperator1 = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblSeperator2 = new System.Windows.Forms.Label();
            this.lblSec = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.mtxtTime = new System.Windows.Forms.MaskedTextBox();
            this.chkbxTakeScreenshot = new System.Windows.Forms.CheckBox();
            this.chkbxWarning = new System.Windows.Forms.CheckBox();
            this.chkbx5minScreenshot = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cmbbxAction
            // 
            this.cmbbxAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbxAction.FormattingEnabled = true;
            this.cmbbxAction.Items.AddRange(new object[] {
            "Shutdown",
            "Restart"});
            this.cmbbxAction.Location = new System.Drawing.Point(75, 12);
            this.cmbbxAction.Name = "cmbbxAction";
            this.cmbbxAction.Size = new System.Drawing.Size(97, 21);
            this.cmbbxAction.TabIndex = 26;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(9, 38);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(46, 23);
            this.btnStart.TabIndex = 19;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHours.Location = new System.Drawing.Point(4, 64);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(36, 25);
            this.lblHours.TabIndex = 20;
            this.lblHours.Text = "00";
            // 
            // lblSeperator1
            // 
            this.lblSeperator1.AutoSize = true;
            this.lblSeperator1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeperator1.Location = new System.Drawing.Point(46, 64);
            this.lblSeperator1.Name = "lblSeperator1";
            this.lblSeperator1.Size = new System.Drawing.Size(18, 25);
            this.lblSeperator1.TabIndex = 21;
            this.lblSeperator1.Text = ":";
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMin.Location = new System.Drawing.Point(70, 64);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(36, 25);
            this.lblMin.TabIndex = 22;
            this.lblMin.Text = "00";
            // 
            // lblSeperator2
            // 
            this.lblSeperator2.AutoSize = true;
            this.lblSeperator2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeperator2.Location = new System.Drawing.Point(112, 64);
            this.lblSeperator2.Name = "lblSeperator2";
            this.lblSeperator2.Size = new System.Drawing.Size(18, 25);
            this.lblSeperator2.TabIndex = 23;
            this.lblSeperator2.Text = ":";
            // 
            // lblSec
            // 
            this.lblSec.AutoSize = true;
            this.lblSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSec.Location = new System.Drawing.Point(136, 64);
            this.lblSec.Name = "lblSec";
            this.lblSec.Size = new System.Drawing.Size(36, 25);
            this.lblSec.TabIndex = 24;
            this.lblSec.Text = "00";
            // 
            // btnStop
            // 
            this.btnStop.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnStop.Location = new System.Drawing.Point(61, 38);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(50, 23);
            this.btnStop.TabIndex = 25;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // mtxtTime
            // 
            this.mtxtTime.Location = new System.Drawing.Point(9, 12);
            this.mtxtTime.Mask = "00:00:00";
            this.mtxtTime.Name = "mtxtTime";
            this.mtxtTime.Size = new System.Drawing.Size(60, 20);
            this.mtxtTime.TabIndex = 18;
            // 
            // chkbxTakeScreenshot
            // 
            this.chkbxTakeScreenshot.AutoSize = true;
            this.chkbxTakeScreenshot.Checked = true;
            this.chkbxTakeScreenshot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbxTakeScreenshot.Location = new System.Drawing.Point(9, 92);
            this.chkbxTakeScreenshot.Name = "chkbxTakeScreenshot";
            this.chkbxTakeScreenshot.Size = new System.Drawing.Size(80, 17);
            this.chkbxTakeScreenshot.TabIndex = 27;
            this.chkbxTakeScreenshot.Text = "Screenshot";
            this.chkbxTakeScreenshot.UseVisualStyleBackColor = true;
            // 
            // chkbxWarning
            // 
            this.chkbxWarning.AutoSize = true;
            this.chkbxWarning.Checked = true;
            this.chkbxWarning.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbxWarning.Location = new System.Drawing.Point(95, 92);
            this.chkbxWarning.Name = "chkbxWarning";
            this.chkbxWarning.Size = new System.Drawing.Size(66, 17);
            this.chkbxWarning.TabIndex = 28;
            this.chkbxWarning.Text = "Warning";
            this.chkbxWarning.UseVisualStyleBackColor = true;
            // 
            // chkbx5minScreenshot
            // 
            this.chkbx5minScreenshot.AutoSize = true;
            this.chkbx5minScreenshot.Location = new System.Drawing.Point(9, 115);
            this.chkbx5minScreenshot.Name = "chkbx5minScreenshot";
            this.chkbx5minScreenshot.Size = new System.Drawing.Size(137, 17);
            this.chkbx5minScreenshot.TabIndex = 29;
            this.chkbx5minScreenshot.Text = "Screenshot every 5 min";
            this.chkbx5minScreenshot.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnStop;
            this.ClientSize = new System.Drawing.Size(181, 137);
            this.Controls.Add(this.chkbx5minScreenshot);
            this.Controls.Add(this.chkbxWarning);
            this.Controls.Add(this.chkbxTakeScreenshot);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblSec);
            this.Controls.Add(this.lblSeperator2);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.lblSeperator1);
            this.Controls.Add(this.lblHours);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.mtxtTime);
            this.Controls.Add(this.cmbbxAction);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Shutdown 2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbbxAction;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.Label lblSeperator1;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblSeperator2;
        private System.Windows.Forms.Label lblSec;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.MaskedTextBox mtxtTime;
        private System.Windows.Forms.CheckBox chkbxTakeScreenshot;
        private System.Windows.Forms.CheckBox chkbxWarning;
        private System.Windows.Forms.CheckBox chkbx5minScreenshot;

    }
}

