using Appointment.Application.UserProfile;
using Appointment.Domain;
using Appointment.Infrastructure.Dtos.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.Application
{
    public class ActivityDto
    {
        public Guid ActivityId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
        public string HostUsername { get; set; }
        public bool IsCancelled { get; set; }
        public ICollection<ProfileDto> Attendees { get; set; }
        public ICollection<ActivityPhotoDto> ActivityPhotos { get; set; }
    }
}
