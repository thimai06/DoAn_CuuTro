create database DB_Cuutro
go
use DB_Cuutro
go
--drop database DB_Cuutro
--
create table Role_Type(
	ID_type varchar(2) not null primary key,
	Name_role nvarchar(100) not null,
	)
go
create table Pesonal(
	ID_user varchar(255)primary key not null,
	ID_type varchar(2) FOREIGN KEY REFERENCES Role_Type(ID_type) default '5',
	Personal_name nvarchar(255) ,
	char(12) unique,
	Address nvarchar(250),
	Gender nvarchar(3),
	Phone char(10),
	password varchar(255) not null,
	status varchar(10)
)
---------------------
go
create  table Relief_classification(
	ID_rc varchar(10) primary key not null,
	Description nvarchar(250) not null
)
go

--huyện
create table District(
	ID_district varchar(10) primary key not null,	
	Name_district nvarchar(255),
	)
go
-----------------------
-- phường/ xã
create table Ward(
	ID_ward varchar(10) primary key not null,	
	ID_district varchar(10) FOREIGN KEY (ID_district) REFERENCES District (ID_district) ,
	Name_ward nvarchar(255) not null,	

	)
	
--
go 
--danh mục
create table categorize(
	ID_cate varchar(10) primary key not null,
	Name_cate nvarchar(255) not null
)
go 
-- dot cứu trợ
create table Relief(
	ID_relieft INT IDENTITY(1,1) PRIMARY KEY,
	ID_rc varchar(10)not null,
	ID_ward varchar(10) not null ,
	Time_sent_post datetime DEFAULT GETDATE(),
	Content nvarchar(max) ,
	Content_thank nvarchar(max) ,
	Title nvarchar(255) not null,
	Description nvarchar(max),
	Start_date date DEFAULT GETDATE(),
	End_date date ,
	map varchar(255) ,
	note varchar(255),
	status varchar(255)
	--khóa ngoại	
	CONSTRAINT fk_xa FOREIGN KEY (ID_ward) REFERENCES Ward(ID_ward),		
	CONSTRAINT fk_rc FOREIGN KEY (ID_rc) REFERENCES Relief_classification(ID_rc)
	
)
-- minh chứng
create table Proof(
	ID_proof INT IDENTITY(1,1) PRIMARY KEY,
	ID_relieft int FOREIGN KEY REFERENCES Relief(ID_relieft),
	Link varchar(255) ,
	Type nvarchar(255) 
)
go 
-- phiếu đăng kí
create table Registration_form(
	ID_re INT IDENTITY(1,1) PRIMARY KEY,
	ID_user varchar(255) not null,
	ID_relieft int not null,
	Status nvarchar(255),
	CONSTRAINT fk_usrf FOREIGN KEY (ID_user) REFERENCES Pesonal(ID_user),
	CONSTRAINT fk_re FOREIGN KEY (ID_relieft) REFERENCES Relief(ID_relieft)
)
go 
create table Product(
	ID_product varchar(10) primary key not null,
	ID_cate varchar(10) FOREIGN KEY REFERENCES categorize(ID_cate),
	Name_product nvarchar(255) not null
)
go
-------

create table Details_registration(
	ID_product varchar(10),
	ID_re int,
	Quantity int not null,
	
	CONSTRAINT fk_pr FOREIGN KEY (ID_product) REFERENCES Product(ID_product),
	CONSTRAINT fk_redt FOREIGN KEY (ID_re) REFERENCES Registration_form (ID_re)
)
-- phiếu nhập
create table Receipt(
	ID_receipt INT IDENTITY(1,1) PRIMARY KEY,
	ID_relieft int FOREIGN KEY REFERENCES Relief(ID_relieft),
	ID_user varchar(255) FOREIGN KEY REFERENCES Pesonal(ID_user),
	Date date DEFAULT GETDATE(),
	Nguoitang nvarchar(255) 
)
go
create table Details_receipt(
	ID_receipt int ,
	ID_product varchar(10) ,
	Quantity int not null,
	CONSTRAINT fk_dtrc FOREIGN KEY (ID_receipt) REFERENCES Receipt(ID_receipt),
	CONSTRAINT dtpr FOREIGN KEY (ID_product) REFERENCES Product (ID_product)
)

