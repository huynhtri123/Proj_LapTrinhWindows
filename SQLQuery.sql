use project_LTWD
--CONG DAN--
CREATE TABLE CongDan (
 hoTen nvarchar(100),
 ngayThangNamSinh nvarchar(255),
 gioiTinh nvarchar(100),
 cmnd varchar(100) PRIMARY KEY,
 danToc nvarchar(255),
 tinhTrangHonNhan nvarchar(100),
 noiDangKiKhaiSinh nvarchar(100),
 queQuan nvarchar(255),
 noiThuongTru nvarchar(100),
 trinhDoHocVan nvarchar(255),
 ngheNghiep nvarchar(100),
 luong nvarchar(20),
 soLanKetHon nvarchar (20),
 tamTru nvarchar (100),
 noiCapCMND nvarchar (100),
 ngayCap nvarchar (100),
 quocTich nvarchar (100)
);
INSERT INTO CongDan (hoTen, ngayThangNamSinh, gioiTinh,cmnd,danToc,tinhTrangHonNhan,noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,soLanKetHon,tamTru,noiCapCMND,NgayCap,quocTich)
VALUES (N'Trịnh Văn Hải', '01/01/1981', N'Nam','1','Kinh',N'Đã kết hôn với người có cmnd là 2',N'Nghệ An',N'Nghệ An',N'Nghệ An',N'Đại Học',N'Làm mộc', '1000000','1',N'Hà Nội 01/01/2019',N'Nghệ An','02/02/2021',N'Việt Nam');
INSERT INTO CongDan (hoTen, ngayThangNamSinh, gioiTinh,cmnd,danToc,tinhTrangHonNhan,noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,soLanKetHon,tamTru,noiCapCMND,NgayCap,quocTich)
VALUES (N'Đặng Thị Hoa', '02/02/1980', N'Nữ','2','Kinh',N'Đã kết hôn với người có cmnd là 1',N'Đà Nẵng',N'Đà Nẵng',N'Đà Nẵng',N'Đại Học',N'Làm nông', '2200000','2',N'Hà Nội 02/02/2020',N'Đà Nẵng','03/03/2021',N'Việt Nam');
INSERT INTO CongDan (hoTen, ngayThangNamSinh, gioiTinh,cmnd,danToc,tinhTrangHonNhan,noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,soLanKetHon,tamTru,noiCapCMND,NgayCap,quocTich)
VALUES (N'Trịnh Văn Đạt', '03/06/2003', N'Nam','3',N'Ba Na',N'Độc Thân',N'Nghệ An',N'Nghệ An',N'Nghệ An',N'Đại Học',N'Sinh viên', '30000000','3',N'Nhà trọ 03/03/2021',N'Nghệ An','04/04/2021',N'Việt Nam');
INSERT INTO CongDan (hoTen, ngayThangNamSinh, gioiTinh,cmnd,danToc,tinhTrangHonNhan,noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,soLanKetHon,tamTru,noiCapCMND,NgayCap,quocTich)
VALUES (N'Nguyễn Thị Hòa', '04/03/1988', N'Nữ','5',N'Mường',N'Đã kết hôn với người có cmnd là 4',N'Vũng Tàu',N'Vũng Tàu',N'Vũng Tàu',N'Trung Học Phổ Thông',N'Học sinh', '30000000','3',N'Quãng Ngãi 04/06/2018',N'Vũng Tàu','04/04/2021',N'Việt Nam');
INSERT INTO CongDan (hoTen, ngayThangNamSinh, gioiTinh,cmnd,danToc,tinhTrangHonNhan,noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,soLanKetHon,tamTru,noiCapCMND,NgayCap,quocTich)
VALUES (N'Hồ Văn Cường', '07/04/1984', N'Nam','4',N'Mường',N'Đã kết hôn với người có cmnd là 5',N'Vũng Tàu',N'Vũng Tàu',N'Vũng Tàu',N'Đại Học',N'Thợ may', '30000000','3',N'Quãng Ngãi 05/02/2023',N'Vũng Tàu','04/04/2021',N'Việt Nam');
INSERT INTO CongDan (hoTen, ngayThangNamSinh, gioiTinh,cmnd,danToc,tinhTrangHonNhan,noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,soLanKetHon,tamTru,noiCapCMND,NgayCap,quocTich)
VALUES (N'Trịnh Thị Liễu', '08/09/2000', N'Nữ','6','Kinh',N'Độc Thân',N'Nghệ An',N'Nghệ An',N'Nghệ An',N'Trung Học Phổ Thông',N'Bán hàng', '40000000','3',N'Kí túc xá 09/02/2021',N'Nghệ An','14/05/2019',N'Việt Nam');
INSERT INTO CongDan (hoTen, ngayThangNamSinh, gioiTinh,cmnd,danToc,tinhTrangHonNhan,noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,soLanKetHon,tamTru,noiCapCMND,NgayCap,quocTich)
VALUES (N'Hồ Thị Mến', '03/05/2004', N'Nữ','7','Kinh',N'Độc Thân',N'Vũng Tàu',N'Vũng Tàu',N'Vũng Tàu',N'Đại Học',N'Sinh viên', '40000000','3',N'Kí túc xá 09/02/2021',N'Hồ Chí Minh','04/04/2022',N'Việt Nam');
INSERT INTO CongDan (hoTen, ngayThangNamSinh, gioiTinh,cmnd,danToc,tinhTrangHonNhan,noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,soLanKetHon,tamTru,noiCapCMND,NgayCap,quocTich)
VALUES (N'Hà Thủ Môn', '06/06/1992', N'Nữ','9','Kinh',N'Đã kết hôn với người có cmnd là 8',N'Đồng Tháp',N'Đồng Tháp',N'Đồng Tháp',N'Trung Học Cơ Sở',N'Sửa xe', '47000000','3',N'Biên Hòa 03/03/2021',N'Đồng Tháp','04/04/2021',N'Việt Nam');
INSERT INTO CongDan (hoTen, ngayThangNamSinh, gioiTinh,cmnd,danToc,tinhTrangHonNhan,noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,soLanKetHon,tamTru,noiCapCMND,NgayCap,quocTich)
VALUES (N'Trịnh Thăng Bình', '01/03/1994', N'Nam','8','Kinh',N'Đã kết hôn với người có cmnd là 9',N'Đồng Nai',N'Đồng Nai',N'Đồng Nai',N'Không Học',N'Làm nông', '40000000','3',N'Biên Hòa 07/02/2023',N'Đồng Nai','04/04/2021',N'Việt Nam');
INSERT INTO CongDan (hoTen, ngayThangNamSinh, gioiTinh,cmnd,danToc,tinhTrangHonNhan,noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,soLanKetHon,tamTru,noiCapCMND,NgayCap,quocTich)
VALUES (N'Đào Tấn Lộc', '02/04/2004', N'Nữ','10','Kinh',N'Độc Thân',N'Quảng Bình',N'Quảng Bình',N'Quảng Bình',N'Đại Học',N'Sinh viên', '40000000','3',N'Kí túc xá 07/06/2020',N'Quảng Bình','14/04/2023',N'Việt Nam');
INSERT INTO CongDan (hoTen, ngayThangNamSinh, gioiTinh,cmnd,danToc,tinhTrangHonNhan,noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,soLanKetHon,tamTru,noiCapCMND,NgayCap,quocTich)
VALUES (N'Hồ Gia Bảo', '03/08/1992', N'Nữ','11','Kinh',N'Độc Thân',N'Quảng Trị',N'Quảng Trị',N'Quảng Trị',N'Trung Học Cơ Sở',N'Sửa xe', '47000000','3',N'Biên Hòa 08/02/2022',N'Quảng Trị','24/05/2021',N'Việt Nam');
INSERT INTO CongDan (hoTen, ngayThangNamSinh, gioiTinh,cmnd,danToc,tinhTrangHonNhan,noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,soLanKetHon,tamTru,noiCapCMND,NgayCap,quocTich)
VALUES (N'Đinh Mạnh Ninh', '09/03/1994', N'Nam','12','Kinh',N'Độc Thân',N'Đồng Nai',N'Đồng Nai',N'Đồng Nai',N'Đại Học',N'Làm nông', '40000000','3',N'Biên Hòa 09/03/2021',N'Đồng Nai','7/04/2021',N'Việt Nam');

