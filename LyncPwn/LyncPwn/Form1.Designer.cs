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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtResponse1 = new System.Windows.Forms.TextBox();
            this.txtResponse2 = new System.Windows.Forms.TextBox();
            this.lblSatus = new System.Windows.Forms.Label();
            this.cbxSendResponse = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Response 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Response 2:";
            // 
            // txtResponse1
            // 
            this.txtResponse1.Location = new System.Drawing.Point(130, 46);
            this.txtResponse1.Name = "txtResponse1";
            this.txtResponse1.Size = new System.Drawing.Size(304, 20);
            this.txtResponse1.TabIndex = 2;
            this.txtResponse1.Text = "hi";
            // 
            // txtResponse2
            // 
            this.txtResponse2.Location = new System.Drawing.Point(130, 73);
            this.txtResponse2.Name = "txtResponse2";
            this.txtResponse2.Size = new System.Drawing.Size(304, 20);
            this.txtResponse2.TabIndex = 3;
            this.txtResponse2.Text = "one moment... I need to check";
            // 
            // lblSatus
            // 
            this.lblSatus.AutoSize = true;
            this.lblSatus.Location = new System.Drawing.Point(42, 100);
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
            this.cbxSendResponse.Location = new System.Drawing.Point(133, 13);
            this.cbxSendResponse.Name = "cbxSendResponse";
            this.cbxSendResponse.Size = new System.Drawing.Size(102, 17);
            this.cbxSendResponse.TabIndex = 6;
            this.cbxSendResponse.Text = "Send Response";
            this.cbxSendResponse.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 144);
            this.Controls.Add(this.cbxSendResponse);
            this.Controls.Add(this.lblSatus);
            this.Controls.Add(this.txtResponse2);
            this.Controls.Add(this.txtResponse1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
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
    }
}

