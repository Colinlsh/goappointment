using System;
using System.Collections.Generic;

namespace Appointment.Domain.Tenant
{
    public class UserProfile
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string Bio { get; set; }
        public string Username { get; set; }
        public AppUser AppUser { get; set; }
        public AdminUser AdminUser { get; set; }
        public Guid ReligionFK { get; set; }
        public Guid CountryFK { get; set; }
        public Guid OccupationFK { get; set; }
        public ICollection<AppUserQuestionAnswer> QuestionAnswers { get; set; }
        public ICollection<AppUserPhoto> Photos { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
