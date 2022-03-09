USE [Appointment_R0.1]
GO
-- super admin
INSERT [AppointmentMain].[DashboardSuperAdminUser] ([SuperAdminUserId], [CreateDate], [UpdateDate],[UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'7322c637-e2f6-454f-0841-08d91e4e7c82', CAST(N'2021-05-24T08:54:29.3622084' AS DateTime2), CAST(N'2021-05-24T08:54:29.3618877' AS DateTime2), N'Colin88888888', N'COLIN88888888', N'Colin88888888@test.com', N'COLIN88888888@TEST.COM', 0, N'AQAAAAEAACcQAAAAEP53nnHw1wXJ+d/a3/JTu6YjBq8/bUTV12N8/y7vjZy/qK5uFu/SoFJdh+1G/QWXOw==', N'C2SBRY53AP37C2ANEDUUOP7QDP6SYKHR', N'c35a04b8-9f5f-4fe2-86ce-d282e674e754', N'98989898', 0, 0, NULL, 1, 0)

select * from AppointmentMain.DashboardSuperAdminUser
select * from [AppointmentMain].TenantMapping
update [AppointmentMain].TenantMapping
set DBServer = 'db'
update [AppointmentMain].TenantMapping
set DBServer = 'localhost,1433'




INSERT [Tenant_001].[AppUser] ([Id], [CreateDate], [UpdateDate],[UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'7322c637-e2f6-454f-0841-08d91e4e7c82', CAST(N'2021-05-24T08:54:29.3622084' AS DateTime2), CAST(N'2021-05-24T08:54:29.3618877' AS DateTime2), N'Colin88888888', N'COLIN88888888', N'Colin88888888@test.com', N'COLIN88888888@TEST.COM', 0, N'AQAAAAEAACcQAAAAEP53nnHw1wXJ+d/a3/JTu6YjBq8/bUTV12N8/y7vjZy/qK5uFu/SoFJdh+1G/QWXOw==', N'C2SBRY53AP37C2ANEDUUOP7QDP6SYKHR', N'c35a04b8-9f5f-4fe2-86ce-d282e674e754', N'98989898', 0, 0, NULL, 1, 0)

INSERT [Tenant_001].[AppUser] ([Id], [ActiveStatus], [CreateDate], [UpdateDate], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'6d1f565b-7483-47bf-0842-08d91e4e7c82', N'A',CAST(N'2021-05-24T08:54:29.3627034' AS DateTime2), CAST(N'2021-05-24T08:54:29.3627029' AS DateTime2),  N'Jane88888888', N'JANE88888888', N'Jane88888888@test.com', N'JANE88888888@TEST.COM', 0, N'AQAAAAEAACcQAAAAEP53nnHw1wXJ+d/a3/JTu6YjBq8/bUTV12N8/y7vjZy/qK5uFu/SoFJdh+1G/QWXOw==', N'DK742UR6RTBTNRT2MCWOMH6C5JXMIQFK', N'f84fe583-690d-4e13-af76-03b4ab52a999', N'98888888', 0, 0, NULL, 1, 0)

INSERT INTO [Tenant_001].[AppUserProfile]
           ([AppUserProfileId]
           ,[Title]
           ,[FirstName]
           ,[LastName]
           ,[DisplayName]
           ,[Gender]
           ,[Age]
           ,[Bio]
           ,[AppUserFK]
           ,[ReligionFK]
           ,[CountryFK]
           ,[OccupationFK]
           ,[Birthdate]
           ,[CreateDate]
           ,[UpdateDate])
     VALUES
           ('F0A7F42D-D190-4156-BE45-8C5D2664E990'
           ,N'Mr', N'Colin', N'Lee', N'Colin'
           ,'M'
           , N'30'
           , N''
           ,'7322c637-e2f6-454f-0841-08d91e4e7c82'
           ,N'00000000-0000-0000-0000-000000000009', N'00000000-0000-0000-0000-000000000233', N'00000000-0000-0000-0000-000000000000'
           ,CAST(N'1990-01-01T00:00:00.0000000' AS DateTime2)
           ,CAST(N'2021-05-24T08:54:29.3622084' AS DateTime2), CAST(N'2021-05-24T08:54:29.3618877' AS DateTime2))
GO

--INSERT [Tenant_002].[AppUser] ([Id], [ActiveStatus], [CreateDate], [UpdateDate], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'6d1f565b-7483-47bf-0842-08d91e4e7c82', N'A',CAST(N'2021-05-24T08:54:29.3627034' AS DateTime2), CAST(N'2021-05-24T08:54:29.3627029' AS DateTime2),  N'Jane88888888', N'JANE88888888', N'Jane88888888@test.com', N'JANE88888888@TEST.COM', 0, N'AQAAAAEAACcQAAAAEP53nnHw1wXJ+d/a3/JTu6YjBq8/bUTV12N8/y7vjZy/qK5uFu/SoFJdh+1G/QWXOw==', N'DK742UR6RTBTNRT2MCWOMH6C5JXMIQFK', N'f84fe583-690d-4e13-af76-03b4ab52a999', N'98888888', 0, 0, NULL, 1, 0)

--USE [Appointment_R0.1]
--GO

--select * from Tenant_002.AppUser
--select * from AppointmentMain.TenantMapping

--delete Tenant_001.
--where Id = '6d1f565b-7483-47bf-0842-08d91e4e7c82'


--INSERT INTO [Tenant_001].[AppUserProfile]
--           ([AppUserProfileId]
--           ,[Title]
--           ,[FirstName]
--           ,[LastName]
--           ,[DisplayName]
--           ,[Gender]
--           ,[Age]
--           ,[Bio]
--           ,[AppUserFK]
--           ,[ReligionFK]
--           ,[CountryFK]
--           ,[OccupationFK]
--           ,[Birthdate]
--           ,[CreateDate]
--           ,[UpdateDate])
--     VALUES
--           ('F0A7F42D-D190-4156-BE45-8C5D2664E990'
--           ,N'Mr', N'Colin', N'Lee', N'Colin'
--           ,'M'
--           , N'30'
--           , N''
--           ,'7322c637-e2f6-454f-0841-08d91e4e7c82'
--           ,N'00000000-0000-0000-0000-000000000009', N'00000000-0000-0000-0000-000000000233', N'00000000-0000-0000-0000-000000000000'
--           ,CAST(N'1990-01-01T00:00:00.0000000' AS DateTime2)
--           ,CAST(N'2021-05-24T08:54:29.3622084' AS DateTime2), CAST(N'2021-05-24T08:54:29.3618877' AS DateTime2))
--GO

--INSERT INTO [Tenant_002].[AppUserProfile]
--           ([AppUserProfileId]
--           ,[Title]
--           ,[FirstName]
--           ,[LastName]
--           ,[DisplayName]
--           ,[Gender]
--           ,[Age]
--           ,[Bio]
--           ,[AppUserFK]
--           ,[ReligionFK]
--           ,[CountryFK]
--           ,[OccupationFK]
--           ,[Birthdate]
--           ,[CreateDate]
--           ,[UpdateDate])
--     VALUES
--           ('7CB89516-1E97-47DA-8A69-94D121B5FE45',N'Mrs', N'Jane', N'Goh', N'Jane'
--           ,'F'
--           ,'30'
--           ,''
--           ,'6d1f565b-7483-47bf-0842-08d91e4e7c82',N'00000000-0000-0000-0000-000000000009', N'00000000-0000-0000-0000-000000000233', N'00000000-0000-0000-0000-000000000000'
--           ,CAST(N'1990-01-01T00:00:00.0000000' AS DateTime2)
--           ,CAST(N'2021-05-24T08:54:29.3627034' AS DateTime2), CAST(N'2021-05-24T08:54:29.3627029' AS DateTime2))
--GO