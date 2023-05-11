namespace DoAn_Nhom7
{
    partial class FKhaiTu
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
            this.ucKhaiTu1 = new DoAn_Nhom7.UCKhaiTu();
            this.SuspendLayout();
            // 
            // ucKhaiTu1
            // 
            this.ucKhaiTu1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ucKhaiTu1.Location = new System.Drawing.Point(40, 15);
            this.ucKhaiTu1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ucKhaiTu1.Name = "ucKhaiTu1";
            this.ucKhaiTu1.Size = new System.Drawing.Size(1173, 655);
            this.ucKhaiTu1.TabIndex = 0;
            this.ucKhaiTu1.Load += new System.EventHandler(this.ucKhaiTu1_Load);
            // 
            // FKhaiTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1280, 691);
            this.Controls.Add(this.ucKhaiTu1);
            this.Name = "FKhaiTu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KHAI TỬ";
            this.Load += new System.EventHandler(this.FKhaiTu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UCKhaiTu ucKhaiTu1;
    }
}