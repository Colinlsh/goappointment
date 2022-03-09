using System;
using System.Collections.Generic;
using System.Linq;

namespace Appointment.Application.Core.Helpers
{
    public static class Helpers
    {
        public static string GetNewSchema(string latestSchema)
        {
            var _tenantPrefix = "Tenant_";
            var _tenantNumber = latestSchema.Replace(_tenantPrefix, "");
            var _parsingResult = int.TryParse(_tenantNumber, out int result);

            if (!_parsingResult)
                return null;

            result += 1;

            if (result < 10)
                return $"{_tenantPrefix}00{result}";
            else if (result >= 10)
                return $"{_tenantPrefix}0{result}";
            else
                return $"{_tenantPrefix}{result}";
        }

        public static string GetNewHeCode(string latestHeCode)
        {
            var _HePrefix = "AP";
            var _HeNumber = latestHeCode.Replace(_HePrefix, "");
            var _parsingResult = int.TryParse(_HeNumber, out int result);

            if (!_parsingResult)
                return null;

            result += 1;

            if (result < 10)
                return $"{_HePrefix}000{result}";
            else if (result >= 10)
                return $"{_HePrefix}00{result}";
            else
                return $"{_HePrefix}0{result}";
        }

        public static List<DateTime> GetDates(int year, int month)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))
                             // Days: 1, 2 ... 31 etc.
                             .Select(day => new DateTime(year, month, day))
                             // Map each day to a date
                             .ToList(); // Load dates into a list
        }

        public static List<DateTime> GetDayInterval(DateTime StartDate, DateTime EndDate, int intervalMins = 60)
        {
            var intervalDateTime = new List<DateTime>();

            var hourDifference = EndDate.Subtract(StartDate).TotalMinutes;

            var loopCount = hourDifference / intervalMins;

            var concatMins = intervalMins;

            intervalDateTime.Add(StartDate);

            for (int interval = 0; interval < loopCount; interval++)
            {
                intervalDateTime.Add(StartDate.AddMinutes(concatMins));
                concatMins += intervalMins;
            }

            return intervalDateTime;
        }
    }
}

