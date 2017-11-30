using DOVE.Application.Entity.DoveManage;
using DOVE.Application.IService.DoveManage;
using DOVE.Data;
using DOVE.Data.Repository;
using DOVE.Util;
using DOVE.Util.WebControl;
using DOVE.Util.Extension;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;

namespace DOVE.Application.Service.DoveManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创 建：超级管理员
    /// 日 期：2017-11-30 15:59
    /// 描 述：活动信息表
    /// </summary>
    public class T_ActivityService : RepositoryFactory<T_ActivityEntity>, T_ActivityIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public DataTable GetPageList(Pagination pagination, string queryJson)
        {
           try
           {
                var strSql = new StringBuilder();
                strSql.Append(@"SELECT w.* from T_Activity w WHERE 1 = 1 ");
                var parameter = new List<DbParameter>();
                var queryParam = queryJson.ToJObject();
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    strSql.Append(" AND w.ACTIVITYSTARTTIME Between " + DbParameters.CreateDbParmCharacter() + "StartTime AND " + DbParameters.CreateDbParmCharacter() + "EndTime ");
                    parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "StartTime", (queryParam["StartTime"].ToString() + " 00:00:00").ToDate()));
                    parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "EndTime", (queryParam["EndTime"].ToString() + " 23:59:59").ToDate()));
                }
                return this.BaseRepository().FindTable(strSql.ToString(), parameter.ToArray(), pagination);
           }    
           catch     
           {     
                throw;
           }     
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<T_ActivityEntity> GetList(string queryJson)
        {
            return this.BaseRepository().IQueryable().ToList();
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public T_ActivityEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            this.BaseRepository().Delete(keyValue);
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, T_ActivityEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                this.BaseRepository().Update(entity);
            }
            else
            {
                entity.Create();
                this.BaseRepository().Insert(entity);
            }
        }
        #endregion
    }
}
