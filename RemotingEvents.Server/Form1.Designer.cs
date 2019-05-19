namespace RemotingEvents.Server
{
    partial class frm_Main
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
            this.bttn_StartServer = new System.Windows.Forms.Button();
            this.bttn_StopServer = new System.Windows.Forms.Button();
            this.tbx_Messages = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bttn_StartServer
            // 
            this.bttn_StartServer.Location = new System.Drawing.Point(240, 200);
            this.bttn_StartServer.Name = "bttn_StartServer";
            this.bttn_StartServer.Size = new System.Drawing.Size(94, 24);
            this.bttn_StartServer.TabIndex = 0;
            this.bttn_StartServer.Text = "Start Server";
            this.bttn_StartServer.UseVisualStyleBackColor = true;
            this.bttn_StartServer.Click += new System.EventHandler(this.bttn_StartServer_Click);
            // 
            // bttn_StopServer
            // 
            this.bttn_StopServer.Location = new System.Drawing.Point(340, 200);
            this.bttn_StopServer.Name = "bttn_StopServer";
            this.bttn_StopServer.Size = new System.Drawing.Size(94, 24);
            this.bttn_StopServer.TabIndex = 1;
            this.bttn_StopServer.Text = "Stop Server";
            this.bttn_StopServer.UseVisualStyleBackColor = true;
            this.bttn_StopServer.Click += new System.EventHandler(this.bttn_StopServer_Click);
            // 
            // tbx_Messages
            // 
            this.tbx_Messages.Location = new System.Drawing.Point(8, 12);
            this.tbx_Messages.Multiline = true;
            this.tbx_Messages.Name = "tbx_Messages";
            this.tbx_Messages.ReadOnly = true;
            this.tbx_Messages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_Messages.Size = new System.Drawing.Size(426, 165);
            this.tbx_Messages.TabIndex = 2;
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 232);
            this.Controls.Add(this.tbx_Messages);
            this.Controls.Add(this.bttn_StopServer);
            this.Controls.Add(this.bttn_StartServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Main";
            this.Text = "Remoting Events Server";
            this.Load += new System.EventHandler(this.frm_Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bttn_StartServer;
        private System.Windows.Forms.Button bttn_StopServer;
        private System.Windows.Forms.TextBox tbx_Messages;
    }
}

