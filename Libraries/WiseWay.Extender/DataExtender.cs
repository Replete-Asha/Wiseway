using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Felidae.Extender
{
    public static class DataExtender
    {
        public static bool HasRecords(this DataTable value)
        {
            if (value == null)
                return false;
            if (value.Rows.Count <= 0)
                return false;
            else
                return true;
        }

        public static int RecordCount(this DataTable value)
        {
            if (!value.HasRecords())
                return 0;
            else
            {
                return value.Rows.Count;
            }
        }

        public static bool HasTable(this DataSet value, string tableName)
        {
            if (value.Tables.Contains(tableName))
                return true;
            else
                return false;
        }

        public static bool HasData(this DataSet value)
        {
            if (value != null && value.Tables.Count > 0 && value.Table(0).HasRecords())
                return true;
            else
                return false;
        }

        public static bool HasData(this DataTable value)
        {
            if (value != null && value.HasRecords())
                return true;
            else
                return false;
        }

        public static DataTable Table(this DataSet value, string tableName)
        {
            if (value.HasTable(tableName))
                return value.Tables[tableName];
            else
                return null;
        }
        public static DataTable Table(this DataSet value, int index)
        {
            if (value.Tables.Count > index)
                return value.Tables[index];
            else
                return null;
        }

        public static void MapTableNames(this DataSet value)
        {
            foreach (DataTable oTable in value.Tables)
            {
                try
                {
                    if (oTable.Columns.Contains("TableName"))
                        oTable.TableName = oTable.Rows[0]["TableName"].ToString();
                }
                catch { }
            }
        }

        //public static string ToJSON(this DataTable oTable)
        //{
        //    System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        //    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        //    Dictionary<string, object> row;
        //    foreach (DataRow dr in oTable.Rows)
        //    {
        //        row = new Dictionary<string, object>();
        //        foreach (DataColumn col in oTable.Columns)
        //        {
        //            row.Add(col.ColumnName, dr[col]);
        //        }
        //        rows.Add(row);
        //    }
        //    return serializer.Serialize(rows);
        //}

        public static long ToLong(this object value)
        {
            long _value = 0;
            try
            {
                _value = Convert.ToInt64(value);
            }
            catch { }
            return _value;
        }

        public static decimal ToDecimal(this object value)
        {
            decimal _value = 0;
            try
            {
                _value = Convert.ToDecimal(value);
            }
            catch { }
            return _value;
        }
    }

}
