using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace AttendanceSystemClientV2.Helpers {
    public static class EnumerableExtension {

        /// <summary>
        /// list转datatable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataTable ListToDataTable<T> ( List<T> list, string tableName ) {
            var result = new DataTable (tableName);
            if (list.Count <= 0) {
                return result;
            }
            var propertys = list[0].GetType ().GetProperties ();
            foreach (var pi in propertys) {
                //获取类型
                var colType = pi.PropertyType;
                //当类型为Nullable<>时
                if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition () == typeof (Nullable<>))) {
                    colType = colType.GetGenericArguments ()[0];
                }
                result.Columns.Add (pi.Name, colType);
            }
            foreach (T t in list) {
                var tempList = new ArrayList ();
                var t1 = t;
                foreach (var obj in propertys.Select(pi => pi.GetValue (t1, null))) {
                    tempList.Add (obj);
                }
                var array = tempList.ToArray ();
                result.LoadDataRow (array, true);
            }
            return result;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumeration"></param>
        /// <param name="action"></param>
        public static void ForEach<T> ( this IEnumerable<T> enumeration, Action<T> action ) {

            foreach (T item in enumeration) {
                action (item);
            }
        }

        /// <summary>
        /// Convert  list to Data Table
        /// </summary>
        /// <typeparam name="T">Target Class</typeparam>
        /// <param name="varlist">list you want to convert it to Data Table</param>
        /// <param name="fn">Delegate Function to Create Row</param>
        /// <returns>Data Table That Represent List data</returns>
        public static DataTable ToADOTable<T> ( this IEnumerable<T> varlist, CreateRowDelegate<T> fn ) {
            DataTable toReturn = new DataTable ();

            // Could add a check to verify that there is an element 0
            T TopRec = varlist.ElementAtOrDefault (0);

            if (TopRec == null)
                return toReturn;

            // Use reflection to get property names, to create table
            // column names

            PropertyInfo[] oProps = ((Type)TopRec.GetType ()).GetProperties ();

            foreach (PropertyInfo pi in oProps) {
                Type pt = pi.PropertyType;
                if (pt.IsGenericType && pt.GetGenericTypeDefinition () == typeof (Nullable<>))
                    pt = Nullable.GetUnderlyingType (pt);
                toReturn.Columns.Add (pi.Name, pt);
            }

            foreach (T rec in varlist) {
                DataRow dr = toReturn.NewRow ();
                foreach (PropertyInfo pi in oProps) {
                    object o = pi.GetValue (rec, null);
                    if (o == null)
                        dr[pi.Name] = DBNull.Value;
                    else
                        dr[pi.Name] = o;
                }
                toReturn.Rows.Add (dr);
            }

            return toReturn;
        }

        /// <summary>
        /// Convert  list to Data Table
        /// </summary>
        /// <typeparam name="T">Target Class</typeparam>
        /// <param name="varlist">list you want to convert it to Data Table</param>
        /// <returns>Data Table That Represent List data</returns>
        public static DataTable ToADOTable<T> ( this IEnumerable<T> varlist ) {
            DataTable toReturn = new DataTable ();

            // Could add a check to verify that there is an element 0
            T TopRec = varlist.ElementAtOrDefault (0);

            if (TopRec == null)
                return toReturn;

            // Use reflection to get property names, to create table
            // column names

            PropertyInfo[] oProps = ((Type)TopRec.GetType ()).GetProperties ();

            foreach (PropertyInfo pi in oProps) {
                Type pt = pi.PropertyType;
                if (pt.IsGenericType && pt.GetGenericTypeDefinition () == typeof (Nullable<>))
                    pt = Nullable.GetUnderlyingType (pt);
                toReturn.Columns.Add (pi.Name, pt);
            }

            foreach (T rec in varlist) {
                DataRow dr = toReturn.NewRow ();
                foreach (PropertyInfo pi in oProps) {
                    object o = pi.GetValue (rec, null);

                    if (o == null)
                        dr[pi.Name] = DBNull.Value;
                    else
                        dr[pi.Name] = o;
                }
                toReturn.Rows.Add (dr);
            }

            return toReturn;
        }


        /// <summary>
        /// Convert Data Table To List of Type T
        /// </summary>
        /// <typeparam name="T">Target Class to convert data table to List of T </typeparam>
        /// <param name="datatable">Data Table you want to convert it</param>
        /// <returns>List of Target Class</returns>
        public static List<T> ToList<T> ( this DataTable datatable ) where T : new () {
            List<T> Temp = new List<T> ();
            try {
                List<string> columnsNames = new List<string> ();
                foreach (DataColumn DataColumn in datatable.Columns)
                    columnsNames.Add (DataColumn.ColumnName);
                Temp = datatable.AsEnumerable ().ToList ().ConvertAll<T> (row => getObject<T> (row, columnsNames));
                return Temp;
            } catch { return Temp; }
        }

        public static T getObject<T> ( DataRow row, List<string> columnsName ) where T : new () {
            T obj = new T ();
            try {
                string columnname = "";
                string value = "";
                PropertyInfo[] Properties; Properties = typeof (T).GetProperties ();
                foreach (PropertyInfo objProperty in Properties) {
                    columnname = columnsName.Find (name => name.ToLower () == objProperty.Name.ToLower ());
                    if (!string.IsNullOrEmpty (columnname)) {
                        value = row[columnname].ToString ();
                        if (!string.IsNullOrEmpty (value)) {
                            if (Nullable.GetUnderlyingType (objProperty.PropertyType) != null) {
                                value = row[columnname].ToString ().Replace ("$", "").Replace (",", "");
                                objProperty.SetValue (obj, Convert.ChangeType (value, Type.GetType (Nullable.GetUnderlyingType (objProperty.PropertyType).ToString ())), null);
                            } else {
                                value = row[columnname].ToString ().Replace ("%", "");
                                objProperty.SetValue (obj, Convert.ChangeType (value, Type.GetType (objProperty.PropertyType.ToString ())), null);
                            }
                        }
                    }
                } return obj;
            } catch { return obj; }
        }

        public delegate object[] CreateRowDelegate<T> ( T t );



    }
}
