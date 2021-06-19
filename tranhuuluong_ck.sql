create database TRANHUULUONGDB
use TRANHUULUONGDB
create table UserAccount(
	ID int IDENTITY(1,1),
	UserName varchar(20),
	Password varchar(100) not null,
	Status nvarchar(50) not null,
	primary key(UserName)
)
create table Category(
	CategoryID varchar(50),
	Name nvarchar(20),
	Description nvarchar(250),
	primary key(CategoryID)
)
insert into Category(CategoryID,Name,Description)
values('DH','casio','casio')
create table Product(
	ID int primary key,
	Name nvarchar(250),
	UnitCost decimal(15,0),
	Quantity int,
	Image nvarchar(250),
	Description nvarchar(250),
	Status nvarchar(50),
	CategoryID varchar(50),
	constraint FK_Categorryid foreign key(CategoryID) references Category(CategoryID)

)
insert into Product(ID,Name,UnitCost,Quantity,CategoryID)
values(1,'Dong Ho Casio',20000000,1,'DH')

insert into UserAccount(UserName,Password,Status)
values('admin','21232f297a57a5a743894a0e4a801fc3','active')
UPDATE UserAccount
SET Password = 'kuluong2000'
WHERE UserName ='kuluong2000';