----
-- insert data
insert into Role_Type
Values  ('1',N'Root'),
		('2',N'Thành phố'),
		('3',N'Huyện'),
		('4', N'Phường'),
		('5','Khách')
--
insert into Pesonal
values	('tuan.nhm','5',N'Nguyễn Hữu Minh Tuấn','206390601234',N'Quảng Nam',N'Nam','0795599636','@Minhtuan1806','1'),
		('my.ttt','5',N'Trần Thị Thanh My','206111101234',N'Hà Nội',N'Nữ','0795590636','@Minhtuan1806','1'),
		('khong.vth','1',N'Võ Tấn Hoàng Không','202222601234',N'Hà Nội',N'Nữ','0795519636','@Thimai1806','1'),
		('thinh.nt','5',N'Nguyễn Tấn Thịnh','206390602234',N'Hà Nội',N'Nam','0795592636','@Minhtuan1806','1'),
		('ngoc.ltb','5',N'Lương Thị Bảo Ngọc','206390111234',N'Đà Nẵng',N'Nữ','0795399636','@Minhtuan1806','1'),
		('anh.tt','5',N'Tạ Trường Anh','216390111234',N'Bình Định',N'nam','0795399636','@Minhtuan1806','1')
--


insert into categorize
values	('AQ',N'Áo Quần'),
	    ('T', N'Tiền'),
	    ('TP',N'Thực Phẩm')

--
insert into Product
values  ('11','AQ',N'Quần áo'),
		('12','TP',N'Bánh mỳ'),
		('13','TP',N'Cá hộp'),
		('14','TP','Cam'),
		('15','T',N'Tiền')
--


insert into District
values ('DBa',N'Điện Bàn'),
		('DLo',N'Đại Lộc')

insert into Ward
values ('DAn','DBa',N'Điện An'),
		('DNg','DBa',N'Điện Ngọc'),
		('DNaT','DBa',N'Điện Nam Trung'),
		('DaAn','DLo',N'Đại An'),
		('DaCu','DLo',N'Đại Cường'),
		('DaHo','DLo',N'Đại Hồng')
--
insert into Relief_classification
values	('CTTT','Thiên tai'),
		('CTDB','Bịch bệnh'),
		('CTGD','Gia đình khó khăn')

delete Relief
insert into Relief(ID_rc,ID_ward,Content,Content_thank,Title,
			Description,Start_date,End_date,map,note,status)
values	('CTTT','DAn',N'nội dung của bài post cứu trợ',null,N'Cứu trợ bão lũ Điện Bàn'
		,N'thì vậy đó','2022-06-18','2022-07-18',null,null,'1'),

		('CTDB','DNg',N'nội dung của bài post cứu trợ 123',null,N'Cứu trợ bão lũ Điện Bàn'
		,N'thì vậy đó','2022-06-18','2022-07-01',null,null,'1'),
		 
		('CTTT','DaCu',N'nội dung của bài post cứu trợ 456',null,N'Cứu trợ bão lũ Đại Lộc'
		,N'thì vậy đó','2022-06-20','2022-07-18',null,null,'1')
delete Receipt
insert into Receipt(ID_relieft,ID_user,Date,Nguoitang)
values (1,'khong.vth',null,null),
		(1,'khong.vth',null,null),
		(2,'khong.vth',null,null)

insert into Details_receipt
values (1,11,40),
		(1,12,40),
		(1,13,30),
		(2,11,40),
		(2,14,20),
		(3,11,40),
		(3,12,20),
		(3,13,40)
insert into Registration_form (ID_user,ID_relieft,status)
values ('anh.tt',1,'1'),
		('tuan.nhm',1,'1'),
		('thinh.nt',2,'1')
insert into Details_registration
values	(11,1,10),
		(12,1,20),
		(13,1,40),
		(14,2,10),
		(12,2,20),
		(13,2,40),
		(11,3,10),
		(12,3,10),
		(13,3,50),
		(14,3,10)		