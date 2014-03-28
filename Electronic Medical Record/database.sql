��USE [Medical_Records]

GO

/****** Object:  Table [dbo].[Student_Profile]    Script Date: 02/17/2014 23:43:32 ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

SET ANSI_PADDING ON

GO

CREATE TABLE [dbo].[Student_Profile](

	[First_Name] [varchar](50) NOT NULL,

	[Middle_Name] [varchar](50) NULL,

	[Last_Name] [varchar](50) NULL,

	[DOB] [varchar](50) NOT NULL,

	[Education] [varchar](50) NOT NULL,

	[Branch] [varchar](50) NOT NULL,

	[Year_Of_Joining] [date] NOT NULL,

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

 CONSTRAINT [PK_Student_Profile] PRIMARY KEY CLUSTERED 

(

	[ID] ASC

)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]

) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF

GO

/****** Object:  Table [dbo].[Pt_entry_per_day]    Script Date: 02/17/2014 23:43:32 ******/

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

 CONSTRAINT [PK_Pt_entry_per_day] PRIMARY KEY CLUSTERED 

(

	[ID] ASC

)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]

) ON [PRIMARY]

GO

SET ANSI_PADDING OFF

GO

/****** Object:  Table [dbo].[Others_Profile]    Script Date: 02/17/2014 23:43:32 ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

SET ANSI_PADDING ON

GO

CREATE TABLE [dbo].[Others_Profile](

	[First_Name] [varchar](50) NOT NULL,

	[Middle_Name] [varchar](50) NULL,

	[Last_Name] [varchar](50) NULL,

	[DOB] [date] NOT NULL,

	[Education] [varchar](50) NOT NULL,

	[Branch] [varchar](50) NOT NULL,

	[Year_Of_Joining] [date] NOT NULL,

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

 CONSTRAINT [PK_Others_Profile] PRIMARY KEY CLUSTERED 

(

	[ID] ASC

)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]

) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF

GO


/****** Object:  Table [dbo].[Faculty_Profile]    Script Date: 02/17/2014 23:43:32 ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

SET ANSI_PADDING ON

GO

CREATE TABLE [dbo].[Faculty_Profile](

	[First_Name] [varchar](50) NOT NULL,

	[Middle_Name] [varchar](50) NULL,

	[Last_Name] [varchar](50) NULL,

	[DOB] [date] NOT NULL,

	[Education] [varchar](50) NOT NULL,

	[Branch] [varchar](50) NOT NULL,

	[Year_Of_Joining] [date] NOT NULL,

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

 CONSTRAINT [PK_Faculty_Profile] PRIMARY KEY CLUSTERED 

(

	[ID] ASC

)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]

) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF

GO

