USE [master]
GO
/****** Object:  Database [db_Lakshay_Onlinetest]    Script Date: 8/27/2018 2:57:01 PM ******/
CREATE DATABASE [db_Lakshay_Onlinetest]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_Lakshay_Onlinetest', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\db_Lakshay_Onlinetest.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'db_Lakshay_Onlinetest_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\db_Lakshay_Onlinetest_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [db_Lakshay_Onlinetest] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_Lakshay_Onlinetest].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_Lakshay_Onlinetest] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_Lakshay_Onlinetest] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_Lakshay_Onlinetest] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_Lakshay_Onlinetest] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_Lakshay_Onlinetest] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_Lakshay_Onlinetest] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_Lakshay_Onlinetest] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [db_Lakshay_Onlinetest] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_Lakshay_Onlinetest] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_Lakshay_Onlinetest] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_Lakshay_Onlinetest] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_Lakshay_Onlinetest] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_Lakshay_Onlinetest] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_Lakshay_Onlinetest] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_Lakshay_Onlinetest] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_Lakshay_Onlinetest] SET  ENABLE_BROKER 
GO
ALTER DATABASE [db_Lakshay_Onlinetest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_Lakshay_Onlinetest] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_Lakshay_Onlinetest] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_Lakshay_Onlinetest] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_Lakshay_Onlinetest] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_Lakshay_Onlinetest] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_Lakshay_Onlinetest] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_Lakshay_Onlinetest] SET RECOVERY FULL 
GO
ALTER DATABASE [db_Lakshay_Onlinetest] SET  MULTI_USER 
GO
ALTER DATABASE [db_Lakshay_Onlinetest] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_Lakshay_Onlinetest] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_Lakshay_Onlinetest] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_Lakshay_Onlinetest] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'db_Lakshay_Onlinetest', N'ON'
GO
USE [db_Lakshay_Onlinetest]
GO
/****** Object:  StoredProcedure [dbo].[Samp]    Script Date: 8/27/2018 2:57:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Samp]
    @param1 int = 5,
    @param2 int =6
AS
    SELECT @param2 = @param2 / @param1 
	print @param2
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[Samp1]    Script Date: 8/27/2018 2:57:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Samp1]
    @param1 int = 5,
    @param2 int =6
AS
    SELECT @param2 = @param2 / @param1 
	print convert(varchar(10),@param2)
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[Sample_]    Script Date: 8/27/2018 2:57:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sample_]
    @param1 int = 5,
    @param2 int =6 
AS
    SELECT @param2 = @param2 / @param1 
	print @param2
RETURN 0

GO
/****** Object:  StoredProcedure [dbo].[Sample_Pr]    Script Date: 8/27/2018 2:57:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sample_Pr]
    @param1 int = 5,
    @param2 int =6 
AS
    SELECT @param2 = @param2 + @param1 
	print convert(varchar(10),@param2)
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[Sample_Pro]    Script Date: 8/27/2018 2:57:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sample_Pro]
    @param1 int = 5,
    @param2 int =6 
AS
    SELECT @param2 = @param2 + @param1 
	print convert(nvarchar(10),@param2)
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[Sample_Procedure]    Script Date: 8/27/2018 2:57:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sample_Procedure] 
    @param1 int = 5,
    @param2 int =6 
AS
    SELECT @param2 = @param2 + @param1 
GO
/****** Object:  StoredProcedure [dbo].[Sample_Prodooo]    Script Date: 8/27/2018 2:57:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sample_Prodooo]
    @param1 int = 5,
    @param2 int =6 
AS
    SELECT @param2 = @param2 + @param1 
	print @param2
RETURN 0
GO
/****** Object:  Table [dbo].[tbl_FillBlank]    Script Date: 8/27/2018 2:57:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_FillBlank](
	[FB_Id] [nvarchar](15) NOT NULL,
	[FB_Ques] [nvarchar](400) NULL,
	[FB_Ans_Key] [nvarchar](30) NULL,
	[Sub_Id_FB] [nvarchar](15) NULL,
 CONSTRAINT [pk_FB_Id] PRIMARY KEY CLUSTERED 
(
	[FB_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[FB_Ques] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_MCQ]    Script Date: 8/27/2018 2:57:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_MCQ](
	[MCQ_Id] [nvarchar](15) NOT NULL,
	[MCQ_Ques] [nvarchar](400) NULL,
	[Op_A] [nvarchar](200) NULL,
	[Op_B] [nvarchar](200) NULL,
	[Op_C] [nvarchar](200) NULL,
	[Op_D] [nvarchar](200) NULL,
	[Op_E] [nvarchar](200) NULL,
	[MCQ_Ans_Key] [nvarchar](200) NULL,
	[Sub_Id_MCQ] [nvarchar](15) NULL,
 CONSTRAINT [pk_MCQ_Id] PRIMARY KEY CLUSTERED 
(
	[MCQ_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[MCQ_Ques] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Subjects]    Script Date: 8/27/2018 2:57:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Subjects](
	[Sub_Id] [nvarchar](15) NOT NULL,
	[Sub_Name] [nvarchar](20) NULL,
	[Sub_Category] [nvarchar](20) NULL,
 CONSTRAINT [pk_Sub_Id] PRIMARY KEY CLUSTERED 
(
	[Sub_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Test]    Script Date: 8/27/2018 2:57:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Test](
	[Test_Id] [nvarchar](15) NOT NULL,
	[Sub_Id_Test] [nvarchar](15) NULL,
	[Test_Name] [nvarchar](40) NULL,
	[Time_Alloted] [time](7) NULL,
	[No_of_Ques] [int] NULL,
 CONSTRAINT [pk_Test_Id] PRIMARY KEY CLUSTERED 
(
	[Test_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_TestReport]    Script Date: 8/27/2018 2:57:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TestReport](
	[Report_Id] [nvarchar](15) NOT NULL,
	[Test_Id_TestRep] [nvarchar](15) NULL,
	[Tran_Id_Tran] [nvarchar](15) NULL,
	[User_Id_User] [nvarchar](15) NULL,
	[Attempted_Ques_No] [int] NULL,
	[Correct_Ques_No] [int] NULL,
	[Wrong_Ques_No] [int] NULL,
	[Start_Time] [datetime] NULL,
	[End_Time] [datetime] NULL,
	[Score] [int] NULL,
	[Percentage] [float] NULL,
	[Result_Status] [nvarchar](15) NULL,
 CONSTRAINT [pk_Report_Id] PRIMARY KEY CLUSTERED 
(
	[Report_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Transaction]    Script Date: 8/27/2018 2:57:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Transaction](
	[Tran_Id] [nvarchar](15) NOT NULL,
	[MCQ_Id] [nvarchar](15) NULL,
	[FB_Id] [nvarchar](15) NULL,
	[TF_Id] [nvarchar](15) NULL,
	[Test_Id_Tran] [nvarchar](15) NULL,
	[Ques_Type] [nvarchar](20) NULL,
 CONSTRAINT [pk_Tran_Id] PRIMARY KEY CLUSTERED 
(
	[Tran_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_TrueOrFalse]    Script Date: 8/27/2018 2:57:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TrueOrFalse](
	[TF_Id] [nvarchar](15) NOT NULL,
	[TF_Ques] [nvarchar](400) NULL,
	[TF_Ans_Key] [nvarchar](20) NULL,
	[Sub_Id_TF] [nvarchar](15) NULL,
 CONSTRAINT [pk_TF_Id] PRIMARY KEY CLUSTERED 
(
	[TF_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[TF_Ques] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_User]    Script Date: 8/27/2018 2:57:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_User](
	[User_Id] [nvarchar](15) NOT NULL,
	[Name] [nvarchar](40) NULL,
	[User_Email] [nvarchar](40) NULL,
	[Phone_No] [nvarchar](20) NULL,
	[Password] [nvarchar](20) NULL,
	[DOB] [date] NULL,
	[Mail_Status] [bit] NULL,
 CONSTRAINT [pk_User_Id] PRIMARY KEY CLUSTERED 
(
	[User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Phone_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[tbl_FillBlank]  WITH CHECK ADD  CONSTRAINT [fk_Sub_Id_FB] FOREIGN KEY([Sub_Id_FB])
REFERENCES [dbo].[tbl_Subjects] ([Sub_Id])
GO
ALTER TABLE [dbo].[tbl_FillBlank] CHECK CONSTRAINT [fk_Sub_Id_FB]
GO
ALTER TABLE [dbo].[tbl_MCQ]  WITH CHECK ADD  CONSTRAINT [fk_Sub_Id_MCQ] FOREIGN KEY([Sub_Id_MCQ])
REFERENCES [dbo].[tbl_Subjects] ([Sub_Id])
GO
ALTER TABLE [dbo].[tbl_MCQ] CHECK CONSTRAINT [fk_Sub_Id_MCQ]
GO
ALTER TABLE [dbo].[tbl_Test]  WITH CHECK ADD  CONSTRAINT [fk_Sub_Id_Test] FOREIGN KEY([Sub_Id_Test])
REFERENCES [dbo].[tbl_Subjects] ([Sub_Id])
GO
ALTER TABLE [dbo].[tbl_Test] CHECK CONSTRAINT [fk_Sub_Id_Test]
GO
ALTER TABLE [dbo].[tbl_TestReport]  WITH CHECK ADD  CONSTRAINT [fk_Test_Id_TestRep] FOREIGN KEY([Test_Id_TestRep])
REFERENCES [dbo].[tbl_Test] ([Test_Id])
GO
ALTER TABLE [dbo].[tbl_TestReport] CHECK CONSTRAINT [fk_Test_Id_TestRep]
GO
ALTER TABLE [dbo].[tbl_TestReport]  WITH CHECK ADD  CONSTRAINT [fk_Tran_Id_Tran] FOREIGN KEY([Tran_Id_Tran])
REFERENCES [dbo].[tbl_Transaction] ([Tran_Id])
GO
ALTER TABLE [dbo].[tbl_TestReport] CHECK CONSTRAINT [fk_Tran_Id_Tran]
GO
ALTER TABLE [dbo].[tbl_TestReport]  WITH CHECK ADD  CONSTRAINT [fk_User_Id_User] FOREIGN KEY([User_Id_User])
REFERENCES [dbo].[tbl_User] ([User_Id])
GO
ALTER TABLE [dbo].[tbl_TestReport] CHECK CONSTRAINT [fk_User_Id_User]
GO
ALTER TABLE [dbo].[tbl_Transaction]  WITH CHECK ADD  CONSTRAINT [fk_FB_Id] FOREIGN KEY([FB_Id])
REFERENCES [dbo].[tbl_FillBlank] ([FB_Id])
GO
ALTER TABLE [dbo].[tbl_Transaction] CHECK CONSTRAINT [fk_FB_Id]
GO
ALTER TABLE [dbo].[tbl_Transaction]  WITH CHECK ADD  CONSTRAINT [fk_MCQ_Id] FOREIGN KEY([MCQ_Id])
REFERENCES [dbo].[tbl_MCQ] ([MCQ_Id])
GO
ALTER TABLE [dbo].[tbl_Transaction] CHECK CONSTRAINT [fk_MCQ_Id]
GO
ALTER TABLE [dbo].[tbl_Transaction]  WITH CHECK ADD  CONSTRAINT [fk_Test_Id_Tran] FOREIGN KEY([Test_Id_Tran])
REFERENCES [dbo].[tbl_Transaction] ([Tran_Id])
GO
ALTER TABLE [dbo].[tbl_Transaction] CHECK CONSTRAINT [fk_Test_Id_Tran]
GO
ALTER TABLE [dbo].[tbl_Transaction]  WITH CHECK ADD  CONSTRAINT [fk_TF_Id] FOREIGN KEY([TF_Id])
REFERENCES [dbo].[tbl_TrueOrFalse] ([TF_Id])
GO
ALTER TABLE [dbo].[tbl_Transaction] CHECK CONSTRAINT [fk_TF_Id]
GO
ALTER TABLE [dbo].[tbl_TrueOrFalse]  WITH CHECK ADD  CONSTRAINT [fk_Sub_Id_TF] FOREIGN KEY([Sub_Id_TF])
REFERENCES [dbo].[tbl_Subjects] ([Sub_Id])
GO
ALTER TABLE [dbo].[tbl_TrueOrFalse] CHECK CONSTRAINT [fk_Sub_Id_TF]
GO
USE [master]
GO
ALTER DATABASE [db_Lakshay_Onlinetest] SET  READ_WRITE 
GO
