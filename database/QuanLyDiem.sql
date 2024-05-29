use master
drop database QLDiem
create database QLDiem
go
use QLDiem
go

create table KhoaDaoTao
(
	MaKhoa nvarchar(50) primary key,
	TenKhoa nvarchar(50),
	DienThoai nvarchar(40)
)

create table Lop
(
	MaLop nvarchar(30) primary key,
	MaKhoa nvarchar(50),
	TenLop nvarchar(50),
	Khoa nvarchar(50),
	HeDaoTao nvarchar(20),
	NamNhapHoc int,
	SiSo int,
	constraint FK_Lop_KhoaDaoTao foreign key(MaKhoa)  references KhoaDaoTao(MaKhoa)
)

create table SinhVien
(
	MaSV nvarchar(40) primary key,
	HoDem nvarchar(50),
	Ten nvarchar(50),
	NgaySinh Date,
	DiaChi nvarchar(50),
	GioiTinh nvarchar(20),
	Email nvarchar(30),
	SoDienThoai nvarchar(30),
	MaLop nvarchar(30),
	constraint FK_SinhVien_Lop foreign key(MaLop) references Lop(MaLop)
)

create table MonHoc
(
	MaMH nvarchar(30) primary key,
	TenMH nvarchar(50),
	SoTinChi int,
	HocKy int,

)
create table DiemThi
(
	MaMH nvarchar(30),
	MaSV nvarchar(40),
	Diem int,
	KyHoc int
	constraint PK_DiemThi primary key(MaMH,MaSV),
	constraint FK_DiemThi_SinhVien foreign key(MaSV) references SinhVien(MaSV),
	constraint FK_DiemThi_MonHoc foreign key(MaMH) references MonHoc(MaMH)
)

create table DangNhap
(
	UserID int identity(1,1) primary key ,
	Ten nvarchar(20),
	Password nvarchar(20) 
)

insert into KhoaDaoTao values
('7480201',N'Công Nghệ Thông Tin','0347655391'),
('7480101',N'Khoa Học Máy Tính','0394564566'),
('7480104',N'Hệ Thống Thông Tin','0985743732'),
('7810101',N'Du lịch','0934598375'),
('7510205',N'Công nghệ kỹ thuật ô tô','0934456456'),
('7510401',N'Công nghệ kỹ thuật cơ khí','0934398234'),
('7510406',N'Robot và trí tuệ nhân tạo','0945093454'),
('7220201',N'Công nghệ thực phẩm','0934543598'),
('7220209',N'Công nghệ kỹ thuật nhiệt','0934534585'),
('7510201',N'Công nghệ kỹ thuật cơ điện tử','0933453475'),
('7510302',N'Mạng máy tính và truyền thông dữ liệu','0934589735')

insert into Lop values
('CNTT03','7480201',N'Công Nghệ Thông Tin 3',N'K13',N'Đại Học',2018,80),
('CNTT01','7480201',N'Công Nghệ Thông Tin 1',N'K14',N'Đại Học',2019,70),
('KHMT03','7480101',N'Khoa Học Máy Tính 3',N'K13',N'Đại Học',2018,76),
('HTTT01','7480104',N'Hệ Thống Thông Tin 3',N'K21',N'Cao Đẳng',2017,77),
('HTTT02','7480104',N'Hệ Thống Thông Tin 3',N'K13',N'Đại Học',2018,68),
('DL03','7810101',N'Du Lịch 3',N'K13',N'Đại Học',2018,80),
('CNTP1','7220201',N'Công nghệ thực phẩm 1',N'K14',N'Đại Học',2019,70),
('CNKTOTO03','7810101',N'Công nghệ kỹ thuật ô tô 3',N'K13',N'Đại Học',2018,76),
('CNKTCK03','7510401',N'Công nghệ kỹ thuật cơ khí 3',N'K21',N'Cao Đẳng',2017,77),
('R&TTNT03','7510406',N'Robot và trí tuệ nhân tạo 3',N'K13',N'Đại Học',2018,68),
('CNKTN03','7220209',N'Công nghệ kỹ thuật nhiệt 3',N'K13',N'Đại Học',2018,80),
('CNTP02','7220201',N'Công nghệ thực phẩm 2',N'K13',N'Đại Học',2018,70),
('CNKTCDT','7510201',N'Công nghệ kỹ thuật cơ điện tử',N'K13',N'Đại Học',2018,76),
('MMT&TT03','7510302',N'Mạng máy tính và truyền thông dữ liệu 3',N'K21',N'Cao Đẳng',2017,77)

--Bảng SinhVien
--Cntt01--
insert into SinhVien values ('2018604692',N'Đinh Quang',N'Anh','2000-01-26',N'Hà Nam',N'Nam','nah@gmail.com','035312345','CNTT01')
insert into SinhVien values ('2018601134',N'Đinh Tuấn',N'Anh','2000-04-23',N'Hà Nội',N'Nam','tanh@gmail.com','035312456','CNTT01')
insert into SinhVien values ('2018600641',N'Phùng Văn',N'Đại','2000-12-12',N'Hải Phòng',N'Nam','daivan@gmail.com','035314564','CNTT01')
insert into SinhVien values ('2018602968',N'Vũ Thị Kim',N'Anh','2000-08-26',N'Hải Phòng',N'Nam','khanhanh@gmail.com','035645345','CNTT01')
insert into SinhVien values ('2018604067',N'Trần Thọ',N'Bằng','2000-06-16',N'Hà Nội',N'Nam','bangbang@gmail.com','034532345','CNTT01')
insert into SinhVien values ('2018603223',N'Nguyễn Thị',N'Trang','2000-02-24',N'Nam Định',N'Nữ','chang@gmail.com','035314353','CNTT01')
insert into SinhVien values ('2018602701',N'Đoàn Minh',N'Châu','2000-12-12',N'Hải Phòng',N'Nam','chau@gmail.com','035314564','CNTT01')
insert into SinhVien values ('2018601630',N'Hoàng Duy',N'Công','2000-01-26',N'Hải Phòng',N'Nam','khanhcong@gmail.com','035645345','CNTT01')
insert into SinhVien values ('2018603443',N'Nguyễn Thị',N'Linh','2000-12-16',N'Hà Nội',N'Nữ','Nguyenlinh@gmail.com','034532345','CNTT01')
insert into SinhVien values ('2018603377',N'Nguyễn Văn',N'Đạt','2000-12-24',N'Nam Định',N'Nam','dat1lit@gmail.com','035314353','CNTT01')

