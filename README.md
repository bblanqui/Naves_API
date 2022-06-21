# Naves Softka API
Esta realizado para probar la creatividad del desarollador
El proyecto solucionas varias historias de usuario donde se requiere un manejo de inventario de las naves, permitir crear naves apartir de una nave maestra.
esta solucion esta creada y desplegada en C# con el framework asp.netcore 5
-----------------------------------------


pasos para la ejecución.

1 entrar a la url http://softka.somee.com/swagger/index.html
-----------------------------------------
2 existen 4 tipo de naves, el endpoint de post te pide tipo de nave debes pulsar de 1 a 4
-----------------------------------------
3 el servicio solo te va permitir crear solo 3 naves por tipo, es decir que si quiere crear una nave tipo volador 4 veces no te deja.
-----------------------------------------
4 el endpoint de buscar por caracteristica te permite ingresar un string y buscar todas la coincidencias posibles
-----------------------------------------
5 prueba y reporta tu error


CREAR DB EN SQL SERVER SCRIPT

script para crear la base de datos

-------------------------------
--db 



USE [master]
CREATE DATABASE [dbSofkaNaves]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbSofkaNaves_Data', FILENAME = N'c:\dzsqls\dbSofkaNaves.mdf' , SIZE = 8192KB , MAXSIZE = 30720KB , FILEGROWTH = 22528KB )
 LOG ON 
( NAME = N'dbSofkaNaves_Logs', FILENAME = N'c:\dzsqls\dbSofkaNaves.ldf' , SIZE = 8192KB , MAXSIZE = 30720KB , FILEGROWTH = 22528KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbSofkaNaves].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [dbSofkaNaves] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [dbSofkaNaves] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [dbSofkaNaves] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [dbSofkaNaves] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [dbSofkaNaves] SET ARITHABORT OFF 
GO

ALTER DATABASE [dbSofkaNaves] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [dbSofkaNaves] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [dbSofkaNaves] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [dbSofkaNaves] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [dbSofkaNaves] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [dbSofkaNaves] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [dbSofkaNaves] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [dbSofkaNaves] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [dbSofkaNaves] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [dbSofkaNaves] SET  ENABLE_BROKER 
GO

ALTER DATABASE [dbSofkaNaves] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [dbSofkaNaves] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [dbSofkaNaves] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [dbSofkaNaves] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [dbSofkaNaves] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [dbSofkaNaves] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [dbSofkaNaves] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [dbSofkaNaves] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [dbSofkaNaves] SET  MULTI_USER 
GO

ALTER DATABASE [dbSofkaNaves] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [dbSofkaNaves] SET DB_CHAINING OFF 
GO

ALTER DATABASE [dbSofkaNaves] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [dbSofkaNaves] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [dbSofkaNaves] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [dbSofkaNaves] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [dbSofkaNaves] SET QUERY_STORE = OFF
GO

ALTER DATABASE [dbSofkaNaves] SET  READ_WRITE 
GO




-- crear tablas




--tipo naves



USE [dbSofkaNaves]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_M_Tipo_Nave](
	[Id_Tipo_Nave] [int] IDENTITY(1,1) NOT NULL,
	[Descripción_Nave] [varchar](500) NULL,
 CONSTRAINT [PK_tbl_M_Tipo_Nave] PRIMARY KEY CLUSTERED 
(
	[Id_Tipo_Nave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO





--stock naves



USE [dbSofkaNaves]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_H_Stock](
	[Id_Stock] [int] IDENTITY(1,1) NOT NULL,
	[Tipo_Nave] [int] NULL,
	[Stock_Nave] [int] NOT NULL,
	[Id_Nave] [int] NOT NULL,
	[Fecha_Ocupación] [datetime] NULL,
 CONSTRAINT [PK_tbl_H_Stock] PRIMARY KEY CLUSTERED 
(
	[Id_Stock] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tbl_H_Stock]  WITH CHECK ADD  CONSTRAINT [FK_tbl_H_Stock_tbl_H_Naves] FOREIGN KEY([Id_Nave])
REFERENCES [dbo].[tbl_H_Naves] ([Id_Nave])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[tbl_H_Stock] CHECK CONSTRAINT [FK_tbl_H_Stock_tbl_H_Naves]
GO

ALTER TABLE [dbo].[tbl_H_Stock]  WITH CHECK ADD  CONSTRAINT [FK_tbl_H_Stock_tbl_M_Tipo_Nave] FOREIGN KEY([Tipo_Nave])
REFERENCES [dbo].[tbl_M_Tipo_Nave] ([Id_Tipo_Nave])
GO

ALTER TABLE [dbo].[tbl_H_Stock] CHECK CONSTRAINT [FK_tbl_H_Stock_tbl_M_Tipo_Nave]
GO





--Naves





USE [dbSofkaNaves]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_H_Naves](
	[Id_Nave] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Nave] [varchar](500) NULL,
	[Tipo_Nave] [int] NOT NULL,
	[Fecha_Creación] [datetime] NULL,
 CONSTRAINT [PK_tbl_H_Naves] PRIMARY KEY CLUSTERED 
(
	[Id_Nave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tbl_H_Naves]  WITH CHECK ADD  CONSTRAINT [FK_tbl_H_Naves_tbl_M_Tipo_Nave] FOREIGN KEY([Tipo_Nave])
REFERENCES [dbo].[tbl_M_Tipo_Nave] ([Id_Tipo_Nave])
GO

ALTER TABLE [dbo].[tbl_H_Naves] CHECK CONSTRAINT [FK_tbl_H_Naves_tbl_M_Tipo_Nave]
GO


















