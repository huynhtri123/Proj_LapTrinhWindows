namespace DoAn_Nhom7
{
    partial class FTamTruTamVang
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
            this.ucTamTruTamVang1 = new DoAn_Nhom7.UCTamTruTamVang();
            this.SuspendLayout();
            // 
            // ucTamTruTamVang1
            // 
            this.ucTamTruTamVang1.AutoSize = true;
            this.ucTamTruTamVang1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ucTamTruTamVang1.Location = new System.Drawing.Point(13, 13);
            this.ucTamTruTamVang1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ucTamTruTamVang1.Name = "ucTamTruTamVang1";
            this.ucTamTruTamVang1.Size = new System.Drawing.Size(1049, 694);
            this.ucTamTruTamVang1.TabIndex = 0;
            // 
            // FTamTruTamVang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1171, 699);
            this.Controls.Add(this.ucTamTruTamVang1);
            this.Name = "FTamTruTamVang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TẠM TRÚ TẠM VẮNG";
            this.Load += new System.EventHandler(this.FTamTruTamVang_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UCTamTruTamVang ucTamTruTamVang1;
    }
}