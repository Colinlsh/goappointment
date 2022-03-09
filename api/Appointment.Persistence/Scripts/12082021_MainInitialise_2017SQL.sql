USE [Appointment_R0.1]
GO
/****** Object:  Table [AppointmentMain].[CTAppointmentStatus]    Script Date: 12/8/2021 8:54:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppointmentMain].[CTAppointmentStatus](
	[AppointmentStatusId] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](max) NULL,
	[DisplayValue] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[IsUserMaintainable] [bit] NOT NULL,
	[EffectiveStartDate] [datetime2](7) NOT NULL,
	[EffectiveEndDate] [datetime2](7) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
	[SortOrder] [int] NOT NULL,
 CONSTRAINT [PK_CTAppointmentStatus] PRIMARY KEY CLUSTERED 
(
	[AppointmentStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [AppointmentMain].[CTCountry]    Script Date: 12/8/2021 8:54:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppointmentMain].[CTCountry](
	[CountryId] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](max) NULL,
	[DisplayValue] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[IsUserMaintainable] [bit] NOT NULL,
	[EffectiveStartDate] [datetime2](7) NOT NULL,
	[EffectiveEndDate] [datetime2](7) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
	[SortOrder] [int] NOT NULL,
	[PhoneCountryCode] [nvarchar](max) NULL,
 CONSTRAINT [PK_CTCountry] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [AppointmentMain].[CTOccupation]    Script Date: 12/8/2021 8:54:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppointmentMain].[CTOccupation](
	[OccupationId] [uniqueidentifier] NOT NULL,
	[DisplayValue] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[IsUserMaintainable] [bit] NOT NULL,
	[SortOrder] [int] NOT NULL,
	[EffectiveStartDate] [datetime2](7) NOT NULL,
	[EffectiveEndDate] [datetime2](7) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_CTOccupation] PRIMARY KEY CLUSTERED 
(
	[OccupationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [AppointmentMain].[CTRace]    Script Date: 12/8/2021 8:54:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppointmentMain].[CTRace](
	[RaceId] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](max) NULL,
	[DisplayValue] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[IsUserMaintainable] [bit] NOT NULL,
	[EffectiveStartDate] [datetime2](7) NOT NULL,
	[EffectiveEndDate] [datetime2](7) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
	[IRISCode] [nvarchar](max) NULL,
	[SortOrder] [int] NOT NULL,
 CONSTRAINT [PK_CTRace] PRIMARY KEY CLUSTERED 
(
	[RaceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [AppointmentMain].[CTRelationship]    Script Date: 12/8/2021 8:54:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppointmentMain].[CTRelationship](
	[RelationshipId] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](max) NULL,
	[DisplayValue] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[IsUserMaintainable] [bit] NOT NULL,
	[SortOrder] [int] NOT NULL,
	[EffectiveStartDate] [datetime2](7) NOT NULL,
	[EffectiveEndDate] [datetime2](7) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_CTRelationship] PRIMARY KEY CLUSTERED 
(
	[RelationshipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [AppointmentMain].[CTReligion]    Script Date: 12/8/2021 8:54:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppointmentMain].[CTReligion](
	[ReligionId] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](max) NULL,
	[DisplayValue] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[IsUserMaintainable] [bit] NOT NULL,
	[SortOrder] [int] NOT NULL,
	[EffectiveStartDate] [datetime2](7) NOT NULL,
	[EffectiveEndDate] [datetime2](7) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_CTReligion] PRIMARY KEY CLUSTERED 
(
	[ReligionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [AppointmentMain].[DashboardSuperAdminUser]    Script Date: 12/8/2021 8:54:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppointmentMain].[DashboardSuperAdminUser](
	[SuperAdminUserId] [uniqueidentifier] NOT NULL,
	[ActiveStatus] [nvarchar](max) NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[NormalizedUserName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[NormalizedEmail] [nvarchar](max) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_DashboardSuperAdminUser] PRIMARY KEY CLUSTERED 
(
	[SuperAdminUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [AppointmentMain].[RefreshToken]    Script Date: 12/8/2021 8:54:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppointmentMain].[RefreshToken](
	[RefreshTokenId] [uniqueidentifier] NOT NULL,
	[SuperAdminUserId] [uniqueidentifier] NULL,
	[Token] [nvarchar](max) NULL,
	[Expires] [datetime2](7) NOT NULL,
	[Revoked] [datetime2](7) NULL,
 CONSTRAINT [PK_RefreshToken] PRIMARY KEY CLUSTERED 
(
	[RefreshTokenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [AppointmentMain].[TenantConfiguration]    Script Date: 12/8/2021 8:54:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppointmentMain].[TenantConfiguration](
	[TenantConfigurationID] [uniqueidentifier] NOT NULL,
	[TenantMappingFK] [uniqueidentifier] NOT NULL,
	[KioskTenantCode] [nvarchar](max) NULL,
	[KioskTenantName] [nvarchar](max) NULL,
 CONSTRAINT [PK_TenantConfiguration] PRIMARY KEY CLUSTERED 
(
	[TenantConfigurationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [AppointmentMain].[TenantMapping]    Script Date: 12/8/2021 8:54:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AppointmentMain].[TenantMapping](
	[TenantID] [uniqueidentifier] NOT NULL,
	[TenantCode] [nvarchar](max) NULL,
	[SchemaName] [nvarchar](max) NULL,
	[DBServer] [nvarchar](max) NULL,
	[DBName] [nvarchar](max) NULL,
	[DBUserName] [nvarchar](max) NULL,
	[DBUserPassword] [nvarchar](max) NULL,
	[CreateDate] [datetime2](7) NULL,
	[CreateBy] [nvarchar](max) NULL,
	[UpdateDate] [datetime2](7) NULL,
	[UpdateBy] [nvarchar](max) NULL,
	[TenantIndex] [int] NOT NULL,
	[HeCode] [nvarchar](max) NULL,
	[IsMobileEnabled] [bit] NULL,
 CONSTRAINT [PK_TenantMapping] PRIMARY KEY CLUSTERED 
(
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [AppointmentMain].[RefreshToken]  WITH CHECK ADD  CONSTRAINT [FK_RefreshToken_DashboardSuperAdminUser_SuperAdminUserId] FOREIGN KEY([SuperAdminUserId])
REFERENCES [AppointmentMain].[DashboardSuperAdminUser] ([SuperAdminUserId])
GO
ALTER TABLE [AppointmentMain].[RefreshToken] CHECK CONSTRAINT [FK_RefreshToken_DashboardSuperAdminUser_SuperAdminUserId]
GO
ALTER TABLE [AppointmentMain].[TenantConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_TenantConfiguration_TenantMapping_TenantMappingFK] FOREIGN KEY([TenantMappingFK])
REFERENCES [AppointmentMain].[TenantMapping] ([TenantID])
ON DELETE CASCADE
GO
ALTER TABLE [AppointmentMain].[TenantConfiguration] CHECK CONSTRAINT [FK_TenantConfiguration_TenantMapping_TenantMappingFK]
GO