select * from CongDan

--QUAN HE--

GO
CREATE TABLE QuanHe (
    CMND1 varchar(100),
    CMND2 varchar(100),
    quanHeVoiCMND1 NVARCHAR(50),
	quanHeVoiCMND2 NVARCHAR(50),
    PRIMARY KEY (CMND1, CMND2),
    FOREIGN KEY (CMND1) REFERENCES CongDan(CMND),
    FOREIGN KEY (CMND2) REFERENCES CongDan(CMND)
);

INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('1' , '2' , N'Vợ',N'Chồng');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES  ('1' , '3' , 'Con Trai',N'Bố');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES  ('1' , '6' , N'Con Gái',N'Bố');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('2' , '1' , N'Chồng',N'Vợ');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('2' , '3' , 'Con Trai',N'Mẹ');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('2' , '6' , 'Con Gái',N'Mẹ');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('3' , '1' , N'Bố','Con Trai');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('3' , '2' , N'Mẹ','Con Trai');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('3' , '6' , 'Em Gái','Anh Trai');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('6' , '1' , N'Bố',N'Con Gái');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('6' , '2' , N'Mẹ',N'Con Gái');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('6' , '3' , 'Anh Trai','Em Gái');

INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('4' , '5' , N'Vợ',N'Chồng');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('4' , '7' , N'Con Gái',N'Bố');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('5' , '4' , N'Chồng',N'Vợ');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('5' , '7' , N'Con Gái',N'Mẹ');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('7' , '5' , N'Mẹ',N'Con Gái');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('7' , '4' , N'Bố',N'Con Gái');


INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('8' , '9' , N'Vợ',N'Chồng');
INSERT INTO QuanHe (CMND1 , CMND2 , quanHeVoiCMND1 , quanHeVoiCMND2)
VALUES ('9' , '8' , N'Chồng',N'Vợ');
select * from QuanHe
--SO HO KHAU--

CREATE TABLE SoHoKhau(
	maSoHoKhau varchar (200) NOT NULL,
	CMNDChuHo varchar (100)  not null,
	maKV nvarchar (100)not null,
	xaPhuong nvarchar (100),
	quanHuyen nvarchar (100),
	tinhTP nvarchar (100),		
	diaChi nvarchar (100),
	ngayLap nvarchar (100),
	primary key (maSoHoKhau, CMNDChuHo),

	CONSTRAINT pk_soHoKhau_congDan
	FOREIGN KEY (CMNDChuHo)
	REFERENCES CongDan (cmnd)
);

INSERT INTO SoHoKhau(maSoHoKhau,CMNDChuHo,maKV,xaPhuong,quanHuyen,tinhTP,diaChi,ngayLap)
Values('1','1','2NT',N'Nam Kim',N'Nam Đàn',N'Nghệ An',N'Ấp 3','13/07/1994')
INSERT INTO SoHoKhau(maSoHoKhau,CMNDChuHo,maKV,xaPhuong,quanHuyen,tinhTP,diaChi,ngayLap)
Values('2','4','1',N'Linh Chiểu',N'Thủ Đức',N'Hồ Chí Minh',N'Đường số 5','22/12/1995')
INSERT INTO SoHoKhau(maSoHoKhau,CMNDChuHo,maKV,xaPhuong,quanHuyen,tinhTP,diaChi,ngayLap)
Values('3','8','3MD',N'Linh Trung',N'Thủ Đức',N'Hồ Chí Minh',N'Duong so 5','05/07/1988')
select * from SoHoKhau

--THANH VIEN SO HO KHAU--
CREATE TABLE ThanhVienSoHoKhau(
    maSoHoKhau varchar(200) not null,
    CMNDChuHo varchar (100) NOT NULL ,
    CMNDThanhVien varchar (100) NOT NULL,
    quanHeVoiChuHo nvarchar(100) not null,
    CONSTRAINT pk_ThanhVienSoHoKhau PRIMARY KEY (maSoHoKhau, CMNDChuHo, CMNDThanhVien),
    CONSTRAINT fk_thanhVienSoHoKhau_soHoKhau FOREIGN KEY (maSoHoKhau, CMNDChuHo) REFERENCES SoHoKhau (maSoHoKhau, CMNDChuHo),
    CONSTRAINT fk_thanhVien_congDan FOREIGN KEY (CMNDThanhVien) REFERENCES CongDan (cmnd),
    CONSTRAINT fk_thanhVien_quanHe FOREIGN KEY (CMNDChuHo, CMNDThanhVien) REFERENCES QuanHe (CMND1, CMND2)
);

