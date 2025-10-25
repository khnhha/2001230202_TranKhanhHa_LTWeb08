create database Sach
use Sach

create table ChuDe
(
	MaCD nchar(10) not null primary key,
	TenChuDe nvarchar(20)
)

create table NhaXuatBan
(
	MaNXB nchar(10) not null primary key,
	TenNXB nvarchar(50),
	Diachi nvarchar(30),
	Dienthoai nchar(12)
)

create table TacGia
(
	MaTG nchar(10) not null primary key,
	TenTG nvarchar(50) not null,
	DiachiTG nvarchar(30),
	DienthoaiTG nchar(12)
)

create table Sach
(
	MaSach nchar(10) not null primary key,
	TenSach nvarchar(30) not null,
	Giaban float,
	Mota nvarchar(500),
	Anhbia nchar(500),
	Ngaycapnhat date,
	MaCD nchar(10),
	MaNXB nchar(10),
	foreign key (MaCD) references ChuDe(MaCD),
	foreign key (MaNXB) references NhaXuatBan(MaNXB)
)
--drop table ChiTietDonHang
--drop table VietSach
--drop table Sach

create table VietSach
(
	MaSach nchar(10) not null,
	MaTG nchar(10) not null,
	Vaitro nvarchar(30),
	Vitri nvarchar(30),
	primary key (MaSach, MaTG),
	foreign key (MaSach) references Sach(MaSach),
	foreign key (MaTG) references TacGia(MaTG)
)

create table KhachHang
(
	MaKH nchar(10) not null primary key,
	HoTen nvarchar(50) not null,
	TaiKhoan nchar(30),
	MatKhau nchar(20),
	Email nchar(30),
	DiachiKH nvarchar(20),
	DienthoaiKH nchar(12),
	Ngaysinh date
)

create table DonDatHang
(
	MaDonHang nchar(10) not null primary key,
	Dathanhtoan nvarchar(20) not null,
	Tinhtranggiaohang nvarchar(20),
	Ngaydat date,
	Ngaygiao date,
	MaKH nchar(10) not null,
	foreign key (MaKH) references KhachHang(MaKH)
)

create table ChiTietDonHang
(
	MaDonHang nchar(10) not null,
	MaSach nchar(10) not null,
	SoLuong int,
	DonGia float,
	primary key (MaDonHang, MaSach),
	foreign key (MaDonHang) references DonDatHang(MaDonHang),
	foreign key (MaSach) references Sach(MaSach)
)

insert into ChuDe (MaCD, TenChuDe) values
('CD001', N'Tiểu thuyết'),
('CD002', N'Sách giáo khoa'),
('CD003', N'Truyện tranh')

insert into NhaXuatBan (MaNXB, TenNXB, Diachi, Dienthoai) values
('NXB001', N'Văn học', N'Hà Nội', null),
('NXB002', N'Kim Đồng', N'TP.HCM', null),
('NXB003', N'Chính trị Quốc gia', N'Hà Nội', null)

insert into TacGia (MaTG, TenTG, DiachiTG, DienthoaiTG) values
('TG001', N'Gabriel Garcia Márquez', N'Columbia', null),
('TG002', N'Emily Brontë', N'Anh', null),
('TG003', N' Akutami Gege', N'Nhật Bản', null),
('TG004', N'Vũ Trọng Phụng', N'Việt Nam', null),
('TG005', N'Nhiều tác giả', N'Việt Nam', null)