--Cntt03--
insert into SinhVien values ('2018603147',N'Lê Hồng',N'Phong','2000-02-26',N'Hà Nam',N'Nam','phongle@gmail.com','035312345','CNTT03')
insert into SinhVien values ('2018602730',N'Đỗ Vinh',N'Hà','2000-04-23',N'Hà Nội',N'Nam','havinh@gmail.com','035312456','CNTT03')
insert into SinhVien values ('2018602283',N'Đoàn Duy',N'Nam','2000-12-12',N'Hải Phòng',N'Nam','namdoan@gmail.com','035314564','CNTT03')
insert into SinhVien values ('2018602093',N'Hoàng Duy',N'Khánh','2000-08-26',N'Hải Phòng',N'Nam','khanh@gmail.com','035645345','CNTT03')
insert into SinhVien values ('2018602659',N'Nguyễn Anh',N'Linh','2000-06-16',N'Hà Nội',N'Nam','anhlinh@gmail.com','034532345','CNTT03')
insert into SinhVien values ('2018602294',N'Vũ Văn',N'Doan','2000-02-24',N'Nam Định',N'Nam','doan@gmail.com','035314353','CNTT03')
insert into SinhVien values ('2018602958',N'Nguyễn Đức',N'Điệp','2000-05-24',N'Hà Nội',N'Nam','diepka@gmail.com','0353134554','CNTT03')
insert into SinhVien values ('2018602241',N'Lê Thành',N'Công','2000-03-04',N'Hà Nội',N'Nam','cong@gmail.com','0353134554','CNTT03')
insert into SinhVien values ('2018602230',N'Khúc Văn',N'Đoàn','2000-02-02',N'Hà Nội',N'Nam','kdoan@gmail.com','0353134554','CNTT03')
insert into SinhVien values ('2018602135',N'Lường Bá',N'Hoàng','2000-09-14',N'Hà Nội',N'Nam','hoang@gmail.com','0353134554','CNTT03')

--Httt01--
insert into SinhVien values ('2018604593',N'Đinh Quang',N'Huy','2000-01-26',N'Hà Nam',N'Nam','huyh@gmail.com','035312345','HTTT01')
insert into SinhVien values ('2018602994',N'Đinh Tuấn',N'Hoàng','2000-04-23',N'Hà Nội',N'Nam','tanhoan@gmail.com','035312456','HTTT01')
insert into SinhVien values ('2018602768',N'Vũ Thị Kim',N'Thư','2000-08-26',N'Hải Phòng',N'Nữ','khanthuhanh@gmail.com','035645345','HTTT01')
insert into SinhVien values ('2018602529',N'Trần Thọ',N'Hợp','2000-06-16',N'Hà Nội',N'Nam','banghop@gmail.com','034532345','HTTT01')
insert into SinhVien values ('2018602232',N'Nguyễn Thị',N'Hôm','2000-02-24',N'Nam Định',N'Nữ','homchang@gmail.com','035314353','HTTT01')
insert into SinhVien values ('2018602612',N'Đoàn Minh',N'Hoàng','2000-12-12',N'Hải Phòng',N'Nam','hoiangchau@gmail.com','035314564','HTTT01')
insert into SinhVien values ('2018603575',N'Hoàng Duy',N'Thành','2000-01-26',N'Hải Phòng',N'Nam','thanhkhanhcong@gmail.com','035645345','HTTT01')
insert into SinhVien values ('2018601253',N'Nguyễn Thị',N'Hiếu','2000-12-16',N'Hà Nội',N'Nữ','Nguyenhieu@gmail.com','034532345','HTTT01')
insert into SinhVien values ('2018603058',N'Nguyễn Văn',N'Linh','2000-12-24',N'Nam Định',N'Nam','datlinh@gmail.com','035314353','HTTT01')
insert into SinhVien values ('2018602206',N'Nguyễn Văn',N'Long','2000-12-24',N'Nam Định',N'Nam','longlong@gmail.com','035314353','HTTT01')

--HTTT02---
insert into SinhVien values ('2017604748',N'Nguyễn Duy',N'Phong','2000-02-26',N'Hà Nam',N'Nam','phong@gmail.com','035312345','HTTT02')
insert into SinhVien values ('2018604698',N'Nguyễn Trọng',N'Hà','2000-04-23',N'Hà Nội',N'Nam','havinhtrong@gmail.com','035312456','HTTT02')
insert into SinhVien values ('2018603047',N'Nguyễn Thị ',N'Nam','2000-12-12',N'Hải Phòng',N'Nữ','namdoanthi@gmail.com','035314564','HTTT02')
insert into SinhVien values ('1041060321',N'Đặng Quang',N'Khánh','2000-08-26',N'Hải Phòng',N'Nam','khanhquang@gmail.com','035645345','HTTT02')
insert into SinhVien values ('2018604833',N'Nguyễn Văn',N'Linh','2000-06-16',N'Hà Nội',N'Nam','anhlinhvna@gmail.com','034532345','HTTT02')
insert into SinhVien values ('2017604991',N'Trương Văn',N'Doan','2000-02-24',N'Nam Định',N'Nam','doandoan@gmail.com','035314353','HTTT02')
insert into SinhVien values ('2018604160',N'Hoàng Thanh',N'Điệp','2000-05-24',N'Hà Nội',N'Nam','diethanh@gmail.com','0353134554','HTTT02')
insert into SinhVien values ('2018603476',N'Lê Thành',N'Công','2000-03-04',N'Hà Nội',N'Nam','congthanh@gmail.com','0353134554','HTTT02')
insert into SinhVien values ('2018603120',N'Lê Đức',N'Đoàn','2000-02-02',N'Hà Nội',N'Nam','kdoadoann@gmail.com','0353134554','HTTT02')
insert into SinhVien values ('2018601796',N'Nguyễn Anh',N'Hoàng','2000-09-14',N'Hà Nội',N'Nam','anhhoang@gmail.com','0353134554','HTTT02')

--KHMT03--
insert into SinhVien values ('2018605120',N'Nguyễn Duy',N'Trọng','2000-02-26',N'Hà Nam',N'Nam','trong@gmail.com','035312345','KHMT03')
insert into SinhVien values ('2018600803',N'Nguyễn Trọng',N'Thập','2000-04-23',N'Hà Nội',N'Nam','trong10@gmail.com','035312456','KHMT03')
insert into SinhVien values ('0841060248',N'Nguyễn Thị ',N'Chinh','2000-12-12',N'Hải Phòng',N'Nữ','chinhchinh@gmail.com','035314564','KHMT03')
insert into SinhVien values ('2018600683',N'Đặng Quang',N'Long','2000-08-26',N'Hải Phòng',N'Nam','khanhlong@gmail.com','035645345','KHMT03')
insert into SinhVien values ('0841360080',N'Nguyễn Văn',N'Thịnh','2000-06-16',N'Hà Nội',N'Nam','anhthinh@gmail.com','034532345','KHMT03')
insert into SinhVien values ('2018601284',N'Đoàn Minh',N'Duy','2000-12-12',N'Hải Phòng',N'Nam','duychau@gmail.com','035314564','KHMT03')
insert into SinhVien values ('2018602038',N'Hoàng Duy',N'Long','2000-01-26',N'Hải Phòng',N'Nam','thanhlong@gmail.com','035645345','KHMT03')
insert into SinhVien values ('2018602852',N'Nguyễn Thị',N'Hợp','2000-12-16',N'Hà Nội',N'Nữ','hophon@gmail.com','034532345','KHMT03')
insert into SinhVien values ('2018603687',N'Nguyễn Văn',N'Duy','2000-12-24',N'Nam Định',N'Nam','duyhi@gmail.com','035314353','KHMT03')
insert into SinhVien values ('2018602090',N'Nguyễn Thị',N'Lan','2000-12-24',N'Nam Định',N'Nữ','lanlong@gmail.com','035314353','KHMT03')

