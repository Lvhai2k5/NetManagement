namespace QuanLyTiemNet
{
    partial class ForgotPassword
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
            this.btnReUse = new System.Windows.Forms.Button();
            this.btnBackLogin = new System.Windows.Forms.Button();
            this.txtsdt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnReUse
            // 
            this.btnReUse.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnReUse.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnReUse.Location = new System.Drawing.Point(340, 304);
            this.btnReUse.Name = "btnReUse";
            this.btnReUse.Size = new System.Drawing.Size(356, 76);
            this.btnReUse.TabIndex = 0;
            this.btnReUse.Text = "Gửi yêu cầu";
            this.btnReUse.UseVisualStyleBackColor = false;
            this.btnReUse.Click += new System.EventHandler(this.btnReUse_Click);
            // 
            // btnBackLogin
            // 
            this.btnBackLogin.BackColor = System.Drawing.Color.MintCream;
            this.btnBackLogin.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnBackLogin.Location = new System.Drawing.Point(756, 430);
            this.btnBackLogin.Name = "btnBackLogin";
            this.btnBackLogin.Size = new System.Drawing.Size(202, 55);
            this.btnBackLogin.TabIndex = 1;
            this.btnBackLogin.Text = "Đăng nhập";
            this.btnBackLogin.UseVisualStyleBackColor = false;
            this.btnBackLogin.Click += new System.EventHandler(this.btnBackLogin_Click);
            // 
            // txtsdt
            // 
            this.txtsdt.Location = new System.Drawing.Point(273, 178);
            this.txtsdt.Multiline = true;
            this.txtsdt.Name = "txtsdt";
            this.txtsdt.Size = new System.Drawing.Size(372, 59);
            this.txtsdt.TabIndex = 2;
            this.txtsdt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtsdt.TextChanged += new System.EventHandler(this.txtsdt_TextChanged);
            this.txtsdt.Enter += new System.EventHandler(this.txtsdt_Enter);
            this.txtsdt.Leave += new System.EventHandler(this.txtsdt_Leave);
            // 
            // ForgotPassword
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::QuanLyTiemNet.Properties.Resources._13;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(970, 497);
            this.Controls.Add(this.btnReUse);
            this.Controls.Add(this.btnBackLogin);
            this.Controls.Add(this.txtsdt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ForgotPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ForgotPassword";
            this.Load += new System.EventHandler(this.ForgotPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReUse;
        private System.Windows.Forms.Button btnBackLogin;
        private System.Windows.Forms.TextBox txtsdt;
    }
}