namespace DoAn_Nhom7_Entity
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
            this.ucCanCuoc1 = new DoAn_Nhom7_Entity.UCCanCuoc();
            this.SuspendLayout();
            // 
            // ucCanCuoc1
            // 
            this.ucCanCuoc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.ucCanCuoc1.Location = new System.Drawing.Point(13, 13);
            this.ucCanCuoc1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ucCanCuoc1.Name = "ucCanCuoc1";
            this.ucCanCuoc1.Size = new System.Drawing.Size(1168, 648);
            this.ucCanCuoc1.TabIndex = 0;
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
            this.ResumeLayout(false);

        }

        #endregion

        private UCCanCuoc ucCanCuoc1;
    }
}