select * from Tenant_001.Service
select * from Tenant_001.ServiceServiceItem
select * from Tenant_001.ServiceItem
select * from AppointmentMain.CTAppointmentStatus
select * from Tenant_001.Appointment
select * from Tenant_001.AppointmentService
select * from Tenant_001.AppointmentCustomerProfile
select * from Tenant_001.CalendarItem
select * from Tenant_001.CustomerProfile
select * from Tenant_001.AppUserRole
select * from Tenant_001.AppUser
select * from AppointmentMain.TenantMapping
delete AppointmentMain.TenantMapping where TenantID = 'A6DB56A2-FEB5-483E-A96A-08D93C2F5478'

delete Tenant_001.Service where ServiceId = '162EF9D2-7EA3-4E6A-3E4B-08D939E8EF7F'
delete Tenant_001.Appointment where AppointmentId = '1B3EDA8C-61F1-467B-81F8-08D93A144ABD'

delete Tenant_001.ServiceItem where ServiceItemId in ('CA155F3C-1F05-426F-E4EC-08D93B50E79A')



7322C637-E2F6-454F-0841-08D91E4E7C82

insert Tenant_001.AppUserAppUserRole
values ('47DE64DA-9C65-4CF1-068E-08D9391BEAF0','7322C637-E2F6-454F-0841-08D91E4E7C82')
insert Tenant_001.AppUserAppUserRole
values ('FB3FD0C2-D6EB-48B1-068F-08D9391BEAF0','6d1f565b-7483-47bf-0842-08d91e4e7c82')

select * from APILog order by TimeStamp desc