--CNKTCDT--
insert into SinhVien values ('2018600001',N'Đinh Quang',N'Định','2000-01-26',N'Hà Nam',N'Nam','nah@gmail.com','035312345','CNKTCDT')
insert into SinhVien values ('2018600002',N'Đinh Tuấn',N'Công','2000-04-23',N'Hà Nội',N'Nam','tanh@gmail.com','035312456','CNKTCDT')
insert into SinhVien values ('2018600003',N'Phùng Văn',N'Mạnh','2000-12-12',N'Hải Phòng',N'Nam','daivan@gmail.com','035314564','CNKTCDT')
insert into SinhVien values ('2018600004',N'Vũ Thị Kim',N'Anh','2000-08-26',N'Hải Phòng',N'Nam','khanhanh@gmail.com','035645345','CNKTCDT')
insert into SinhVien values ('2018600005',N'Trần Thọ',N'Thi','2000-06-16',N'Hà Nội',N'Nam','bangbang@gmail.com','034532345','CNKTCDT')
insert into SinhVien values ('2018600006',N'Nguyễn Thị',N'Hà','2000-02-24',N'Nam Định',N'Nữ','chang@gmail.com','035314353','CNKTCDT')
insert into SinhVien values ('2018600007',N'Đoàn Minh',N'Chinh','2000-12-12',N'Hải Phòng',N'Nam','chau@gmail.com','035314564','CNKTCDT')
insert into SinhVien values ('2018600008',N'Hoàng Duy',N'Chiến','2000-01-26',N'Hải Phòng',N'Nam','khanhcong@gmail.com','035645345','CNKTCDT')
insert into SinhVien values ('2018600009',N'Nguyễn Thị',N'Đoàn','2000-12-16',N'Hà Nội',N'Nữ','Nguyenlinh@gmail.com','034532345','CNKTCDT')
insert into SinhVien values ('2018600010',N'Nguyễn Văn',N'Đạt','2000-12-24',N'Nam Định',N'Nam','dat1lit@gmail.com','035314353','CNKTCDT')

--CNKTCK03--
insert into SinhVien values ('2018600011',N'Lê Hồng',N'Phong','2000-02-26',N'Hà Nam',N'Nam','phongle@gmail.com','035312345','CNKTCK03')
insert into SinhVien values ('2018600012',N'Đỗ Vinh',N'Hà','2000-04-23',N'Hà Nội',N'Nam','havinh@gmail.com','035312456','CNKTCK03')
insert into SinhVien values ('2018600013',N'Đoàn Duy',N'Nam','2000-12-12',N'Hải Phòng',N'Nam','namdoan@gmail.com','035314564','CNKTCK03')
insert into SinhVien values ('2018600014',N'Hoàng Duy',N'Khánh','2000-08-26',N'Hải Phòng',N'Nam','khanh@gmail.com','035645345','CNKTCK03')
insert into SinhVien values ('2018600015',N'Nguyễn Anh',N'Linh','2000-06-16',N'Hà Nội',N'Nam','anhlinh@gmail.com','034532345','CNKTCK03')
insert into SinhVien values ('2018600016',N'Vũ Văn',N'Doan','2000-02-24',N'Nam Định',N'Nam','doan@gmail.com','035314353','CNKTCK03')
insert into SinhVien values ('2018600017',N'Nguyễn Đức',N'Điệp','2000-05-24',N'Hà Nội',N'Nam','diepka@gmail.com','0353134554','CNKTCK03')
insert into SinhVien values ('2018600018',N'Lê Thành',N'Công','2000-03-04',N'Hà Nội',N'Nam','cong@gmail.com','0353134554','CNKTCK03')
insert into SinhVien values ('2018600019',N'Khúc Văn',N'Đoàn','2000-02-02',N'Hà Nội',N'Nam','kdoan@gmail.com','0353134554','CNKTCK03')
insert into SinhVien values ('2018600020',N'Lường Bá',N'Hoàng','2000-09-14',N'Hà Nội',N'Nam','hoang@gmail.com','0353134554','CNKTCK03')

--CNKTN03--
insert into SinhVien values ('2018600021',N'Đinh Quang',N'Huy','2000-01-26',N'Hà Nam',N'Nam','huyh@gmail.com','035312345','CNKTN03')
insert into SinhVien values ('2018600022',N'Đinh Tuấn',N'Hoàng','2000-04-23',N'Hà Nội',N'Nam','tanhoan@gmail.com','035312456','CNKTN03')
insert into SinhVien values ('2018600023',N'Vũ Thị Kim',N'Thư','2000-08-26',N'Hải Phòng',N'Nữ','khanthuhanh@gmail.com','035645345','CNKTN03')
insert into SinhVien values ('2018600024',N'Trần Thọ',N'Hợp','2000-06-16',N'Hà Nội',N'Nam','banghop@gmail.com','034532345','CNKTN03')
insert into SinhVien values ('2018600025',N'Nguyễn Thị',N'Hôm','2000-02-24',N'Nam Định',N'Nữ','homchang@gmail.com','035314353','CNKTN03')
insert into SinhVien values ('2018600026',N'Đoàn Minh',N'Hoàng','2000-12-12',N'Hải Phòng',N'Nam','hoiangchau@gmail.com','035314564','CNKTN03')
insert into SinhVien values ('2018600027',N'Hoàng Duy',N'Thành','2000-01-26',N'Hải Phòng',N'Nam','thanhkhanhcong@gmail.com','035645345','CNKTN03')
insert into SinhVien values ('2018600028',N'Nguyễn Thị',N'Hiếu','2000-12-16',N'Hà Nội',N'Nữ','Nguyenhieu@gmail.com','034532345','CNKTN03')
insert into SinhVien values ('2018600029',N'Nguyễn Văn',N'Linh','2000-12-24',N'Nam Định',N'Nam','datlinh@gmail.com','035314353','CNKTN03')
insert into SinhVien values ('2018600030',N'Nguyễn Văn',N'Long','2000-12-24',N'Nam Định',N'Nam','longlong@gmail.com','035314353','CNKTN03')

