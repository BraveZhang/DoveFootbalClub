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
using System;

namespace DOVE.Application.Service.DoveManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创 建：超级管理员
    /// 日 期：2017-11-30 15:59
    /// 描 述：活动信息表
    /// </summary>
    public class T_ActivityService : RepositoryFactory, T_ActivityIService
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
                strSql.Append(@"SELECT w.*,u.realname initiatorname
                                  from T_Activity w
                                  left join base_user u
                                    on u.userid = w.initiator
                                   and u.enabledmark = 1
                                   and u.deletemark = 0
                                 WHERE 1 = 1 ");
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
        /// 获取详情列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public DataTable GetDetailList(string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append(@"SELECT u.account, u.userid,u.realname, u.nickname, d.description, d.time
                                     from T_Activity w
                                     left join t_activity_detail d
                                       on w.activityid = d.activityid
                                      and d.enabledmark = 1
                                      and d.deletemark = 0
                                     left join base_user u
                                       on u.userid = d.userid
                                      and u.enabledmark = 1
                                      and u.deletemark = 0
                                    WHERE 1 = 1  ");
                var parameter = new List<DbParameter>();
                var queryParam = queryJson.ToJObject();
                if (!queryParam["activityid"].IsEmpty())
                {
                    strSql.Append(" AND d.activityid = " + DbParameters.CreateDbParmCharacter() + "Activityid");
                    parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "Activityid", queryParam["activityid"].ToString()));
                }
                strSql.Append(" order by d.time desc");
                return this.BaseRepository().FindTable(strSql.ToString(), parameter.ToArray());
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
            return this.BaseRepository().IQueryable<T_ActivityEntity>().ToList();
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public T_ActivityEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity<T_ActivityEntity>(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            this.BaseRepository().Delete<T_ActivityEntity>(keyValue);
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <param name="strUserIds">参与者id字符串</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, T_ActivityEntity entity, string strUserIds)
        {
            IRepository db = new RepositoryFactory().BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue);
                    db.Update(entity);
                }
                else
                {
                    entity.Create();

                    db.Insert(entity);

                    //只有新建活动的时候才判断参与鸽子并插入详情表中去，因为界面选中的要素不全，修改活动也加上下列逻辑的话容易导致详情其他的信息丢失！
                    if (!string.IsNullOrEmpty(strUserIds) && strUserIds.ToList<string>().Count > 0)
                    {
                        db.Delete<T_Activity_DetailEntity>(t => t.Activityid.Equals(entity.Activityid));

                        List<string> userIdList = strUserIds.ToList<string>();
                        int n = 1;
                        foreach (var item in userIdList)
                        {
                            T_Activity_DetailEntity activityDetailModel = new T_Activity_DetailEntity();
                            activityDetailModel.Create();
                            activityDetailModel.Activityid = entity.Activityid;
                            activityDetailModel.Userid = item;
                            activityDetailModel.Sortcode = n;
                            activityDetailModel.Deletemark = 0;
                            activityDetailModel.Enabledmark = 1;

                            db.Insert(activityDetailModel);
                            n++;
                        }
                    }
                }

                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
        #endregion
    }
}
