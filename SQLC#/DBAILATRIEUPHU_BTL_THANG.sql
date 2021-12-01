use master
go

create database DBAILATRIEUPHU

use DBAILATRIEUPHU
go

create table CAPDO1
(
	maCauHoi varchar(10) primary key not null,
	noiDungCauHoi nvarchar(100),
	dapAnA nvarchar(50),
	dapAnB nvarchar(50),
	dapAnC nvarchar(50),
	dapAnD nvarchar(50),
	dapAnDung nvarchar(50),
	chuThich nvarchar(200)
)

create table CAPDO2
(
	maCauHoi varchar(10) primary key not null,
	noiDungCauHoi nvarchar(100),
	dapAnA nvarchar(50),
	dapAnB nvarchar(50),
	dapAnC nvarchar(50),
	dapAnD nvarchar(50),
	dapAnDung nvarchar(50),
	chuThich nvarchar(200)
)

create table CAPDO3
(
	maCauHoi varchar(10) primary key not null,
	noiDungCauHoi nvarchar(100),
	dapAnA nvarchar(50),
	dapAnB nvarchar(50),
	dapAnC nvarchar(50),
	dapAnD nvarchar(50),
	dapAnDung nvarchar(50),
	chuThich nvarchar(200)
)

create table TAIKHOAN
(
	tenDangNhap varchar(20) primary key not null,
	matKhau varchar(20) not null,
	tenNguoiChoi nvarchar(30) not null,
	maxCauHoi int,
	sumTienThuong int
)
