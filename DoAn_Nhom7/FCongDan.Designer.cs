namespace DoAn_Nhom7
{
    partial class FCongDan
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
            this.ucCanCuoc1 = new DoAn_Nhom7.UCCanCuoc();
            this.SuspendLayout();
            // 
            // ucCanCuoc1
            // 
            this.ucCanCuoc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ucCanCuoc1.Location = new System.Drawing.Point(7, 13);
            this.ucCanCuoc1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ucCanCuoc1.Name = "ucCanCuoc1";
            this.ucCanCuoc1.Size = new System.Drawing.Size(1176, 650);
            this.ucCanCuoc1.TabIndex = 0;
            this.ucCanCuoc1.Load += new System.EventHandler(this.ucCanCuoc1_Load);
            // 
            // FCongDan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1196, 676);
            this.Controls.Add(this.ucCanCuoc1);
            this.Name = "FCongDan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CÔNG DÂN";
            this.Load += new System.EventHandler(this.FCongDan_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtCCCD;
        private UCCanCuoc ucCanCuoc1;
    }
}