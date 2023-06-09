USE [digitalbankst]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 19/03/2023 21:41:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Us_id] [int] IDENTITY(1,1) NOT NULL,
	[Us_nombre] [varchar](100) NOT NULL,
	[Us_fech_nacimiento] [datetime] NOT NULL,
	[Us_sexo] [varchar](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Us_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SP_Del_US]    Script Date: 19/03/2023 21:41:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Del_US]
		@Us_id int
		AS
		delete from Usuarios WHERE Us_id = @Us_id
GO
/****** Object:  StoredProcedure [dbo].[SP_Ins_US]    Script Date: 19/03/2023 21:41:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Ins_US]
		@Us_nombre varchar (100),
		@Us_fech_nacimiento date,
		@Us_sexo varchar (1)
		AS
		insert into Usuarios(Us_nombre,Us_fech_nacimiento,Us_sexo) 
		values (@Us_nombre,@Us_fech_nacimiento,@Us_sexo)
GO
/****** Object:  StoredProcedure [dbo].[SP_Sel_US]    Script Date: 19/03/2023 21:41:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Sel_US]
		AS
		SELECT * FROM Usuarios order by Us_id desc;
GO
/****** Object:  StoredProcedure [dbo].[SP_Sel_US_id]    Script Date: 19/03/2023 21:41:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Sel_US_id]
		@Us_id int
		AS
		SELECT * FROM Usuarios where Us_id = @Us_id;
GO
/****** Object:  StoredProcedure [dbo].[SP_Upd_US]    Script Date: 19/03/2023 21:41:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [dbo].[SP_Upd_US]
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
GO
