using DOVE.Application.Entity.SystemManage;
using DOVE.Application.IService.SystemManage;
using DOVE.Data;
using DOVE.Data.Repository;
using DOVE.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace DOVE.Application.Service.SystemManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创建人：张勇
    /// 日 期：2015.11.18 11:02
    /// 描 述：数据库管理（支持：SqlServer）
    /// </summary>
    public class DataBaseTableService : RepositoryFactory, IDataBaseTableService
    {
        private IDataBaseLinkService dataBaseLinkService = new DataBaseLinkService();

        #region 获取数据
        /// <summary>
        /// 数据表列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表明</param>
        /// <returns></returns>
        public DataTable GetTableList(string dataBaseLinkId, string tableName)
        {
            DataBaseLinkEntity dataBaseLinkEntity = dataBaseLinkService.GetEntity(dataBaseLinkId);
            if (dataBaseLinkEntity != null)
            {
                #region Old 注释by zy 20170912 原来的只支持SqlServer
                //StringBuilder strSql = new StringBuilder();
                //strSql.Append(@"DECLARE @TableInfo TABLE ( name VARCHAR(50) , sumrows VARCHAR(11) , reserved VARCHAR(50) , data VARCHAR(50) , index_size VARCHAR(50) , unused VARCHAR(50) , pk VARCHAR(50) )
                //            DECLARE @TableName TABLE ( name VARCHAR(50) )
                //            DECLARE @name VARCHAR(50)
                //            DECLARE @pk VARCHAR(50)
                //            INSERT INTO @TableName ( name ) SELECT o.name FROM sysobjects o , sysindexes i WHERE o.id = i.id AND o.Xtype = 'U' AND i.indid < 2 ORDER BY i.rows DESC , o.name
                //            WHILE EXISTS ( SELECT 1 FROM @TableName ) BEGIN SELECT TOP 1 @name = name FROM @TableName DELETE @TableName WHERE name = @name DECLARE @objectid INT SET @objectid = OBJECT_ID(@name) SELECT @pk = COL_NAME(@objectid, colid) FROM sysobjects AS o INNER JOIN sysindexes AS i ON i.name = o.name INNER JOIN sysindexkeys AS k ON k.indid = i.indid WHERE o.xtype = 'PK' AND parent_obj = @objectid AND k.id = @objectid INSERT INTO @TableInfo ( name , sumrows , reserved , data , index_size , unused ) EXEC sys.sp_spaceused @name UPDATE @TableInfo SET pk = @pk WHERE name = @name END
                //            SELECT F.name , F.reserved , F.data , F.index_size , RTRIM(F.sumrows) AS sumrows , F.unused , ISNULL(p.tdescription, f.name) AS tdescription , F.pk
                //            FROM @TableInfo F LEFT JOIN ( SELECT name = CASE WHEN A.COLORDER = 1 THEN D.NAME ELSE '' END , tdescription = CASE WHEN A.COLORDER = 1 THEN ISNULL(F.VALUE, '') ELSE '' END FROM SYSCOLUMNS A LEFT JOIN SYSTYPES B ON A.XUSERTYPE = B.XUSERTYPE INNER JOIN SYSOBJECTS D ON A.ID = D.ID AND D.XTYPE = 'U' AND D.NAME <> 'DTPROPERTIES' LEFT JOIN sys.extended_properties F ON D.ID = F.major_id WHERE a.COLORDER = 1 AND F.minor_id = 0 ) P ON F.name = p.name
                //            WHERE 1 = 1 ");
                //if (!string.IsNullOrEmpty(tableName))
                //{
                //    strSql.Append(" AND f.name='" + tableName + "'");
                //}
                //strSql.Append(" ORDER BY f.name");
                //return this.BaseRepository(dataBaseLinkEntity.DbConnection).FindTable(strSql.ToString());
                #endregion

                #region 支持多数据库 add by zy 20170912 增加对Oracle的支持
                StringBuilder strSql = new StringBuilder();
                switch (DbHelper.DbType)
                {
                    case DatabaseType.SqlServer:
                        strSql.Append(@"DECLARE @TableInfo TABLE ( name VARCHAR(50) , sumrows VARCHAR(11) , reserved VARCHAR(50) , data VARCHAR(50) , index_size VARCHAR(50) , unused VARCHAR(50) , pk VARCHAR(50) )
                                    DECLARE @TableName TABLE ( name VARCHAR(50) )
                                    DECLARE @name VARCHAR(50)
                                    DECLARE @pk VARCHAR(50)
                                    INSERT INTO @TableName ( name ) SELECT o.name FROM sysobjects o , sysindexes i WHERE o.id = i.id AND o.Xtype = 'U' AND i.indid < 2 ORDER BY i.rows DESC , o.name
                                    WHILE EXISTS ( SELECT 1 FROM @TableName ) BEGIN SELECT TOP 1 @name = name FROM @TableName DELETE @TableName WHERE name = @name DECLARE @objectid INT SET @objectid = OBJECT_ID(@name) SELECT @pk = COL_NAME(@objectid, colid) FROM sysobjects AS o INNER JOIN sysindexes AS i ON i.name = o.name INNER JOIN sysindexkeys AS k ON k.indid = i.indid WHERE o.xtype = 'PK' AND parent_obj = @objectid AND k.id = @objectid INSERT INTO @TableInfo ( name , sumrows , reserved , data , index_size , unused ) EXEC sys.sp_spaceused @name UPDATE @TableInfo SET pk = @pk WHERE name = @name END
                                    SELECT F.name , F.reserved , F.data , F.index_size , RTRIM(F.sumrows) AS sumrows , F.unused , ISNULL(p.tdescription, f.name) AS tdescription , F.pk
                                    FROM @TableInfo F LEFT JOIN ( SELECT name = CASE WHEN A.COLORDER = 1 THEN D.NAME ELSE '' END , tdescription = CASE WHEN A.COLORDER = 1 THEN ISNULL(F.VALUE, '') ELSE '' END FROM SYSCOLUMNS A LEFT JOIN SYSTYPES B ON A.XUSERTYPE = B.XUSERTYPE INNER JOIN SYSOBJECTS D ON A.ID = D.ID AND D.XTYPE = 'U' AND D.NAME <> 'DTPROPERTIES' LEFT JOIN sys.extended_properties F ON D.ID = F.major_id WHERE a.COLORDER = 1 AND F.minor_id = 0 ) P ON F.name = p.name
                                    WHERE 1 = 1 ");
                        if (!string.IsNullOrEmpty(tableName))
                        {
                            strSql.Append(" AND f.name='" + tableName + "'");
                        }
                        strSql.Append(" ORDER BY f.name");
                        break;
                    case DatabaseType.Oracle:
                        strSql.Append(@"SELECT *
                                        FROM (SELECT initcap(o.table_name) as name,
                                                     num_rows * avg_row_len as reserved,
                                                     '' as data,
                                                     b.index_size as index_size,
                                                     count_rows(a.table_name) as sumrows,
                                                     '' as unused,
                                                     nvl(a.comments, o.table_name) as tdescription,
                                                     initcap(p.column_name) as pk
                                                FROM user_tables o
                                                left join user_tab_comments a
                                                  on a.table_name = o.table_name
                                                left join (select segment_name as table_name,
                                                                 sum(bytes) as index_size
                                                            from user_segments
                                                           group by segment_name) b
                                                  on b.table_name = o.table_name
                                                left join (select col.column_name, col.table_name
                                                            from user_constraints con, user_cons_columns col
                                                           where con.constraint_name = col.constraint_name
                                                             and con.constraint_type = 'P') p
                                                  on p.table_name = o.table_name
                                               order by o.table_name)
                                       WHERE 1 = 1");
                        if (!string.IsNullOrEmpty(tableName))
                        {
                            strSql.Append(" AND name like '%" + tableName + "%'");
                        }
                        break;
                    case DatabaseType.MySql:
                        break;
                    default:
                        throw new Exception("数据库类型目前不支持！");
                }
                return this.BaseRepository(dataBaseLinkEntity.DbConnection).FindTable(strSql.ToString());
                #endregion
            }
            return null;
        }
        /// <summary>
        /// 数据表字段列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表明</param>
        /// <returns></returns>
        public IEnumerable<DataBaseTableFieldEntity> GetTableFiledList(string dataBaseLinkId, string tableName)
        {
            DataBaseLinkEntity dataBaseLinkEntity = dataBaseLinkService.GetEntity(dataBaseLinkId);
            if (dataBaseLinkEntity != null)
            {
                #region Old 注释by zy 20170913 原来的只支持SqlServer
                //StringBuilder strSql = new StringBuilder();
                //strSql.Append(@"SELECT [number] = a.colorder , [column] = a.name , [datatype] = b.name , [length] = COLUMNPROPERTY(a.id, a.name, 'PRECISION') , [identity] = CASE WHEN COLUMNPROPERTY(a.id, a.name, 'IsIdentity') = 1 THEN '1' ELSE '' END , [key] = CASE WHEN EXISTS ( SELECT 1 FROM sysobjects WHERE xtype = 'PK' AND parent_obj = a.id AND name IN ( SELECT name FROM sysindexes WHERE indid IN ( SELECT indid FROM sysindexkeys WHERE id = a.id AND colid = a.colid ) ) ) THEN '1' ELSE '' END , [isnullable] = CASE WHEN a.isnullable = 1 THEN '1' ELSE '' END , [defaults] = ISNULL(e.text, '') , [remark] = ISNULL(g.[value], a.name)
                //                FROM syscolumns a LEFT JOIN systypes b ON a.xusertype = b.xusertype INNER JOIN sysobjects d ON a.id = d.id AND d.xtype = 'U' AND d.name <> 'dtproperties' LEFT JOIN syscomments e ON a.cdefault = e.id LEFT JOIN sys.extended_properties g ON a.id = g.major_id AND a.colid = g.minor_id LEFT JOIN sys.extended_properties f ON d.id = f.major_id AND f.minor_id = 0
                //                WHERE d.name = @tableName
                //                ORDER BY a.id , a.colorder");
                //DbParameter[] parameter =
                //{
                //    DbParameters.CreateDbParameter("@tableName",tableName)
                //};
                //return this.BaseRepository(dataBaseLinkEntity.DbConnection).FindList<DataBaseTableFieldEntity>(strSql.ToString(), parameter);
                #endregion

                StringBuilder strSql = new StringBuilder();
                //List<DbParameter> parameter = new List<DbParameter>();
                switch (DbHelper.DbType)
                {
                    case DatabaseType.SqlServer:
                        strSql.Append(@"SELECT  [number] = a.colorder , 
                                        		[column] = a.name , 
                                        		[datatype] = b.name , 
                                        		[length] = COLUMNPROPERTY(a.id, a.name, 'PRECISION') , 
                                        		[identity] = CASE WHEN COLUMNPROPERTY(a.id, a.name, 'IsIdentity') = 1 THEN '1' ELSE '' END , 
                                        		[key] = CASE WHEN EXISTS ( SELECT 1 FROM sysobjects WHERE xtype = 'PK' AND parent_obj = a.id AND name IN ( SELECT name FROM sysindexes WHERE indid IN ( SELECT indid FROM sysindexkeys WHERE id = a.id AND colid = a.colid ) ) ) THEN '1' ELSE '' END , 
                                        		[isnullable] = CASE WHEN a.isnullable = 1 THEN '1' ELSE '' END , 
                                        		[defaults] = ISNULL(e.text, '') , 
                                        		[remark] = ISNULL(g.[value], a.name)
                                        FROM syscolumns a 
                                        LEFT JOIN systypes b ON a.xusertype = b.xusertype 
                                        INNER JOIN sysobjects d ON a.id = d.id AND d.xtype = 'U' AND d.name <> 'dtproperties' 
                                        LEFT JOIN syscomments e ON a.cdefault = e.id 
                                        LEFT JOIN sys.extended_properties g ON a.id = g.major_id AND a.colid = g.minor_id 
                                        LEFT JOIN sys.extended_properties f ON d.id = f.major_id AND f.minor_id = 0
                                        WHERE d.name = '" + tableName + "'" +
                                       @"ORDER BY a.id , a.colorder ");
                        //parameter.Clear();
                        //parameter.Add(DbParameters.CreateDbParameter("@tableName", tableName));
                        break;
                    case DatabaseType.Oracle:
                        //strSql.Append(@"SELECT rownum as " + @"""number""" + ", " +
                        //          @"     initcap(substr(a.column_name, 1, 1)) || lower(substr(a.column_name, 2, length(a.column_name))) as " + @"""column""" + "," +
                        //          @"     a.data_type as " + @"""datatype""" + "," +
                        //          @"     a.data_length as " + @"""length""" + "," +
                        //          @"     (case
                        //                  when exists (select 1
                        //                         from user_constraints w
                        //                         left join user_ind_columns x
                        //                           on x.table_name = w.table_name
                        //                        where w.constraint_type = :constraint_type" +
                        //          @"              and w.table_name = a.table_name
                        //                          and x.column_name = a.column_name) 
                        //                  then '√' 
                        //                  else  ''" +
                        //          @"     end) as " + @"""key""" + "," +
                        //          @"    '' as " + @"""identity""" + "," +
                        //          @"    (case a.nullable
                        //                  when :nullable" + " then  '√'" +
                        //          @"      else ''
                        //                  end) as " + @"""isnullable""" + "," +
                        //          @"    nvl(a.data_default, '') as " + @"""default""" + "," +
                        //          @"    nvl(b.comments, a.column_name) as " + @"""remark""" +
                        //          @" from dba_tab_columns a
                        //          left join user_col_comments b
                        //            on b.table_name = a.table_name
                        //           and b.column_name = a.column_name 
                        //          left join (select col#, name
                        //                       from sys.col$
                        //                      where obj# = (select object_id
                        //                                      from all_objects
                        //                                     where 1 = 1 " +
                        //          @"                             and object_name = :table_name" +
                        //          @"                             and rownum = 1)) c
                        //            on c.name = a.column_name");
                        //strSql.Append(" WHERE a.table_name= :table_name and a.owner= :owner order by c.col# ");
                        //parameter.Clear();
                        //parameter.Add(DbParameters.CreateDbParameter(":constraint_type", "P"));
                        //parameter.Add(DbParameters.CreateDbParameter(":nullable", "Y"));
                        //parameter.Add(DbParameters.CreateDbParameter(":table_name", tableName.ToUpper()));
                        //parameter.Add(DbParameters.CreateDbParameter(":owner", DbHelper.UserID.ToUpper()));
                        strSql.Append(@"SELECT rownum as " + @"""number""" + ", " +
                                      //@"     initcap(substr(a.column_name, 1, 1)) || substr(a.column_name, 2, length(a.column_name)) as " + @"""column""" + "," +
                                      @"     initcap(a.column_name) as " + @"""column""" + "," +
                                      @"     a.data_type as " + @"""datatype""" + "," +
                                      @"     a.data_length as " + @"""length""" + "," +
                                      @"     (case
                                                                      when exists (select 1
                                                                             from user_constraints w
                                                                             left join user_ind_columns x
                                                                               on x.table_name = w.table_name
                                                                            where w.constraint_type = 'P'" +
                                      @"              and w.table_name = a.table_name
                                                                              and x.column_name = a.column_name) 
                                                                      then '1' 
                                                                      else  ''" +
                                      @"     end) as " + @"""key""" + "," +
                                      @"    '' as " + @"""identity""" + "," +
                                      @"    (case a.nullable
                                                                      when 'Y'" + " then  '1'" +
                                      @"      else ''
                                                                      end) as " + @"""isnullable""" + "," +
                                      @"    nvl(a.data_default, '') as " + @"""default""" + "," +
                                      @"    nvl(b.comments, a.column_name) as " + @"""remark""" +
                                      @" from dba_tab_columns a
                                                              left join user_col_comments b
                                                                on b.table_name = a.table_name
                                                               and b.column_name = a.column_name 
                                                              left join (select col#, name
                                                                           from sys.col$
                                                                          where obj# = (select object_id
                                                                                          from all_objects
                                                                                         where 1 = 1 " +
                                      @"                             and object_name = '" + tableName.ToUpper() + "'" +
                                      @"                             and rownum = 1)) c
                                    on c.name = a.column_name");
                        strSql.Append(" WHERE a.table_name= '" + tableName.ToUpper() + "'" + "and a.owner= '" + DbHelper.UserID.ToUpper() + "'" + "order by c.col# ");
                        break;
                    case DatabaseType.MySql:
                        break;
                    default:
                        throw new Exception("数据库类型目前不支持！");
                }
                //return this.BaseRepository(dataBaseLinkEntity.DbConnection).FindList<DataBaseTableFieldEntity>(strSql.ToString(), parameter.ToArray());
                return this.BaseRepository(dataBaseLinkEntity.DbConnection).FindList<DataBaseTableFieldEntity>(strSql.ToString());
            }
            return null;
        }
        /// <summary>
        /// 数据库表数据列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接</param>
        /// <param name="tableName">表明</param>
        /// <param name="switchWhere">条件</param>
        /// <param name="logic">逻辑</param>
        /// <param name="keyword">关键字</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        public DataTable GetTableDataList(string dataBaseLinkId, string tableName, string switchWhere, string logic, string keyword, Pagination pagination)
        {
            DataBaseLinkEntity dataBaseLinkEntity = dataBaseLinkService.GetEntity(dataBaseLinkId);
            if (dataBaseLinkEntity != null)
            {
                StringBuilder strSql = new StringBuilder();
                List<DbParameter> parameter = new List<DbParameter>();
                strSql.Append("SELECT * FROM " + tableName + " WHERE 1=1");
                if (!string.IsNullOrEmpty(keyword))
                {
                    strSql.Append(" AND " + switchWhere + "");
                    switch (logic)
                    {
                        case "Equal":           //等于
                            strSql.Append(" = ");
                            parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + switchWhere, keyword));
                            break;
                        case "NotEqual":        //不等于
                            strSql.Append(" <> ");
                            parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + switchWhere, keyword));
                            break;
                        case "Greater":         //大于
                            strSql.Append(" > ");
                            parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + switchWhere, keyword));
                            break;
                        case "GreaterThan":     //大于等于
                            strSql.Append(" >= ");
                            parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + switchWhere, keyword));
                            break;
                        case "Less":            //小于
                            strSql.Append(" < ");
                            parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + switchWhere, keyword));
                            break;
                        case "LessThan":        //小于等于
                            strSql.Append(" >= ");
                            parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + switchWhere, keyword));
                            break;
                        case "Null":            //为空
                            strSql.Append(" is null ");
                            parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + switchWhere, keyword));
                            break;
                        case "NotNull":         //不为空
                            strSql.Append(" is not null ");
                            parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + switchWhere, keyword));
                            break;
                        case "Like":            //包含
                            strSql.Append(" like ");
                            parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + switchWhere, '%' + keyword + '%'));
                            break;
                        default:
                            break;
                    }
                    strSql.Append(DbParameters.CreateDbParmCharacter() + switchWhere + "");
                }
                return this.BaseRepository(dataBaseLinkEntity.DbConnection).FindTable(strSql.ToString(), parameter.ToArray(), pagination);
            }
            return null;
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存数据库表表单（新增、修改）
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表名称</param>
        /// <param name="tableDescription">表说明</param>
        /// <param name="fieldList">字段列表</param>
        public void SaveForm(string dataBaseLinkId, string tableName, string tableDescription, IEnumerable<DataBaseTableFieldEntity> fieldList)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("if exists (select 1");
            strSql.Append("            from  sysobjects");
            strSql.Append("            where  id = object_id('" + tableName + "')");
            strSql.Append("            and   type = 'U')");
            strSql.Append("   drop table " + tableName + "");
            strSql.Append("go");

            strSql.Append("/*==============================================================*/");
            strSql.Append("/* Table: " + tableName + "                                     */");
            strSql.Append("/*==============================================================*/");
            strSql.Append("create table " + tableName + " (");


            strSql.Append("   LogId                varchar(50)        not null,");
            strSql.Append("   SourceObjectId       varchar(50)        null,");
            strSql.Append("   SourceContentJson    text               null,");
            strSql.Append("   IPAddress            varchar(50)        null,");
            strSql.Append("   IPAddressName        varchar(200)       null,");
            strSql.Append("   Category             int                null,");



            strSql.Append("   constraint PK_BASE_LOG primary key nonclustered (LogId)");
            strSql.Append(")");
            strSql.Append("go");

            //declare @CurrentUser sysname
            //select @CurrentUser = user_name()
            //execute sp_addextendedproperty 'MS_Description', 
            //   '系统日志表',
            //   'user', @CurrentUser, 'table', 'Base_Log'
            //go

            //declare @CurrentUser sysname
            //select @CurrentUser = user_name()
            //execute sp_addextendedproperty 'MS_Description', 
            //   '日志主键',
            //   'user', @CurrentUser, 'table', 'Base_Log', 'column', 'LogId'
            //go
        }
        #endregion
    }
}
