using Appointment.Domain.Enums;
using Appointment.Domain.Tenant;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Appointment.Persistence
{
    public partial class AppointmentDataContext
    {
        public DbSet<Activity> Activity { get; set; }
        public DbSet<ActivityAttendee> ActivityAttendee { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswer { get; set; }
        public DbSet<AppUserQuestionAnswer> AppUserQuestionAnswer { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<AppUserPhoto> Photo { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }
        public DbSet<ServiceServiceItem> ServiceServiceItem { get; set; }
        public DbSet<ServiceItem> ServiceItem { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<AppointmentService> AppointmentService { get; set; }
        public DbSet<Domain.Tenant.Appointment> Appointment { get; set; }
        public DbSet<AppointmentCustomerProfile> AppointmentCustomerProfile { get; set; }
        public DbSet<AppointmentTelegramCustomerProfile> AppointmentTelegramCustomerProfile { get; set; }
        public DbSet<CustomerProfile> CustomerProfile { get; set; }
        public DbSet<CalendarItem> CalendarItem { get; set; }
        // public DbSet<AppUserRole> AppUserRole { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<StoreOffDays> StoreOffDays { get; set; }
        public DbSet<StoreSpecialOffs> StoreSpecialOffs { get; set; }
        public DbSet<TelegramCustomerProfile> TelegramCustomerProfile { get; set; }
        public DbSet<TenantSettings> TenantSettings { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // identity declaration
            builder.Entity<AppUser>().ToTable(nameof(AppUser), Schema);
            builder.Entity<AdminUser>().ToTable(nameof(AdminUser), Schema);
            // builder.Entity<AdminUser>().HasKey(x => x.Id);
            // builder.Entity<AdminUser>().

            // builder.Entity<AppUserRole>().ToTable(nameof(AppUserRole), Schema).Property(au => au.Id).HasColumnName("RoleId");
            // builder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims", Schema);
            // builder.Entity<IdentityUserLogin<Guid>>(entity => { entity.ToTable("AppUserLogins", Schema); });
            // builder.Ignore<IdentityUserToken<Guid>>();
            //builder.Entity<AppUserToken>(entity => { entity.ToTable("AppUserTokens", Schema); });
            // builder.Entity<IdentityRoleClaim<Guid>>(entity => { entity.ToTable("AppRoleClaims", Schema); });
            // builder.Ignore<IdentityUserRole<Guid>>();

            builder.Entity<TenantSettings>().ToTable(nameof(TenantSettings), Schema).HasKey(ts => ts.TenantSettingID);

            DeclareAdminUserRelationship(builder);

            DeclareAppointmentTelegramCustomerProfileRelationship(builder);

            DeclareTelegramCustomerProfileRelationship(builder);

            DeclareStoreRelationship(builder);

            DeclareStoreOffDaysRelationship(builder);

            DeclareStoreSpecialOffDaysRelationship(builder);

            DeclareAppUserAppUserRoleRelationship(builder);

            DeclareAppointmentServiceRelationship(builder);

            DeclareCustomerProfileRelationship(builder);

            DeclareAppointmentCustomerProfileRelationship(builder);

            DeclareCalendarItemRelationship(builder);

            DeclareAppointmentRelationship(builder);

            DeclareServiceItemRelationship(builder);

            DeclareServiceServiceItemRelationship(builder);

            DeclareServiceRelationship(builder);

            DeclareRefreshTokenRelationship(builder);

            DeclareAppUserRelationship(builder);

            DeclareUserProfileRelationship(builder);

            DeclarePhotoRelationship(builder);

            DeclareActivityAttendeeRelationship(builder);

            DeclareAppUserQuestionAnswerRelationship(builder);

            DeclareQuestionAnswerRelationship(builder);

            DeclareQuestionRelationship(builder);

            DeclareAnswerRelationship(builder);

            DeclareActivityRelationship(builder);
        }

        private void DeclareAppointmentTelegramCustomerProfileRelationship(ModelBuilder builder)
        {
            builder.Entity<AppointmentTelegramCustomerProfile>().HasKey(x => new { x.AppointmentFK, x.TelegramCustomerProfileFK });
            builder.Entity<AppointmentTelegramCustomerProfile>().ToTable(nameof(AppointmentTelegramCustomerProfile), Schema);

            builder.Entity<AppointmentTelegramCustomerProfile>()
                .HasOne(tcp => tcp.Appointment)
                .WithMany(a => a.TelegramCustomerProfile)
                .HasForeignKey(x => x.TelegramCustomerProfileFK);

            builder.Entity<AppointmentTelegramCustomerProfile>()
                .HasOne(tcp => tcp.TelegramCustomerProfile)
                .WithMany(a => a.Appointments)
                .HasForeignKey(x => x.AppointmentFK);
        }

        private void DeclareTelegramCustomerProfileRelationship(ModelBuilder builder)
        {
            builder.Entity<TelegramCustomerProfile>().HasKey(x => x.TelegramCustomerProfileId);
            builder.Entity<TelegramCustomerProfile>().ToTable(nameof(TelegramCustomerProfile), Schema);

            builder.Entity<TelegramCustomerProfile>()
                .HasMany(tcp => tcp.Appointments)
                .WithOne(a => a.TelegramCustomerProfile)
                .HasForeignKey(tcp => tcp.TelegramCustomerProfileFK);
        }

        private void DeclareStoreSpecialOffDaysRelationship(ModelBuilder builder)
        {
            builder.Entity<StoreSpecialOffs>().HasKey(x => x.Id);
            builder.Entity<StoreSpecialOffs>().ToTable(nameof(StoreSpecialOffs), Schema);

            builder.Entity<StoreSpecialOffs>()
                .HasOne(od => od.Store)
                .WithMany(s => s.SpecialOffDays)
                .HasForeignKey(od => od.StoreFK);

            builder.Entity<StoreSpecialOffs>().Property(s => s.IsDaily).HasDefaultValue(false);
        }

        private void DeclareStoreOffDaysRelationship(ModelBuilder builder)
        {
            builder.Entity<StoreOffDays>().HasKey(x => x.Id);
            builder.Entity<StoreOffDays>().ToTable(nameof(StoreOffDays), Schema);

            builder.Entity<StoreOffDays>()
                .HasOne(od => od.Store)
                .WithMany(s => s.OffDays)
                .HasForeignKey(od => od.StoreFK);
        }

        private void DeclareStoreRelationship(ModelBuilder builder)
        {
            builder.Entity<Store>().HasKey(x => x.Id);
            builder.Entity<Store>()
                .HasMany(s => s.OffDays)
                .WithOne(of => of.Store)
                .HasForeignKey(s => s.StoreFK);

            builder.Entity<Store>()
                .HasMany(s => s.SpecialOffDays)
                .WithOne(of => of.Store)
                .HasForeignKey(s => s.StoreFK);

            builder.Entity<Store>().ToTable(nameof(Store), Schema);
        }

        private void DeclareAppUserAppUserRoleRelationship(ModelBuilder builder)
        {
            // builder.Entity<AppUserAppUserRole>().ToTable(nameof(AppUserAppUserRole), Schema);
            // builder.Entity<AppUserAppUserRole>().HasKey(x => new { x.AppUserRoleFK, x.AppUserFK });

            // builder.Entity<AppUserAppUserRole>()
            //     .HasOne(auaur => auaur.AppUser)
            //     .WithMany(au => au.AppUserRoles)
            //     .HasForeignKey(auaur => auaur.AppUserFK);

            // builder.Entity<AppUserAppUserRole>()
            //     .HasOne(auaur => auaur.AppUserRole)
            //     .WithMany(au => au.AppUsers)
            //     .HasForeignKey(auaur => auaur.AppUserRoleFK);
        }

        private void DeclareAppointmentServiceRelationship(ModelBuilder builder)
        {
            builder.Entity<AppointmentService>().ToTable(nameof(AppointmentService), Schema);
            builder.Entity<AppointmentService>().HasKey(x => new { x.AppointmentFK, x.SerivceFK });
            builder.Entity<AppointmentService>()
                .HasOne(apps => apps.Appointment)
                .WithMany(a => a.Services)
                .HasForeignKey(apps => apps.AppointmentFK);
            builder.Entity<AppointmentService>()
                .HasOne(apps => apps.Service)
                .WithMany(a => a.Appointments)
                .HasForeignKey(apps => apps.SerivceFK);
        }

        private void DeclareCustomerProfileRelationship(ModelBuilder builder)
        {
            builder.Entity<CustomerProfile>().ToTable(nameof(CustomerProfile), Schema);
            builder.Entity<CustomerProfile>().HasKey(x => x.Id);
            builder.Entity<CustomerProfile>()
                .HasMany(cp => cp.Appointments)
                .WithOne(acp => acp.CustomerProfile)
                .HasForeignKey(cp => cp.AppointmentFK);
        }

        private void DeclareAppointmentCustomerProfileRelationship(ModelBuilder builder)
        {
            builder.Entity<AppointmentCustomerProfile>().ToTable(nameof(AppointmentCustomerProfile), Schema);
            builder.Entity<AppointmentCustomerProfile>().HasKey(x => new { x.AppointmentFK, x.CustomerProfileFK });
            builder.Entity<AppointmentCustomerProfile>()
                .HasOne(acp => acp.Appointment)
                .WithMany(a => a.CustomerProfiles)
                .HasForeignKey(acp => acp.AppointmentFK);

            builder.Entity<AppointmentCustomerProfile>()
                .HasOne(acp => acp.CustomerProfile)
                .WithMany(cp => cp.Appointments)
                .HasForeignKey(acp => acp.CustomerProfileFK);
        }

        private void DeclareCalendarItemRelationship(ModelBuilder builder)
        {
            builder.Entity<CalendarItem>().ToTable(nameof(CalendarItem), Schema);
            builder.Entity<CalendarItem>().HasKey(x => x.Id);

            builder.Entity<CalendarItem>()
                .HasOne(ci => ci.Appointment)
                .WithOne(a => a.CalendarItem)
                .HasForeignKey<Domain.Tenant.Appointment>(a => a.CalendarItemFK);
        }

        private void DeclareAppointmentRelationship(ModelBuilder builder)
        {
            builder.Entity<Domain.Tenant.Appointment>().ToTable(nameof(Appointment), Schema);
            builder.Entity<Domain.Tenant.Appointment>().HasKey(x => x.Id);
            builder.Entity<Domain.Tenant.Appointment>()
                .HasOne(a => a.CalendarItem)
                .WithOne(ci => ci.Appointment)
                .HasForeignKey<Domain.Tenant.Appointment>(a => a.CalendarItemFK);

            builder.Entity<Domain.Tenant.Appointment>()
                .HasMany(a => a.TelegramCustomerProfile)
                .WithOne(atcp => atcp.Appointment)
                .HasForeignKey(atcp => atcp.AppointmentFK);
        }

        private void DeclareServiceItemRelationship(ModelBuilder builder)
        {
            builder.Entity<ServiceItem>().ToTable(nameof(ServiceItem), Schema);
            builder.Entity<ServiceItem>().HasKey(x => x.Id);

            builder.Entity<ServiceItem>().Property(s => s.EffectiveEndDate).HasDefaultValue(DateTime.Parse("2999-12-31 00:00:00"));
        }

        private void DeclareServiceServiceItemRelationship(ModelBuilder builder)
        {
            builder.Entity<ServiceServiceItem>().ToTable(nameof(ServiceServiceItem), Schema);
            builder.Entity<ServiceServiceItem>().HasKey(x => new { x.ServiceFK, x.ServiceItemFK });

            builder.Entity<ServiceServiceItem>()
                .HasOne(ssi => ssi.Service)
                .WithMany(s => s.ServiceItems)
                .HasForeignKey(x => x.ServiceFK);

            builder.Entity<ServiceServiceItem>()
                .HasOne(ssi => ssi.ServiceItem)
                .WithMany(s => s.Services)
                .HasForeignKey(x => x.ServiceItemFK);
        }

        private void DeclareServiceRelationship(ModelBuilder builder)
        {
            builder.Entity<Service>().ToTable(nameof(Service), Schema);
            builder.Entity<Service>().HasKey(x => x.Id);

            builder.Entity<Service>().Property(s => s.EffectiveEndDate).HasDefaultValue(DateTime.Parse("2999-12-31 00:00:00"));
        }

        private void DeclareRefreshTokenRelationship(ModelBuilder builder)
        {
            builder.Entity<RefreshToken>().ToTable(nameof(RefreshToken), Schema);
            builder.Entity<RefreshToken>().HasKey(x => x.RefreshTokenId);
            // builder.Entity<RefreshToken>().HasOne(x => x.AppUser).WithMany(y => y.RefreshTokens);
        }

        private void DeclareActivityRelationship(ModelBuilder builder)
        {
            builder.Entity<Activity>().ToTable(nameof(Activity), Schema);
            builder.Entity<Activity>().HasKey(x => x.ActivityId);
        }

        private void DeclareAnswerRelationship(ModelBuilder builder)
        {
            builder.Entity<Answer>().ToTable(nameof(Answer), Schema);
            builder.Entity<Answer>().HasKey(x => x.AnswerId);
        }

        private void DeclareQuestionRelationship(ModelBuilder builder)
        {
            builder.Entity<Question>().ToTable(nameof(Question), Schema);
            builder.Entity<Question>().HasKey(x => x.QuestionId);
        }

        private void DeclarePhotoRelationship(ModelBuilder builder)
        {
            builder.Entity<AppUserPhoto>().ToTable(nameof(AppUserPhoto), Schema);

            builder.Entity<AppUserPhoto>()
                .HasKey(p => new { p.Id });

            builder.Entity<AppUserPhoto>()
                .HasOne(p => p.AppUserProfile)
                .WithMany(au => au.Photos)
                .HasForeignKey(p => p.AppUserProfileFK);

            builder.Entity<ActivityPhoto>().ToTable(nameof(ActivityPhoto), Schema);

            builder.Entity<ActivityPhoto>()
                .HasKey(p => new { p.PhotoId });

            builder.Entity<ActivityPhoto>()
                .HasOne(p => p.Activity)
                .WithMany(au => au.ActivityPhotos)
                .HasForeignKey(p => p.ActivityFk);
        }

        private void DeclareQuestionAnswerRelationship(ModelBuilder builder)
        {
            builder.Entity<QuestionAnswer>().ToTable(nameof(QuestionAnswer), Schema);

            builder.Entity<QuestionAnswer>(x => x.HasKey(aa => new
            {
                aa.QuestionFk,
                aa.AnswerFk,
            }));

            builder.Entity<QuestionAnswer>()
                .HasOne(qa => qa.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(qa => qa.QuestionFk);

            builder.Entity<QuestionAnswer>()
                .HasOne(qa => qa.Answer)
                .WithMany(q => q.Questions)
                .HasForeignKey(qa => qa.AnswerFk);
        }

        private void DeclareAppUserQuestionAnswerRelationship(ModelBuilder builder)
        {
            builder.Entity<AppUserQuestionAnswer>().ToTable("AppUserQuestionAnswer", Schema);

            builder.Entity<AppUserQuestionAnswer>(x => x.HasKey(aa => new
            {
                aa.AppUserProfileFK,
                aa.QuestionFK,
                aa.AnswerFK,
            }));

            builder.Entity<AppUserQuestionAnswer>()
                .HasOne(auqa => auqa.AppUserProfile)
                .WithMany(a => a.QuestionAnswers)
                .HasForeignKey(auqa => auqa.AppUserProfileFK);

            builder.Entity<AppUserQuestionAnswer>()
                .HasOne(auqa => auqa.Question)
                .WithMany(q => q.AppUserAnswers)
                .HasForeignKey(auqa => auqa.QuestionFK);

            builder.Entity<AppUserQuestionAnswer>()
                .HasOne(auqa => auqa.Answer)
                .WithMany(a => a.AppUserQuestions)
                .HasForeignKey(auqa => auqa.AnswerFK);
        }

        private void DeclareActivityAttendeeRelationship(ModelBuilder builder)
        {
            builder.Entity<ActivityAttendee>().ToTable(nameof(ActivityAttendee), Schema);
            builder.Entity<ActivityAttendee>(x => x.HasKey(aa => new { aa.AppUserFK, aa.ActivityFK }));
            // builder.Entity<ActivityAttendee>()
            //     .HasOne(u => u.AppUser)
            //     .WithMany(a => a.Activities)
            //     .HasForeignKey(aa => aa.AppUserFK);

            // builder.Entity<ActivityAttendee>()
            //     .HasOne(u => u.Activity)
            //     .WithMany(a => a.Attendees)
            //     .HasForeignKey(aa => aa.ActivityFK);

            builder.Entity<Activity>()
                .HasMany(ap => ap.ActivityPhotos)
                .WithOne(p => p.Activity);
        }

        private void DeclareAppUserRelationship(ModelBuilder builder)
        {
            builder.Entity<AppUser>().HasKey(au => new { au.Username });

            builder.Entity<AppUser>()
                .Property(au => au.ActiveStatus)
                .HasDefaultValue(ActiveStatus.Active.GetDescription());

            // builder.Entity<AppUser>()
            //     .HasMany(au => au.Activities)
            //     .WithOne(aa => aa.AppUser)
            //     .HasForeignKey(aa => aa.ActivityFK);

            builder.Entity<AppUser>()
                .HasOne(au => au.UserProfile)
                .WithOne(aup => aup.AppUser)
                .HasForeignKey<AppUser>(aup => aup.UserProfileFK);
        }

        private void DeclareAdminUserRelationship(ModelBuilder builder)
        {
            builder.Entity<AdminUser>().HasKey(adu => adu.Id);

            builder.Entity<AdminUser>()
                .Property(adu => adu.ActiveStatus)
                .HasDefaultValue(ActiveStatus.Active.GetDescription());

            builder.Entity<AdminUser>()
                .HasOne(adu => adu.UserProfile)
                .WithOne(up => up.AdminUser)
                .HasForeignKey<AdminUser>(x => x.UserProfileFK);
        }

        private void DeclareUserProfileRelationship(ModelBuilder builder)
        {
            builder.Entity<UserProfile>().ToTable(nameof(UserProfile), Schema);
            builder.Entity<UserProfile>().HasKey(aup => aup.Id);

            // builder.Entity<UserProfile>()
            //     .HasOne(aup => aup.AppUser)
            //     .WithOne(au => au.UserProfile)
            //     .HasForeignKey<UserProfile>(aup => aup.AppUser);

            // builder.Entity<UserProfile>()
            //     .HasOne(aup => aup.AdminUser)
            //     .WithOne(au => au.UserProfile)
            //     .HasForeignKey<UserProfile>(aup => aup.AdminUser);

            builder.Entity<UserProfile>()
                .Property(au => au.Birthdate)
                .HasDefaultValue(DateTime.Parse("01/01/1990"));

            builder.Entity<UserProfile>()
                .Property(au => au.ReligionFK)
                .HasDefaultValue(Guid.Parse("00000000-0000-0000-0000-000000000009"));

            builder.Entity<UserProfile>()
                .Property(au => au.CountryFK)
                .HasDefaultValue(Guid.Parse("00000000-0000-0000-0000-000000000233"));

            builder.Entity<UserProfile>()
                .Property(au => au.CountryFK)
                .HasDefaultValue(Guid.Parse("00000000-0000-0000-0000-000000000233"));

            builder.Entity<UserProfile>()
                .Property(au => au.Bio)
                .HasDefaultValue(string.Empty);

            builder.Entity<UserProfile>()
                .HasMany(ap => ap.Photos)
                .WithOne(p => p.AppUserProfile)
                .HasForeignKey(ap => ap.AppUserProfileFK);
        }
    }
}
