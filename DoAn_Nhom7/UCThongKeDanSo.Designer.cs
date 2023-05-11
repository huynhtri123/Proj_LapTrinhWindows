namespace DoAn_Nhom7
{
    partial class UCThongKeDanSo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCThongKeDanSo));
            this.chartTyLeNamNu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblchxh = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartTyLeNamNu)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // chartTyLeNamNu
            // 
            this.chartTyLeNamNu.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea2.Name = "ChartArea1";
            this.chartTyLeNamNu.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartTyLeNamNu.Legends.Add(legend2);
            this.chartTyLeNamNu.Location = new System.Drawing.Point(393, 41);
            this.chartTyLeNamNu.Name = "chartTyLeNamNu";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Tỷ Lệ Nam Nữ";
            this.chartTyLeNamNu.Series.Add(series2);
            this.chartTyLeNamNu.Size = new System.Drawing.Size(393, 364);
            this.chartTyLeNamNu.TabIndex = 0;
            this.chartTyLeNamNu.Text = "Tỷ lệ nam nữ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Thistle;
            this.panel1.Controls.Add(this.lblchxh);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.chartTyLeNamNu);
            this.panel1.Location = new System.Drawing.Point(22, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(814, 444);
            this.panel1.TabIndex = 2;
            // 
            // lblchxh
            // 
            this.lblchxh.AutoSize = true;
            this.lblchxh.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblchxh.Location = new System.Drawing.Point(244, 9);
            this.lblchxh.Name = "lblchxh";
            this.lblchxh.Size = new System.Drawing.Size(354, 29);
            this.lblchxh.TabIndex = 2;
            this.lblchxh.Text = "THỐNG KÊ TỶ LỆ GIỚI TÍNH";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(11, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(376, 364);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // UCThongKeDanSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "UCThongKeDanSo";
            this.Size = new System.Drawing.Size(992, 573);
            this.Load += new System.EventHandler(this.UCThongKeDanSo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartTyLeNamNu)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartTyLeNamNu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblchxh;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
