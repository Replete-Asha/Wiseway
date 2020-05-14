using System;
using System.Collections.Generic;
using System.Text;

namespace Felidae.Extender
{
    public static class DateExtender
    {
        #region Date Extensions
        public static string ToShortDateStringWithCoalesce(this DateTime value)
        {
            string _Result = "";
            DateTime _tmp = new DateTime(1900, 1, 1);
            if (value > _tmp)
                _Result = value.ToShortDateString();

            return _Result;
        }

        public static DateTime ToDateTimeWithCoalesce(this object value, DateTime defaultValue)
        {
            DateTime _Result = defaultValue;
            try
            {
                _Result = Convert.ToDateTime(value);
                if (_Result < new DateTime(1900, 1, 1))
                    _Result = defaultValue;
            }
            catch { }

            return _Result;
        }

        public static DateTime ToDateTimeWithCoalesce(this object value)
        {
            DateTime _Result = new DateTime(1900, 1, 1);

            try
            {
                _Result = Convert.ToDateTime(value);
                if (_Result < new DateTime(1900, 1, 1))
                    _Result = new DateTime(1900, 1, 1);
            }
            catch { }

            return _Result;
        }

        public static DateTime? ToDateTimeWithNull(this object value)
        {
            DateTime? _Result = null;

            try
            {
                _Result = Convert.ToDateTime(value);
            }
            catch { }

            return _Result;
        }

        public static DateTime? UnixTimeStampToDateTime(this object value)
        {
            DateTime? _Result = null;
            try
            {
                double unixTimeStamp = 0;
                if (value.GetType() != typeof(double))
                {
                    unixTimeStamp = value.ToString().ToDouble();
                }
                if (unixTimeStamp == 0)
                    return _Result;

                System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                _Result = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            }
            catch { }
            return _Result;
        }

        public static double ToUnixTimeStamp(this DateTime value)
        {
            TimeSpan epochTicks = new TimeSpan(new DateTime(1970, 1, 1).Ticks);
            TimeSpan unixTicks = new TimeSpan(DateTime.UtcNow.Ticks) - epochTicks;
            double unixTime = unixTicks.TotalSeconds;

            return unixTime;
        }

        #endregion
    }

}
