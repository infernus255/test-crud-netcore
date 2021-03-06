USE [master]
GO
/****** Object:  Database [test-crud]    Script Date: 4/22/2022 4:58:11 PM ******/
CREATE DATABASE [test-crud]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'test-crud', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\test-crud.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'test-crud_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\test-crud_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [test-crud] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [test-crud].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [test-crud] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [test-crud] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [test-crud] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [test-crud] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [test-crud] SET ARITHABORT OFF 
GO
ALTER DATABASE [test-crud] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [test-crud] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [test-crud] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [test-crud] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [test-crud] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [test-crud] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [test-crud] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [test-crud] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [test-crud] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [test-crud] SET  DISABLE_BROKER 
GO
ALTER DATABASE [test-crud] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [test-crud] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [test-crud] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [test-crud] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [test-crud] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [test-crud] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [test-crud] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [test-crud] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [test-crud] SET  MULTI_USER 
GO
ALTER DATABASE [test-crud] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [test-crud] SET DB_CHAINING OFF 
GO
ALTER DATABASE [test-crud] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [test-crud] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [test-crud] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [test-crud] SET QUERY_STORE = OFF
GO
USE [test-crud]
GO
/****** Object:  Table [dbo].[tGenero]    Script Date: 4/22/2022 4:58:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tGenero](
	[cod_genero] [int] IDENTITY(1,1) NOT NULL,
	[txt_desc] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_genero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tGeneroPelicula]    Script Date: 4/22/2022 4:58:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tGeneroPelicula](
	[cod_pelicula] [int] NOT NULL,
	[cod_genero] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_pelicula] ASC,
	[cod_genero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tPelicula]    Script Date: 4/22/2022 4:58:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tPelicula](
	[cod_pelicula] [int] IDENTITY(1,1) NOT NULL,
	[txt_desc] [varchar](500) NULL,
	[cant_disponibles_alquiler] [int] NULL,
	[cant_disponibles_venta] [int] NULL,
	[precio_alquiler] [numeric](18, 2) NULL,
	[precio_venta] [numeric](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_pelicula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tRol]    Script Date: 4/22/2022 4:58:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tRol](
	[cod_rol] [int] IDENTITY(1,1) NOT NULL,
	[txt_desc] [varchar](500) NULL,
	[sn_activo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tSeguridad]    Script Date: 4/22/2022 4:58:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tSeguridad](
	[cod_seguridad] [int] IDENTITY(1,1) NOT NULL,
	[txt_user] [varchar](50) NOT NULL,
	[txt_nombre] [varchar](200) NOT NULL,
	[txt_apellido] [varchar](200) NOT NULL,
	[txt_password] [varchar](50) NOT NULL,
	[cod_rol] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_seguridad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tUsers]    Script Date: 4/22/2022 4:58:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tUsers](
	[cod_usuario] [int] IDENTITY(1,1) NOT NULL,
	[txt_user] [varchar](50) NULL,
	[txt_password] [varchar](50) NULL,
	[txt_nombre] [varchar](200) NULL,
	[txt_apellido] [varchar](200) NULL,
	[nro_doc] [varchar](50) NULL,
	[cod_rol] [int] NULL,
	[sn_activo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tGeneroPelicula]  WITH CHECK ADD  CONSTRAINT [fk_genero_pelicula] FOREIGN KEY([cod_pelicula])
REFERENCES [dbo].[tPelicula] ([cod_pelicula])
GO
ALTER TABLE [dbo].[tGeneroPelicula] CHECK CONSTRAINT [fk_genero_pelicula]
GO
ALTER TABLE [dbo].[tGeneroPelicula]  WITH CHECK ADD  CONSTRAINT [fk_pelicula_genero] FOREIGN KEY([cod_genero])
REFERENCES [dbo].[tGenero] ([cod_genero])
GO
ALTER TABLE [dbo].[tGeneroPelicula] CHECK CONSTRAINT [fk_pelicula_genero]
GO
ALTER TABLE [dbo].[tSeguridad]  WITH CHECK ADD  CONSTRAINT [fk_security_rol] FOREIGN KEY([cod_rol])
REFERENCES [dbo].[tRol] ([cod_rol])
GO
ALTER TABLE [dbo].[tSeguridad] CHECK CONSTRAINT [fk_security_rol]
GO
ALTER TABLE [dbo].[tUsers]  WITH CHECK ADD  CONSTRAINT [fk_user_rol] FOREIGN KEY([cod_rol])
REFERENCES [dbo].[tRol] ([cod_rol])
GO
ALTER TABLE [dbo].[tUsers] CHECK CONSTRAINT [fk_user_rol]
GO
USE [master]
GO
ALTER DATABASE [test-crud] SET  READ_WRITE 
GO
