using System;

namespace Appointment.Infrastructure.Common.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public string Username { get; private set; }

        public UserNotFoundException(string username, string message) : base(message)
        {
            Username = username;
        }
    }
}