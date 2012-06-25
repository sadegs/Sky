namespace LyncPwn
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtResponse1 = new System.Windows.Forms.TextBox();
            this.txtResponse2 = new System.Windows.Forms.TextBox();
            this.lblSatus = new System.Windows.Forms.Label();
            this.cbxSendResponse = new System.Windows.Forms.CheckBox();
            this.txtHrStart = new System.Windows.Forms.TextBox();
            this.cbxAutoReply = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMinStart = new System.Windows.Forms.TextBox();
            this.txtHrFinish = new System.Windows.Forms.TextBox();
            this.txtMinFinish = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMouseMin = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Response 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Response 2:";
            // 
            // txtResponse1
            // 
            this.txtResponse1.Location = new System.Drawing.Point(134, 197);
            this.txtResponse1.Name = "txtResponse1";
            this.txtResponse1.Size = new System.Drawing.Size(304, 20);
            this.txtResponse1.TabIndex = 2;
            this.txtResponse1.Text = "hi";
            // 
            // txtResponse2
            // 
            this.txtResponse2.Location = new System.Drawing.Point(134, 224);
            this.txtResponse2.Name = "txtResponse2";
            this.txtResponse2.Size = new System.Drawing.Size(304, 20);
            this.txtResponse2.TabIndex = 3;
            this.txtResponse2.Text = "one moment... I need to check";
            // 
            // lblSatus
            // 
            this.lblSatus.AutoSize = true;
            this.lblSatus.Location = new System.Drawing.Point(46, 251);
            this.lblSatus.Name = "lblSatus";
            this.lblSatus.Size = new System.Drawing.Size(47, 13);
            this.lblSatus.TabIndex = 4;
            this.lblSatus.Text = "--status--";
            // 
            // cbxSendResponse
            // 
            this.cbxSendResponse.AutoSize = true;
            this.cbxSendResponse.Checked = true;
            this.cbxSendResponse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxSendResponse.Location = new System.Drawing.Point(47, 174);
            this.cbxSendResponse.Name = "cbxSendResponse";
            this.cbxSendResponse.Size = new System.Drawing.Size(102, 17);
            this.cbxSendResponse.TabIndex = 6;
            this.cbxSendResponse.Text = "Send Response";
            this.cbxSendResponse.UseVisualStyleBackColor = true;
            // 
            // txtHrStart
            // 
            this.txtHrStart.Location = new System.Drawing.Point(187, 53);
            this.txtHrStart.Name = "txtHrStart";
            this.txtHrStart.Size = new System.Drawing.Size(23, 20);
            this.txtHrStart.TabIndex = 7;
            this.txtHrStart.Text = "8";
            // 
            // cbxAutoReply
            // 
            this.cbxAutoReply.AutoSize = true;
            this.cbxAutoReply.Checked = true;
            this.cbxAutoReply.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxAutoReply.Location = new System.Drawing.Point(48, 56);
            this.cbxAutoReply.Name = "cbxAutoReply";
            this.cbxAutoReply.Size = new System.Drawing.Size(133, 17);
            this.cbxAutoReply.TabIndex = 8;
            this.cbxAutoReply.Text = "AutoReply Only During";
            this.cbxAutoReply.UseVisualStyleBackColor = true;
            this.cbxAutoReply.CheckedChanged += new System.EventHandler(this.cbxAutoReply_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = ":";
            // 
            // txtMinStart
            // 
            this.txtMinStart.Location = new System.Drawing.Point(226, 54);
            this.txtMinStart.Name = "txtMinStart";
            this.txtMinStart.Size = new System.Drawing.Size(32, 20);
            this.txtMinStart.TabIndex = 10;
            this.txtMinStart.Text = "40";
            // 
            // txtHrFinish
            // 
            this.txtHrFinish.Location = new System.Drawing.Point(304, 53);
            this.txtHrFinish.Name = "txtHrFinish";
            this.txtHrFinish.Size = new System.Drawing.Size(19, 20);
            this.txtHrFinish.TabIndex = 11;
            this.txtHrFinish.Text = "18";
            // 
            // txtMinFinish
            // 
            this.txtMinFinish.Location = new System.Drawing.Point(339, 52);
            this.txtMinFinish.Name = "txtMinFinish";
            this.txtMinFinish.Size = new System.Drawing.Size(40, 20);
            this.txtMinFinish.TabIndex = 12;
            this.txtMinFinish.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(323, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = ":";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(277, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "to";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Mouse Move Every :";
            // 
            // txtMouseMin
            // 
            this.txtMouseMin.Location = new System.Drawing.Point(155, 115);
            this.txtMouseMin.Name = "txtMouseMin";
            this.txtMouseMin.Size = new System.Drawing.Size(23, 20);
            this.txtMouseMin.TabIndex = 16;
            this.txtMouseMin.Text = "10";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(184, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "minutes";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "lyncPwn";
            this.notifyIcon1.BalloonTipTitle = "lyncPwn";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "lync";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 315);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMouseMin);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMinFinish);
            this.Controls.Add(this.txtHrFinish);
            this.Controls.Add(this.txtMinStart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxAutoReply);
            this.Controls.Add(this.txtHrStart);
            this.Controls.Add(this.cbxSendResponse);
            this.Controls.Add(this.lblSatus);
            this.Controls.Add(this.txtResponse2);
            this.Controls.Add(this.txtResponse1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtResponse1;
        private System.Windows.Forms.TextBox txtResponse2;
        private System.Windows.Forms.Label lblSatus;
        private System.Windows.Forms.CheckBox cbxSendResponse;
        private System.Windows.Forms.TextBox txtHrStart;
        private System.Windows.Forms.CheckBox cbxAutoReply;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMinStart;
        private System.Windows.Forms.TextBox txtHrFinish;
        private System.Windows.Forms.TextBox txtMinFinish;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMouseMin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

