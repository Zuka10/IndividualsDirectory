CREATE DATABASE [IndividualsDirectoryDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'IndividualsDirectoryDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\IndividualsDirectoryDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'IndividualsDirectoryDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\IndividualsDirectoryDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [IndividualsDirectoryDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IndividualsDirectoryDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [IndividualsDirectoryDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [IndividualsDirectoryDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [IndividualsDirectoryDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [IndividualsDirectoryDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [IndividualsDirectoryDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [IndividualsDirectoryDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [IndividualsDirectoryDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [IndividualsDirectoryDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [IndividualsDirectoryDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [IndividualsDirectoryDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [IndividualsDirectoryDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [IndividualsDirectoryDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [IndividualsDirectoryDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [IndividualsDirectoryDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [IndividualsDirectoryDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [IndividualsDirectoryDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [IndividualsDirectoryDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [IndividualsDirectoryDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [IndividualsDirectoryDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [IndividualsDirectoryDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [IndividualsDirectoryDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [IndividualsDirectoryDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [IndividualsDirectoryDB] SET RECOVERY FULL 
GO
ALTER DATABASE [IndividualsDirectoryDB] SET  MULTI_USER 
GO
ALTER DATABASE [IndividualsDirectoryDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [IndividualsDirectoryDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [IndividualsDirectoryDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [IndividualsDirectoryDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [IndividualsDirectoryDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [IndividualsDirectoryDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'IndividualsDirectoryDB', N'ON'
GO
ALTER DATABASE [IndividualsDirectoryDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [IndividualsDirectoryDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [IndividualsDirectoryDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/17/2025 1:00:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 3/17/2025 1:00:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persons]    Script Date: 3/17/2025 1:00:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Gender] [int] NOT NULL,
	[PersonalNumber] [varchar](11) NOT NULL,
	[BirthDate] [datetime2](7) NOT NULL,
	[CityId] [int] NOT NULL,
	[ImagePath] [nvarchar](500) NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhoneNumbers]    Script Date: 3/17/2025 1:00:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhoneNumbers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NumberType] [int] NOT NULL,
	[Number] [nvarchar](50) NOT NULL,
	[PersonId] [int] NOT NULL,
 CONSTRAINT [PK_PhoneNumbers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RelatedIndividuals]    Script Date: 3/17/2025 1:00:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelatedIndividuals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Relationship] [int] NOT NULL,
	[PersonId] [int] NOT NULL,
	[RelatedPersonId] [int] NOT NULL,
 CONSTRAINT [PK_RelatedIndividuals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Persons_CityId]    Script Date: 3/17/2025 1:00:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_Persons_CityId] ON [dbo].[Persons]
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PhoneNumbers_PersonId]    Script Date: 3/17/2025 1:00:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_PhoneNumbers_PersonId] ON [dbo].[PhoneNumbers]
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RelatedIndividuals_PersonId]    Script Date: 3/17/2025 1:00:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_RelatedIndividuals_PersonId] ON [dbo].[RelatedIndividuals]
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RelatedIndividuals_RelatedPersonId]    Script Date: 3/17/2025 1:00:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_RelatedIndividuals_RelatedPersonId] ON [dbo].[RelatedIndividuals]
(
	[RelatedPersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [FK_Persons_Cities_CityId] FOREIGN KEY([CityId])
REFERENCES [dbo].[Cities] ([Id])
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [FK_Persons_Cities_CityId]
GO
ALTER TABLE [dbo].[PhoneNumbers]  WITH CHECK ADD  CONSTRAINT [FK_PhoneNumbers_Persons_PersonId] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Persons] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PhoneNumbers] CHECK CONSTRAINT [FK_PhoneNumbers_Persons_PersonId]
GO
ALTER TABLE [dbo].[RelatedIndividuals]  WITH CHECK ADD  CONSTRAINT [FK_RelatedIndividuals_Persons_PersonId] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Persons] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RelatedIndividuals] CHECK CONSTRAINT [FK_RelatedIndividuals_Persons_PersonId]
GO
ALTER TABLE [dbo].[RelatedIndividuals]  WITH CHECK ADD  CONSTRAINT [FK_RelatedIndividuals_Persons_RelatedPersonId] FOREIGN KEY([RelatedPersonId])
REFERENCES [dbo].[Persons] ([Id])
GO
ALTER TABLE [dbo].[RelatedIndividuals] CHECK CONSTRAINT [FK_RelatedIndividuals_Persons_RelatedPersonId]
GO
ALTER TABLE [dbo].[Cities]  WITH CHECK ADD  CONSTRAINT [CHK_CityName] CHECK  ((NOT ([Name]) collate Latin1_General_BIN like '%[?-?]%' OR NOT ([Name]) collate Georgian_Modern_Sort_BIN like '%[A-Za-z]%'))
GO
ALTER TABLE [dbo].[Cities] CHECK CONSTRAINT [CHK_CityName]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [CHK_BirthDate] CHECK  ((datediff(year,[BirthDate],getdate())>=(18)))
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [CHK_BirthDate]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [CHK_FirstName] CHECK  ((NOT ([FirstName]) collate Latin1_General_BIN like '%[?-?]%' OR NOT ([FirstName]) collate Georgian_Modern_Sort_BIN like '%[A-Za-z]%'))
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [CHK_FirstName]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [CHK_LastName] CHECK  ((NOT ([LastName]) collate Latin1_General_BIN like '%[?-?]%' OR NOT ([LastName]) collate Georgian_Modern_Sort_BIN like '%[A-Za-z]%'))
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [CHK_LastName]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [CHK_PersonalNumber] CHECK  ((len([PersonalNumber])=(11) AND NOT [PersonalNumber] like '%[^0-9]%'))
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [CHK_PersonalNumber]
GO
ALTER TABLE [dbo].[PhoneNumbers]  WITH CHECK ADD  CONSTRAINT [CHK_PhoneNumber] CHECK  ((len([Number])>=(4) AND len([Number])<=(50)))
GO
ALTER TABLE [dbo].[PhoneNumbers] CHECK CONSTRAINT [CHK_PhoneNumber]
GO
USE [master]
GO
ALTER DATABASE [IndividualsDirectoryDB] SET  READ_WRITE 
GO

-- Insert sample cities
INSERT INTO [dbo].[Cities] ([Name]) VALUES ('New York'), ('Los Angeles'), ('Chicago');

-- Insert sample persons
INSERT INTO [dbo].[Persons] ([FirstName], [LastName], [Gender], [PersonalNumber], [BirthDate], [CityId], [ImagePath])
VALUES 
    ('John', 'Doe', 1, '12345678901', '1985-06-15', 1, NULL),
    ('Jane', 'Smith', 2, '98765432109', '1990-09-25', 2, NULL);

-- Insert sample phone numbers
INSERT INTO [dbo].[PhoneNumbers] ([NumberType], [Number], [PersonId])
VALUES 
    (1, '123-456-7890', 1),
    (2, '987-654-3210', 2);

-- Insert sample related individuals
INSERT INTO [dbo].[RelatedIndividuals] ([Relationship], [PersonId], [RelatedPersonId])
VALUES 
    (1, 1, 2); -- John Doe is related to Jane Smith
