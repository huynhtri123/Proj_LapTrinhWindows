namespace DoAn_Nhom7
{
    partial class FSoHoKhau
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
            this.ucSoHoKhau1 = new DoAn_Nhom7.UCSoHoKhau();
            this.SuspendLayout();
            // 
            // ucSoHoKhau1
            // 
            this.ucSoHoKhau1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ucSoHoKhau1.Location = new System.Drawing.Point(15, 16);
            this.ucSoHoKhau1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ucSoHoKhau1.Name = "ucSoHoKhau1";
            this.ucSoHoKhau1.Size = new System.Drawing.Size(1176, 709);
            this.ucSoHoKhau1.TabIndex = 0;
            this.ucSoHoKhau1.Load += new System.EventHandler(this.ucSoHoKhau1_Load);
            // 
            // FSoHoKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1236, 725);
            this.Controls.Add(this.ucSoHoKhau1);
            this.Name = "FSoHoKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SỔ HỘ KHẨU";
            this.Load += new System.EventHandler(this.FSoHoKhau_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UCSoHoKhau ucSoHoKhau1;
    }
}