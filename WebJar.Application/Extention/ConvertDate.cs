using System.Globalization;

namespace WebJar.Application.Extention
{
    public static class ConvertDate
    {
        /// <summary>
        /// Return Year - Month (1400 - 3)
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string GetMonthAndYear(DateTime time)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            var getMonthAndYear = persianCalendar.GetYear(time) + "-" + persianCalendar.GetMonth(time);
            return getMonthAndYear;
        }
        /// <summary>
        /// Return Year , Month , Day , Hour , Minute , Second , MiliSecond
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime GetDate(DateTime time)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            var curentDate = persianCalendar.ToDateTime(time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second, time.Millisecond);
            return curentDate;
        }
        /// <summary>
        /// Return Year , Month , Day 
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime GetDateYeadAndMonthAndDay(DateTime time)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            var curentDate = persianCalendar.GetYear(time) + "/" + persianCalendar.GetMonth(time) + "/" + persianCalendar.GetDayOfMonth(time);
            var convert = ParsePersianDate(curentDate);
            return convert;
        }

        private static DateTime ParsePersianDate(this string date)
        {
            var dateParts = date.Split('/');
            return new DateTime(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2]), new PersianCalendar());
        }
    }
}
