using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Felidae.Extender
{
    public static class MiscExtenders
    {
        public static string ToJSON(this object value)
        {
            string _result = "";
            try
            {
                _result = JsonConvert.SerializeObject(value, Formatting.None);
            }
            catch { }
            return _result;
        }
    }
}
