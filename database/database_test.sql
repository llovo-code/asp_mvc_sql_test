create database test_aspnet
go
use  test_aspnet
go

create table Categoria_Articulo(
IdCategoria int identity (1,1) primary key not null,
Codigo_Categoria nvarchar (25), 
Nombre_Categoria nvarchar(125)
)

go
create table Articulos(
IdArticulo int primary key identity(1,1) not null,
Codigo nvarchar(25),
Descripcion nvarchar(255),
IdCategoria int foreign key references Categoria_Articulo(IdCategoria),
Precio float
)
go
create table Clientes (
IdCliente int primary key identity(1,1) not null,
Codigo_Cliente nvarchar(25),
PN_Cliente nvarchar(25) not null,
SN_Cliente nvarchar(25),
PA_Cliente nvarchar(25)not null,
SA_Cliente nvarchar(25),
)
go
create table Pedido(
IdPedido int primary key identity(1,1) not null,
NumeroPedido nvarchar(50),
FechaPedido datetime, 
IdCliente int foreign key references Clientes(IdCliente),
TerminoPago nvarchar(50),
TotalPedido float
)

go
create table Lineas_de_Pedido(

IdLineaDePedido int primary key identity (1,1),
IdPedido int foreign key references Pedido(IdPedido),
IdArticlo int foreign key references Articulos(IdArticulo),
CantidadPedido int,
Precio float,
SubTotal float 
)


select * from Categoria_Articulo
go
--Insecion de Cliente
create proc AddCliente
@CodCliente nvarchar(25),
@PN nvarchar (25),
@SN nvarchar (25),
@PA nvarchar (25),
@SA nvarchar (25)
as 
declare @CodC as int 
set @CodC = (select Codigo_Cliente from Clientes where Codigo_Cliente = @CodCliente)

if(@CodCliente = '' or @PN = '' or @SN = '')
	begin
		print 'Los Campos Codigo Cliente, Primer Nombre y Primer Apellido no pueden estar vacios'
	end
else 
	begin
		if (@CodC = @CodCliente)
			begin
				print 'Cliente ya existe en la db'
			end
		else 
			begin 
				insert into Clientes values (@CodCliente,@PN,@SN,@PA,@SA)
			end
	end

exec AddCliente '0000123','Franciso','Javier','Morazan','Treminio'

--Vista para Clientes
go
create view ListCliente as 
select IdCliente as [ID],Codigo_Cliente as [Codigo],PN_Cliente +' '+SN_Cliente +' '+PA_Cliente+' '+SA_Cliente as [Cliente] from Clientes

--SP Lista Cliente
go
create proc ListarClientes
as 
select * from ListCliente

--#####################################################################################
declare @as as int
set @as= (select IdCategoria from Categoria_Articulo where Codigo_Categoria = 'AC2563')
if (@as is null)
	begin 
	print '-1'
	end
else
	begin
		print '-2'
	end
insert into Categoria_Articulo values ('AC2561','Accesorios de Computadora'),
									  ('PC2185','Computadoras'),
									  ('PRN258','Impresoras')
go
create proc AddArticulo 
@Codigo_Arc as nvarchar(25),
@Descp as nvarchar(255),
@CodCat as nvarchar(25),
@Precio  as float
as
declare @Cod as nvarchar(25)
declare @IdC as int 
set @Cod = (Select Codigo from Articulos where Codigo = @Codigo_Arc)
set @IdC = (Select IdCategoria from Categoria_Articulo where Codigo_Categoria = @CodCat)

if (@IdC is null)
	begin 
		set @IdC = -1
	end
if( @Codigo_Arc = '' or @Descp = '' or @CodCat = '' or @Precio = '')
	begin
		print 'Rellene todos los Campos ' 
	end
else 
	begin 
		if (@Precio < 0)
			begin 
				print 'El precio del Articulo debe ser mayor a -1'
			end
		else
			begin
				if(@Codigo_Arc = @Cod)
					begin 
						print 'Articulo ya existe en la base de datos'
					end
				else
					begin
						if(@IdC >0)
							begin
								insert into Articulos values (@Codigo_Arc,@Descp,@IdC,@Precio)
								

							end
						else
							begin
								print 'Categoria no existe'
							end
					end
			end
	end

go

exec AddArticulo 'ALMG198','ALMOHADILLA GAMER MP6051GN UNNO TEKNO','AC2561','2.25'
exec AddArticulo 'ALMG2698','ALMOHADILLA ARG-AC-1226BK GAMER','AC2561',5.95
exec AddArticulo 'ALMG2699','ALMOHADILLA ARG-AC-1227BK GAMER','AC2561',8.95

update Articulos set Codigo = 'ALMG2895',
					Descripcion = 'ALMOHADILLA XTA-200 C/ILUMINACION LED XTECH',
					Precio = 19.50
					where IdArticulo = 3


go

alter view ListArticulos as 
select IdArticulo as [ID], art.Codigo as [Codigo Articulo], art.Descripcion as [Descripcion],
ca.Codigo_Categoria as [Codigo Categoria],ca.Nombre_Categoria as [Nombre Categoria], art.Precio as [Precio]
from Articulos as art
inner join Categoria_Articulo as ca on art.IdCategoria = ca.IdCategoria

go
create proc ListarArticulos 
as 
select * from ListArticulos


exec ListarArticulos

select * from Pedido
select * from Lineas_de_Pedido