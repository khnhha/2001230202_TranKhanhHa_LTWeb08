create table Theloaitin
(
	IDLoai int not null primary key,
	Tentheloai nvarchar(100) not null
)
create table Tintuc
(
	IdTin int not null primary key,
	IDLoai int not null,
	Tieudetin nvarchar(100),
	Noidungtin nText,
	foreign key (IDLoai) references Theloaitin(IDLoai)
)
insert into Theloaitin (IDLoai, Tentheloai) values
(1, N'Th? thao'),
(2, N'Kinh t?'),
(3, N'Th? gi?i')