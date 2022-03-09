using System;

namespace Appointment.Infrastructure.Common.Helpers
{
    public static class AgeCalculator
    {
        public static string GetCurrentAge(this DateTime value)
        {
            // Get today's date
            var today = DateTime.Today;

            // Calculate the age.
            var _age = today.Year - value.Year;

            // Go back to the year in which the person was born in case of a leap year
            if (value.Date > today.AddYears(-_age)) _age--;

            return _age.ToString();
        }
    }
}