insert into ThanhVienSoHoKhau(maSoHoKhau,CmndChuHo, CMNDThanhVien , quanHeVoiChuHo)
values ('1','1','2',N'Vợ');
insert into ThanhVienSoHoKhau(maSoHoKhau,CmndChuHo, CMNDThanhVien, quanHeVoiChuHo)
values ('1','1','3','Con Trai');
insert into ThanhVienSoHoKhau(maSoHoKhau,CmndChuHo, CMNDThanhVien, quanHeVoiChuHo)
values ('1','1','6',N'Con Gái');

insert into ThanhVienSoHoKhau(maSoHoKhau,CmndChuHo, CMNDThanhVien , quanHeVoiChuHo)
values ('2','4','5',N'Vợ');
insert into ThanhVienSoHoKhau(maSoHoKhau,CmndChuHo, CMNDThanhVien , quanHeVoiChuHo)
values ('2','4','7',N'Con Gái');

insert into ThanhVienSoHoKhau(maSoHoKhau,CmndChuHo, CMNDThanhVien , quanHeVoiChuHo)
values ('3','8','9',N'Vợ');

select * from ThanhVienSoHoKhau

--THUE--
Create table Thue (
CCCD varchar(100) NOT NULL Primary key,
LoaiThue nvarchar(100),
MucThue real,
TinhTrang nvarchar(50),
CONSTRAINT thue_theo_cccd
FOREIGN KEY (CCCD)
REFERENCES CongDan (cmnd)
)

insert into Thue (CCCD, LoaiThue, MucThue, TinhTrang)
values ('1',N'Thuế thu nhập cá nhân',1.5, N'Chưa đóng');
insert into Thue (CCCD, LoaiThue, MucThue, TinhTrang)
values ('2',N'Thuế thu nhập cá nhân',2.4, N'Chưa đóng');
insert into Thue (CCCD, LoaiThue, MucThue, TinhTrang)
values ('3',N'Thuế thu nhập cá nhân',3.6, N'Chưa đóng');
insert into Thue (CCCD, LoaiThue, MucThue, TinhTrang)
values ('4',N'Thuế thu nhập cá nhân', 2.3, N'Chưa đóng');

select * from Thue

--TAI KHOAN--
CREATE TABLE TaiKhoan (
 TaiKhoan varchar(100) primary key,
 MatKhau varchar(255)
);
INSERT INTO TaiKhoan (TaiKhoan, MatKhau)
VALUES ('admin', '123');
INSERT INTO TaiKhoan (TaiKhoan, MatKhau)
VALUES ('nva', '123');
INSERT INTO TaiKhoan (TaiKhoan, MatKhau)
VALUES ('nvb', '123');
select * from TaiKhoan
--INSERT INTO SoHoKhau (maSoHoKhau, CMNDChuHo, maKV, xaPhuong, quanHuyen, tinhTP, diaChi, ngayLap) SELECT '5', '6', maKV, xaPhuong, quanHuyen, tinhTP, diaChi, ngayLap FROM SoHoKhau WHERE maSoHoKhau = '2'
--INSERT INTO ThanhVienSoHoKhau(maSoHoKhau, CMNDChuHo, CMNDThanhVien, quanHeVoiChuHo) SELECT '5', '6',CMNDThanhVien, quanHeVoiCMND1 FROM ThanhVienSoHoKhau INNER JOIN QuanHe ON QuanHe.CMND2 = ThanhVienSoHoKhau.CMNDThanhVien WHERE ThanhVienSoHoKhau.maSoHoKhau = '1' AND QuanHe.CMND1 = '6'
--DELETE FROM ThanhVienSoHoKhau WHERE maSoHoKhau ='1'
--DELETE FROM SoHoKhau WHERE maSoHoKhau ='1'
 SELECT maSoHoKhau FROM ThanhVienSoHoKhau WHERE CMNDThanhVien= 3
SELECT maSoHoKhau FROM SoHoKhau WHERE CMNDChuHo=1
SELECT * FROM CongDan WHERE hoTen LIKE N'%Hải%'

