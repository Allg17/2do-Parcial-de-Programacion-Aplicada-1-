create database AplicadaSegundoParcials
use AplicadaSegundoParcials


create table Personas
(
	IdPersonas int primary key identity(1,1),
	Nombre varchar(MAX),
	Fecha date

);

create table Telefonos
(
	IdTelefono int primary key identity(1,1),
	TipodeTelefono varchar(MAX),
	Telefono varchar(MAX),
	IdPersonas int
);

create table TipoTelefonoes
(
	IdTipoTelefono int primary key identity(1,1),
	TipoTelefonos varchar(MAX)
);


insert into Tipotelefonoes(TipoTelefonos) values('Celular')
insert into Tipotelefonoes(TipoTelefonos) values('Casa')
insert into Tipotelefonoes(TipoTelefonos) values('Trabajo')

select * from Telefonos