create database AplicadaSegundoParcials
use AplicadaSegundoParcials


create table Personas
(
	IdPersonas int primary key identity(1,1),
	Nombre varchar(30),
	Fecha date

);

create table Telefonos
(
	IdTelefono int primary key identity(1,1),
	TipodeTelefono varchar(10),
	Telefono varchar(30),
	IdPersonas int
);

create table TipoTelefonoes
(
	IdTipoTelefono int primary key identity(1,1),
	TipoTelefonos varchar(15)
);


insert into Tipotelefonoes(TipoTelefonos) values('Celular')
insert into Tipotelefonoes(TipoTelefonos) values('Casa')
insert into Tipotelefonoes(TipoTelefonos) values('Trabajo')

select * from Telefonos