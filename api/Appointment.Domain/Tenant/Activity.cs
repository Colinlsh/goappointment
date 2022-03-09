using System;
using System.Collections.Generic;

namespace Appointment.Domain.Tenant
{
    public class Activity
    {
        #region Public Properties
        public Guid ActivityId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsUserMaintainable { get; set; }
        public bool IsCancelled { get; set; }
        // public ICollection<ActivityAttendee> Attendees { get; set; }
        public ICollection<ActivityPhoto> ActivityPhotos { get; set; }
        #endregion
    }
}
