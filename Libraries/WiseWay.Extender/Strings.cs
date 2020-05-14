using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Felidae.Extender
{
    public static class Strings
    {
        public static string Coalesce(this string value)
        {
            string _Result = "";

            if (!value.IsNullOrWhiteSpace())
                _Result = value;

            return _Result;
        }

        public static string Coalesce(this string value, string _default)
        {
            string _Result = _default;

            if (!value.IsNullOrWhiteSpace())
                _Result = value;

            return _Result;
        }

        public static bool IsNullOrWhiteSpace(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return true;
            else if (Convert.IsDBNull(value))
                return true;
            else if (value.Trim().Length == 0)
                return true;
            else
                return false;
        }

        public static bool IsNumber(this string value)
        {
            double Num;
            return double.TryParse(value, out Num);
        }

        public static int ToInt32(this string value)
        {
            int _result = 0;
            try
            {
                _result = Convert.ToInt32(value);
            }
            catch { }
            return _result;
        }
        public static decimal ToDecimal(this string value)
        {
            decimal _result = 0;
            try
            {
                _result = Convert.ToDecimal(value);
            }
            catch { }
            return _result;
        }

        public static float ToFloat(this string value)
        {
            float _result = 0;
            try
            {
                float.TryParse(value, out _result);
            }
            catch { }
            return _result;
        }

        public static bool ToBoolean(this string value)
        {
            bool _result = false;
            value = value.Coalesce("").ToUpper();
            _result = value.Equals("1") || value.Equals("TRUE") || value.Equals("YES");
            return _result;
        }

        public static List<string> ToList(this string value, char deliminator = ',')
        {
            List<string> result = value.Split(deliminator).ToList();
            result = result.Select(x => x.Trim()).ToList();
            return result;
        }
    }
}
