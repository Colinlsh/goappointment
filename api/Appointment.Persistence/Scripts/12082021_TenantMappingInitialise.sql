USE [Appointment_R0.1]
GO
INSERT [AppointmentMain].[TenantMapping] ([TenantID], [TenantCode], [SchemaName], [DBServer], [DBName], [DBUserName], [DBUserPassword], [CreateDate], [CreateBy], [UpdateDate], [UpdateBy], [TenantIndex], [HeCode], [IsMobileEnabled]) VALUES (N'b3bf5c06-7b37-43f9-59e7-08d9390fafdc', N'Tenant_001', N'Tenant_001', N'db', N'Appointment_R0.1', N'Tenant_001', N'Tenant_001', CAST(N'2021-06-27T02:02:58.7172580' AS DateTime2), N'Colin88888888', CAST(N'2021-06-27T02:02:58.7173099' AS DateTime2), N'Colin88888888', 1, N'AP0001', NULL)
GO
INSERT [AppointmentMain].[TenantMapping] ([TenantID], [TenantCode], [SchemaName], [DBServer], [DBName], [DBUserName], [DBUserPassword], [CreateDate], [CreateBy], [UpdateDate], [UpdateBy], [TenantIndex], [HeCode], [IsMobileEnabled]) VALUES (N'963d0a69-2bb6-4208-fff0-08d93ed5f6d5', N'Tenant_002', N'Tenant_002', N'db', N'Appointment_R0.1', N'Tenant_002', N'Tenant_002', CAST(N'2021-07-04T10:24:53.9629538' AS DateTime2), N'Colin88888888', CAST(N'2021-07-04T10:24:53.9630097' AS DateTime2), N'Colin88888888', 2, N'AP0002', NULL)
GO