--CNKTOTO03--
insert into SinhVien values ('2017600031',N'Nguyễn Duy',N'Phong','2000-02-26',N'Hà Nam',N'Nam','phong@gmail.com','035312345','CNKTOTO03')
insert into SinhVien values ('2018600032',N'Nguyễn Trọng',N'Hà','2000-04-23',N'Hà Nội',N'Nam','havinhtrong@gmail.com','035312456','CNKTOTO03')
insert into SinhVien values ('2018600033',N'Nguyễn Thị ',N'Nam','2000-12-12',N'Hải Phòng',N'Nữ','namdoanthi@gmail.com','035314564','CNKTOTO03')
insert into SinhVien values ('2018600034',N'Đặng Quang',N'Khánh','2000-08-26',N'Hải Phòng',N'Nam','khanhquang@gmail.com','035645345','CNKTOTO03')
insert into SinhVien values ('2018600035',N'Nguyễn Văn',N'Linh','2000-06-16',N'Hà Nội',N'Nam','anhlinhvna@gmail.com','034532345','CNKTOTO03')
insert into SinhVien values ('2017600036',N'Trương Văn',N'Doan','2000-02-24',N'Nam Định',N'Nam','doandoan@gmail.com','035314353','CNKTOTO03')
insert into SinhVien values ('2018600037',N'Hoàng Thanh',N'Điệp','2000-05-24',N'Hà Nội',N'Nam','diethanh@gmail.com','0353134554','CNKTOTO03')
insert into SinhVien values ('2018600038',N'Lê Thành',N'Công','2000-03-04',N'Hà Nội',N'Nam','congthanh@gmail.com','0353134554','CNKTOTO03')
insert into SinhVien values ('2018600039',N'Lê Đức',N'Đoàn','2000-02-02',N'Hà Nội',N'Nam','kdoadoann@gmail.com','0353134554','CNKTOTO03')
insert into SinhVien values ('2018600040',N'Nguyễn Anh',N'Hoàng','2000-09-14',N'Hà Nội',N'Nam','anhhoang@gmail.com','0353134554','CNKTOTO03')

--CNTP02--
insert into SinhVien values ('2018600041',N'Nguyễn Duy',N'Trọng','2000-02-26',N'Hà Nam',N'Nam','trong@gmail.com','035312345','CNTP02')
insert into SinhVien values ('2018600042',N'Nguyễn Trọng',N'Thập','2000-04-23',N'Hà Nội',N'Nam','trong10@gmail.com','035312456','CNTP02')
insert into SinhVien values ('0841060043',N'Nguyễn Thị ',N'Chinh','2000-12-12',N'Hải Phòng',N'Nữ','chinhchinh@gmail.com','035314564','CNTP02')
insert into SinhVien values ('2018600044',N'Đặng Quang',N'Long','2000-08-26',N'Hải Phòng',N'Nam','khanhlong@gmail.com','035645345','CNTP02')
insert into SinhVien values ('2018600045',N'Nguyễn Văn',N'Thịnh','2000-06-16',N'Hà Nội',N'Nam','anhthinh@gmail.com','034532345','CNTP02')
insert into SinhVien values ('2018600046',N'Đoàn Minh',N'Duy','2000-12-12',N'Hải Phòng',N'Nam','duychau@gmail.com','035314564','CNTP02')
insert into SinhVien values ('2018600047',N'Hoàng Duy',N'Long','2000-01-26',N'Hải Phòng',N'Nam','thanhlong@gmail.com','035645345','CNTP02')
insert into SinhVien values ('2018600048',N'Nguyễn Thị',N'Hợp','2000-12-16',N'Hà Nội',N'Nữ','hophon@gmail.com','034532345','CNTP02')
insert into SinhVien values ('2018600049',N'Nguyễn Văn',N'Duy','2000-12-24',N'Nam Định',N'Nam','duyhi@gmail.com','035314353','CNTP02')
insert into SinhVien values ('2018600050',N'Nguyễn Thị',N'Lan','2000-12-24',N'Nam Định',N'Nữ','lanlong@gmail.com','035314353','CNTP02')

--CNTP1--
insert into SinhVien values ('2018600051',N'Đinh Quang',N'Anh','2000-01-26',N'Hà Nam',N'Nam','nah@gmail.com','035312345','CNTP1')
insert into SinhVien values ('2018600052',N'Đinh Tuấn',N'Anh','2000-04-23',N'Hà Nội',N'Nam','tanh@gmail.com','035312456','CNTP1')
insert into SinhVien values ('2018600053',N'Phùng Văn',N'Đại','2000-12-12',N'Hải Phòng',N'Nam','daivan@gmail.com','035314564','CNTP1')
insert into SinhVien values ('2018600054',N'Vũ Thị Kim',N'Anh','2000-08-26',N'Hải Phòng',N'Nam','khanhanh@gmail.com','035645345','CNTP1')
insert into SinhVien values ('2018600055',N'Trần Thọ',N'Bằng','2000-06-16',N'Hà Nội',N'Nam','bangbang@gmail.com','034532345','CNTP1')
insert into SinhVien values ('2018600056',N'Nguyễn Thị',N'Trang','2000-02-24',N'Nam Định',N'Nữ','chang@gmail.com','035314353','CNTP1')
insert into SinhVien values ('2018600057',N'Đoàn Minh',N'Châu','2000-12-12',N'Hải Phòng',N'Nam','chau@gmail.com','035314564','CNTP1')
insert into SinhVien values ('2018600058',N'Hoàng Duy',N'Công','2000-01-26',N'Hải Phòng',N'Nam','khanhcong@gmail.com','035645345','CNTP1')
insert into SinhVien values ('2018600059',N'Nguyễn Thị',N'Linh','2000-12-16',N'Hà Nội',N'Nữ','Nguyenlinh@gmail.com','034532345','CNTP1')
insert into SinhVien values ('2018600060',N'Nguyễn Văn',N'Đạt','2000-12-24',N'Nam Định',N'Nam','dat1lit@gmail.com','035314353','CNTP1')

--DL03--
insert into SinhVien values ('2018600061',N'Đinh Quang',N'Thập','2000-01-26',N'Hà Nam',N'Nam','huyh@gmail.com','035312345','DL03')
insert into SinhVien values ('2018600062',N'Đinh Tuấn',N'Anh','2000-04-23',N'Hà Nội',N'Nam','tanhoan@gmail.com','035312456','DL03')
insert into SinhVien values ('2018600063',N'Vũ Thị Kim',N'Thu','2000-08-26',N'Hải Phòng',N'Nữ','khanthuhanh@gmail.com','035645345','DL03')
insert into SinhVien values ('2018600064',N'Trần Thọ',N'Thơm','2000-06-16',N'Hà Nội',N'Nam','banghop@gmail.com','034532345','DL03')
insert into SinhVien values ('2018600065',N'Nguyễn Thị',N'Thu','2000-02-24',N'Nam Định',N'Nữ','homchang@gmail.com','035314353','DL03')
insert into SinhVien values ('2018600066',N'Đoàn Văn',N'Đoàn','2000-12-12',N'Hải Phòng',N'Nam','hoiangchau@gmail.com','035314564','DL03')
insert into SinhVien values ('2018600067',N'Hoàng Thị',N'Thanh','2000-01-26',N'Hải Phòng',N'Nam','thanhkhanhcong@gmail.com','035645345','DL03')
insert into SinhVien values ('2018600068',N'Nguyễn Thị',N'Lụa','2000-12-16',N'Hà Nội',N'Nữ','Nguyenhieu@gmail.com','034532345','DL03')
insert into SinhVien values ('2018600069',N'Nguyễn Đức',N'Văn','2000-12-24',N'Nam Định',N'Nam','datlinh@gmail.com','035314353','DL03')
insert into SinhVien values ('2018600070',N'Nguyễn văn',N'Toàn','2000-12-24',N'Nam Định',N'Nam','longlong@gmail.com','035314353','DL03')

