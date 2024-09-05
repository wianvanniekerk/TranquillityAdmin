namespace WindowsFormsApp1.Communication.Email
{
    partial class CommunicationEmail
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
            this.cmbEmailSender = new System.Windows.Forms.ComboBox();
            this.txtEmailSubject = new System.Windows.Forms.TextBox();
            this.rtbEmailBody = new System.Windows.Forms.RichTextBox();
            this.btnEmailSend = new System.Windows.Forms.Button();
            this.lstEmailRecipients = new System.Windows.Forms.ListBox();
            this.lblEmailFrom = new System.Windows.Forms.Label();
            this.lblEmailTo = new System.Windows.Forms.Label();
            this.lblEmailMessage = new System.Windows.Forms.Label();
            this.lblEmailSubject = new System.Windows.Forms.Label();
            this.lblEmailHeader = new System.Windows.Forms.Label();
            this.btnEmailBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbEmailSender
            // 
            this.cmbEmailSender.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmailSender.FormattingEnabled = true;
            this.cmbEmailSender.Location = new System.Drawing.Point(410, 126);
            this.cmbEmailSender.Name = "cmbEmailSender";
            this.cmbEmailSender.Size = new System.Drawing.Size(826, 23);
            this.cmbEmailSender.TabIndex = 0;
            // 
            // txtEmailSubject
            // 
            this.txtEmailSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailSubject.Location = new System.Drawing.Point(410, 314);
            this.txtEmailSubject.Name = "txtEmailSubject";
            this.txtEmailSubject.Size = new System.Drawing.Size(826, 21);
            this.txtEmailSubject.TabIndex = 2;
            // 
            // rtbEmailBody
            // 
            this.rtbEmailBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbEmailBody.Location = new System.Drawing.Point(410, 374);
            this.rtbEmailBody.Name = "rtbEmailBody";
            this.rtbEmailBody.Size = new System.Drawing.Size(826, 289);
            this.rtbEmailBody.TabIndex = 3;
            this.rtbEmailBody.Text = "";
            // 
            // btnEmailSend
            // 
            this.btnEmailSend.Font = new System.Drawing.Font("Segoe UI Semibold", 18F);
            this.btnEmailSend.Location = new System.Drawing.Point(677, 681);
            this.btnEmailSend.Name = "btnEmailSend";
            this.btnEmailSend.Size = new System.Drawing.Size(320, 102);
            this.btnEmailSend.TabIndex = 4;
            this.btnEmailSend.Text = "Send";
            this.btnEmailSend.UseVisualStyleBackColor = true;
            this.btnEmailSend.Click += new System.EventHandler(this.btnEmailSend_Click);
            // 
            // lstEmailRecipients
            // 
            this.lstEmailRecipients.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstEmailRecipients.FormattingEnabled = true;
            this.lstEmailRecipients.ItemHeight = 15;
            this.lstEmailRecipients.Location = new System.Drawing.Point(410, 189);
            this.lstEmailRecipients.Name = "lstEmailRecipients";
            this.lstEmailRecipients.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstEmailRecipients.Size = new System.Drawing.Size(826, 94);
            this.lstEmailRecipients.TabIndex = 5;
            // 
            // lblEmailFrom
            // 
            this.lblEmailFrom.AutoSize = true;
            this.lblEmailFrom.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.lblEmailFrom.Location = new System.Drawing.Point(293, 126);
            this.lblEmailFrom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmailFrom.Name = "lblEmailFrom";
            this.lblEmailFrom.Size = new System.Drawing.Size(48, 21);
            this.lblEmailFrom.TabIndex = 19;
            this.lblEmailFrom.Text = "From";
            // 
            // lblEmailTo
            // 
            this.lblEmailTo.AutoSize = true;
            this.lblEmailTo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.lblEmailTo.Location = new System.Drawing.Point(293, 189);
            this.lblEmailTo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmailTo.Name = "lblEmailTo";
            this.lblEmailTo.Size = new System.Drawing.Size(27, 21);
            this.lblEmailTo.TabIndex = 20;
            this.lblEmailTo.Text = "To";
            // 
            // lblEmailMessage
            // 
            this.lblEmailMessage.AutoSize = true;
            this.lblEmailMessage.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.lblEmailMessage.Location = new System.Drawing.Point(293, 374);
            this.lblEmailMessage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmailMessage.Name = "lblEmailMessage";
            this.lblEmailMessage.Size = new System.Drawing.Size(75, 21);
            this.lblEmailMessage.TabIndex = 21;
            this.lblEmailMessage.Text = "Message";
            // 
            // lblEmailSubject
            // 
            this.lblEmailSubject.AutoSize = true;
            this.lblEmailSubject.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.lblEmailSubject.Location = new System.Drawing.Point(293, 314);
            this.lblEmailSubject.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmailSubject.Name = "lblEmailSubject";
            this.lblEmailSubject.Size = new System.Drawing.Size(65, 21);
            this.lblEmailSubject.TabIndex = 22;
            this.lblEmailSubject.Text = "Subject";
            // 
            // lblEmailHeader
            // 
            this.lblEmailHeader.AutoSize = true;
            this.lblEmailHeader.Font = new System.Drawing.Font("Haettenschweiler", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailHeader.Location = new System.Drawing.Point(509, 19);
            this.lblEmailHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmailHeader.Name = "lblEmailHeader";
            this.lblEmailHeader.Size = new System.Drawing.Size(527, 53);
            this.lblEmailHeader.TabIndex = 23;
            this.lblEmailHeader.Text = "Tranquillity Admin Email Service";
            // 
            // btnEmailBack
            // 
            this.btnEmailBack.Font = new System.Drawing.Font("Segoe UI Semibold", 18F);
            this.btnEmailBack.Location = new System.Drawing.Point(8, 681);
            this.btnEmailBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnEmailBack.Name = "btnEmailBack";
            this.btnEmailBack.Size = new System.Drawing.Size(312, 102);
            this.btnEmailBack.TabIndex = 24;
            this.btnEmailBack.Text = "Back to Dashboard";
            this.btnEmailBack.UseVisualStyleBackColor = true;
            this.btnEmailBack.Click += new System.EventHandler(this.btnEmailBack_Click);
            // 
            // CommunicationEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1531, 795);
            this.Controls.Add(this.btnEmailBack);
            this.Controls.Add(this.lblEmailHeader);
            this.Controls.Add(this.lblEmailSubject);
            this.Controls.Add(this.lblEmailMessage);
            this.Controls.Add(this.lblEmailTo);
            this.Controls.Add(this.lblEmailFrom);
            this.Controls.Add(this.lstEmailRecipients);
            this.Controls.Add(this.btnEmailSend);
            this.Controls.Add(this.rtbEmailBody);
            this.Controls.Add(this.txtEmailSubject);
            this.Controls.Add(this.cmbEmailSender);
            this.Name = "CommunicationEmail";
            this.Text = "CommunicationEmail";
            this.Load += new System.EventHandler(this.CommunicationEmail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbEmailSender;
        private System.Windows.Forms.TextBox txtEmailSubject;
        private System.Windows.Forms.RichTextBox rtbEmailBody;
        private System.Windows.Forms.Button btnEmailSend;
        private System.Windows.Forms.ListBox lstEmailRecipients;
        private System.Windows.Forms.Label lblEmailFrom;
        private System.Windows.Forms.Label lblEmailTo;
        private System.Windows.Forms.Label lblEmailMessage;
        private System.Windows.Forms.Label lblEmailSubject;
        private System.Windows.Forms.Label lblEmailHeader;
        private System.Windows.Forms.Button btnEmailBack;
    }
}