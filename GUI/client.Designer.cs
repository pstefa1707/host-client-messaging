namespace messaging_app
{
    partial class client
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
            this.textChat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sendBtn = new System.Windows.Forms.Button();
            this.sendText = new System.Windows.Forms.TextBox();
            this.updated = new System.Windows.Forms.Label();
            this.updater = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // textChat
            // 
            this.textChat.Location = new System.Drawing.Point(12, 30);
            this.textChat.Multiline = true;
            this.textChat.Name = "textChat";
            this.textChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textChat.Size = new System.Drawing.Size(776, 354);
            this.textChat.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chat:";
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(653, 390);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(135, 48);
            this.sendBtn.TabIndex = 2;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // sendText
            // 
            this.sendText.Location = new System.Drawing.Point(12, 390);
            this.sendText.Multiline = true;
            this.sendText.Name = "sendText";
            this.sendText.Size = new System.Drawing.Size(638, 48);
            this.sendText.TabIndex = 3;
            // 
            // updated
            // 
            this.updated.AutoSize = true;
            this.updated.BackColor = System.Drawing.Color.White;
            this.updated.Location = new System.Drawing.Point(628, 32);
            this.updated.Name = "updated";
            this.updated.Size = new System.Drawing.Size(74, 13);
            this.updated.TabIndex = 4;
            this.updated.Text = "Last Updated:";
            // 
            // updater
            // 
            this.updater.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Updater_DoWork);
            // 
            // client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.updated);
            this.Controls.Add(this.sendText);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textChat);
            this.Name = "client";
            this.Text = "client";
            this.Load += new System.EventHandler(this.Client_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textChat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.TextBox sendText;
        private System.Windows.Forms.Label updated;
        private System.ComponentModel.BackgroundWorker updater;
    }
}