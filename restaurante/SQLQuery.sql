create table [dbo].[Restaurante](
	[restId] [int] IDENTITY (1,1) NOT NULL,
	[restName] [varchar] (100) DEFAULT '',
	PRIMARY KEY (restId)
	)


create table [dbo].[Prato](
	[pratoId] [int] IDENTITY(1,1) NOT NULL,
	[restId] [int] NOT NULL, 
	[pratoName] [varchar] (100) NOT NULL,
	[pratoPreco] [float] NOT NULL,
	PRIMARY KEY (pratoId)
	)


alter table [dbo].[Prato] with check add foreign key ([restId])
references [dbo].[Restaurante] ([restId])
go

insert into Restaurante
(restName)
values ('Restaurante 1')

insert into Restaurante 
(restName)
values ('Restaurante 2')

insert into Restaurante 
(restName)
values ('Restaurante 3')

select * from Restaurante

insert into Prato
(restId, PratoName, PratoPreco)
values (1, 'prato 1', '20.00')

insert into Prato
(restId, PratoName, PratoPreco)
values (1, 'prato 2', '25.00')

insert into Prato
(restId, pratoName, pratoPreco)
values (2, 'prato 3', '30.50')



alter table [dbo].[Prato] with check add foreign key ([restId])
references [dbo].[Restaurante] ([restId])
on delete cascade
go


insert into Restaurante
(restName)
values ('Restaurante 1')

insert into Restaurante 
(restName)
values ('Restaurante 2')

insert into Restaurante 
(restName)
values ('Restaurante 3')


insert into Prato
(restId, PratoName, PratoPreco)
values (1, 'prato 1', '20.00')

insert into Prato
(restId, PratoName, PratoPreco)
values (1, 'prato 2', '25.00')

insert into Prato
(restId, pratoName, pratoPreco)
values (2, 'prato 3', '30.50')