--MMT&TT03--
insert into SinhVien values ('2018600071',N'Duy',N'Mạnh','2000-02-26',N'Hà Nam',N'Nam','trong@gmail.com','035312345','MMT&TT03')
insert into SinhVien values ('2018600072',N'Đan',N'Trường','2000-04-23',N'Hà Nội',N'Nam','trong10@gmail.com','035312456','MMT&TT03')
insert into SinhVien values ('0841060073',N'Angela Phương',N'Trinh','2000-12-12',N'Hải Phòng',N'Nữ','chinhchinh@gmail.com','035314564','MMT&TT03')
insert into SinhVien values ('2018600074',N'Trịnh Đình',N'Quang','2000-08-26',N'Hải Phòng',N'Nam','khanhlong@gmail.com','035645345','MMT&TT03')
insert into SinhVien values ('2018600075',N'Khắc',N'Việt','2000-06-16',N'Hà Nội',N'Nam','anhthinh@gmail.com','034532345','MMT&TT03')
insert into SinhVien values ('2018600076',N'Hoài',N'Linh','2000-12-12',N'Hải Phòng',N'Nam','duychau@gmail.com','035314564','MMT&TT03')
insert into SinhVien values ('2018600077',N'Trường',N'Giang','2000-01-26',N'Hải Phòng',N'Nam','thanhlong@gmail.com','035645345','MMT&TT03')
insert into SinhVien values ('2018600078',N'Bảo',N'Thi','2000-12-16',N'Hà Nội',N'Nữ','hophon@gmail.com','034532345','MMT&TT03')
insert into SinhVien values ('2018600079',N'Lam',N'Trường','2000-12-24',N'Nam Định',N'Nam','duyhi@gmail.com','035314353','MMT&TT03')
insert into SinhVien values ('2018600080',N'Chi',N'Pu','2000-12-24',N'Nam Định',N'Nữ','lanlong@gmail.com','035314353','MMT&TT03')

--R&TTNT03--
insert into SinhVien values ('2018600081',N'Châu Đăng',N'Khoa','2000-02-26',N'Hà Nam',N'Nam','trong@gmail.com','035312345','R&TTNT03')
insert into SinhVien values ('2018600082',N'Đàm Vĩnh',N'Hưng','2000-04-23',N'Hà Nội',N'Nam','trong10@gmail.com','035312456','R&TTNT03')
insert into SinhVien values ('0841060083',N'Hoàng Thùy',N'Linh','2000-12-12',N'Hải Phòng',N'Nữ','chinhchinh@gmail.com','035314564','R&TTNT03')
insert into SinhVien values ('2018600084',N'Hà Anh',N'Tuấn','2000-08-26',N'Hải Phòng',N'Nam','khanhlong@gmail.com','035645345','R&TTNT03')
insert into SinhVien values ('2018600085',N'Hồ Quang',N'Hiếu','2000-06-16',N'Hà Nội',N'Nam','anhthinh@gmail.com','034532345','R&TTNT03')
insert into SinhVien values ('2018600086',N'Lâm Chấn Huy',N'Huy','2000-12-12',N'Hải Phòng',N'Nam','duychau@gmail.com','035314564','R&TTNT03')
insert into SinhVien values ('2018600087',N'Nam',N'Cường','2000-01-26',N'Hải Phòng',N'Nam','thanhlong@gmail.com','035645345','R&TTNT03')
insert into SinhVien values ('2018600088',N'Phi',N'Nhung','2000-12-16',N'Hà Nội',N'Nữ','hophon@gmail.com','034532345','R&TTNT03')
insert into SinhVien values ('2018600089',N'Noo Phước',N'Thịnh','2000-12-24',N'Nam Định',N'Nam','duyhi@gmail.com','035314353','R&TTNT03')
insert into SinhVien values ('2018600090',N'Soobin Hoàng',N'Sơn','2000-12-24',N'Nam Định',N'Nam','lanlong@gmail.com','035314353','R&TTNT03')


insert into MonHoc values
('JAVA',N'Lập Trình JAVA',4,6),
('C#',N'Lập Trình Windows',3,6),
('XML',N'Công Nghệ XML',3,6),
('DHUD',N'Đồ Họa Ứng Dụng',3,6),
('TA',N'Tiếng Anh Công Nghệ Thông Tin',5,6),
('HCG',N'Hệ Chuyên Gia',3,7),
('LTW',N'Lập trình ứng dụng cơ sở dữ liệu trên Web',3,7),
('MNM',N'Phần mềm mã nguồn mở',3,8),
('NMT',N'Nhập môn tin học',3,1),
('TCC1',N'Toán cao cấp 1',3,1),
('TCC2',N'Toán cao cấp 2',3,2),
('TRR',N'Toán rời rạc',3,2)




insert into DiemThi values 
('JAVA','2018603147',10,6),
('JAVA','0841060248',9,6),
('JAVA','0841360080',8,6),
('JAVA','1041060321',7,6),
('JAVA','2017604748',6,6),
('JAVA','2017604991',7,6),
('JAVA','2018600641',8,6),
('JAVA','2018600683',9,6),
('JAVA','2018600803',7,6),
('JAVA','2018601134',10,6),
('JAVA','2018601253',6,6),
('JAVA','2018601284',8,6),
('JAVA','2018601630',10,6),
('JAVA','2018601796',9,6),
('JAVA','2018602038',8,6),
('JAVA','2018602090',9,6),
('JAVA','2018602093',10,6),
('JAVA','2018602135',10,6),
('JAVA','2018602206',8,6),
('JAVA','2018602230',10,6),
('JAVA','2018602232',9,6),
('JAVA','2018602241',7,6),
('JAVA','2018602283',10,6),
('JAVA','2018602294',10,6),
('JAVA','2018602529',8,6),
('JAVA','2018602612',9,6),
('JAVA','2018602659',6,6),
('JAVA','2018602701',7,6),
('JAVA','2018602730',10,6),
('JAVA','2018602768',8,6),
('JAVA','2018602852',8,6),
('JAVA','2018602958',10,6),
('JAVA','2018602968',8,6),
('JAVA','2018602994',9,6),
('JAVA','2018603047',7,6),
('JAVA','2018603058',10,6),
('JAVA','2018603120',8,6),
('JAVA','2018603223',9,6),
('JAVA','2018603377',7,6),
('JAVA','2018603443',9,6),
('JAVA','2018603476',8,6),
('JAVA','2018603575',7,6),
('JAVA','2018603687',6,6),
('JAVA','2018604067',7,6),
('JAVA','2018604160',8,6),
('JAVA','2018604593',9,6),
('JAVA','2018604692',9,6),
('JAVA','2018604698',8,6),
('JAVA','2018604833',10,6),
('JAVA','2018605120',8,6)

