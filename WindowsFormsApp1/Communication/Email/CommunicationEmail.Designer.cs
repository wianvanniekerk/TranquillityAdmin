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
            this.cmbEmailSender.Location = new System.Drawing.Point(547, 155);
            this.cmbEmailSender.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbEmailSender.Name = "cmbEmailSender";
            this.cmbEmailSender.Size = new System.Drawing.Size(1100, 26);
            this.cmbEmailSender.TabIndex = 0;
            // 
            // txtEmailSubject
            // 
            this.txtEmailSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailSubject.Location = new System.Drawing.Point(547, 386);
            this.txtEmailSubject.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEmailSubject.Name = "txtEmailSubject";
            this.txtEmailSubject.Size = new System.Drawing.Size(1100, 24);
            this.txtEmailSubject.TabIndex = 2;
            // 
            // rtbEmailBody
            // 
            this.rtbEmailBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbEmailBody.Location = new System.Drawing.Point(547, 460);
            this.rtbEmailBody.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtbEmailBody.Name = "rtbEmailBody";
            this.rtbEmailBody.Size = new System.Drawing.Size(1100, 355);
            this.rtbEmailBody.TabIndex = 3;
            this.rtbEmailBody.Text = "";
            // 
            // btnEmailSend
            // 
            this.btnEmailSend.Font = new System.Drawing.Font("Segoe UI Semibold", 18F);
            this.btnEmailSend.Location = new System.Drawing.Point(903, 838);
            this.btnEmailSend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEmailSend.Name = "btnEmailSend";
            this.btnEmailSend.Size = new System.Drawing.Size(427, 126);
            this.btnEmailSend.TabIndex = 4;
            this.btnEmailSend.Text = "Send";
            this.btnEmailSend.UseVisualStyleBackColor = true;
            this.btnEmailSend.Click += new System.EventHandler(this.btnEmailSend_Click);
            // 
            // lstEmailRecipients
            // 
            this.lstEmailRecipients.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstEmailRecipients.FormattingEnabled = true;
            this.lstEmailRecipients.ItemHeight = 18;
            this.lstEmailRecipients.Location = new System.Drawing.Point(547, 233);
            this.lstEmailRecipients.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstEmailRecipients.Name = "lstEmailRecipients";
            this.lstEmailRecipients.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstEmailRecipients.Size = new System.Drawing.Size(1100, 112);
            this.lstEmailRecipients.TabIndex = 5;
            // 
            // lblEmailFrom
            // 
            this.lblEmailFrom.AutoSize = true;
            this.lblEmailFrom.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.lblEmailFrom.Location = new System.Drawing.Point(391, 155);
            this.lblEmailFrom.Name = "lblEmailFrom";
            this.lblEmailFrom.Size = new System.Drawing.Size(59, 28);
            this.lblEmailFrom.TabIndex = 19;
            this.lblEmailFrom.Text = "From";
            // 
            // lblEmailTo
            // 
            this.lblEmailTo.AutoSize = true;
            this.lblEmailTo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.lblEmailTo.Location = new System.Drawing.Point(391, 233);
            this.lblEmailTo.Name = "lblEmailTo";
            this.lblEmailTo.Size = new System.Drawing.Size(33, 28);
            this.lblEmailTo.TabIndex = 20;
            this.lblEmailTo.Text = "To";
            // 
            // lblEmailMessage
            // 
            this.lblEmailMessage.AutoSize = true;
            this.lblEmailMessage.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.lblEmailMessage.Location = new System.Drawing.Point(391, 460);
            this.lblEmailMessage.Name = "lblEmailMessage";
            this.lblEmailMessage.Size = new System.Drawing.Size(92, 28);
            this.lblEmailMessage.TabIndex = 21;
            this.lblEmailMessage.Text = "Message";
            // 
            // lblEmailSubject
            // 
            this.lblEmailSubject.AutoSize = true;
            this.lblEmailSubject.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.lblEmailSubject.Location = new System.Drawing.Point(391, 386);
            this.lblEmailSubject.Name = "lblEmailSubject";
            this.lblEmailSubject.Size = new System.Drawing.Size(79, 28);
            this.lblEmailSubject.TabIndex = 22;
            this.lblEmailSubject.Text = "Subject";
            // 
            // lblEmailHeader
            // 
            this.lblEmailHeader.AutoSize = true;
            this.lblEmailHeader.Font = new System.Drawing.Font("Haettenschweiler", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailHeader.Location = new System.Drawing.Point(679, 23);
            this.lblEmailHeader.Name = "lblEmailHeader";
            this.lblEmailHeader.Size = new System.Drawing.Size(660, 67);
            this.lblEmailHeader.TabIndex = 23;
            this.lblEmailHeader.Text = "Tranquillity Admin Email Service";
            // 
            // btnEmailBack
            // 
            this.btnEmailBack.Font = new System.Drawing.Font("Segoe UI Semibold", 18F);
            this.btnEmailBack.Location = new System.Drawing.Point(11, 838);
            this.btnEmailBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEmailBack.Name = "btnEmailBack";
            this.btnEmailBack.Size = new System.Drawing.Size(416, 126);
            this.btnEmailBack.TabIndex = 24;
            this.btnEmailBack.Text = "Back to Dashboard";
            this.btnEmailBack.UseVisualStyleBackColor = true;
            this.btnEmailBack.Click += new System.EventHandler(this.btnEmailBack_Click);
            // 
            // CommunicationEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1924, 978);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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