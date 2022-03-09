using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Appointment.Infrastructure.Constants
{
    public enum LoginRole
    {
        [Description("Admin")]
        Admin, 
        [Description("User")]
        User
    }
}
