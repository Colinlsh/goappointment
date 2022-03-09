using Appointment.Domain.Main;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Appointment.Persistence
{
    public class AppointmentMainDataContext : DbContext
    {
        public DbSet<TenantMapping> TenantMapping { get; set; }
        public DbSet<TenantConfiguration> TenantConfiguration { get; set; }
        public DbSet<CTOccupation> CTOccupation { get; set; }
        public DbSet<CTReligion> CTReligion { get; set; }
        public DbSet<CTCountry> CTCountry { get; set; }
        public DbSet<CTRace> CTRace { get; set; }
        public DbSet<CTRelationship> CTRelationship { get; set; }
        public DbSet<CTAppointmentStatus> CTAppointmentStatus { get; set; }

        public AppointmentMainDataContext(DbContextOptions<AppointmentMainDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TenantMapping>()
                .HasKey(tm => tm.TenantID);

            builder.Entity<TenantMapping>()
                .HasOne(tm => tm.TenantConfiguration)
                .WithOne(tc => tc.TenantMapping)
                .HasForeignKey<TenantConfiguration>(tc => tc.TenantMappingFK);

            builder.Entity<TenantMapping>().ToTable(nameof(TenantMapping), "AppointmentMain");


            builder.Entity<TenantConfiguration>()
                .HasKey(tc => tc.TenantConfigurationID);

            builder.Entity<TenantConfiguration>()
                .HasOne(tc => tc.TenantMapping)
                .WithOne(tm => tm.TenantConfiguration);

            builder.Entity<TenantConfiguration>().ToTable(nameof(TenantConfiguration), "AppointmentMain");

            builder.Entity<CTReligion>().ToTable(nameof(CTReligion), "AppointmentMain");
            builder.Entity<CTReligion>().HasKey(x => x.ReligionId);


            builder.Entity<CTCountry>().ToTable(nameof(CTCountry), "AppointmentMain");
            builder.Entity<CTCountry>().HasKey(x => x.CountryId);

            builder.Entity<CTOccupation>().ToTable(nameof(CTOccupation), "AppointmentMain");
            builder.Entity<CTOccupation>().HasKey(x => x.OccupationId);

            builder.Entity<CTRace>().ToTable(nameof(CTRace), "AppointmentMain");
            builder.Entity<CTRace>().HasKey(x => x.RaceId);

            builder.Entity<CTRelationship>().ToTable(nameof(CTRelationship), "AppointmentMain");
            builder.Entity<CTRelationship>().HasKey(x => x.RelationshipId);

            builder.Entity<CTAppointmentStatus>().ToTable(nameof(CTAppointmentStatus), "AppointmentMain");
            builder.Entity<CTAppointmentStatus>().HasKey(x => x.AppointmentStatusId);

            builder.Entity<RefreshToken>().ToTable(nameof(RefreshToken), "AppointmentMain");
            builder.Entity<RefreshToken>().HasKey(x => x.RefreshTokenId);
        }
    }
}
