# Colegio Project Setup Instructions

This guide will help you set up and run the Colegio project on your local machine.

## Prerequisites

Before you begin, ensure you have the following installed on your machine:

- **Microsoft SQL Server Management Studio**: For database management.
- **.NET 6.0**: To build and run the backend API.
- **Node.js and npm (Node Package Manager)**: To manage frontend dependencies.
- **Angular 15.2.11**: To serve the Angular frontend application.

## Step-by-Step Instructions

### 1. Set Up the Database

1. **Open Microsoft SQL Server Management Studio**.

2. **Run the Database Script**:
   - Copy the provided SQL script below to create the database and tables for the Colegio project.
   - Paste and execute the script in Microsoft SQL Server Management Studio to create the `Colegio` database and its tables.

   **Database Script**:
```
USE [master]
GO
/****** Object:  Database [Colegio]    Script Date: 23/08/2024 3:06:28 p. m. ******/
CREATE DATABASE [Colegio]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Colegio', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Colegio.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Colegio_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Colegio_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Colegio] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Colegio].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Colegio] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Colegio] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Colegio] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Colegio] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Colegio] SET ARITHABORT OFF 
GO
ALTER DATABASE [Colegio] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Colegio] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Colegio] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Colegio] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Colegio] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Colegio] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Colegio] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Colegio] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Colegio] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Colegio] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Colegio] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Colegio] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Colegio] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Colegio] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Colegio] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Colegio] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Colegio] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Colegio] SET RECOVERY FULL 
GO
ALTER DATABASE [Colegio] SET  MULTI_USER 
GO
ALTER DATABASE [Colegio] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Colegio] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Colegio] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Colegio] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Colegio] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Colegio] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Colegio', N'ON'
GO
ALTER DATABASE [Colegio] SET QUERY_STORE = ON
GO
ALTER DATABASE [Colegio] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Colegio]
GO
/****** Object:  Table [dbo].[AlumnoGrado]    Script Date: 23/08/2024 3:06:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlumnoGrado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AlumnoId] [int] NULL,
	[GradoId] [int] NULL,
	[Grupo] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Alumnos]    Script Date: 23/08/2024 3:06:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumnos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Apellidos] [nvarchar](100) NOT NULL,
	[Genero] [nvarchar](10) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grados]    Script Date: 23/08/2024 3:06:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grados](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[ProfesorId] [int] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesores]    Script Date: 23/08/2024 3:06:28 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Apellidos] [nvarchar](100) NOT NULL,
	[Genero] [nvarchar](10) NOT NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AlumnoGrado]  WITH CHECK ADD FOREIGN KEY([AlumnoId])
REFERENCES [dbo].[Alumnos] ([Id])
GO
ALTER TABLE [dbo].[AlumnoGrado]  WITH CHECK ADD FOREIGN KEY([GradoId])
REFERENCES [dbo].[Grados] ([Id])
GO
ALTER TABLE [dbo].[Grados]  WITH CHECK ADD FOREIGN KEY([ProfesorId])
REFERENCES [dbo].[Profesores] ([Id])
GO
USE [master]
GO
ALTER DATABASE [Colegio] SET  READ_WRITE 
GO

```
OR use the backup .bak file in the DB folder

### 2. Configure the Backend

1. **Open the .NET Solution**:
   - Navigate to the folder containing the .NET backend solution.
   - Open the solution in your preferred IDE (e.g., Visual Studio, Visual Studio Code).

![image](https://github.com/user-attachments/assets/35f89b7e-712d-4ee3-9b6c-5260b34da0ac)


2. **Update Database Credentials**:
   - Locate the `appsettings.json` file in the .NET project.
   - Update the connection string with your SQL Server credentials to connect to the Colegio database.

![image](https://github.com/user-attachments/assets/246234f5-d05f-4a65-9edd-9c500a76ec45)


   **Example**:
```
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=Colegio;User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;"
     }
   }
```

3. **Run the API**:
   - Build and run the .NET project to start the backend API.

![image](https://github.com/user-attachments/assets/63ee3c39-dbfe-4ef0-8253-648980f9a1a0)


### 3. Set Up the Frontend

1. **Open the Frontend Folder**:
   - Navigate to the folder containing the Angular frontend project.

2. **Install Dependencies**:
   - Open a terminal or command prompt in the frontend folder.

![image](https://github.com/user-attachments/assets/16451cd5-97d7-4f1f-a0fd-343a82c9131e)

   - Run the following command to install all necessary dependencies:

```
   npm install
```
3. **Run the Angular Application**:
   - Start the Angular development server by running:

   ```
   ng serve
   ```
   
4. **Access the Application**:
   - Open your web browser and navigate to `http://localhost:4200` to use the application.

![image](https://github.com/user-attachments/assets/659fbf0b-5459-4ca8-b31d-12afd91b97bc)


Congratulations! You have successfully set up the Colegio project on your local machine. You can now start exploring it!
Any question to : juand.salazar.m@gmail.com