insert into Sach ( MaSach, TenSach, Giaban, Mota, Anhbia, Ngaycapnhat, MaCD, MaNXB) values
(
	'S001', 
	N'Trăm Năm Cô Đơn', 
	200000, 
	N'Trăm Năm Cô Đơn kể về số phận của gia đình Buendía qua bảy thế hệ, từ khi José Arcadio Buendía sáng lập Macondo đến khi hậu duệ cuối cùng của gia đình chứng kiến sự sụp đổ của nó. Nội dung chính của cuốn sách xoay quanh ba chủ đề lớn: vòng lặp của lịch sử, sự cô đơn của con người, và mối liên kết giữa thực tại và huyền thoại.', 
	'https://cdn1.fahasa.com/media/catalog/product/t/r/tram_nam_co_don-01.jpg',
	'2023-05-01',
	'CD001',
	'NXB001'
),
(
	'S002', 
	N'Đồi Gió Hú', 
	120000, 
	N'Cuốn tiểu thuyết khám phá sự hủy diệt do đam mê mãnh liệt, lòng căm thù và sự trả thù, kéo dài qua hai thế hệ, đồng thời phê phán rào cản giai cấp và các chuẩn mực xã hội thời bấy giờ. ', 
	'https://revelogue.com/wp-content/uploads/2020/08/doi-gio-hu-minh-hoa.jpg',
	'2024-10-21',
	'CD001',
	'NXB001'
),
(
	'S003', 
	N'Chú Thuật Hồi Chiến tập 19', 
	30000, 
	N'Sau khi “luật” mới được thêm vào Tử Diệt Hồi Du, Itadori và Fushiguro quyết định nhắm tới Higuruma Hiromi, người chơi đang nắm giữ 100 điểm. Nhưng khi đột nhập vào kết giới Tokyo số 1, họ bị tách nhau ra. Mỗi người đều có một trợ thủ và lên đường đến chỗ Higuruma..!', 
	'https://product.hstatic.net/200000122283/product/chu_thuat_hoi_chien_ban_dac_biet_bia_tap_19_cadb7a9aa9a1436f9a7793bcdba305c6_master.jpg',
	'2023-12-10',
	'CD003',
	'NXB002'
),
(
	'S004', 
	N'Tư tưởng Hồ Chí Minh', 
	60000, 
	N'Giáo trình thể hiện nhiều kết quả nghiên cứu mới về tư tưởng Hồ Chí Minh, gắn với các nội dung học tập và làm theo tư tưởng, đạo đức, phong cách Hồ Chí Minh.', 
	'https://cdn1.fahasa.com/media/catalog/product/s/_/s_-b1.jpg',
	'2025-02-03',
	'CD002',
	'NXB003'
),
(
	'S005', 
	N'Số đỏ', 
	55000, 
	N'Tiểu thuyết trào phúng của nhà văn Vũ Trọng Phụng, phơi bày sâu sắc những tệ nạn xã hội và sự giả tạo của tầng lớp thượng lưu trong bối cảnh Việt Nam những năm 1930-1945, qua cuộc đời tráo trở của nhân vật chính Xuân Tóc Đỏ.', 
	'https://cdn1.fahasa.com/media/catalog/product/s/_/s_-b1.jpg',
	'2025-08-15',
	'CD001',
	'NXB001'
)

insert into VietSach (MaTG, MaSach, Vaitro, Vitri) values
('TG001', 'S001', null, null),
('TG002', 'S002', null, null),
('TG003', 'S003', null, null),
('TG004', 'S005', null, null),
('TG005', 'S004', null, null)

insert into KhachHang(MaKH, HoTen, TaiKhoan, MatKhau, Email, DiachiKH, DienthoaiKH, Ngaysinh) values
('KH001', N'Trịnh Trần Phương Tuấn', 'Jack97', '123456789', null, N'TP.HCM', '0945378169', null),
('KH002', N'Nguyễn Bảo Khánh', 'BaoKhanh', '01010101', null, N'Hà Nội', '0947165849', null),
('KH003', N'Nguyễn Thiên An', 'ThienAnAn', '88888888', null, N'Vũng Tàu', '0813467518', null)

insert into DonDatHang (MaDonHang, Dathanhtoan, Tinhtranggiaohang, Ngaydat, Ngaygiao, MaKH) values
('DH001', N'Đã Thanh Toán', N'Đang giao', '2025-10-23', '2025-10-24', 'KH002'),
('DH002', N'Đã Thanh Toán', N'Đang chuẩn bị', '2025-10-24', null , 'KH001'),
('DH003', N'Đã Thanh Toán', N'Đã giao', '2025-10-20', '2025-10-22', 'KH003'),
('DH004', N'Chưa Thanh Toán', N'Đang chuẩn bị', '2025-10-25', null, 'KH003')

insert into ChiTietDonHang(MaDonHang, MaSach, SoLuong, DonGia) values
('DH001', 'S002', 1, 120000),
('DH002', 'S001', 2, 200000),
('DH003', 'S003', 1, 30000),
('DH004', 'S005', 1, 55000)
