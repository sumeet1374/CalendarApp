using System;
using System.Collections.Generic;
using System.Globalization;

namespace CalendarApp.Util
{
    public static class DateTimeUtil
    {
        public static DateTime AppendTime(this DateTime date,string timeString)
        {
            var format = "MM/dd/yyyy hh:mm tt";
            var stringDate = date.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            var datewithtime = $"{stringDate} {timeString}";
            return DateTime.ParseExact(datewithtime, format, CultureInfo.InvariantCulture);
        }
        public static List<string> GetRemainingTimeSlots(this DateTime currentTime,int startTimeOffset = 0,int frequency = 5)
        {
            var timeStrings = new List<string>();
            var nextDate = currentTime.AddDays(1);
            var endDate = nextDate.Date;
            currentTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, currentTime.Hour, currentTime.Minute, 0);
            var minutesToAdd = ((frequency - (currentTime.Minute % frequency))+ frequency) + startTimeOffset;
            currentTime = currentTime.AddMinutes(minutesToAdd) ;
            while (currentTime < endDate)
            {
                timeStrings.Add(currentTime.ToString("hh:mm tt", CultureInfo.InvariantCulture));
                currentTime = currentTime.AddMinutes(frequency);
            }

            return timeStrings;
        }
    }
}
