namespace RemotingEvents.Client
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
            this.bttn_Disconnect = new System.Windows.Forms.Button();
            this.bttn_Connect = new System.Windows.Forms.Button();
            this.tbx_Input = new System.Windows.Forms.TextBox();
            this.bttn_Send = new System.Windows.Forms.Button();
            this.tbx_Messages = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bttn_Disconnect
            // 
            this.bttn_Disconnect.Location = new System.Drawing.Point(280, 12);
            this.bttn_Disconnect.Name = "bttn_Disconnect";
            this.bttn_Disconnect.Size = new System.Drawing.Size(182, 32);
            this.bttn_Disconnect.TabIndex = 3;
            this.bttn_Disconnect.Text = "Disconnect Server";
            this.bttn_Disconnect.UseVisualStyleBackColor = true;
            this.bttn_Disconnect.Click += new System.EventHandler(this.bttn_Disconnect_Click);
            // 
            // bttn_Connect
            // 
            this.bttn_Connect.Location = new System.Drawing.Point(12, 12);
            this.bttn_Connect.Name = "bttn_Connect";
            this.bttn_Connect.Size = new System.Drawing.Size(182, 32);
            this.bttn_Connect.TabIndex = 2;
            this.bttn_Connect.Text = "Connect To Server";
            this.bttn_Connect.UseVisualStyleBackColor = true;
            this.bttn_Connect.Click += new System.EventHandler(this.bttn_Connect_Click);
            // 
            // tbx_Input
            // 
            this.tbx_Input.Location = new System.Drawing.Point(12, 62);
            this.tbx_Input.Name = "tbx_Input";
            this.tbx_Input.Size = new System.Drawing.Size(328, 20);
            this.tbx_Input.TabIndex = 4;
            // 
            // bttn_Send
            // 
            this.bttn_Send.Location = new System.Drawing.Point(351, 59);
            this.bttn_Send.Name = "bttn_Send";
            this.bttn_Send.Size = new System.Drawing.Size(111, 25);
            this.bttn_Send.TabIndex = 5;
            this.bttn_Send.Text = "Send";
            this.bttn_Send.UseVisualStyleBackColor = true;
            this.bttn_Send.Click += new System.EventHandler(this.bttn_Send_Click);
            // 
            // tbx_Messages
            // 
            this.tbx_Messages.Location = new System.Drawing.Point(12, 104);
            this.tbx_Messages.Multiline = true;
            this.tbx_Messages.Name = "tbx_Messages";
            this.tbx_Messages.ReadOnly = true;
            this.tbx_Messages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_Messages.Size = new System.Drawing.Size(450, 195);
            this.tbx_Messages.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(351, 315);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 25);
            this.button1.TabIndex = 7;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 352);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbx_Messages);
            this.Controls.Add(this.bttn_Send);
            this.Controls.Add(this.tbx_Input);
            this.Controls.Add(this.bttn_Disconnect);
            this.Controls.Add(this.bttn_Connect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Remoting Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bttn_Disconnect;
        private System.Windows.Forms.Button bttn_Connect;
        private System.Windows.Forms.TextBox tbx_Input;
        private System.Windows.Forms.Button bttn_Send;
        private System.Windows.Forms.TextBox tbx_Messages;
        private System.Windows.Forms.Button button1;
    }
}