insert into DiemThi values
('C#','2018603147',9,6),
('C#','0841060248',8,6),
('C#','0841360080',7,6),
('C#','1041060321',6,6),
('C#','2017604748',7,6),
('C#','2017604991',8,6),
('C#','2018600641',9,6),
('C#','2018600683',8,6),
('C#','2018600803',6,6),
('C#','2018601134',8,6),
('C#','2018601253',9,6),
('C#','2018601284',7,6),
('C#','2018601630',8,6),
('C#','2018601796',7,6),
('C#','2018602038',6,6),
('C#','2018602090',7,6),
('C#','2018602093',8,6),
('C#','2018602135',8,6),
('C#','2018602206',9,6),
('C#','2018602230',8,6),
('C#','2018602232',7,6),
('C#','2018602241',8,6),
('C#','2018602283',7,6),
('C#','2018602294',7,6),
('C#','2018602529',9,6),
('C#','2018602612',8,6),
('C#','2018602659',8,6),
('C#','2018602701',9,6),
('C#','2018602730',8,6),
('C#','2018602768',7,6),
('C#','2018602852',6,6),
('C#','2018602958',9,6),
('C#','2018602968',7,6),
('C#','2018602994',8,6),
('C#','2018603047',6,6),
('C#','2018603058',9,6),
('C#','2018603120',7,6),
('C#','2018603223',7,6),
('C#','2018603377',8,6),
('C#','2018603443',7,6),
('C#','2018603476',9,6),
('C#','2018603575',8,6),
('C#','2018603687',8,6),
('C#','2018604067',9,6),
('C#','2018604160',7,6),
('C#','2018604593',6,6),
('C#','2018604692',8,6),
('C#','2018604698',7,6),
('C#','2018604833',9,6),
('C#','2018605120',6,6)

insert into DiemThi values 
('DHUD','2018603147',10,6),
('DHUD','0841060248',9,6),
('DHUD','0841360080',8,6),
('DHUD','1041060321',7,6),
('DHUD','2017604748',6,6),
('DHUD','2017604991',7,6),
('DHUD','2018600641',8,6),
('DHUD','2018600683',9,6),
('DHUD','2018600803',7,6),
('DHUD','2018601134',10,6),
('DHUD','2018601253',6,6),
('DHUD','2018601284',8,6),
('DHUD','2018601630',10,6),
('DHUD','2018601796',9,6),
('DHUD','2018602038',8,6),
('DHUD','2018602090',9,6),
('DHUD','2018602093',10,6),
('DHUD','2018602135',10,6),
('DHUD','2018602206',8,6),
('DHUD','2018602230',10,6),
('DHUD','2018602232',9,6),
('DHUD','2018602241',7,6),
('DHUD','2018602283',10,6),
('DHUD','2018602294',10,6),
('DHUD','2018602529',8,6),
('DHUD','2018602612',9,6),
('DHUD','2018602659',9,6),
('DHUD','2018602701',7,6),
('DHUD','2018602730',10,6),
('DHUD','2018602768',8,6),
('DHUD','2018602852',8,6),
('DHUD','2018602958',10,6),
('DHUD','2018602968',8,6),
('DHUD','2018602994',9,6),
('DHUD','2018603047',7,6),
('DHUD','2018603058',10,6),
('DHUD','2018603120',8,6),
('DHUD','2018603223',9,6),
('DHUD','2018603377',7,6),
('DHUD','2018603443',9,6),
('DHUD','2018603476',8,6),
('DHUD','2018603575',7,6),
('DHUD','2018603687',6,6),
('DHUD','2018604067',7,6),
('DHUD','2018604160',8,6),
('DHUD','2018604593',9,6),
('DHUD','2018604692',9,6),
('DHUD','2018604698',8,6),
('DHUD','2018604833',10,6),
('DHUD','2018605120',8,6)


insert into DiemThi values 
('XML','2018603147',9,6),
('XML','0841060248',10,6),
('XML','0841360080',7,6),
('XML','1041060321',9,6),
('XML','2017604748',8,6),
('XML','2017604991',6,6),
('XML','2018600641',9,6),
('XML','2018600683',10,6),
('XML','2018600803',9,6),
('XML','2018601134',7,6),
('XML','2018601253',9,6),
('XML','2018601284',9,6),
('XML','2018601630',7,6),
('XML','2018601796',8,6),
('XML','2018602038',6,6),
('XML','2018602090',10,6),
('XML','2018602093',8,6),
('XML','2018602135',7,6),
('XML','2018602206',9,6),
('XML','2018602230',7,6),
('XML','2018602232',10,6),
('XML','2018602241',9,6),
('XML','2018602283',7,6),
('XML','2018602294',6,6),
('XML','2018602529',9,6),
('XML','2018602612',7,6),
('XML','2018602659',7,6),
('XML','2018602701',9,6),
('XML','2018602730',8,6),
('XML','2018602768',6,6),
('XML','2018602852',10,6),
('XML','2018602958',8,6),
('XML','2018602968',9,6),
('XML','2018602994',7,6),
('XML','2018603047',6,6),
('XML','2018603058',8,6),
('XML','2018603120',7,6),
('XML','2018603223',7,6),
('XML','2018603377',7,6),
('XML','2018603443',8,6),
('XML','2018603476',7,6),
('XML','2018603575',9,6),
('XML','2018603687',8,6),
('XML','2018604067',9,6),
('XML','2018604160',10,6),
('XML','2018604593',8,6),
('XML','2018604692',7,6),
('XML','2018604698',9,6),
('XML','2018604833',8,6),
('XML','2018605120',6,6)


insert into DiemThi values 
('HCG','2018603147',9,7),
('HCG','0841060248',10,7),
('HCG','0841360080',7,7),
('HCG','1041060321',9,7),
('HCG','2017604748',8,7),
('HCG','2017604991',6,7),
('HCG','2018600641',9,7),
('HCG','2018600683',10,7),
('HCG','2018600803',9,7),
('HCG','2018601134',7,7),
('HCG','2018601253',9,7),
('HCG','2018601284',9,7),
('HCG','2018601630',7,7),
('HCG','2018601796',8,7),
('HCG','2018602038',6,7),
('HCG','2018602090',10,7),
('HCG','2018602093',8,7),
('HCG','2018602135',7,7),
('HCG','2018602206',9,7),
('HCG','2018602230',7,7),
('HCG','2018602232',10,7),
('HCG','2018602241',9,7),
('HCG','2018602283',7,7),
('HCG','2018602294',6,7),
('HCG','2018602529',9,7),
('HCG','2018602612',7,7),
('HCG','2018602659',7,7),
('HCG','2018602701',9,7),
('HCG','2018602730',8,7),
('HCG','2018602768',6,7),
('HCG','2018602852',10,7),
('HCG','2018602958',8,7),
('HCG','2018602968',9,7),
('HCG','2018602994',7,7),
('HCG','2018603047',6,7),
('HCG','2018603058',8,7),
('HCG','2018603120',7,7),
('HCG','2018603223',7,7),
('HCG','2018603377',7,7),
('HCG','2018603443',8,7),
('HCG','2018603476',7,7),
('HCG','2018603575',9,7),
('HCG','2018603687',8,7),
('HCG','2018604067',9,7),
('HCG','2018604160',10,7),
('HCG','2018604593',8,7),
('HCG','2018604692',7,7),
('HCG','2018604698',9,7),
('HCG','2018604833',8,7),
('HCG','2018605120',6,7)



