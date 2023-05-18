namespace DoAn_Nhom7
{
    partial class FTrangChu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTrangChu));
            this.tclChucNang = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.pnTimKiem = new System.Windows.Forms.Panel();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.cmbTimKiem = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnTimKiemTen = new System.Windows.Forms.Button();
            this.rdbChuaKetHon = new System.Windows.Forms.RadioButton();
            this.rdbDaKetHon = new System.Windows.Forms.RadioButton();
            this.lblTinhTrang = new System.Windows.Forms.Label();
            this.rdbTatCa = new System.Windows.Forms.RadioButton();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dGVDanhSach = new System.Windows.Forms.DataGridView();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtCCCD = new System.Windows.Forms.TextBox();
            this.lblCCCD = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.pnDichVu = new System.Windows.Forms.Panel();
            this.pnHienThi = new System.Windows.Forms.Panel();
            this.pnMenu = new System.Windows.Forms.Panel();
            this.btnKhaiTu = new System.Windows.Forms.Button();
            this.btnKhaiSinh = new System.Windows.Forms.Button();
            this.btnHonNhan = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnTamTru = new System.Windows.Forms.Button();
            this.btnSoHoKhau = new System.Windows.Forms.Button();
            this.btnThue = new System.Windows.Forms.Button();
            this.btnCCCD = new System.Windows.Forms.Button();
            this.tclChucNang.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pnTimKiem.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVDanhSach)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.pnDichVu.SuspendLayout();
            this.pnMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tclChucNang
            // 
            this.tclChucNang.Controls.Add(this.tabPage1);
            this.tclChucNang.Controls.Add(this.tabPage2);
            this.tclChucNang.Controls.Add(this.tabPage5);
            this.tclChucNang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tclChucNang.Location = new System.Drawing.Point(1, 1);
            this.tclChucNang.Name = "tclChucNang";
            this.tclChucNang.SelectedIndex = 0;
            this.tclChucNang.Size = new System.Drawing.Size(1510, 704);
            this.tclChucNang.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightBlue;
            this.tabPage1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage1.BackgroundImage")));
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.btnDangNhap);
            this.tabPage1.Controls.Add(this.pnTimKiem);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Font = new System.Drawing.Font("Symbol", 8.25F);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1502, 669);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Trang chủ";
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.Color.Transparent;
            this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDangNhap.Location = new System.Drawing.Point(1138, 21);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(173, 52);
            this.btnDangNhap.TabIndex = 9;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // pnTimKiem
            // 
            this.pnTimKiem.BackColor = System.Drawing.Color.Transparent;
            this.pnTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnTimKiem.Controls.Add(this.lblTimKiem);
            this.pnTimKiem.Controls.Add(this.cmbTimKiem);
            this.pnTimKiem.Location = new System.Drawing.Point(292, 104);
            this.pnTimKiem.Name = "pnTimKiem";
            this.pnTimKiem.Size = new System.Drawing.Size(804, 63);
            this.pnTimKiem.TabIndex = 7;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.BackColor = System.Drawing.Color.White;
            this.lblTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTimKiem.Location = new System.Drawing.Point(36, 20);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(181, 25);
            this.lblTimKiem.TabIndex = 8;
            this.lblTimKiem.Text = "Tìm kiếm dịch vụ:";
            // 
            // cmbTimKiem
            // 
            this.cmbTimKiem.AutoCompleteCustomSource.AddRange(new string[] {
            "Can cuoc cong dan",
            "Thue",
            "So ho khau",
            "Tam tru, tam vang",
            "Thong ke dan so",
            "Hon nhan va gia dinh",
            "Khai sinh",
            "Khai tu"});
            this.cmbTimKiem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTimKiem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.cmbTimKiem.FormattingEnabled = true;
            this.cmbTimKiem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbTimKiem.Items.AddRange(new object[] {
            "CĂN CƯỚC CÔNG DÂN",
            "THUẾ",
            "SỔ HỘ KHẨU",
            "TẠM TRÚ/ TẠM VẮNG",
            "THỐNG KÊ DÂN SỐ",
            "HÔN NHÂN VÀ GIA ĐÌNH",
            "KHAI SINH",
            "KHAI TỬ"});
            this.cmbTimKiem.Location = new System.Drawing.Point(233, 17);
            this.cmbTimKiem.Name = "cmbTimKiem";
            this.cmbTimKiem.Size = new System.Drawing.Size(526, 28);
            this.cmbTimKiem.TabIndex = 7;
            this.cmbTimKiem.SelectedIndexChanged += new System.EventHandler(this.cmbTimKiem_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Azure;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(325, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(740, 51);
            this.label1.TabIndex = 1;
            this.label1.Text = "QUẢN LÝ CÔNG DÂN THÀNH PHỐ";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightBlue;
            this.tabPage2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage2.BackgroundImage")));
            this.tabPage2.Controls.Add(this.btnTimKiemTen);
            this.tabPage2.Controls.Add(this.rdbChuaKetHon);
            this.tabPage2.Controls.Add(this.rdbDaKetHon);
            this.tabPage2.Controls.Add(this.lblTinhTrang);
            this.tabPage2.Controls.Add(this.rdbTatCa);
            this.tabPage2.Controls.Add(this.btnRefresh);
            this.tabPage2.Controls.Add(this.dGVDanhSach);
            this.tabPage2.Controls.Add(this.btnTimKiem);
            this.tabPage2.Controls.Add(this.txtCCCD);
            this.tabPage2.Controls.Add(this.lblCCCD);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1502, 669);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tra cứu hồ sơ";
            // 
            // btnTimKiemTen
            // 
            this.btnTimKiemTen.BackColor = System.Drawing.Color.Beige;
            this.btnTimKiemTen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiemTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTimKiemTen.Location = new System.Drawing.Point(1027, 17);
            this.btnTimKiemTen.Name = "btnTimKiemTen";
            this.btnTimKiemTen.Size = new System.Drawing.Size(222, 42);
            this.btnTimKiemTen.TabIndex = 12;
            this.btnTimKiemTen.Text = "Tìm Theo Tên";
            this.btnTimKiemTen.UseVisualStyleBackColor = false;
            this.btnTimKiemTen.Click += new System.EventHandler(this.btnTimKiemTen_Click);
            // 
            // rdbChuaKetHon
            // 
            this.rdbChuaKetHon.AutoSize = true;
            this.rdbChuaKetHon.BackColor = System.Drawing.Color.Transparent;
            this.rdbChuaKetHon.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rdbChuaKetHon.Location = new System.Drawing.Point(771, 74);
            this.rdbChuaKetHon.Name = "rdbChuaKetHon";
            this.rdbChuaKetHon.Size = new System.Drawing.Size(174, 33);
            this.rdbChuaKetHon.TabIndex = 11;
            this.rdbChuaKetHon.TabStop = true;
            this.rdbChuaKetHon.Text = "Chưa kết hôn";
            this.rdbChuaKetHon.UseVisualStyleBackColor = false;
            // 
            // rdbDaKetHon
            // 
            this.rdbDaKetHon.AutoSize = true;
            this.rdbDaKetHon.BackColor = System.Drawing.Color.Transparent;
            this.rdbDaKetHon.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rdbDaKetHon.Location = new System.Drawing.Point(604, 74);
            this.rdbDaKetHon.Name = "rdbDaKetHon";
            this.rdbDaKetHon.Size = new System.Drawing.Size(148, 33);
            this.rdbDaKetHon.TabIndex = 10;
            this.rdbDaKetHon.TabStop = true;
            this.rdbDaKetHon.Text = "Đã kết hôn";
            this.rdbDaKetHon.UseVisualStyleBackColor = false;
            // 
            // lblTinhTrang
            // 
            this.lblTinhTrang.AutoSize = true;
            this.lblTinhTrang.BackColor = System.Drawing.Color.Transparent;
            this.lblTinhTrang.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTinhTrang.Location = new System.Drawing.Point(301, 76);
            this.lblTinhTrang.Name = "lblTinhTrang";
            this.lblTinhTrang.Size = new System.Drawing.Size(127, 29);
            this.lblTinhTrang.TabIndex = 9;
            this.lblTinhTrang.Text = "Tình trạng:";
            // 
            // rdbTatCa
            // 
            this.rdbTatCa.AutoSize = true;
            this.rdbTatCa.BackColor = System.Drawing.Color.Transparent;
            this.rdbTatCa.Checked = true;
            this.rdbTatCa.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rdbTatCa.Location = new System.Drawing.Point(486, 74);
            this.rdbTatCa.Name = "rdbTatCa";
            this.rdbTatCa.Size = new System.Drawing.Size(100, 33);
            this.rdbTatCa.TabIndex = 8;
            this.rdbTatCa.TabStop = true;
            this.rdbTatCa.Text = "Tất cả";
            this.rdbTatCa.UseVisualStyleBackColor = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Beige;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnRefresh.Location = new System.Drawing.Point(1265, 17);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(124, 42);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dGVDanhSach
            // 
            this.dGVDanhSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dGVDanhSach.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dGVDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVDanhSach.Location = new System.Drawing.Point(63, 128);
            this.dGVDanhSach.Name = "dGVDanhSach";
            this.dGVDanhSach.RowHeadersWidth = 51;
            this.dGVDanhSach.RowTemplate.Height = 24;
            this.dGVDanhSach.Size = new System.Drawing.Size(1250, 496);
            this.dGVDanhSach.TabIndex = 3;
            this.dGVDanhSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVDanhSach_CellClick);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.Beige;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTimKiem.Location = new System.Drawing.Point(799, 17);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(222, 42);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Tìm Theo CMND";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtCCCD
            // 
            this.txtCCCD.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtCCCD.Location = new System.Drawing.Point(448, 21);
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.Size = new System.Drawing.Size(345, 34);
            this.txtCCCD.TabIndex = 1;
            // 
            // lblCCCD
            // 
            this.lblCCCD.AutoSize = true;
            this.lblCCCD.BackColor = System.Drawing.Color.Transparent;
            this.lblCCCD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCCCD.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblCCCD.Location = new System.Drawing.Point(263, 21);
            this.lblCCCD.Name = "lblCCCD";
            this.lblCCCD.Size = new System.Drawing.Size(166, 29);
            this.lblCCCD.TabIndex = 0;
            this.lblCCCD.Text = "CCCD/CMND:";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.pnDichVu);
            this.tabPage5.Controls.Add(this.pnMenu);
            this.tabPage5.Location = new System.Drawing.Point(4, 31);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1502, 669);
            this.tabPage5.TabIndex = 7;
            this.tabPage5.Text = "Dịch vụ";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // pnDichVu
            // 
            this.pnDichVu.BackColor = System.Drawing.Color.LightBlue;
            this.pnDichVu.Controls.Add(this.pnHienThi);
            this.pnDichVu.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnDichVu.Location = new System.Drawing.Point(279, 3);
            this.pnDichVu.Name = "pnDichVu";
            this.pnDichVu.Size = new System.Drawing.Size(1220, 663);
            this.pnDichVu.TabIndex = 1;
            // 
            // pnHienThi
            // 
            this.pnHienThi.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnHienThi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.pnHienThi.Location = new System.Drawing.Point(9, 9);
            this.pnHienThi.Name = "pnHienThi";
            this.pnHienThi.Size = new System.Drawing.Size(1206, 646);
            this.pnHienThi.TabIndex = 0;
            // 
            // pnMenu
            // 
            this.pnMenu.BackColor = System.Drawing.Color.DarkSlateGray;
            this.pnMenu.Controls.Add(this.btnKhaiTu);
            this.pnMenu.Controls.Add(this.btnKhaiSinh);
            this.pnMenu.Controls.Add(this.btnHonNhan);
            this.pnMenu.Controls.Add(this.btnThongKe);
            this.pnMenu.Controls.Add(this.btnTamTru);
            this.pnMenu.Controls.Add(this.btnSoHoKhau);
            this.pnMenu.Controls.Add(this.btnThue);
            this.pnMenu.Controls.Add(this.btnCCCD);
            this.pnMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnMenu.Location = new System.Drawing.Point(3, 3);
            this.pnMenu.Name = "pnMenu";
            this.pnMenu.Size = new System.Drawing.Size(279, 663);
            this.pnMenu.TabIndex = 0;
            // 
            // btnKhaiTu
            // 
            this.btnKhaiTu.BackColor = System.Drawing.Color.Transparent;
            this.btnKhaiTu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhaiTu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnKhaiTu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnKhaiTu.Location = new System.Drawing.Point(25, 591);
            this.btnKhaiTu.Name = "btnKhaiTu";
            this.btnKhaiTu.Size = new System.Drawing.Size(227, 43);
            this.btnKhaiTu.TabIndex = 8;
            this.btnKhaiTu.Text = "KHAI TỬ";
            this.btnKhaiTu.UseVisualStyleBackColor = false;
            this.btnKhaiTu.Click += new System.EventHandler(this.btnKhaiTu_Click);
            // 
            // btnKhaiSinh
            // 
            this.btnKhaiSinh.BackColor = System.Drawing.Color.Transparent;
            this.btnKhaiSinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhaiSinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnKhaiSinh.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnKhaiSinh.Location = new System.Drawing.Point(25, 520);
            this.btnKhaiSinh.Name = "btnKhaiSinh";
            this.btnKhaiSinh.Size = new System.Drawing.Size(227, 43);
            this.btnKhaiSinh.TabIndex = 7;
            this.btnKhaiSinh.Text = "KHAI SINH";
            this.btnKhaiSinh.UseVisualStyleBackColor = false;
            this.btnKhaiSinh.Click += new System.EventHandler(this.btnKhaiSinh_Click);
            // 
            // btnHonNhan
            // 
            this.btnHonNhan.BackColor = System.Drawing.Color.Transparent;
            this.btnHonNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHonNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnHonNhan.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnHonNhan.Location = new System.Drawing.Point(25, 453);
            this.btnHonNhan.Name = "btnHonNhan";
            this.btnHonNhan.Size = new System.Drawing.Size(227, 43);
            this.btnHonNhan.TabIndex = 6;
            this.btnHonNhan.Text = "HÔN NHÂN";
            this.btnHonNhan.UseVisualStyleBackColor = false;
            this.btnHonNhan.Click += new System.EventHandler(this.btnHonNhan_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.Transparent;
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThongKe.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnThongKe.Location = new System.Drawing.Point(25, 385);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(227, 43);
            this.btnThongKe.TabIndex = 5;
            this.btnThongKe.Text = "THỐNG KÊ DÂN SỐ";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnTamTru
            // 
            this.btnTamTru.BackColor = System.Drawing.Color.Transparent;
            this.btnTamTru.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTamTru.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTamTru.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTamTru.Location = new System.Drawing.Point(25, 315);
            this.btnTamTru.Name = "btnTamTru";
            this.btnTamTru.Size = new System.Drawing.Size(227, 43);
            this.btnTamTru.TabIndex = 3;
            this.btnTamTru.Text = "TẠM TRÚ/TẠM VẮNG";
            this.btnTamTru.UseVisualStyleBackColor = false;
            this.btnTamTru.Click += new System.EventHandler(this.btnTamTru_Click);
            // 
            // btnSoHoKhau
            // 
            this.btnSoHoKhau.BackColor = System.Drawing.Color.Transparent;
            this.btnSoHoKhau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSoHoKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSoHoKhau.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSoHoKhau.Location = new System.Drawing.Point(25, 245);
            this.btnSoHoKhau.Name = "btnSoHoKhau";
            this.btnSoHoKhau.Size = new System.Drawing.Size(227, 43);
            this.btnSoHoKhau.TabIndex = 2;
            this.btnSoHoKhau.Text = "SỔ HỘ KHẨU";
            this.btnSoHoKhau.UseVisualStyleBackColor = false;
            this.btnSoHoKhau.Click += new System.EventHandler(this.btnSoHoKhau_Click);
            // 
            // btnThue
            // 
            this.btnThue.BackColor = System.Drawing.Color.Transparent;
            this.btnThue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThue.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnThue.Location = new System.Drawing.Point(25, 173);
            this.btnThue.Name = "btnThue";
            this.btnThue.Size = new System.Drawing.Size(227, 43);
            this.btnThue.TabIndex = 1;
            this.btnThue.Text = "THUẾ";
            this.btnThue.UseVisualStyleBackColor = false;
            this.btnThue.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnCCCD
            // 
            this.btnCCCD.BackColor = System.Drawing.Color.Transparent;
            this.btnCCCD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCCCD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCCCD.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCCCD.Location = new System.Drawing.Point(25, 101);
            this.btnCCCD.Name = "btnCCCD";
            this.btnCCCD.Size = new System.Drawing.Size(227, 43);
            this.btnCCCD.TabIndex = 0;
            this.btnCCCD.Text = "CCCD/CMND";
            this.btnCCCD.UseVisualStyleBackColor = false;
            this.btnCCCD.Click += new System.EventHandler(this.btnCCCD_Click);
            // 
            // FTrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1511, 703);
            this.Controls.Add(this.tclChucNang);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FTrangChu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TRANG CHỦ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tclChucNang.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.pnTimKiem.ResumeLayout(false);
            this.pnTimKiem.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVDanhSach)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.pnDichVu.ResumeLayout(false);
            this.pnMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tclChucNang;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnTimKiem;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.ComboBox cmbTimKiem;
        private System.Windows.Forms.DataGridView dGVDanhSach;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtCCCD;
        private System.Windows.Forms.Label lblCCCD;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.RadioButton rdbChuaKetHon;
        private System.Windows.Forms.RadioButton rdbDaKetHon;
        private System.Windows.Forms.Label lblTinhTrang;
        private System.Windows.Forms.RadioButton rdbTatCa;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Panel pnDichVu;
        private System.Windows.Forms.Panel pnMenu;
        private System.Windows.Forms.Button btnCCCD;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnTamTru;
        private System.Windows.Forms.Button btnSoHoKhau;
        private System.Windows.Forms.Button btnThue;
        private System.Windows.Forms.Button btnHonNhan;
        private System.Windows.Forms.Button btnKhaiTu;
        private System.Windows.Forms.Button btnKhaiSinh;
        private System.Windows.Forms.Panel pnHienThi;
        private System.Windows.Forms.Button btnTimKiemTen;
    }
}

