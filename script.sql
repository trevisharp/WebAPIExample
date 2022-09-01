use master
go

if exists(select * from sys.databases where name = 'RedeSocial')
	drop database RedeSocial
go

create database RedeSocial
go

use RedeSocial
go

create table Usuario(
	ID int identity primary key,
	Email varchar(150) not null,
	Senha varchar(MAX) not null,
	CPF bigint not null,
	CEP int not null
);
go