insert into DiemThi values 
('LTW','2018603147',10,7),
('LTW','0841060248',9,7),
('LTW','0841360080',8,7),
('LTW','1041060321',7,7),
('LTW','2017604748',6,7),
('LTW','2017604991',7,7),
('LTW','2018600641',8,7),
('LTW','2018600683',9,7),
('LTW','2018600803',7,7),
('LTW','2018601134',10,7),
('LTW','2018601253',6,7),
('LTW','2018601284',8,7),
('LTW','2018601630',10,7),
('LTW','2018601796',9,7),
('LTW','2018602038',8,7),
('LTW','2018602090',9,7),
('LTW','2018602093',10,7),
('LTW','2018602135',10,7),
('LTW','2018602206',8,7),
('LTW','2018602230',10,7),
('LTW','2018602232',9,7),
('LTW','2018602241',7,7),
('LTW','2018602283',10,7),
('LTW','2018602294',10,7),
('LTW','2018602529',8,7),
('LTW','2018602612',9,7),
('LTW','2018602659',6,7),
('LTW','2018602701',7,7),
('LTW','2018602730',10,7),
('LTW','2018602768',8,7),
('LTW','2018602852',8,7),
('LTW','2018602958',10,7),
('LTW','2018602968',8,7),
('LTW','2018602994',9,7),
('LTW','2018603047',7,7),
('LTW','2018603058',10,7),
('LTW','2018603120',8,7),
('LTW','2018603223',9,7),
('LTW','2018603377',7,7),
('LTW','2018603443',9,7),
('LTW','2018603476',8,7),
('LTW','2018603575',7,7),
('LTW','2018603687',6,7),
('LTW','2018604067',7,7),
('LTW','2018604160',8,7),
('LTW','2018604593',9,7),
('LTW','2018604692',9,7),
('LTW','2018604698',8,7),
('LTW','2018604833',10,7),
('LTW','2018605120',8,7)

insert into DiemThi values 
('MNM','2018603147',null,8),
('MNM','0841060248',null,8),
('MNM','0841360080',null,8),
('MNM','1041060321',null,8),
('MNM','2017604748',null,8),
('MNM','2017604991',null,8),
('MNM','2018600641',null,8),
('MNM','2018600683',null,8),
('MNM','2018600803',null,8),
('MNM','2018601134',null,8),
('MNM','2018601253',null,8),
('MNM','2018601284',null,8),
('MNM','2018601630',null,8),
('MNM','2018601796',null,8),
('MNM','2018602038',null,8),
('MNM','2018602090',null,8),
('MNM','2018602093',null,8),
('MNM','2018602135',null,8),
('MNM','2018602206',null,8),
('MNM','2018602230',null,8),
('MNM','2018602232',null,8),
('MNM','2018602241',null,8),
('MNM','2018602283',null,8),
('MNM','2018602294',null,8),
('MNM','2018602529',null,8),
('MNM','2018602612',null,8),
('MNM','2018602659',null,8),
('MNM','2018602701',null,8),
('MNM','2018602730',null,8),
('MNM','2018602768',null,8),
('MNM','2018602852',null,8),
('MNM','2018602958',null,8),
('MNM','2018602968',null,8),
('MNM','2018602994',null,8),
('MNM','2018603047',null,8),
('MNM','2018603058',null,8),
('MNM','2018603120',null,8),
('MNM','2018603223',null,8),
('MNM','2018603377',null,8),
('MNM','2018603443',null,8),
('MNM','2018603476',null,8),
('MNM','2018603575',null,8),
('MNM','2018603687',null,8),
('MNM','2018604067',null,8),
('MNM','2018604160',null,8),
('MNM','2018604593',null,8),
('MNM','2018604692',null,8),
('MNM','2018604698',null,8),
('MNM','2018604833',null,8),
('MNM','2018605120',null,8)

insert into DiemThi values 
('TA','2018603147',null,6),
('TA','0841060248',null,6),
('TA','0841360080',null,6),
('TA','1041060321',null,6),
('TA','2017604748',null,6),
('TA','2017604991',null,6),
('TA','2018600641',null,6),
('TA','2018600683',null,6),
('TA','2018600803',null,6),
('TA','2018601134',null,6),
('TA','2018601253',null,6),
('TA','2018601284',null,6),
('TA','2018601630',null,6),
('TA','2018601796',null,6),
('TA','2018602038',null,6),
('TA','2018602090',null,6),
('TA','2018602093',null,6),
('TA','2018602135',null,6),
('TA','2018602206',null,6),
('TA','2018602230',null,6),
('TA','2018602232',null,6),
('TA','2018602241',null,6),
('TA','2018602283',null,6),
('TA','2018602294',null,6),
('TA','2018602529',null,6),
('TA','2018602612',null,6),
('TA','2018602659',null,6),
('TA','2018602701',null,6),
('TA','2018602730',null,6),
('TA','2018602768',null,6),
('TA','2018602852',null,6),
('TA','2018602958',null,6),
('TA','2018602968',null,6),
('TA','2018602994',null,6),
('TA','2018603047',null,6),
('TA','2018603058',null,6),
('TA','2018603120',null,6),
('TA','2018603223',null,6),
('TA','2018603377',null,6),
('TA','2018603443',null,6),
('TA','2018603476',null,6),
('TA','2018603575',null,6),
('TA','2018603687',null,6),
('TA','2018604067',null,6),
('TA','2018604160',null,6),
('TA','2018604593',null,6),
('TA','2018604692',null,6),
('TA','2018604698',null,6),
('TA','2018604833',null,6),
('TA','2018605120',null,6)


insert into DiemThi values
('NMT','2018603147',9,1),
('NMT','0841060248',8,1),
('NMT','0841360080',7,1),
('NMT','1041060321',6,1),
('NMT','2017604748',7,1),
('NMT','2017604991',8,1),
('NMT','2018600641',9,1),
('NMT','2018600683',8,1),
('NMT','2018600803',6,1),
('NMT','2018601134',8,1),
('NMT','2018601253',9,1),
('NMT','2018601284',7,1),
('NMT','2018601630',8,1),
('NMT','2018601796',7,1),
('NMT','2018602038',6,1),
('NMT','2018602090',7,1),
('NMT','2018602093',8,1),
('NMT','2018602135',8,1),
('NMT','2018602206',9,1),
('NMT','2018602230',8,1),
('NMT','2018602232',7,1),
('NMT','2018602241',8,1),
('NMT','2018602283',7,1),
('NMT','2018602294',7,1),
('NMT','2018602529',9,1),
('NMT','2018602612',8,1),
('NMT','2018602659',8,1),
('NMT','2018602701',9,1),
('NMT','2018602730',8,1),
('NMT','2018602768',7,1),
('NMT','2018602852',6,1),
('NMT','2018602958',9,1),
('NMT','2018602968',7,1),
('NMT','2018602994',8,1),
('NMT','2018603047',6,1),
('NMT','2018603058',9,1),
('NMT','2018603120',7,1),
('NMT','2018603223',7,1),
('NMT','2018603377',8,1),
('NMT','2018603443',7,1),
('NMT','2018603476',9,1),
('NMT','2018603575',8,1),
('NMT','2018603687',8,1),
('NMT','2018604067',9,1),
('NMT','2018604160',7,1),
('NMT','2018604593',6,1),
('NMT','2018604692',8,1),
('NMT','2018604698',7,1),
('NMT','2018604833',9,1),
('NMT','2018605120',6,1)

