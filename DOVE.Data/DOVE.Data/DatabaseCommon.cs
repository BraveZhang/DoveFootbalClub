using DOVE.Data.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using DOVE.Util;
using DOVE.Util.Attributes;
using Newtonsoft.Json.Linq;
using DOVE.Util.Extension;

namespace DOVE.Data
{
    public class DatabaseCommon
    {
        #region 对象参数转换DbParameter
        /// <summary>
        /// 对象参数转换DbParameter
        /// </summary>
        /// <returns></returns>
        public static DbParameter[] GetParameter<T>(T entity)
        {
            IList<DbParameter> parameter = new List<DbParameter>();
            DbType dbtype = new DbType();
            Type type = entity.GetType();
            PropertyInfo[] props = type.GetProperties();
            foreach (PropertyInfo pi in props)
            {
                if (pi.GetValue(entity, null) != null)
                {
                    switch (pi.PropertyType.ToString())
                    {
                        case "System.Nullable`1[System.Int32]":
                            dbtype = DbType.Int32;
                            break;
                        case "System.Nullable`1[System.Decimal]":
                            dbtype = DbType.Decimal;
                            break;
                        case "System.Nullable`1[System.DateTime]":
                            dbtype = DbType.DateTime;
                            break;
                        default:
                            dbtype = DbType.String;
                            break;
                    }
                    parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + pi.Name, pi.GetValue(entity, null), dbtype));
                }
            }
            return parameter.ToArray();
        }
        /// <summary>
        /// 对象参数转换DbParameter
        /// </summary>
        /// <returns></returns>
        public static DbParameter[] GetParameter(Hashtable ht)
        {
            IList<DbParameter> parameter = new List<DbParameter>();
            DbType dbtype = new DbType();
            foreach (string key in ht.Keys)
            {
                if (ht[key] is DateTime)
                    dbtype = DbType.DateTime;
                else
                    dbtype = DbType.String;
                parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + key, ht[key], dbtype));
            }
            return parameter.ToArray();
        }
        #endregion

        #region 获取实体类自定义信息
        /// <summary>
        /// 获取实体类主键字段
        /// </summary>
        /// <returns></returns>
        public static object GetKeyField<T>()
        {
            Type objTye = typeof(T);
            string _KeyField = "";
            PrimaryKeyAttribute KeyField;
            var name = objTye.Name;
            foreach (Attribute attr in objTye.GetCustomAttributes(true))
            {
                KeyField = attr as PrimaryKeyAttribute;
                if (KeyField != null)
                    _KeyField = KeyField.Name;
            }
            return _KeyField;
        }
        /// <summary>
        /// 获取实体类主键字段
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        public static object GetKeyFieldValue<T>(T entity)
        {
            Type objTye = typeof(T);
            string _KeyField = "";
            PrimaryKeyAttribute KeyField;
            var name = objTye.Name;
            foreach (Attribute attr in objTye.GetCustomAttributes(true))
            {
                KeyField = attr as PrimaryKeyAttribute;
                if (KeyField != null)
                    _KeyField = KeyField.Name;
            }
            PropertyInfo property = objTye.GetProperty(_KeyField);
            return property.GetValue(entity, null).ToString();
        }
        /// <summary>
        /// 获取实体类 字段中文名称
        /// </summary>
        /// <param name="pi">字段属性信息</param>
        /// <returns></returns>
        public static string GetFieldText(PropertyInfo pi)
        {
            DisplayNameAttribute descAttr;
            string txt = "";
            var descAttrs = pi.GetCustomAttributes(typeof(DisplayNameAttribute), true);
            if (descAttrs.Any())
            {
                descAttr = descAttrs[0] as DisplayNameAttribute;
                txt = descAttr.DisplayName;
            }
            else
            {
                txt = pi.Name;
            }
            return txt;
        }
        /// <summary>
        /// 获取实体类中文名称
        /// </summary>
        /// <returns></returns>
        public static string GetClassName<T>()
        {
            Type objTye = typeof(T);
            string entityName = "";
            var busingessNames = objTye.GetCustomAttributes(true).OfType<DisplayNameAttribute>();
            var descriptionAttributes = busingessNames as DisplayNameAttribute[] ?? busingessNames.ToArray();
            if (descriptionAttributes.Any())
                entityName = descriptionAttributes.ToList()[0].DisplayName;
            else
            {
                entityName = objTye.Name;
            }
            return entityName;
        }
        #endregion

        #region 拼接 Insert SQL语句
        /// <summary>
        /// 哈希表生成Insert语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="ht">Hashtable</param>
        /// <returns>int</returns>
        public static StringBuilder InsertSql(string tableName, Hashtable ht)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" Insert Into ");
            sb.Append(tableName);
            sb.Append("(");
            StringBuilder sp = new StringBuilder();
            StringBuilder sb_prame = new StringBuilder();
            foreach (string key in ht.Keys)
            {
                if (ht[key] != null)
                {
                    sb_prame.Append("," + key);
                    sp.Append("," + DbParameters.CreateDbParmCharacter() + "" + key);
                }
            }
            sb.Append(sb_prame.ToString().Substring(1, sb_prame.ToString().Length - 1) + ") Values (");
            sb.Append(sp.ToString().Substring(1, sp.ToString().Length - 1) + ")");
            return sb;
        }

        /// <summary>
        /// 泛型方法，反射生成InsertSql语句
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns>int</returns>
        public static StringBuilder InsertSql<T>(T entity)
        {
            Type type = entity.GetType();
            StringBuilder sb = new StringBuilder();
            sb.Append(" Insert Into ");
            sb.Append(EntityAttribute.GetEntityTable<T>());
            sb.Append("(");
            StringBuilder sp = new StringBuilder();
            StringBuilder sb_prame = new StringBuilder();
            PropertyInfo[] props = type.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                if (prop.GetValue(entity, null) != null)
                {
                    sb_prame.Append("," + (prop.Name));
                    sp.Append("," + DbParameters.CreateDbParmCharacter() + "" + (prop.Name));
                }
            }
            sb.Append(sb_prame.ToString().Substring(1, sb_prame.ToString().Length - 1) + ") Values (");
            sb.Append(sp.ToString().Substring(1, sp.ToString().Length - 1) + ")");
            return sb;
        }
        #endregion

        #region 拼接 Update SQL语句
        /// <summary>
        /// 哈希表生成UpdateSql语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="ht">Hashtable</param>
        /// <param name="pkName">主键</param>
        /// <returns></returns>
        public static StringBuilder UpdateSql(string tableName, Hashtable ht, string pkName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" Update ");
            sb.Append(tableName);
            sb.Append(" Set ");
            bool isFirstValue = true;
            foreach (string key in ht.Keys)
            {
                if (ht[key] != null && pkName != key)
                {
                    if (isFirstValue)
                    {
                        isFirstValue = false;
                        sb.Append(key);
                        sb.Append("=");
                        sb.Append(DbParameters.CreateDbParmCharacter() + key);
                    }
                    else
                    {
                        sb.Append("," + key);
                        sb.Append("=");
                        sb.Append(DbParameters.CreateDbParmCharacter() + key);
                    }
                }
            }
            sb.Append(" Where ").Append(pkName).Append("=").Append(DbParameters.CreateDbParmCharacter() + pkName);
            return sb;
        }
        /// <summary>
        /// 泛型方法，反射生成UpdateSql语句
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <param name="pkName">主键</param>
        /// <returns>int</returns>
        public static StringBuilder UpdateSql<T>(T entity, string pkName)
        {
            Type type = entity.GetType();
            PropertyInfo[] props = type.GetProperties();
            StringBuilder sb = new StringBuilder();
            sb.Append(" Update ");
            sb.Append(EntityAttribute.GetEntityTable<T>());
            sb.Append(" Set ");
            bool isFirstValue = true;
            foreach (PropertyInfo prop in props)
            {
                if (prop.GetValue(entity, null) != null && GetKeyField<T>().ToString() != prop.Name)
                {
                    if (isFirstValue)
                    {
                        isFirstValue = false;
                        sb.Append(prop.Name);
                        sb.Append("=");
                        sb.Append(DbParameters.CreateDbParmCharacter() + prop.Name);
                    }
                    else
                    {
                        sb.Append("," + prop.Name);
                        sb.Append("=");
                        sb.Append(DbParameters.CreateDbParmCharacter() + prop.Name);
                    }
                }
            }
            sb.Append(" Where ").Append(pkName).Append("=").Append(DbParameters.CreateDbParmCharacter() + pkName);
            return sb;
        }
        /// <summary>
        /// 泛型方法，反射生成UpdateSql语句
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns>int</returns>
        public static StringBuilder UpdateSql<T>(T entity)
        {
            string pkName = GetKeyField<T>().ToString();
            Type type = entity.GetType();
            PropertyInfo[] props = type.GetProperties();
            StringBuilder sb = new StringBuilder();
            sb.Append("Update ");
            sb.Append(EntityAttribute.GetEntityTable<T>());
            sb.Append(" Set ");
            bool isFirstValue = true;
            foreach (PropertyInfo prop in props)
            {
                if (prop.GetValue(entity, null) != null && pkName != prop.Name)
                {
                    if (isFirstValue)
                    {
                        isFirstValue = false;
                        sb.Append(prop.Name);
                        sb.Append("=");
                        sb.Append(DbParameters.CreateDbParmCharacter() + prop.Name);
                    }
                    else
                    {
                        sb.Append("," + prop.Name);
                        sb.Append("=");
                        sb.Append(DbParameters.CreateDbParmCharacter() + prop.Name);
                    }
                }
            }
            sb.Append(" Where ").Append(pkName).Append("=").Append(DbParameters.CreateDbParmCharacter() + pkName);
            return sb;
        }
        #endregion

        #region 拼接 Delete SQL语句
        /// <summary>
        /// 拼接删除SQL语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="pkName">字段主键</param>
        /// <returns></returns>
        public static StringBuilder DeleteSql(string tableName)
        {
            return new StringBuilder("Delete From " + tableName);
        }
        /// <summary>
        /// 拼接删除SQL语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="pkName">字段主键</param>
        /// <returns></returns>
        public static StringBuilder DeleteSql(string tableName, string pkName)
        {
            return new StringBuilder("Delete From " + tableName + " Where " + pkName + " = " + DbParameters.CreateDbParmCharacter() + pkName + "");
        }
        /// <summary>
        /// 拼接删除SQL语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="ht">多参数</param>
        /// <returns></returns>
        public static StringBuilder DeleteSql(string tableName, Hashtable ht)
        {
            StringBuilder sb = new StringBuilder("Delete From " + tableName + " Where 1=1");
            foreach (string key in ht.Keys)
            {
                sb.Append(" AND " + key + " = " + DbParameters.CreateDbParmCharacter() + "" + key + "");
            }
            return sb;
        }
        /// <summary>
        /// 拼接删除SQL语句
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        public static StringBuilder DeleteSql<T>(T entity)
        {
            Type type = entity.GetType();
            PropertyInfo[] props = type.GetProperties();
            StringBuilder sb = new StringBuilder("Delete From " + EntityAttribute.GetEntityTable<T>() + " Where 1=1");
            foreach (PropertyInfo prop in props)
            {
                if (prop.GetValue(entity, null) != null)
                {
                    sb.Append(" AND " + prop.Name + " = " + DbParameters.CreateDbParmCharacter() + "" + prop.Name + "");
                }
            }
            return sb;
        }
        #endregion

        #region 拼接 Select SQL语句
        /// <summary>
        /// 拼接 查询 SQL语句
        /// </summary>
        /// <returns></returns>
        public static StringBuilder SelectSql<T>() where T : new()
        {
            string tableName = typeof(T).Name;
            PropertyInfo[] props = GetProperties(new T().GetType());
            StringBuilder sbColumns = new StringBuilder();
            foreach (PropertyInfo prop in props)
            {
                string propertytype = prop.PropertyType.ToString();
                sbColumns.Append(prop.Name + ",");
            }
            if (sbColumns.Length > 0) sbColumns.Remove(sbColumns.ToString().Length - 1, 1);
            string strSql = "SELECT {0} FROM {1} WHERE 1=1 ";
            strSql = string.Format(strSql, sbColumns.ToString(), tableName + " ");
            return new StringBuilder(strSql);
        }
        /// <summary>
        /// 拼接 查询 SQL语句
        /// </summary>
        /// <param name="Top">显示条数</param>
        /// <returns></returns>
        public static StringBuilder SelectSql<T>(int Top) where T : new()
        {
            string tableName = typeof(T).Name;
            PropertyInfo[] props = GetProperties(new T().GetType());
            StringBuilder sbColumns = new StringBuilder();
            foreach (PropertyInfo prop in props)
            {
                sbColumns.Append(prop.Name + ",");
            }
            if (sbColumns.Length > 0) sbColumns.Remove(sbColumns.ToString().Length - 1, 1);
            string strSql = "SELECT top {0} {1} FROM {2} WHERE 1=1 ";
            strSql = string.Format(strSql, Top, sbColumns.ToString(), tableName + " ");
            return new StringBuilder(strSql);
        }
        /// <summary>
        /// 拼接 查询 SQL语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public static StringBuilder SelectSql(string tableName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM " + tableName + " WHERE 1=1 ");
            return strSql;
        }
        /// <summary>
        /// 拼接 查询 SQL语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="Top">显示条数</param>
        /// <returns></returns>
        public static StringBuilder SelectSql(string tableName, int Top)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT top " + Top + " * FROM " + tableName + " WHERE 1=1 ");
            return strSql;
        }
        /// <summary>
        /// 拼接 查询条数 SQL语句
        /// </summary>
        /// <returns></returns>
        public static StringBuilder SelectCountSql<T>() where T : new()
        {
            string tableName = typeof(T).Name;//获取表名
            return new StringBuilder("SELECT Count(1) FROM " + tableName + " WHERE 1=1 ");
        }
        /// <summary>
        /// 拼接 查询最大数 SQL语句
        /// </summary>
        /// <param name="propertyName">属性字段</param>
        /// <returns></returns>
        public static StringBuilder SelectMaxSql<T>(string propertyName) where T : new()
        {
            string tableName = typeof(T).Name;//获取表名
            return new StringBuilder("SELECT MAX(" + propertyName + ") FROM " + tableName + "  WHERE 1=1 ");
        }
        #endregion

        #region 扩展
        /// <summary>
        /// 获取访问元素
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static PropertyInfo[] GetProperties(Type type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }
        #endregion

        #region 自定义时间控件Service处理逻辑 add by zy 20171025
        /// <summary>
        /// 简单起止时间
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="queryParam"></param>
        /// <param name="parameter"></param>
        public static void TimeControlProcess(ref StringBuilder strSql, JObject queryParam, ref List<DbParameter> parameter)
        {
            if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
            {
                strSql.Append(" AND w.Time Between " + DbParameters.CreateDbParmCharacter() + "StartTime AND " + DbParameters.CreateDbParmCharacter() + "EndTime ");
                parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "StartTime", (queryParam["StartTime"].ToString() + " 00:00:00").ToDate()));
                parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "EndTime", (queryParam["EndTime"].ToString() + " 23:59:59").ToDate()));
            }
        }

        /// <summary>
        /// 多维度
        /// </summary>
        /// <param name="strInnerSql"></param>
        /// <param name="queryParam"></param>
        /// <param name="parameter"></param>
        public static void TimeControlTwoProcess(ref StringBuilder strInnerSql, JObject queryParam, ref List<DbParameter> parameter)
        {
            switch (queryParam["hd_dropdowntype"].ToString())
            {
                case "day":
                    if (!queryParam["hd_day"].IsEmpty())
                    {
                        strInnerSql.Append(" AND w.Time Between " + DbParameters.CreateDbParmCharacter() + "DayStartTime AND " + DbParameters.CreateDbParmCharacter() + "DayEndTime ");
                        parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "DayStartTime", (queryParam["hd_day"].ToString() + " 00:00:00").ToDate()));
                        parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "DayEndTime", (queryParam["hd_day"].ToString() + " 23:59:59").ToDate()));
                    }
                    break;
                case "week":
                    if (!queryParam["hd_week"].IsEmpty())
                    {
                        int year = queryParam["hd_week"].ToString().Split('_')[0].ToInt();
                        int weekOrder = queryParam["hd_week"].ToString().Split('_')[1].ToInt();
                        DateTime firstDate = DateTime.MinValue, lastDate = DateTime.MaxValue;
                        Time.WeekRange(year, weekOrder, ref firstDate, ref lastDate);
                        strInnerSql.Append(" AND w.Time Between " + DbParameters.CreateDbParmCharacter() + "WeekStartTime AND " + DbParameters.CreateDbParmCharacter() + "WeekEndTime ");
                        parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "WeekStartTime", (firstDate.ToString("yyyy-MM-dd") + " 00:00:00").ToDate()));
                        parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "WeekEndTime", (lastDate.ToString("yyyy-MM-dd") + " 23:59:59").ToDate()));
                    }
                    break;
                case "month":
                    if (!queryParam["hd_month"].IsEmpty())
                    {
                        int year = DateTime.Now.Year;
                        int monthOrder = queryParam["hd_month"].ToInt();
                        DateTime firstDate = DateTime.MinValue, lastDate = DateTime.MaxValue;
                        Time.MonthRange(year, monthOrder, ref firstDate, ref lastDate);
                        strInnerSql.Append(" AND w.Time Between " + DbParameters.CreateDbParmCharacter() + "MonthStartTime AND " + DbParameters.CreateDbParmCharacter() + "MonthEndTime ");
                        parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "MonthStartTime", (firstDate.ToString("yyyy-MM-dd") + " 00:00:00").ToDate()));
                        parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "MonthEndTime", (lastDate.ToString("yyyy-MM-dd") + " 23:59:59").ToDate()));
                    }
                    break;
                case "year":
                    if (!queryParam["hd_year"].IsEmpty())
                    {
                        int yearOrder = queryParam["hd_year"].ToInt();
                        DateTime firstDate = DateTime.MinValue, lastDate = DateTime.MaxValue;
                        Time.YearRange(yearOrder, ref firstDate, ref lastDate);
                        strInnerSql.Append(" AND w.Time Between " + DbParameters.CreateDbParmCharacter() + "YearStartTime AND " + DbParameters.CreateDbParmCharacter() + "YearEndTime ");
                        parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "YearStartTime", (firstDate.ToString("yyyy-MM-dd") + " 00:00:00").ToDate()));
                        parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "YearEndTime", (lastDate.ToString("yyyy-MM-dd") + " 23:59:59").ToDate()));
                    }
                    break;
                case "custom":
                    if (!queryParam["hd_custom1"].IsEmpty() && !queryParam["hd_custom2"].IsEmpty())
                    {
                        strInnerSql.Append(" AND w.Time Between " + DbParameters.CreateDbParmCharacter() + "CustomStartTime AND " + DbParameters.CreateDbParmCharacter() + "CustomEndTime ");
                        parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "CustomStartTime", (queryParam["hd_custom1"].ToString() + " 00:00:00").ToDate()));
                        parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "CustomEndTime", (queryParam["hd_custom2"].ToString() + " 23:59:59").ToDate()));
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 多粒度
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="strInnerSql"></param>
        /// <param name="queryParam"></param>
        /// <param name="parameter"></param>
        public static void TimeControlThreeProcess(ref StringBuilder strSql,StringBuilder strInnerSql, JObject queryParam, ref List<DbParameter> parameter)
        {
            switch (queryParam["hd_dropdowntype"].ToString())
            {
                case "day":
                    if (!queryParam["hd_day1"].IsEmpty() && !queryParam["hd_day2"].IsEmpty())
                    {
                        strInnerSql.Append(" AND w.Time Between " + DbParameters.CreateDbParmCharacter() + "DayStartTime AND " + DbParameters.CreateDbParmCharacter() + "DayEndTime ");
                        parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "DayStartTime", (queryParam["hd_day1"].ToString() + " 00:00:00").ToDate()));
                        parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "DayEndTime", (queryParam["hd_day2"].ToString() + " 23:59:59").ToDate()));
                        strSql.AppendFormat(@"select to_char(s.time, 'yyyy-mm-dd') as time,sum(s.value) as value,s.type,s.typename,'day' as reporttype 
                                                  from ({0}) s
                                                  group by to_char(s.time, 'yyyy-mm-dd'),s.type, s.typename
                                                  order by to_char(s.time, 'yyyy-mm-dd')", strInnerSql);
                    }
                    break;
                case "week":
                    if (!queryParam["hd_week1"].IsEmpty() && !queryParam["hd_week2"].IsEmpty())
                    {
                        int year1 = queryParam["hd_week1"].ToString().Split('_')[0].ToInt();
                        int weekOrder1 = queryParam["hd_week1"].ToString().Split('_')[1].ToInt();
                        int year2 = queryParam["hd_week2"].ToString().Split('_')[0].ToInt();
                        int weekOrder2 = queryParam["hd_week2"].ToString().Split('_')[1].ToInt();
                        DateTime firstDate = DateTime.MinValue, lastDate = DateTime.MaxValue;
                        firstDate = Time.WeekRangeStartDate(year1, weekOrder1);
                        lastDate = Time.WeekRangeEndDate(year2, weekOrder2);
                        strInnerSql.Append(" AND w.Time Between " + DbParameters.CreateDbParmCharacter() + "WeekStartTime AND " + DbParameters.CreateDbParmCharacter() + "WeekEndTime ");
                        parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "WeekStartTime", (firstDate.ToString("yyyy-MM-dd") + " 00:00:00").ToDate()));
                        parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "WeekEndTime", (lastDate.ToString("yyyy-MM-dd") + " 23:59:59").ToDate()));
                        strSql.AppendFormat(@"select to_char(s.time, 'yyyy-IW') as time,sum(s.value) as value,s.type,s.typename,'week' as reporttype 
                                                  from ({0}) s
                                                  group by to_char(s.time, 'yyyy-IW'),s.type, s.typename
                                                  order by to_char(s.time, 'yyyy-IW')", strInnerSql);
                    }
                    break;
                case "month":
                    if (!queryParam["hd_month1"].IsEmpty() && !queryParam["hd_month2"].IsEmpty())
                    {
                        int year = DateTime.Now.Year;
                        int monthOrder1 = queryParam["hd_month1"].ToInt();
                        int monthOrder2 = queryParam["hd_month2"].ToInt();
                        DateTime firstDate1 = DateTime.MinValue, lastDate1 = DateTime.MaxValue;
                        DateTime firstDate2 = DateTime.MinValue, lastDate2 = DateTime.MaxValue;
                        Time.MonthRange(year, monthOrder1, ref firstDate1, ref lastDate1);
                        Time.MonthRange(year, monthOrder2, ref firstDate2, ref lastDate2);
                        strInnerSql.Append(" AND w.Time Between " + DbParameters.CreateDbParmCharacter() + "MonthStartTime AND " + DbParameters.CreateDbParmCharacter() + "MonthEndTime ");
                        parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "MonthStartTime", (firstDate1.ToString("yyyy-MM-dd") + " 00:00:00").ToDate()));
                        parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "MonthEndTime", (lastDate2.ToString("yyyy-MM-dd") + " 23:59:59").ToDate()));
                        strSql.AppendFormat(@"select to_char(s.time, 'yyyy-mm') as time,sum(s.value) as value,s.type,s.typename,'month' as reporttype 
                                                  from ({0}) s
                                                  group by to_char(s.time, 'yyyy-mm'),s.type, s.typename
                                                  order by to_char(s.time, 'yyyy-mm')", strInnerSql);
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
