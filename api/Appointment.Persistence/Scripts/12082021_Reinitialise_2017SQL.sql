USE [Appointment_R0.1]
GO
--/****** Object:  Table [AppointmentMain].[CTAppointmentStatus]    Script Date: 12/8/2021 8:47:53 AM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--CREATE TABLE [AppointmentMain].[CTAppointmentStatus](
--	[AppointmentStatusId] [uniqueidentifier] NOT NULL,
--	[Code] [nvarchar](max) NULL,
--	[DisplayValue] [nvarchar](max) NULL,
--	[Description] [nvarchar](max) NULL,
--	[IsUserMaintainable] [bit] NOT NULL,
--	[EffectiveStartDate] [datetime2](7) NOT NULL,
--	[EffectiveEndDate] [datetime2](7) NOT NULL,
--	[CreateDate] [datetime2](7) NOT NULL,
--	[UpdateDate] [datetime2](7) NOT NULL,
--	[SortOrder] [int] NOT NULL,
-- CONSTRAINT [PK_CTAppointmentStatus] PRIMARY KEY CLUSTERED 
--(
--	[AppointmentStatusId] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
--GO
--/****** Object:  Table [AppointmentMain].[CTCountry]    Script Date: 12/8/2021 8:47:53 AM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--CREATE TABLE [AppointmentMain].[CTCountry](
--	[CountryId] [uniqueidentifier] NOT NULL,
--	[Code] [nvarchar](max) NULL,
--	[DisplayValue] [nvarchar](max) NULL,
--	[Description] [nvarchar](max) NULL,
--	[IsUserMaintainable] [bit] NOT NULL,
--	[EffectiveStartDate] [datetime2](7) NOT NULL,
--	[EffectiveEndDate] [datetime2](7) NOT NULL,
--	[CreateDate] [datetime2](7) NOT NULL,
--	[UpdateDate] [datetime2](7) NOT NULL,
--	[SortOrder] [int] NOT NULL,
--	[PhoneCountryCode] [nvarchar](max) NULL,
-- CONSTRAINT [PK_CTCountry] PRIMARY KEY CLUSTERED 
--(
--	[CountryId] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
--GO
--/****** Object:  Table [AppointmentMain].[CTOccupation]    Script Date: 12/8/2021 8:47:53 AM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--CREATE TABLE [AppointmentMain].[CTOccupation](
--	[OccupationId] [uniqueidentifier] NOT NULL,
--	[DisplayValue] [nvarchar](max) NULL,
--	[Description] [nvarchar](max) NULL,
--	[IsUserMaintainable] [bit] NOT NULL,
--	[SortOrder] [int] NOT NULL,
--	[EffectiveStartDate] [datetime2](7) NOT NULL,
--	[EffectiveEndDate] [datetime2](7) NOT NULL,
--	[CreateDate] [datetime2](7) NOT NULL,
--	[UpdateDate] [datetime2](7) NOT NULL,
-- CONSTRAINT [PK_CTOccupation] PRIMARY KEY CLUSTERED 
--(
--	[OccupationId] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
--GO
--/****** Object:  Table [AppointmentMain].[CTRace]    Script Date: 12/8/2021 8:47:53 AM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--CREATE TABLE [AppointmentMain].[CTRace](
--	[RaceId] [uniqueidentifier] NOT NULL,
--	[Code] [nvarchar](max) NULL,
--	[DisplayValue] [nvarchar](max) NULL,
--	[Description] [nvarchar](max) NULL,
--	[IsUserMaintainable] [bit] NOT NULL,
--	[EffectiveStartDate] [datetime2](7) NOT NULL,
--	[EffectiveEndDate] [datetime2](7) NOT NULL,
--	[CreateDate] [datetime2](7) NOT NULL,
--	[UpdateDate] [datetime2](7) NOT NULL,
--	[IRISCode] [nvarchar](max) NULL,
-- CONSTRAINT [PK_CTRace] PRIMARY KEY CLUSTERED 
--(
--	[RaceId] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
--GO
--/****** Object:  Table [AppointmentMain].[CTRelationship]    Script Date: 12/8/2021 8:47:53 AM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--CREATE TABLE [AppointmentMain].[CTRelationship](
--	[RelationshipId] [uniqueidentifier] NOT NULL,
--	[Code] [nvarchar](max) NULL,
--	[DisplayValue] [nvarchar](max) NULL,
--	[Description] [nvarchar](max) NULL,
--	[IsUserMaintainable] [bit] NOT NULL,
--	[SortOrder] [int] NOT NULL,
--	[EffectiveStartDate] [datetime2](7) NOT NULL,
--	[EffectiveEndDate] [datetime2](7) NOT NULL,
--	[CreateDate] [datetime2](7) NOT NULL,
--	[UpdateDate] [datetime2](7) NOT NULL,
-- CONSTRAINT [PK_CTRelationship] PRIMARY KEY CLUSTERED 
--(
--	[RelationshipId] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
--GO
--/****** Object:  Table [AppointmentMain].[CTReligion]    Script Date: 12/8/2021 8:47:53 AM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--CREATE TABLE [AppointmentMain].[CTReligion](
--	[ReligionId] [uniqueidentifier] NOT NULL,
--	[Code] [nvarchar](max) NULL,
--	[DisplayValue] [nvarchar](max) NULL,
--	[Description] [nvarchar](max) NULL,
--	[IsUserMaintainable] [bit] NOT NULL,
--	[SortOrder] [int] NOT NULL,
--	[EffectiveStartDate] [datetime2](7) NOT NULL,
--	[EffectiveEndDate] [datetime2](7) NOT NULL,
--	[CreateDate] [datetime2](7) NOT NULL,
--	[UpdateDate] [datetime2](7) NOT NULL,
-- CONSTRAINT [PK_CTReligion] PRIMARY KEY CLUSTERED 
--(
--	[ReligionId] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
--GO
--/****** Object:  Table [AppointmentMain].[DashboardSuperAdminUser]    Script Date: 12/8/2021 8:47:53 AM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--CREATE TABLE [AppointmentMain].[DashboardSuperAdminUser](
--	[SuperAdminUserId] [uniqueidentifier] NOT NULL,
--	[ActiveStatus] [nvarchar](max) NULL,
--	[CreateDate] [datetime2](7) NOT NULL,
--	[UpdateDate] [datetime2](7) NOT NULL,
--	[UserName] [nvarchar](max) NULL,
--	[NormalizedUserName] [nvarchar](max) NULL,
--	[Email] [nvarchar](max) NULL,
--	[NormalizedEmail] [nvarchar](max) NULL,
--	[EmailConfirmed] [bit] NOT NULL,
--	[PasswordHash] [nvarchar](max) NULL,
--	[SecurityStamp] [nvarchar](max) NULL,
--	[ConcurrencyStamp] [nvarchar](max) NULL,
--	[PhoneNumber] [nvarchar](max) NULL,
--	[PhoneNumberConfirmed] [bit] NOT NULL,
--	[TwoFactorEnabled] [bit] NOT NULL,
--	[LockoutEnd] [datetimeoffset](7) NULL,
--	[LockoutEnabled] [bit] NOT NULL,
--	[AccessFailedCount] [int] NOT NULL,
-- CONSTRAINT [PK_DashboardSuperAdminUser] PRIMARY KEY CLUSTERED 
--(
--	[SuperAdminUserId] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
--GO
--/****** Object:  Table [AppointmentMain].[RefreshToken]    Script Date: 12/8/2021 8:47:53 AM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--CREATE TABLE [AppointmentMain].[RefreshToken](
--	[RefreshTokenId] [uniqueidentifier] NOT NULL,
--	[SuperAdminUserId] [uniqueidentifier] NULL,
--	[Token] [nvarchar](max) NULL,
--	[Expires] [datetime2](7) NOT NULL,
--	[Revoked] [datetime2](7) NULL,
-- CONSTRAINT [PK_RefreshToken] PRIMARY KEY CLUSTERED 
--(
--	[RefreshTokenId] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
--GO
--/****** Object:  Table [AppointmentMain].[TenantConfiguration]    Script Date: 12/8/2021 8:47:53 AM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--CREATE TABLE [AppointmentMain].[TenantConfiguration](
--	[TenantConfigurationID] [uniqueidentifier] NOT NULL,
--	[TenantMappingFK] [uniqueidentifier] NOT NULL,
--	[KioskTenantCode] [nvarchar](max) NULL,
--	[KioskTenantName] [nvarchar](max) NULL,
-- CONSTRAINT [PK_TenantConfiguration] PRIMARY KEY CLUSTERED 
--(
--	[TenantConfigurationID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
--GO
--/****** Object:  Table [AppointmentMain].[TenantMapping]    Script Date: 12/8/2021 8:47:53 AM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--CREATE TABLE [AppointmentMain].[TenantMapping](
--	[TenantID] [uniqueidentifier] NOT NULL,
--	[TenantCode] [nvarchar](max) NULL,
--	[SchemaName] [nvarchar](max) NULL,
--	[DBServer] [nvarchar](max) NULL,
--	[DBName] [nvarchar](max) NULL,
--	[DBUserName] [nvarchar](max) NULL,
--	[DBUserPassword] [nvarchar](max) NULL,
--	[CreateDate] [datetime2](7) NULL,
--	[CreateBy] [nvarchar](max) NULL,
--	[UpdateDate] [datetime2](7) NULL,
--	[UpdateBy] [nvarchar](max) NULL,
--	[TenantIndex] [int] NOT NULL,
--	[HeCode] [nvarchar](max) NULL,
--	[IsMobileEnabled] [bit] NULL,
-- CONSTRAINT [PK_TenantMapping] PRIMARY KEY CLUSTERED 
--(
--	[TenantID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
--GO
/****** Object:  Table [Tenant_001].[Activity]    Script Date: 12/8/2021 8:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tenant_001].[Activity](
	[ActivityId] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Category] [nvarchar](max) NULL,
	[Date] [datetime2](7) NOT NULL,
	[City] [nvarchar](max) NULL,
	[Venue] [nvarchar](max) NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
	[IsUserMaintainable] [bit] NOT NULL,
	[IsCancelled] [bit] NOT NULL,
 CONSTRAINT [PK_Activity] PRIMARY KEY CLUSTERED 
(
	[ActivityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Tenant_001].[ActivityAttendee]    Script Date: 12/8/2021 8:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tenant_001].[ActivityAttendee](
	[AppUserFK] [uniqueidentifier] NOT NULL,
	[ActivityFK] [uniqueidentifier] NOT NULL,
	[IsHost] [bit] NOT NULL,
 CONSTRAINT [PK_ActivityAttendee] PRIMARY KEY CLUSTERED 
(
	[AppUserFK] ASC,
	[ActivityFK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Tenant_001].[ActivityPhoto]    Script Date: 12/8/2021 8:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tenant_001].[ActivityPhoto](
	[PhotoId] [nvarchar](450) NOT NULL,
	[Url] [nvarchar](max) NULL,
	[IsMain] [bit] NOT NULL,
	[ActivityFk] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ActivityPhoto] PRIMARY KEY CLUSTERED 
(
	[PhotoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Tenant_001].[Answer]    Script Date: 12/8/2021 8:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tenant_001].[Answer](
	[AnswerId] [uniqueidentifier] NOT NULL,
	[DisplayValue] [nvarchar](max) NULL,
	[EffectiveStartDate] [datetime2](7) NOT NULL,
	[EffectiveEndDate] [datetime2](7) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED 
(
	[AnswerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Tenant_001].[Appointment]    Script Date: 12/8/2021 8:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tenant_001].[Appointment](
	[AppointmentId] [uniqueidentifier] NOT NULL,
	[AppointmentStatusFK] [uniqueidentifier] NOT NULL,
	[CalendarItemFK] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[VisitFK] [uniqueidentifier] NOT NULL,
	[IsCancelled] [bit] NOT NULL,
	[CancellationDateTime] [datetime2](7) NOT NULL,
	[CancellationRequestBy] [uniqueidentifier] NOT NULL,
	[CancellationReason] [nvarchar](max) NULL,
	[IsRemainderSent] [bit] NOT NULL,
	[IsReScheduled] [bit] NOT NULL,
	[IsCustomerTurnUp] [bit] NOT NULL,
	[BookDate] [datetime2](7) NOT NULL,
	[StatusChangeDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
	[IsTelegram] [bit] NOT NULL,
 CONSTRAINT [PK_Appointment] PRIMARY KEY CLUSTERED 
(
	[AppointmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Tenant_001].[AppointmentCustomerProfile]    Script Date: 12/8/2021 8:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tenant_001].[AppointmentCustomerProfile](
	[AppointmentFK] [uniqueidentifier] NOT NULL,
	[CustomerProfileFK] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AppointmentCustomerProfile] PRIMARY KEY CLUSTERED 
(
	[AppointmentFK] ASC,
	[CustomerProfileFK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Tenant_001].[AppointmentService]    Script Date: 12/8/2021 8:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tenant_001].[AppointmentService](
	[AppointmentFK] [uniqueidentifier] NOT NULL,
	[SerivceFK] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AppointmentService] PRIMARY KEY CLUSTERED 
(
	[AppointmentFK] ASC,
	[SerivceFK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Tenant_001].[AppointmentTelegramCustomerProfile]    Script Date: 12/8/2021 8:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tenant_001].[AppointmentTelegramCustomerProfile](
	[AppointmentFK] [uniqueidentifier] NOT NULL,
	[TelegramCustomerProfileFK] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AppointmentTelegramCustomerProfile] PRIMARY KEY CLUSTERED 
(
	[AppointmentFK] ASC,
	[TelegramCustomerProfileFK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Tenant_001].[AppRoleClaims]    Script Date: 12/8/2021 8:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tenant_001].[AppRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Tenant_001].[AppUser]    Script Date: 12/8/2021 8:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tenant_001].[AppUser](
	[AppUserId] [uniqueidentifier] NOT NULL,
	[ActiveStatus] [nvarchar](max) NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
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
 CONSTRAINT [PK_AppUser] PRIMARY KEY CLUSTERED 
(
	[AppUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Tenant_001].[AppUserAppUserRole]    Script Date: 12/8/2021 8:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tenant_001].[AppUserAppUserRole](
	[AppUserRoleFK] [uniqueidentifier] NOT NULL,
	[AppUserFK] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AppUserAppUserRole] PRIMARY KEY CLUSTERED 
(
	[AppUserRoleFK] ASC,
	[AppUserFK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Tenant_001].[AppUserClaims]    Script Date: 12/8/2021 8:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tenant_001].[AppUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Tenant_001].[AppUserLogins]    Script Date: 12/8/2021 8:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tenant_001].[AppUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AppUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Tenant_001].[AppUserPhoto]    Script Date: 12/8/2021 8:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tenant_001].[AppUserPhoto](
	[PhotoId] [nvarchar](450) NOT NULL,
	[Url] [nvarchar](max) NULL,
	[IsMain] [bit] NOT NULL,
	[AppUserProfileFK] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AppUserPhoto] PRIMARY KEY CLUSTERED 
(
	[PhotoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Tenant_001].[AppUserProfile]    Script Date: 12/8/2021 8:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tenant_001].[AppUserProfile](
	[AppUserProfileId] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[DisplayName] [nvarchar](max) NULL,
	[Gender] [nvarchar](max) NULL,
	[Age] [nvarchar](max) NULL,
	[Bio] [nvarchar](max) NULL,
	[AppUserFK] [uniqueidentifier] NOT NULL,
	[ReligionFK] [uniqueidentifier] NOT NULL,
	[CountryFK] [uniqueidentifier] NOT NULL,
	[OccupationFK] [uniqueidentifier] NOT NULL,
	[Birthdate] [datetime2](7) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_AppUserProfile] PRIMARY KEY CLUSTERED 
(
	[AppUserProfileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Tenant_001].[AppUserQuestionAnswer]    Script Date: 12/8/2021 8:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tenant_001].[AppUserQuestionAnswer](
	[AppUserProfileFK] [uniqueidentifier] NOT NULL,
	[QuestionFK] [uniqueidentifier] NOT NULL,
	[AnswerFK] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AppUserQuestionAnswer] PRIMARY KEY CLUSTERED 
(
	[AppUserProfileFK] ASC,
	[QuestionFK] ASC,
	[AnswerFK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Tenant_001].[AppUserRole]    Script Date: 12/8/2021 8:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tenant_001].[AppUserRole](
	[RoleId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[SortOrder] [int] NOT NULL,
 CONSTRAINT [PK_AppUserRole] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Tenant_001].[CalendarItem]    Script Date: 12/8/2021 8:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tenant_001].[CalendarItem](
	[CalendarItemId] [uniqueidentifier] NOT NULL,
	[StartDateTime] [datetime2](7) NOT NULL,
	[EndDateTime] [datetime2](7) NOT NULL,
	[DurationHour] [int] NOT NULL,
	[DurationMinutes] [int] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_CalendarItem] PRIMARY KEY CLUSTERED 
(
	[CalendarItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Tenant_001].[CustomerProfile]    Script Date: 12/8/2021 8:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tenant_001].[CustomerProfile](
	[CustomerProfileId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
 CONSTRAINT [PK_CustomerProfile] PRIMARY KEY CLUSTERED 
(
	[CustomerProfileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Tenant_001].[Question]    Script Date: 12/8/2021 8:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tenant_001].[Question](
	[QuestionId] [uniqueidentifier] NOT NULL,
	[DisplayValue] [nvarchar](max) NULL,
	[IsUserMaintainable] [bit] NOT NULL,
	[EffectiveStartDate] [datetime2](7) NOT NULL,
	[EffectiveEndDate] [datetime2](7) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
	[Type] [nvarchar](max) NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Tenant_001].[QuestionAnswer]    Script Date: 12/8/2021 8:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tenant_001].[QuestionAnswer](
	[QuestionFk] [uniqueidentifier] NOT NULL,
	[AnswerFk] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_QuestionAnswer] PRIMARY KEY CLUSTERED 
(
	[QuestionFk] ASC,
	[AnswerFk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Tenant_001].[RefreshToken]    Script Date: 12/8/2021 8:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tenant_001].[RefreshToken](
	[RefreshTokenId] [uniqueidentifier] NOT NULL,
	[AppUserId] [uniqueidentifier] NULL,
	[Token] [nvarchar](max) NULL,
	[Expires] [datetime2](7) NOT NULL,
	[Revoked] [datetime2](7) NULL,
 CONSTRAINT [PK_RefreshToken] PRIMARY KEY CLUSTERED 
(
	[RefreshTokenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Tenant_001].[Service]    Script Date: 12/8/2021 8:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tenant_001].[Service](
	[ServiceId] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[EffectiveStartDate] [datetime2](7) NOT NULL,
	[EffectiveEndDate] [datetime2](7) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
	[SortOrder] [int] NOT NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[ServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Tenant_001].[ServiceItem]    Script Date: 12/8/2021 8:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tenant_001].[ServiceItem](
	[ServiceItemId] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[DurationHour] [int] NOT NULL,
	[DurationMinutes] [int] NOT NULL,
	[EffectiveStartDate] [datetime2](7) NOT NULL,
	[EffectiveEndDate] [datetime2](7) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
	[SortOrder] [int] NOT NULL,
 CONSTRAINT [PK_ServiceItem] PRIMARY KEY CLUSTERED 
(
	[ServiceItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Tenant_001].[ServiceServiceItem]    Script Date: 12/8/2021 8:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tenant_001].[ServiceServiceItem](
	[ServiceFK] [uniqueidentifier] NOT NULL,
	[ServiceItemFK] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ServiceServiceItem] PRIMARY KEY CLUSTERED 
(
	[ServiceFK] ASC,
	[ServiceItemFK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Tenant_001].[Store]    Script Date: 12/8/2021 8:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tenant_001].[Store](
	[StoreId] [uniqueidentifier] NOT NULL,
	[StoreName] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[OperatingStartHour] [int] NOT NULL,
	[OperatingStartMinutes] [int] NOT NULL,
	[OperatingEndHour] [int] NOT NULL,
	[OperatingEndMinutes] [int] NOT NULL,
	[IsOpenOnSaturday] [bit] NOT NULL,
	[IsOpenOnSunday] [bit] NOT NULL,
	[IsOpenOnWeekends] [bit] NOT NULL,
	[ServiceHoursPerHour] [int] NOT NULL,
 CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED 
(
	[StoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Tenant_001].[StoreOffDays]    Script Date: 12/8/2021 8:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tenant_001].[StoreOffDays](
	[StoreOffDaysId] [uniqueidentifier] NOT NULL,
	[StoreFK] [uniqueidentifier] NOT NULL,
	[OffDay] [datetime2](7) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_StoreOffDays] PRIMARY KEY CLUSTERED 
(
	[StoreOffDaysId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Tenant_001].[StoreSpecialOffs]    Script Date: 12/8/2021 8:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tenant_001].[StoreSpecialOffs](
	[StoreSpecialOffsId] [uniqueidentifier] NOT NULL,
	[StoreFK] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[OffDateTime] [datetime2](7) NOT NULL,
	[OffStartHour] [int] NOT NULL,
	[OffStartMinutes] [int] NOT NULL,
	[OffEndHour] [int] NOT NULL,
	[OffEndMinutes] [int] NOT NULL,
 CONSTRAINT [PK_StoreSpecialOffs] PRIMARY KEY CLUSTERED 
(
	[StoreSpecialOffsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Tenant_001].[TelegramCustomerProfile]    Script Date: 12/8/2021 8:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tenant_001].[TelegramCustomerProfile](
	[TelegramCustomerProfileId] [uniqueidentifier] NOT NULL,
	[ChatId] [bigint] NOT NULL,
	[Username] [nvarchar](max) NULL,
	[Bio] [nvarchar](max) NULL,
 CONSTRAINT [PK_TelegramCustomerProfile] PRIMARY KEY CLUSTERED 
(
	[TelegramCustomerProfileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [Tenant_001].[Appointment] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [StatusChangeDate]
GO
ALTER TABLE [Tenant_001].[Appointment] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [UpdateDate]
GO
ALTER TABLE [Tenant_001].[Appointment] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsTelegram]
GO
ALTER TABLE [Tenant_001].[AppUser] ADD  DEFAULT (N'A') FOR [ActiveStatus]
GO
ALTER TABLE [Tenant_001].[AppUserProfile] ADD  DEFAULT (N'') FOR [Bio]
GO
ALTER TABLE [Tenant_001].[AppUserProfile] ADD  DEFAULT ('00000000-0000-0000-0000-000000000009') FOR [ReligionFK]
GO
ALTER TABLE [Tenant_001].[AppUserProfile] ADD  DEFAULT ('00000000-0000-0000-0000-000000000233') FOR [CountryFK]
GO
ALTER TABLE [Tenant_001].[AppUserProfile] ADD  DEFAULT ('1990-01-01T00:00:00.0000000') FOR [Birthdate]
GO
ALTER TABLE [Tenant_001].[AppUserRole] ADD  DEFAULT ((0)) FOR [SortOrder]
GO
ALTER TABLE [Tenant_001].[Service] ADD  DEFAULT ('2999-12-31T00:00:00.0000000') FOR [EffectiveEndDate]
GO
ALTER TABLE [Tenant_001].[ServiceItem] ADD  DEFAULT ('2999-12-31T00:00:00.0000000') FOR [EffectiveEndDate]
GO
ALTER TABLE [Tenant_001].[Store] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsOpenOnSaturday]
GO
ALTER TABLE [Tenant_001].[Store] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsOpenOnSunday]
GO
ALTER TABLE [Tenant_001].[Store] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsOpenOnWeekends]
GO
ALTER TABLE [Tenant_001].[Store] ADD  DEFAULT ((0)) FOR [ServiceHoursPerHour]
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
ALTER TABLE [Tenant_001].[ActivityAttendee]  WITH CHECK ADD  CONSTRAINT [FK_ActivityAttendee_Activity_ActivityFK] FOREIGN KEY([ActivityFK])
REFERENCES [Tenant_001].[Activity] ([ActivityId])
ON DELETE CASCADE
GO
ALTER TABLE [Tenant_001].[ActivityAttendee] CHECK CONSTRAINT [FK_ActivityAttendee_Activity_ActivityFK]
GO
ALTER TABLE [Tenant_001].[ActivityAttendee]  WITH CHECK ADD  CONSTRAINT [FK_ActivityAttendee_AppUser_AppUserFK] FOREIGN KEY([AppUserFK])
REFERENCES [Tenant_001].[AppUser] ([AppUserId])
ON DELETE CASCADE
GO
ALTER TABLE [Tenant_001].[ActivityAttendee] CHECK CONSTRAINT [FK_ActivityAttendee_AppUser_AppUserFK]
GO
ALTER TABLE [Tenant_001].[ActivityPhoto]  WITH CHECK ADD  CONSTRAINT [FK_ActivityPhoto_Activity_ActivityFk] FOREIGN KEY([ActivityFk])
REFERENCES [Tenant_001].[Activity] ([ActivityId])
ON DELETE CASCADE
GO
ALTER TABLE [Tenant_001].[ActivityPhoto] CHECK CONSTRAINT [FK_ActivityPhoto_Activity_ActivityFk]
GO
ALTER TABLE [Tenant_001].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_CalendarItem_CalendarItemFK] FOREIGN KEY([CalendarItemFK])
REFERENCES [Tenant_001].[CalendarItem] ([CalendarItemId])
ON DELETE CASCADE
GO
ALTER TABLE [Tenant_001].[Appointment] CHECK CONSTRAINT [FK_Appointment_CalendarItem_CalendarItemFK]
GO
ALTER TABLE [Tenant_001].[AppointmentCustomerProfile]  WITH CHECK ADD  CONSTRAINT [FK_AppointmentCustomerProfile_Appointment_AppointmentFK] FOREIGN KEY([AppointmentFK])
REFERENCES [Tenant_001].[Appointment] ([AppointmentId])
ON DELETE CASCADE
GO
ALTER TABLE [Tenant_001].[AppointmentCustomerProfile] CHECK CONSTRAINT [FK_AppointmentCustomerProfile_Appointment_AppointmentFK]
GO
ALTER TABLE [Tenant_001].[AppointmentCustomerProfile]  WITH CHECK ADD  CONSTRAINT [FK_AppointmentCustomerProfile_CustomerProfile_CustomerProfileFK] FOREIGN KEY([CustomerProfileFK])
REFERENCES [Tenant_001].[CustomerProfile] ([CustomerProfileId])
ON DELETE CASCADE
GO
ALTER TABLE [Tenant_001].[AppointmentCustomerProfile] CHECK CONSTRAINT [FK_AppointmentCustomerProfile_CustomerProfile_CustomerProfileFK]
GO
ALTER TABLE [Tenant_001].[AppointmentService]  WITH CHECK ADD  CONSTRAINT [FK_AppointmentService_Appointment_AppointmentFK] FOREIGN KEY([AppointmentFK])
REFERENCES [Tenant_001].[Appointment] ([AppointmentId])
ON DELETE CASCADE
GO
ALTER TABLE [Tenant_001].[AppointmentService] CHECK CONSTRAINT [FK_AppointmentService_Appointment_AppointmentFK]
GO
ALTER TABLE [Tenant_001].[AppointmentService]  WITH CHECK ADD  CONSTRAINT [FK_AppointmentService_Service_SerivceFK] FOREIGN KEY([SerivceFK])
REFERENCES [Tenant_001].[Service] ([ServiceId])
ON DELETE CASCADE
GO
ALTER TABLE [Tenant_001].[AppointmentService] CHECK CONSTRAINT [FK_AppointmentService_Service_SerivceFK]
GO
ALTER TABLE [Tenant_001].[AppointmentTelegramCustomerProfile]  WITH CHECK ADD  CONSTRAINT [FK_AppointmentTelegramCustomerProfile_Appointment_AppointmentFK] FOREIGN KEY([AppointmentFK])
REFERENCES [Tenant_001].[Appointment] ([AppointmentId])
ON DELETE CASCADE
GO
ALTER TABLE [Tenant_001].[AppointmentTelegramCustomerProfile] CHECK CONSTRAINT [FK_AppointmentTelegramCustomerProfile_Appointment_AppointmentFK]
GO
ALTER TABLE [Tenant_001].[AppointmentTelegramCustomerProfile]  WITH CHECK ADD  CONSTRAINT [FK_AppointmentTelegramCustomerProfile_TelegramCustomerProfile_TelegramCustomerProfileFK] FOREIGN KEY([TelegramCustomerProfileFK])
REFERENCES [Tenant_001].[TelegramCustomerProfile] ([TelegramCustomerProfileId])
ON DELETE CASCADE
GO
ALTER TABLE [Tenant_001].[AppointmentTelegramCustomerProfile] CHECK CONSTRAINT [FK_AppointmentTelegramCustomerProfile_TelegramCustomerProfile_TelegramCustomerProfileFK]
GO
ALTER TABLE [Tenant_001].[AppRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AppRoleClaims_AppUserRole_RoleId] FOREIGN KEY([RoleId])
REFERENCES [Tenant_001].[AppUserRole] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [Tenant_001].[AppRoleClaims] CHECK CONSTRAINT [FK_AppRoleClaims_AppUserRole_RoleId]
GO
ALTER TABLE [Tenant_001].[AppUserAppUserRole]  WITH CHECK ADD  CONSTRAINT [FK_AppUserAppUserRole_AppUser_AppUserFK] FOREIGN KEY([AppUserFK])
REFERENCES [Tenant_001].[AppUser] ([AppUserId])
ON DELETE CASCADE
GO
ALTER TABLE [Tenant_001].[AppUserAppUserRole] CHECK CONSTRAINT [FK_AppUserAppUserRole_AppUser_AppUserFK]
GO
ALTER TABLE [Tenant_001].[AppUserAppUserRole]  WITH CHECK ADD  CONSTRAINT [FK_AppUserAppUserRole_AppUserRole_AppUserRoleFK] FOREIGN KEY([AppUserRoleFK])
REFERENCES [Tenant_001].[AppUserRole] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [Tenant_001].[AppUserAppUserRole] CHECK CONSTRAINT [FK_AppUserAppUserRole_AppUserRole_AppUserRoleFK]
GO
ALTER TABLE [Tenant_001].[AppUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AppUserClaims_AppUser_UserId] FOREIGN KEY([UserId])
REFERENCES [Tenant_001].[AppUser] ([AppUserId])
ON DELETE CASCADE
GO
ALTER TABLE [Tenant_001].[AppUserClaims] CHECK CONSTRAINT [FK_AppUserClaims_AppUser_UserId]
GO
ALTER TABLE [Tenant_001].[AppUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AppUserLogins_AppUser_UserId] FOREIGN KEY([UserId])
REFERENCES [Tenant_001].[AppUser] ([AppUserId])
ON DELETE CASCADE
GO
ALTER TABLE [Tenant_001].[AppUserLogins] CHECK CONSTRAINT [FK_AppUserLogins_AppUser_UserId]
GO
ALTER TABLE [Tenant_001].[AppUserPhoto]  WITH CHECK ADD  CONSTRAINT [FK_AppUserPhoto_AppUserProfile_AppUserProfileFK] FOREIGN KEY([AppUserProfileFK])
REFERENCES [Tenant_001].[AppUserProfile] ([AppUserProfileId])
ON DELETE CASCADE
GO
ALTER TABLE [Tenant_001].[AppUserPhoto] CHECK CONSTRAINT [FK_AppUserPhoto_AppUserProfile_AppUserProfileFK]
GO
ALTER TABLE [Tenant_001].[AppUserProfile]  WITH CHECK ADD  CONSTRAINT [FK_AppUserProfile_AppUser_AppUserFK] FOREIGN KEY([AppUserFK])
REFERENCES [Tenant_001].[AppUser] ([AppUserId])
ON DELETE CASCADE
GO
ALTER TABLE [Tenant_001].[AppUserProfile] CHECK CONSTRAINT [FK_AppUserProfile_AppUser_AppUserFK]
GO
ALTER TABLE [Tenant_001].[AppUserQuestionAnswer]  WITH CHECK ADD  CONSTRAINT [FK_AppUserQuestionAnswer_Answer_AnswerFK] FOREIGN KEY([AnswerFK])
REFERENCES [Tenant_001].[Answer] ([AnswerId])
ON DELETE CASCADE
GO
ALTER TABLE [Tenant_001].[AppUserQuestionAnswer] CHECK CONSTRAINT [FK_AppUserQuestionAnswer_Answer_AnswerFK]
GO
ALTER TABLE [Tenant_001].[AppUserQuestionAnswer]  WITH CHECK ADD  CONSTRAINT [FK_AppUserQuestionAnswer_AppUserProfile_AppUserProfileFK] FOREIGN KEY([AppUserProfileFK])
REFERENCES [Tenant_001].[AppUserProfile] ([AppUserProfileId])
ON DELETE CASCADE
GO
ALTER TABLE [Tenant_001].[AppUserQuestionAnswer] CHECK CONSTRAINT [FK_AppUserQuestionAnswer_AppUserProfile_AppUserProfileFK]
GO
ALTER TABLE [Tenant_001].[AppUserQuestionAnswer]  WITH CHECK ADD  CONSTRAINT [FK_AppUserQuestionAnswer_Question_QuestionFK] FOREIGN KEY([QuestionFK])
REFERENCES [Tenant_001].[Question] ([QuestionId])
ON DELETE CASCADE
GO
ALTER TABLE [Tenant_001].[AppUserQuestionAnswer] CHECK CONSTRAINT [FK_AppUserQuestionAnswer_Question_QuestionFK]
GO
ALTER TABLE [Tenant_001].[QuestionAnswer]  WITH CHECK ADD  CONSTRAINT [FK_QuestionAnswer_Answer_AnswerFk] FOREIGN KEY([AnswerFk])
REFERENCES [Tenant_001].[Answer] ([AnswerId])
ON DELETE CASCADE
GO
ALTER TABLE [Tenant_001].[QuestionAnswer] CHECK CONSTRAINT [FK_QuestionAnswer_Answer_AnswerFk]
GO
ALTER TABLE [Tenant_001].[QuestionAnswer]  WITH CHECK ADD  CONSTRAINT [FK_QuestionAnswer_Question_QuestionFk] FOREIGN KEY([QuestionFk])
REFERENCES [Tenant_001].[Question] ([QuestionId])
ON DELETE CASCADE
GO
ALTER TABLE [Tenant_001].[QuestionAnswer] CHECK CONSTRAINT [FK_QuestionAnswer_Question_QuestionFk]
GO
ALTER TABLE [Tenant_001].[RefreshToken]  WITH CHECK ADD  CONSTRAINT [FK_RefreshToken_AppUser_AppUserId] FOREIGN KEY([AppUserId])
REFERENCES [Tenant_001].[AppUser] ([AppUserId])
GO
ALTER TABLE [Tenant_001].[RefreshToken] CHECK CONSTRAINT [FK_RefreshToken_AppUser_AppUserId]
GO
ALTER TABLE [Tenant_001].[ServiceServiceItem]  WITH CHECK ADD  CONSTRAINT [FK_ServiceServiceItem_Service_ServiceFK] FOREIGN KEY([ServiceFK])
REFERENCES [Tenant_001].[Service] ([ServiceId])
ON DELETE CASCADE
GO
ALTER TABLE [Tenant_001].[ServiceServiceItem] CHECK CONSTRAINT [FK_ServiceServiceItem_Service_ServiceFK]
GO
ALTER TABLE [Tenant_001].[ServiceServiceItem]  WITH CHECK ADD  CONSTRAINT [FK_ServiceServiceItem_ServiceItem_ServiceItemFK] FOREIGN KEY([ServiceItemFK])
REFERENCES [Tenant_001].[ServiceItem] ([ServiceItemId])
ON DELETE CASCADE
GO
ALTER TABLE [Tenant_001].[ServiceServiceItem] CHECK CONSTRAINT [FK_ServiceServiceItem_ServiceItem_ServiceItemFK]
GO
ALTER TABLE [Tenant_001].[StoreOffDays]  WITH CHECK ADD  CONSTRAINT [FK_StoreOffDays_Store_StoreFK] FOREIGN KEY([StoreFK])
REFERENCES [Tenant_001].[Store] ([StoreId])
ON DELETE CASCADE
GO
ALTER TABLE [Tenant_001].[StoreOffDays] CHECK CONSTRAINT [FK_StoreOffDays_Store_StoreFK]
GO
ALTER TABLE [Tenant_001].[StoreSpecialOffs]  WITH CHECK ADD  CONSTRAINT [FK_StoreSpecialOffs_Store_StoreFK] FOREIGN KEY([StoreFK])
REFERENCES [Tenant_001].[Store] ([StoreId])
ON DELETE CASCADE
GO
ALTER TABLE [Tenant_001].[StoreSpecialOffs] CHECK CONSTRAINT [FK_StoreSpecialOffs_Store_StoreFK]
GO
