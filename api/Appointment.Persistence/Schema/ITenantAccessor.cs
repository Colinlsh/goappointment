using Appointment.Domain.Tenant;
using System.Collections.Generic;

namespace Appointment.Persistence.Schema
{
    public interface ITenantAccessor
    {
        List<AppointmentDataContext> DbList { get; }
        List<string> Tenants { get; }

        Dictionary<string, AppUser> GetAllUsersByEmail(string email);
        Dictionary<string, AppUser> GetAllUsersByUsername(string username);
        Dictionary<string, AppointmentTelegramCustomerProfile> GetAllTelegramCustomerAppointmentsByChatId(long chatId);
        AppointmentDataContext GetAppointmentDataContext(string schema);
    }
}