use master
go

create database QLSANPHAM

use QLSANPHAM
go

create table HANG
(
	MaHang nvarchar(10) primary key not null,
	TenHang nvarchar(25),
	SoLuong int,
	DonGia money,
	NgayNhap date
)
create table SinhVien
(
	MaSV nvarchar(10) primary key not null,
	HoTen nvarchar(25),
	NgaySinh date,
	GioiTinh int,
	SoDT nvarchar(25)
)

insert SinhVien values('S01', 'Pham Van Thang', '1/1/2021', 1, '1256789')

insert HANG values('H01', 'Banh Ran', 1000, 2000, '1/1/2021')
insert HANG values('H02', 'Banh Chuoi', 450, 10000, '8/3/2021')
insert HANG values('H03', 'Banh My', 600, 5000, '9/2/2021')

select * from HANG