insert into DiemThi values 
('TCC1','2018603147',10,1),
('TCC1','0841060248',9,1),
('TCC1','0841360080',8,1),
('TCC1','1041060321',7,1),
('TCC1','2017604748',6,1),
('TCC1','2017604991',7,1),
('TCC1','2018600641',8,1),
('TCC1','2018600683',9,1),
('TCC1','2018600803',7,1),
('TCC1','2018601134',10,1),
('TCC1','2018601253',6,1),
('TCC1','2018601284',8,1),
('TCC1','2018601630',10,1),
('TCC1','2018601796',9,1),
('TCC1','2018602038',8,1),
('TCC1','2018602090',9,1),
('TCC1','2018602093',10,1),
('TCC1','2018602135',10,1),
('TCC1','2018602206',8,1),
('TCC1','2018602230',10,1),
('TCC1','2018602232',9,1),
('TCC1','2018602241',7,1),
('TCC1','2018602283',10,1),
('TCC1','2018602294',10,1),
('TCC1','2018602529',8,1),
('TCC1','2018602612',9,1),
('TCC1','2018602659',6,1),
('TCC1','2018602701',7,1),
('TCC1','2018602730',10,1),
('TCC1','2018602768',8,1),
('TCC1','2018602852',8,1),
('TCC1','2018602958',10,1),
('TCC1','2018602968',8,1),
('TCC1','2018602994',9,1),
('TCC1','2018603047',7,1),
('TCC1','2018603058',10,1),
('TCC1','2018603120',8,1),
('TCC1','2018603223',9,1),
('TCC1','2018603377',7,1),
('TCC1','2018603443',9,1),
('TCC1','2018603476',8,1),
('TCC1','2018603575',7,1),
('TCC1','2018603687',6,1),
('TCC1','2018604067',7,1),
('TCC1','2018604160',8,1),
('TCC1','2018604593',9,1),
('TCC1','2018604692',9,1),
('TCC1','2018604698',8,1),
('TCC1','2018604833',10,1),
('TCC1','2018605120',8,1)


insert into DiemThi values 
('TCC2','2018603147',9,2),
('TCC2','0841060248',10,2),
('TCC2','0841360080',7,2),
('TCC2','1041060321',9,2),
('TCC2','2017604748',8,2),
('TCC2','2017604991',6,2),
('TCC2','2018600641',9,2),
('TCC2','2018600683',10,2),
('TCC2','2018600803',9,2),
('TCC2','2018601134',7,2),
('TCC2','2018601253',9,2),
('TCC2','2018601284',9,2),
('TCC2','2018601630',7,2),
('TCC2','2018601796',8,2),
('TCC2','2018602038',6,2),
('TCC2','2018602090',10,2),
('TCC2','2018602093',8,2),
('TCC2','2018602135',7,2),
('TCC2','2018602206',9,2),
('TCC2','2018602230',7,2),
('TCC2','2018602232',10,2),
('TCC2','2018602241',9,2),
('TCC2','2018602283',7,2),
('TCC2','2018602294',6,2),
('TCC2','2018602529',9,2),
('TCC2','2018602612',7,2),
('TCC2','2018602659',7,2),
('TCC2','2018602701',9,2),
('TCC2','2018602730',8,2),
('TCC2','2018602768',6,2),
('TCC2','2018602852',10,2),
('TCC2','2018602958',8,2),
('TCC2','2018602968',9,2),
('TCC2','2018602994',7,2),
('TCC2','2018603047',6,2),
('TCC2','2018603058',8,2),
('TCC2','2018603120',7,2),
('TCC2','2018603223',7,2),
('TCC2','2018603377',7,2),
('TCC2','2018603443',8,2),
('TCC2','2018603476',7,2),
('TCC2','2018603575',9,2),
('TCC2','2018603687',8,2),
('TCC2','2018604067',9,2),
('TCC2','2018604160',10,2),
('TCC2','2018604593',8,2),
('TCC2','2018604692',7,2),
('TCC2','2018604698',9,2),
('TCC2','2018604833',8,2),
('TCC2','2018605120',6,2)


insert into DiemThi values 
('TRR','2018603147',10,2),
('TRR','0841060248',9,2),
('TRR','0841360080',8,2),
('TRR','1041060321',7,2),
('TRR','2017604748',6,2),
('TRR','2017604991',7,2),
('TRR','2018600641',8,2),
('TRR','2018600683',9,2),
('TRR','2018600803',7,2),
('TRR','2018601134',10,2),
('TRR','2018601253',6,2),
('TRR','2018601284',8,2),
('TRR','2018601630',10,2),
('TRR','2018601796',9,2),
('TRR','2018602038',8,2),
('TRR','2018602090',9,2),
('TRR','2018602093',10,2),
('TRR','2018602135',10,2),
('TRR','2018602206',8,2),
('TRR','2018602230',10,2),
('TRR','2018602232',9,2),
('TRR','2018602241',7,2),
('TRR','2018602283',10,2),
('TRR','2018602294',10,2),
('TRR','2018602529',8,2),
('TRR','2018602612',9,2),
('TRR','2018602659',9,2),
('TRR','2018602701',7,2),
('TRR','2018602730',10,2),
('TRR','2018602768',8,2),
('TRR','2018602852',8,2),
('TRR','2018602958',10,2),
('TRR','2018602968',8,2),
('TRR','2018602994',9,2),
('TRR','2018603047',7,2),
('TRR','2018603058',10,2),
('TRR','2018603120',8,2),
('TRR','2018603223',9,2),
('TRR','2018603377',7,2),
('TRR','2018603443',9,2),
('TRR','2018603476',8,2),
('TRR','2018603575',7,2),
('TRR','2018603687',6,2),
('TRR','2018604067',7,2),
('TRR','2018604160',8,2),
('TRR','2018604593',9,2),
('TRR','2018604692',9,2),
('TRR','2018604698',8,2),
('TRR','2018604833',10,2),
('TRR','2018605120',8,2)

insert into DangNhap values
('admin','admin'),
('GV01','12345')

select * from KhoaDaoTao
select * from Lop
select * from SinhVien
select * from MonHoc
select * from DiemThi
select * from DangNhap
