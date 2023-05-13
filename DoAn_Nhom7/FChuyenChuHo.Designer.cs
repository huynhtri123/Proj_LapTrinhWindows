namespace DoAn_Nhom7
{
    partial class FChuyenChuHo
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
            this.lblDoanVan = new System.Windows.Forms.Label();
            this.cmbDanhSach = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblDanhSach = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDoanVan
            // 
            this.lblDoanVan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoanVan.Location = new System.Drawing.Point(11, 18);
            this.lblDoanVan.Name = "lblDoanVan";
            this.lblDoanVan.Size = new System.Drawing.Size(493, 78);
            this.lblDoanVan.TabIndex = 0;
            this.lblDoanVan.Text = "Vì người đăng ký khai tử là chủ hộ vậy nên cần phải chọn chủ hộ mới trước khi kha" +
    "i tử để tránh bị xóa hộ khẩu, nếu ấn cancel sẽ bị xóa hộ khẩu. ";
            this.lblDoanVan.Click += new System.EventHandler(this.lblDoanVan_Click);
            // 
            // cmbDanhSach
            // 
            this.cmbDanhSach.FormattingEnabled = true;
            this.cmbDanhSach.Location = new System.Drawing.Point(14, 130);
            this.cmbDanhSach.Name = "cmbDanhSach";
            this.cmbDanhSach.Size = new System.Drawing.Size(460, 23);
            this.cmbDanhSach.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(385, 179);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(89, 22);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblDanhSach
            // 
            this.lblDanhSach.AutoSize = true;
            this.lblDanhSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDanhSach.Location = new System.Drawing.Point(11, 95);
            this.lblDanhSach.Name = "lblDanhSach";
            this.lblDanhSach.Size = new System.Drawing.Size(192, 24);
            this.lblDanhSach.TabIndex = 3;
            this.lblDanhSach.Text = "Danh sách thành viên";
            // 
            // FChuyenChuHo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 233);
            this.Controls.Add(this.lblDanhSach);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cmbDanhSach);
            this.Controls.Add(this.lblDoanVan);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FChuyenChuHo";
            this.Text = "FChuyenChuHo";
            this.Load += new System.EventHandler(this.FChuyenChuHo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDoanVan;
        private System.Windows.Forms.ComboBox cmbDanhSach;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblDanhSach;
    }
}