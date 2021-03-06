﻿namespace R22
{
    partial class frmMain
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
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.cmbScripts = new System.Windows.Forms.ComboBox();
            this.btnGetScripts = new System.Windows.Forms.Button();
            this.btnExecute = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(9, 11);
            this.txtIP.Margin = new System.Windows.Forms.Padding(2);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(118, 20);
            this.txtIP.TabIndex = 0;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(198, 10);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(2);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(56, 19);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // nudPort
            // 
            this.nudPort.Location = new System.Drawing.Point(132, 11);
            this.nudPort.Maximum = new decimal(new int[] {
            65565,
            0,
            0,
            0});
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(62, 20);
            this.nudPort.TabIndex = 1;
            this.nudPort.Value = new decimal(new int[] {
            8080,
            0,
            0,
            0});
            // 
            // cmbScripts
            // 
            this.cmbScripts.FormattingEnabled = true;
            this.cmbScripts.Location = new System.Drawing.Point(9, 36);
            this.cmbScripts.Name = "cmbScripts";
            this.cmbScripts.Size = new System.Drawing.Size(161, 21);
            this.cmbScripts.TabIndex = 5;
            // 
            // btnGetScripts
            // 
            this.btnGetScripts.Location = new System.Drawing.Point(177, 36);
            this.btnGetScripts.Name = "btnGetScripts";
            this.btnGetScripts.Size = new System.Drawing.Size(77, 21);
            this.btnGetScripts.TabIndex = 6;
            this.btnGetScripts.Text = "Get Scripts";
            this.btnGetScripts.UseVisualStyleBackColor = true;
            this.btnGetScripts.Click += new System.EventHandler(this.btnGetScripts_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(9, 63);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(245, 23);
            this.btnExecute.TabIndex = 7;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 89);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.btnGetScripts);
            this.Controls.Add(this.cmbScripts);
            this.Controls.Add(this.nudPort);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtIP);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMain";
            this.Text = "R22";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.NumericUpDown nudPort;
        private System.Windows.Forms.ComboBox cmbScripts;
        private System.Windows.Forms.Button btnGetScripts;
        private System.Windows.Forms.Button btnExecute;
    }
}

