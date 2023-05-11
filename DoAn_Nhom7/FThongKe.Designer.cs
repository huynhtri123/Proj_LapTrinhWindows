namespace DoAn_Nhom7
{
    partial class FThongKe
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
            this.ucThongKeDanSo1 = new DoAn_Nhom7.UCThongKeDanSo();
            this.SuspendLayout();
            // 
            // ucThongKeDanSo1
            // 
            this.ucThongKeDanSo1.Location = new System.Drawing.Point(12, 1);
            this.ucThongKeDanSo1.Name = "ucThongKeDanSo1";
            this.ucThongKeDanSo1.Size = new System.Drawing.Size(905, 532);
            this.ucThongKeDanSo1.TabIndex = 0;
            // 
            // FThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(892, 514);
            this.Controls.Add(this.ucThongKeDanSo1);
            this.Name = "FThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THỐNG KÊ ";
            this.Load += new System.EventHandler(this.FThongKe_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UCThongKeDanSo ucThongKeDanSo1;
    }
}