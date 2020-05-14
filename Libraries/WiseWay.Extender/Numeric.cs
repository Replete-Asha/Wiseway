using System;
using System.Collections.Generic;
using System.Text;

namespace Felidae.Extender
{
    public static class Numeric
    {
        public static string ToString(this decimal amount, int decimalPlaces)
        {
            return Math.Round(amount, decimalPlaces).ToString();
        }

        public static int ToInt(this object value, int defaultValue)
        {
            int result = 0;
            try
            {
                if (value != null)
                    result = Convert.ToInt32(value);
            }
            catch { }
            if (result == 0)
                result = defaultValue;
            return result;
        }

        public static int Coalesce(this int value, int defaultValue)
        {
            if (value == 0)
                return defaultValue;
            else
                return value;
        }

        public static long ToLong(this object value, long defaultValue)
        {
            long result = 0;
            try
            {
                if (value != null)
                    result = Convert.ToInt64(value);
            }
            catch { }
            if (result == 0)
                result = defaultValue;
            return result;
        }

        public static double ToDouble(this object value, double defaultValue = 0)
        {
            double result = 0;
            try
            {
                if (value != null)
                    result = Convert.ToDouble(value);
            }
            catch { }
            if (result == 0)
                result = defaultValue;

            return result;
        }
    }

}
