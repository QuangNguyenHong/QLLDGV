CREATE DATABASE QLLD 
go
use QLLD
go
CREATE TABLE PHONG(
	MaPhong varchar(5) primary key,
	TenPhong nvarchar(MAX) not null,
	ThongTinPhong nvarchar(MAX)
)
go
CREATE TABLE THU(
	MaThu varchar(2) primary key,
	TenThu nvarchar(max) not null
)
go
CREATE TABLE TietHoc(
	MaTiet varchar(3) primary key,
	Tiet int not null,
	TGianBD varchar(max) not null,
	TGianKT varchar(max) not null
)
go
CREATE TABLE Nganh(
	MaNganh varchar(6) primary key,
	TenNganh nvarchar(max) not null
)
go
CREATE TABLE MonHoc(
	MaMH varchar(8) not null primary key,
	TenMH nvarchar(MAX) not null,
	Nganh varchar(6) not null REFERENCES Nganh(MaNganh),
	TinChi int
)
go
CREATE TABLE HocPhan(
	MaNhom uniqueidentifier primary key,
	MonHoc varchar(8) not null REFERENCES MonHoc(MaMH),
	TenNhom nvarchar(MAX) not null,
)
go
CREATE TABLE GIAOVIEN(
	MaGV uniqueidentifier not null primary key,
	HoTenGV nvarchar(MAX) not null,
	BoMonPhuTrach varchar(8) not null REFERENCES MonHoc(MaMH),
	SodtGV varchar(15) not null,
	EmailGV varchar(MAX) not null,
	QueQuan nvarchar(MAX),
	MatKhauGV varchar(MAX) not null
)
go
CREATE TABLE LichDay(
	MaLich uniqueidentifier not null primary key,
	TenMH varchar(8) not null REFERENCES MonHoc(MaMH),
	NhomHP uniqueidentifier not null REFERENCES HocPhan(MaNhom),
	PhongHoc varchar(5) REFERENCES PHONG(MaPhong),
	GVDay uniqueidentifier REFERENCES GIAOVIEN(MaGV),
	ThuNgay varchar(2) REFERENCES THU(MaThu),
	NgayBatDau date,
	NgayKetThuc date,
	GioBatDau varchar(3) REFERENCES TietHoc(MaTiet),
	GioKetThuc varchar(3) REFERENCES TietHoc(MaTiet),
	check (NgayBatDau < NgayKetThuc)
)
go
CREATE TABLE SuKien(
	MaSuKien uniqueidentifier not null primary key,
	TenHP varchar(8) not null REFERENCES MonHoc(MaMH),
	Nhom uniqueidentifier not null REFERENCES HocPhan(MaNhom),
	GiaoVien uniqueidentifier REFERENCES GIAOVIEN(MaGV),
	TenSuKien nvarchar(MAX),
	StartDate date
)
go
CREATE TABLE QuanTri(
	MaAdmin uniqueidentifier not null primary key,
	TenAdmin nvarchar(MAX),
	SDT varchar(MAX),
	Email varchar(MAX),
	MatKhau varchar(MAX)
)
go
CREATE TABLE Message(
	MaMail uniqueidentifier not null primary key,
	NguoiGui uniqueidentifier not null REFERENCES GIAOVIEN(MaGV),
	NoiDung nvarchar(MAX),
	NgayGui date,
	Tinhtrang nvarchar(MAX)
)
go

INSERT INTO THU
VALUES
('0',N'Chủ nhật'),
('1',N'Thứ 2'),
('2',N'Thứ 3'),
('3',N'Thứ 4'),
('4',N'Thứ 5'),
('5',N'Thứ 6'),
('6',N'Thứ 7')
Go
INSERT INTO TietHoc
VALUES
('T01',1,'7:00','7:50'),
('T02',2,'7:51','8:40'),
('T03',3,'8:50','9:40'),
('T04',4,'9:50','10:40'),
('T05',5,'10:41','11:30'),
('T06',6,'13:00','13:50'),
('T07',7,'13:51','14:40'),
('T08',8,'14:50','15:40'),
('T09',9,'15:50','16:40'),
('T10',10,'16:40','17:30'),
('T11',11,'18:30','19:20'),
('T12',12,'19:20','20:10'),
('T13',13,'20:20','17:30')
Go
INSERT INTO Nganh
VALUES
('CNTT',N'Công nghệ thông tin'),
('CNTP',N'Công nghệ thực phẩm'),
('KT',N'Kinh tế'),
('KHXH',N'Khoa học xã hội và nhân văn'),
('NN',N'Ngoại ngữ')
GO
INSERT INTO PHONG 
VALUES 
('G6101',N'G6-101',N'Phòng 101 tại giảng đường G6'),
('G6102',N'G6-102',N'Phòng 102 tại giảng đường G6'),
('G6103',N'G6-103',N'Phòng 103 tại giảng đường G6'),
('G6104',N'G6-104',N'Phòng 104 tại giảng đường G6')
Go
INSERT INTO MonHoc 
VALUES 
('SOT352',N'Quản lý dự án phần mềm','CNTT',3),
('SOT357',N'Kiểm thử phần mềm','CNTT',3),
('SOT366',N'Phát triển phần mềm mã nguồn mở','CNTT',3),
('SSH320',N'Kỹ thuật soạn thảo văn bản','CNTT',2),
('SOT344',N'Trí tuệ nhân tạo','CNTT',3),
('INS366',N'Công nghệ XML và ứng dụng','CNTT',3),
('SOT353',N'Mẫu thiết kế','CNTT',3),
('ECS323',N'Kinh tế học đại cương','KT',2),
('BUA324',N'Nhập môn Quản trị học','KT',2),
('POL320',N'Lôgic học đại cương','CNTT',2),
('SSH317',N'Nhập môn Hành chính nhà nước','KHXH',2),
('NEC350',N'Thiết kế và cài đặt mạng','CNTT',3)
GO
INSERT INTO GIAOVIEN 
VALUES 
(NEWID(),N'Nguyễn Văn A','SOT352','0982138748','anv@gmail.com','Nha Trang','456'),
(NEWID(),N'Nguyễn Hồng Q', 'SOT353','0905967456','qnh@gmail.com','Ninh Hòa','789'),
(NEWID(),N'Lê Thư C','POL320','0982341321','clt@gmail.com','Nha Trang','321'),
(NEWID(),N'Triệu V','SSH317','0932523423','vtr@gmail.com','Nha Trang','432'),
(NEWID(),N'Diễm Q','NEC350','0923423532','qd@gmail.com','Cam Ranh','123'),
(NEWID(),N'Hào Văn Đ','ECS323','0923246544','dhv@gmail.com','Nha Trang','231')
Go
INSERT INTO HocPhan 
VALUES 
(NEWID(),'SOT352', N'Nhóm 1'),
(NEWID(),'SOT352', N'Nhóm 2'),
(NEWID(),'SOT357', N'Nhóm 1'),
(NEWID(),'SOT357', N'Nhóm 2'),
(NEWID(),'SOT357', N'Nhóm 3'),
(NEWID(),'SOT353', N'Nhóm 1'),
(NEWID(),'SOT353', N'Nhóm 2'),
(NEWID(),'SOT353', N'Nhóm 3')
GO
INSERT INTO QuanTri 
VALUES 
(NEWID(),N'Quang', '0904982431', 'quang.nh.61cntt@ntu.edu.vn', '123')
GO