using Appointment.Domain.Log;
using Microsoft.EntityFrameworkCore;

namespace Appointment.Persistence
{
    public class AppointmentLoggingDataContext : DbContext
    {
        public DbSet<APILog> APILogs { get; set; }

        public AppointmentLoggingDataContext(DbContextOptions<AppointmentLoggingDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<APILog>(entity =>
            {
                entity.ToTable(nameof(APILog));

                entity.Property(al => al.Level)
                    .HasMaxLength(20)
                    .IsRequired();

                entity.Property(al => al.RequestMethod)
                    .HasMaxLength(10);

                entity.Property(al => al.UserName)
                    .HasMaxLength(100);

                entity.Property(al => al.Environment)
                    .HasMaxLength(20);
            });
        }
    }
}
