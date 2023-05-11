namespace DoAn_Nhom7
{
    partial class FKhaiSinh
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
            this.ucKhaiSinh1 = new DoAn_Nhom7.UCKhaiSinh();
            this.SuspendLayout();
            // 
            // ucKhaiSinh1
            // 
            this.ucKhaiSinh1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ucKhaiSinh1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ucKhaiSinh1.Location = new System.Drawing.Point(15, 15);
            this.ucKhaiSinh1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ucKhaiSinh1.Name = "ucKhaiSinh1";
            this.ucKhaiSinh1.Size = new System.Drawing.Size(1117, 651);
            this.ucKhaiSinh1.TabIndex = 0;
            this.ucKhaiSinh1.Load += new System.EventHandler(this.ucKhaiSinh1_Load);
            // 
            // FKhaiSinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1177, 675);
            this.Controls.Add(this.ucKhaiSinh1);
            this.Name = "FKhaiSinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KHAI SINH";
            this.Load += new System.EventHandler(this.FKhaiSinh_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UCKhaiSinh ucKhaiSinh1;
    }
}