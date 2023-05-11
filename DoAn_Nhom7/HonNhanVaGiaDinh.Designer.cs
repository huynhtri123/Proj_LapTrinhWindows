namespace DoAn_Nhom7
{
    partial class HonNhanVaGiaDinh
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
            this.ucHonNhan1 = new DoAn_Nhom7.UCHonNhan();
            this.SuspendLayout();
            // 
            // ucHonNhan1
            // 
            this.ucHonNhan1.Location = new System.Drawing.Point(12, 12);
            this.ucHonNhan1.Name = "ucHonNhan1";
            this.ucHonNhan1.Size = new System.Drawing.Size(893, 552);
            this.ucHonNhan1.TabIndex = 0;
            // 
            // HonNhanVaGiaDinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(895, 556);
            this.Controls.Add(this.ucHonNhan1);
            this.Name = "HonNhanVaGiaDinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HÔN NHÂN VÀ GIA ĐÌNH";
            this.Load += new System.EventHandler(this.HonNhanVaGiaDinh_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UCHonNhan ucHonNhan1;
    }
}