USE [Medical_Records]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 04/03/2014 10:49:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[First_Name] [varchar](50) NOT NULL,
	[Middle_Name] [varchar](50) NULL,
	[Last_Name] [varchar](50) NULL,
	[DOB] [varchar](50) NOT NULL,
	[Education] [varchar](50) NOT NULL,
	[Branch] [varchar](50) NOT NULL,
	[Year_Of_Joining] [varchar](50) NOT NULL,
	[ID] [varchar](50) NOT NULL,
	[Gender] [varchar](50) NOT NULL,
	[Corres_Address] [varchar](250) NULL,
	[Perm_Address] [varchar](250) NOT NULL,
	[Local_Address] [varchar](250) NULL,
	[Contact_Num] [varchar](20) NOT NULL,
	[Guar_contact] [varchar](20) NOT NULL,
	[Martial_Status] [varchar](50) NOT NULL,
	[Blood_group] [varchar](50) NOT NULL,
	[Insurance_num] [varchar](50) NULL,
	[Image] [image] NOT NULL,
	[Allergy] [varchar](max) NULL,
	[Observations] [varchar](500) NULL,
	[Family_history] [varchar](500) NULL,
	[Social_history] [varchar](500) NULL,
	[Email_id] [varchar](50) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pt_transfered_to_pharmacist]    Script Date: 04/03/2014 10:49:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pt_transfered_to_pharmacist](
	[ID] [varchar](50) NOT NULL,
	[Pt_Name] [varchar](50) NOT NULL,
	[Date_Time] [varchar](50) NOT NULL,
	[Complain] [varchar](50) NOT NULL,
	[Occupation] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Pt_transfered_to_pharmacist] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pt_entry_per_day]    Script Date: 04/03/2014 10:49:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pt_entry_per_day](
	[ID] [varchar](50) NOT NULL,
	[Pt_Name] [varchar](50) NOT NULL,
	[Date_Time] [varchar](50) NOT NULL,
	[Complain] [varchar](250) NOT NULL,
	[Occupation] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Pt_entry_per_day] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Others]    Script Date: 04/03/2014 10:49:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Others](
	[First_Name] [varchar](50) NOT NULL,
	[Middle_Name] [varchar](50) NULL,
	[Last_Name] [varchar](50) NULL,
	[DOB] [varchar](50) NOT NULL,
	[Education] [varchar](50) NOT NULL,
	[Branch] [varchar](50) NOT NULL,
	[Year_Of_Joining] [varchar](50) NOT NULL,
	[ID] [varchar](50) NOT NULL,
	[Gender] [varchar](50) NOT NULL,
	[Corres_Address] [varchar](250) NULL,
	[Perm_Address] [varchar](250) NOT NULL,
	[Local_Address] [varchar](250) NULL,
	[Contact_Num] [varchar](20) NOT NULL,
	[Guar_contact] [varchar](20) NOT NULL,
	[Martial_Status] [varchar](50) NOT NULL,
	[Blood_group] [varchar](50) NOT NULL,
	[Insurance_num] [varchar](50) NULL,
	[Image] [image] NOT NULL,
	[Allergy] [varchar](max) NULL,
	[Observations] [varchar](500) NULL,
	[Family_history] [varchar](500) NULL,
	[Social_history] [varchar](500) NULL,
	[Email_id] [varchar](50) NULL,
 CONSTRAINT [PK_Others] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Faculty]    Script Date: 04/03/2014 10:49:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Faculty](
	[First_Name] [varchar](50) NOT NULL,
	[Middle_Name] [varchar](50) NULL,
	[Last_Name] [varchar](50) NULL,
	[DOB] [varchar] NOT NULL,
	[Education] [varchar](50) NOT NULL,
	[Branch] [varchar](50) NOT NULL,
	[Year_Of_Joining] [varchar](50) NOT NULL,
	[ID] [varchar](50) NOT NULL,
	[Gender] [varchar](50) NOT NULL,
	[Corres_Address] [varchar](250) NULL,
	[Perm_Address] [varchar](250) NOT NULL,
	[Local_Address] [varchar](250) NULL,
	[Contact_Num] [varchar](20) NOT NULL,
	[Guar_contact] [varchar](20) NOT NULL,
	[Martial_Status] [varchar](50) NOT NULL,
	[Blood_group] [varchar](50) NOT NULL,
	[Insurance_num] [varchar](50) NULL,
	[Image] [image] NOT NULL,
	[Allergy] [varchar](max) NULL,
	[Observations] [varchar](500) NULL,
	[Family_history] [varchar](500) NULL,
	[Social_history] [varchar](500) NULL,
	[Email_id] [varchar](50) NULL,
 CONSTRAINT [PK_Faculty] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
