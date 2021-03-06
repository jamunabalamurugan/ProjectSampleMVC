USE [master]
GO
/****** Object:  Database [IRelax]    Script Date: 8/20/2019 3:12:15 PM ******/
CREATE DATABASE [IRelax]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'IRelax', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\IRelax.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'IRelax_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\IRelax_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [IRelax] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IRelax].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [IRelax] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [IRelax] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [IRelax] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [IRelax] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [IRelax] SET ARITHABORT OFF 
GO
ALTER DATABASE [IRelax] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [IRelax] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [IRelax] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [IRelax] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [IRelax] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [IRelax] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [IRelax] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [IRelax] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [IRelax] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [IRelax] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [IRelax] SET  ENABLE_BROKER 
GO
ALTER DATABASE [IRelax] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [IRelax] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [IRelax] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [IRelax] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [IRelax] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [IRelax] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [IRelax] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [IRelax] SET RECOVERY FULL 
GO
ALTER DATABASE [IRelax] SET  MULTI_USER 
GO
ALTER DATABASE [IRelax] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [IRelax] SET DB_CHAINING OFF 
GO
ALTER DATABASE [IRelax] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [IRelax] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'IRelax', N'ON'
GO
USE [IRelax]
GO
/****** Object:  StoredProcedure [dbo].[insert_activity_track]    Script Date: 8/20/2019 3:12:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insert_activity_track] 
@psno varchar(10),
@id int,
@starttime datetime
as 
begin
insert into DailyActivityTrack values(@psno,@id,@starttime,GETDATE(),1,Convert(date, getdate()))
end
GO
/****** Object:  StoredProcedure [dbo].[insert_login_time]    Script Date: 8/20/2019 3:12:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[insert_login_time] @eid varchar(10), @mood int
as
begin

declare @Prev_stress as float
set @Prev_stress = (SELECT top (1) dbStressValue FROM DailyLoginTime
where dbStressValue is not null and vEmpID = @eid
ORDER BY dLoginTime  DESC)
print @Prev_stress

declare @count as INT
set @count = (select COUNT(*) from DailyLoginTime where vEmpID = @eid)
Print(@count)
set @count = @count+11
declare @stress as float
set @stress = (@count*@Prev_stress + @mood)/(@count+1)
print @stress

insert into DailyLoginTime (vEmpID, dLoginTime, iMood, dbStressValue) values (@eid, GETDATE(),@mood, @stress)

end

GO
/****** Object:  StoredProcedure [dbo].[TaskCompletionListForDay]    Script Date: 8/20/2019 3:12:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[TaskCompletionListForDay](@EmpId varchar(10), @TodayDate datetime)
as
begin
select  DailyActivityTrack.iDActivityID,vDActivityName,(tDStartTime),(tDStopTime) From DailyActivityTrack
join DailyActivities
on DailyActivityTrack.iDActivityID = DailyActivities.iDActivityID
where vEmpID = @EmpId and bDActivityStatus = 1 and dDActivityDate = @TodayDate
end
GO
/****** Object:  StoredProcedure [dbo].[update_login_time]    Script Date: 8/20/2019 3:12:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  procedure [dbo].[update_login_time]
(@eid  varchar(20))
as
begin
update DailyLoginTime set dLoginTime=GETDATE(), iMood=NULL,dbStressValue=NULL,dLogoutTime=NULL
where vEmpID=@eid
select  * FROM DailyLoginTime 
end
GO
/****** Object:  StoredProcedure [dbo].[update_logout_time]    Script Date: 8/20/2019 3:12:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  procedure [dbo].[update_logout_time]
(@eid  varchar(20))
as
begin
update DailyLoginTime set dLogoutTime=GETDATE(), iMood=NULL,dbStressValue=NULL
where vEmpID=@eid
select  * FROM DailyLoginTime 
end
GO
/****** Object:  StoredProcedure [dbo].[WeekendSuggestion]    Script Date: 8/20/2019 3:12:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[WeekendSuggestion](@EmpID varchar(10), @name varchar(30) output,@desc varchar(30) output ,@city varchar(30) output ,@bestTime DateTime output)
as 
begin
select Distinct(vPlaceName),vBestVisitingTime,vCity,vDescription from Places
join WeekendEmployeeInterests
on Places.iWActivityID = WeekendEmployeeInterests.iWActivityID
where vEmpID ='10662432' 
end
GO
/****** Object:  Table [dbo].[DailyActivities]    Script Date: 8/20/2019 3:12:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DailyActivities](
	[iDActivityID] [int] NOT NULL,
	[vDActivityName] [varchar](100) NULL,
	[tDDuration] [time](7) NULL,
	[iStressMinLevel] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[iDActivityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DailyActivityTrack]    Script Date: 8/20/2019 3:12:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DailyActivityTrack](
	[DAT_number] [int] IDENTITY(1,1) NOT NULL,
	[vEmpID] [varchar](10) NULL,
	[iDActivityID] [int] NULL,
	[tDStartTime] [datetime] NULL,
	[tDStopTime] [datetime] NULL,
	[bDActivityStatus] [bit] NULL,
	[dDActivityDate] [date] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DailyEmployeeInterests]    Script Date: 8/20/2019 3:12:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DailyEmployeeInterests](
	[DEI_number] [int] IDENTITY(1,1) NOT NULL,
	[vEmpID] [varchar](10) NULL,
	[iDActivityID] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DailyLoginTime]    Script Date: 8/20/2019 3:12:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DailyLoginTime](
	[DLT_number] [int] IDENTITY(1,1) NOT NULL,
	[vEmpID] [varchar](10) NULL,
	[dLoginTime] [datetime] NULL,
	[dLogoutTime] [datetime] NULL,
	[iMood] [int] NULL,
	[dbStressValue] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[DLT_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmployeePersonalDetails]    Script Date: 8/20/2019 3:12:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmployeePersonalDetails](
	[vEmpID] [varchar](10) NOT NULL,
	[vEmpName] [varchar](50) NULL,
	[vWorkDomain] [varchar](100) NULL,
	[iWorkingHours] [int] NULL,
	[vWorkingLocation] [varchar](50) NULL,
	[iEmpAge] [int] NULL,
	[vEmpMobile] [varchar](15) NULL,
	[vEmpMail] [varchar](100) NULL,
	[vEmpGender] [varchar](10) NULL,
	[dBirthDate] [date] NULL,
	[bMaritialStatus] [bit] NULL,
	[iCreditPoints] [int] NULL,
	[vPassword] [varchar](50) NULL,
	[bAdmin] [bit] NULL,
	[ProfilePhoto] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[vEmpID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ImageDB]    Script Date: 8/20/2019 3:12:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ImageDB](
	[iImageID] [int] IDENTITY(1,1) NOT NULL,
	[vImagePath] [varchar](500) NULL,
	[vOption1] [varchar](20) NULL,
	[vOption2] [varchar](20) NULL,
	[vOption3] [varchar](20) NULL,
	[vCorrectOption] [varchar](20) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Places]    Script Date: 8/20/2019 3:12:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Places](
	[iPlaceID] [int] IDENTITY(1,1) NOT NULL,
	[iWActivityID] [int] NULL,
	[vPlaceName] [varchar](50) NULL,
	[vDescription] [varchar](5000) NULL,
	[vLatitude] [varchar](50) NULL,
	[vLongitude] [varchar](50) NULL,
	[vCity] [varchar](20) NULL,
	[vBestVisitingTime] [varchar](100) NULL,
	[vImageLink] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[iPlaceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Questionaire]    Script Date: 8/20/2019 3:12:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Questionaire](
	[iQuestionID] [int] NOT NULL,
	[vQuestionDesc] [varchar](300) NULL,
	[bQuestionType] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[iQuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WeekendActivities]    Script Date: 8/20/2019 3:12:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WeekendActivities](
	[iWActivityID] [int] NOT NULL,
	[vWActivityName] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[iWActivityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WeekendActivityTrack]    Script Date: 8/20/2019 3:12:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WeekendActivityTrack](
	[iWAT_number] [int] IDENTITY(1,1) NOT NULL,
	[vEmpID] [varchar](10) NULL,
	[iWActivityID] [int] NULL,
	[bWActivityStatus] [bit] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WeekendEmployeeInterests]    Script Date: 8/20/2019 3:12:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WeekendEmployeeInterests](
	[iWEI_number] [int] IDENTITY(1,1) NOT NULL,
	[vEmpID] [varchar](10) NULL,
	[iWActivityID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[iWEI_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[LoginTime]    Script Date: 8/20/2019 3:12:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[LoginTime] as select * from DailyLoginTime where vEmpID = 10662455
GO
/****** Object:  View [dbo].[LoginTime1]    Script Date: 8/20/2019 3:12:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[LoginTime1] as select * from DailyLoginTime 
where vEmpID = 10662432

GO
/****** Object:  View [dbo].[LoginTime2]    Script Date: 8/20/2019 3:12:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[LoginTime2] as select * from DailyLoginTime 
where vEmpID = 10662432
GO
/****** Object:  View [dbo].[LoginTime3]    Script Date: 8/20/2019 3:12:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[LoginTime3] as select * from DailyLoginTime 
where vEmpID = 10662432
GO
ALTER TABLE [dbo].[DailyActivityTrack]  WITH CHECK ADD FOREIGN KEY([iDActivityID])
REFERENCES [dbo].[DailyActivities] ([iDActivityID])
GO
ALTER TABLE [dbo].[DailyActivityTrack]  WITH CHECK ADD FOREIGN KEY([vEmpID])
REFERENCES [dbo].[EmployeePersonalDetails] ([vEmpID])
GO
ALTER TABLE [dbo].[DailyEmployeeInterests]  WITH CHECK ADD FOREIGN KEY([iDActivityID])
REFERENCES [dbo].[DailyActivities] ([iDActivityID])
GO
ALTER TABLE [dbo].[DailyEmployeeInterests]  WITH CHECK ADD FOREIGN KEY([vEmpID])
REFERENCES [dbo].[EmployeePersonalDetails] ([vEmpID])
GO
ALTER TABLE [dbo].[DailyLoginTime]  WITH CHECK ADD FOREIGN KEY([vEmpID])
REFERENCES [dbo].[EmployeePersonalDetails] ([vEmpID])
GO
ALTER TABLE [dbo].[Places]  WITH NOCHECK ADD FOREIGN KEY([iWActivityID])
REFERENCES [dbo].[WeekendActivities] ([iWActivityID])
GO
ALTER TABLE [dbo].[WeekendActivityTrack]  WITH CHECK ADD FOREIGN KEY([iWActivityID])
REFERENCES [dbo].[WeekendActivities] ([iWActivityID])
GO
ALTER TABLE [dbo].[WeekendActivityTrack]  WITH CHECK ADD FOREIGN KEY([vEmpID])
REFERENCES [dbo].[EmployeePersonalDetails] ([vEmpID])
GO
ALTER TABLE [dbo].[WeekendEmployeeInterests]  WITH CHECK ADD FOREIGN KEY([iWActivityID])
REFERENCES [dbo].[WeekendActivities] ([iWActivityID])
GO
ALTER TABLE [dbo].[WeekendEmployeeInterests]  WITH CHECK ADD FOREIGN KEY([vEmpID])
REFERENCES [dbo].[EmployeePersonalDetails] ([vEmpID])
GO
USE [master]
GO
ALTER DATABASE [IRelax] SET  READ_WRITE 
GO
