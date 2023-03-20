--BASE DE DATOS BASICA INICIAL
create database digitalbankst

use digitalbankst

create table Usuarios(
Us_id int primary key identity(1,1) not null,
Us_nombre Varchar(100) not null,
Us_fech_nacimiento date not null,
Us_sexo Varchar(1) not null
);

--PROCEDIMIENTOS ALMACENADOS

	-- Procedimiento que consulta todos los registros
		CREATE PROCEDURE SP_Sel_US
		AS
		SELECT * FROM Usuarios order by Us_id desc;

        exec SP_Sel_US

	-- Procedimiento que Inserta un Registro
		CREATE PROCEDURE SP_Ins_US
		@Us_nombre varchar (100),
		@Us_fech_nacimiento date,
		@Us_sexo varchar (1)
		AS
		insert into Usuarios(Us_nombre,Us_fech_nacimiento,Us_sexo) 
		values (@Us_nombre,@Us_fech_nacimiento,@Us_sexo)

		exec SP_ins_US 'Diego','2023-03-14','m'

	-- Procedimiento que Actualiza el registro
		CREATE PROCEDURE SP_Upd_US
		@Us_id int,
		@Us_nombre varchar (100),
		@Us_fech_nacimiento date,
		@Us_sexo varchar (1)
		AS
		update Usuarios set 
		Us_nombre = @Us_nombre ,
		Us_fech_nacimiento = @Us_fech_nacimiento,
		Us_sexo = @Us_sexo
		where Us_id = @Us_id;

		exec SP_Upd_US '2','Diego2','2023-03-14','m'

		-- Procedimiento que elimina el registro
		CREATE PROCEDURE SP_Del_US
		@Us_id int
		AS
		delete from Usuarios WHERE Us_id = @Us_id

		exec SP_del_US '1'

		-- Procedimiento que consulta 1 de los registros
		CREATE PROCEDURE SP_Sel_US_id
		@Us_id int
		AS
		SELECT * FROM Usuarios where Us_id = @Us_id;

        exec SP_Sel_US_id '1'
