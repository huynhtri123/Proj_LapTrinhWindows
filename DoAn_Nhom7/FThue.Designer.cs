namespace DoAn_Nhom7
{
    partial class FThue
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
            this.ucThue1 = new DoAn_Nhom7.UCThue();
            this.SuspendLayout();
            // 
            // ucThue1
            // 
            this.ucThue1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ucThue1.Location = new System.Drawing.Point(15, 15);
            this.ucThue1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ucThue1.Name = "ucThue1";
            this.ucThue1.Size = new System.Drawing.Size(1381, 765);
            this.ucThue1.TabIndex = 0;
            // 
            // FThue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1215, 738);
            this.Controls.Add(this.ucThue1);
            this.Name = "FThue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THUẾ";
            this.Load += new System.EventHandler(this.FThue_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UCThue ucThue1;
    }
}