namespace Appointment.Infrastructure.Dtos.Api
{
    public sealed class AppUserPhotoDto
    {
        public string PhotoId { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
    }
}
