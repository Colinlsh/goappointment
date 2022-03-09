using Appointment.Infrastructure.Common;
using Microsoft.AspNetCore.Http;

namespace Appointment.Infrastructure.Contracts
{ 
    public interface IPhotoAccessorService
    {
        PhotoUploadResult AddPhoto(IFormFile file);
        PhotoUploadResult AddPhotoString(string filebase64, string name);
        string DeletePhoto(string publicId);
    }
}
