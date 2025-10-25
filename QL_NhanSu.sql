﻿create database QL_NhanSu
use QL_NhanSu

create table tbl_Deparment
(
	DepId int primary key,
	DepName nvarchar(40)
)

create table tbl_Employee
(
	Id int primary key,
	EmployName nvarchar(50),
	Gender nvarchar(5),
	City nvarchar(20),
	DepId int,
	foreign key (DepId) references tbl_Deparment(DepId) 
)

insert into tbl_Deparment(DepId, DepName) values
(1, N'Khoa CNTT'),
(2, N'Khoa Ngoại Ngữ'),
(3, N'Khoa Tài Chính'),
(4, N'Khoa Thực Phẩm'),
(5, N'Phòng Đào Tạo');

insert into tbl_Employee(Id, EmployName, Gender, City, DepId) values
(1, N'Nguyễn Hải Yến', N'Nữ', N'Đà Lạt', 1),
(2, N'Trương Mạnh Hùng', N'Nam', N'TP.HCM', 1),
(3, N'Đinh Duy Minh', N'Nam', N'Thái Bình', 2),
(4, N'Ngô Thị Nguyệt', N'Nữ', N'Long An', 2),
(5, N'Đào Minh Châu', N'Nữ', N'Bạc Liêu', 3),
(14, N'Phan Thị Ngọc Mai', N'Nữ', N'Bến Tre', 3),
(15, N'Trương Nguyễn Quỳnh Anh', N'Nữ', N'TP.HCM', 4),
(16, N'Lê Thanh Liêm', N'Nam', N'TP.HCM', 4);
