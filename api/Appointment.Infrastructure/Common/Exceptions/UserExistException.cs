using System;

namespace Appointment.Infrastructure.Common.Exceptions
{
    public class UserExistException : Exception
    {
        public UserExistException(string message) : base(message)
        {
        }
    }
}