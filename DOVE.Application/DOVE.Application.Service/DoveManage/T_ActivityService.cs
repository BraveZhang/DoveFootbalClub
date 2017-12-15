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
using DOVE.Application.Entity.BaseManage;
using System.Globalization;

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
                strSql.Append(@"SELECT w.*, u.realname initiatorname, d.itemname as addressname
                                 from T_Activity w
                                 left join base_user u
                                   on u.userid = w.initiator
                                  and u.enabledmark = 1
                                  and u.deletemark = 0
                                 left join base_dataitemdetail d
                                   on d.itemvalue = w.address
                                WHERE 1 = 1 ");
                var parameter = new List<DbParameter>();
                var queryParam = queryJson.ToJObject();
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    strSql.Append(" AND w.activitystarttime Between " + DbParameters.CreateDbParmCharacter() + "StartTime AND " + DbParameters.CreateDbParmCharacter() + "EndTime ");
                    parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "StartTime", (queryParam["StartTime"].ToString() + " 00:00:00").ToDate()));
                    parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "EndTime", (queryParam["EndTime"].ToString() + " 23:59:59").ToDate()));
                }
                strSql.Append(" or w.activitystarttime is null");// 为了小立报名导入excel的时候没有填主表活动开始时间而加
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
                strSql.Append(@"SELECT u.account, u.userid, u.realname, u.nickname, d.description, d.time,d.sortcode,u.wechat
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
            IRepository db = new RepositoryFactory().BaseRepository().BeginTrans();
            try
            {
                db.Delete<T_ActivityEntity>(keyValue);
                db.Delete<T_Activity_DetailEntity>(ele => ele.Activityid == keyValue);

                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
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
                    DateTime dateTime = DateTime.MinValue;
                    IFormatProvider ifp = new CultureInfo("zh-CN", true);
                    DateTime.TryParseExact(entity.Activitycode, "yyyyMMdd", ifp, DateTimeStyles.None, out dateTime);

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
                            activityDetailModel.Time = dateTime;
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

        /// <summary>
        /// 小立报名Excel导入保存
        /// </summary>
        /// <param name="dt">数据dt</param>
        /// <param name="sheetName">sheetName</param>
        /// <returns></returns>
        public void XiaoliSaveForm(DataTable dt, string sheetName)
        {
            IRepository db = new RepositoryFactory().BaseRepository().BeginTrans();
            try
            {
                #region 插入活动
                // 初始化活动主表
                DateTime dateTime = DateTime.MinValue;
                IFormatProvider ifp = new CultureInfo("zh-CN", true);
                DateTime.TryParseExact(sheetName, "yyyyMMdd", ifp, DateTimeStyles.None, out dateTime);
                T_ActivityEntity activityModel = new T_ActivityEntity();
                activityModel.Create();
                activityModel.Activityname = "";
                activityModel.Activitycode = sheetName;
                activityModel.Activitystarttime = dateTime;// 需要自己修改
                activityModel.Activityendtime = dateTime;// 需要自己修改
                activityModel.Deletemark = 0;
                activityModel.Enabledmark = 1;

                db.Insert(activityModel);

                int n = 1;
                // 循环每一行数据，根据行列坐标获取单元格值进行数据插入操作
                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    string wechat = dt.Rows[k]["微信"].ToString();
                    string username = dt.Rows[k]["姓名"].ToString();

                    var userList = db.IQueryable<UserEntity>().Where(ele =>
                    ele.WeChat == wechat ||
                    ele.RealName == username ||
                    ele.RealName == wechat ||
                    ele.WeChat == username).ToList();

                    if (userList != null && userList.Count == 0)
                    {
                        throw new Exception("用户信息在数据库中不存在：" + wechat + " " + username);
                    }

                    if (!dt.Columns.Contains("报名时间")) throw new Exception("列【报名时间】在Excel中不存在：" + wechat + " " + username);
                    if (!dt.Columns.Contains("备注")) throw new Exception("列【备注】在Excel中不存在：" + wechat + " " + username);

                    T_Activity_DetailEntity activityDetailModel = new T_Activity_DetailEntity();
                    activityDetailModel.Create();
                    activityDetailModel.Activityid = activityModel.Activityid;
                    activityDetailModel.Userid = userList.FirstOrDefault().UserId;
                    activityDetailModel.Time = DateTime.Parse(dt.Rows[k]["报名时间"].ToString());
                    activityDetailModel.Description = dt.Rows[k]["备注"].ToString();
                    activityDetailModel.Teamname = dt.Columns.Contains("队别") == true ? dt.Rows[k]["队别"].ToString() : "";
                    activityDetailModel.Sortcode = n;
                    activityDetailModel.Deletemark = 0;
                    activityDetailModel.Enabledmark = 1;

                    db.Insert(activityDetailModel);
                    n++;

                }
                #endregion
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }

        /// <summary>
        /// 多活动Excel导入保存
        /// </summary>
        /// <param name="dt">数据dt</param>
        /// <returns></returns>
        public void ActivitiesSaveForm(DataTable dt)
        {
            IRepository db = new RepositoryFactory().BaseRepository().BeginTrans();
            try
            {
                #region 插入活动
                if (dt != null && dt.Rows.Count > 0)
                {
                    // 循环每次的活动列，进行活动插入，如果该列不是时间格式，则跳过
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        DateTime dateTime = DateTime.MinValue;
                        IFormatProvider ifp = new CultureInfo("zh-CN", true);
                        bool result = DateTime.TryParseExact(dt.Columns[j].ToString(), "yyyyMMdd", ifp, DateTimeStyles.None, out dateTime);
                        if (!result) continue;
                        //// 查询数据库中是否存在该活动编号
                        //List<T_ActivityEntity> activityEntityList = t_activityBLL.GetList("where activitycode='" + dtActivities.Columns[j].ToString() + "'").ToList();
                        //if (activityEntityList != null && activityEntityList.ToList().Count > 0)
                        //{
                        //    if (activityEntityList.ToList().Count > 1)
                        //        return Error("活动编号有多个！");
                        //    t_activityBLL.GetEntity(activityEntityList.ToList().First().Activityid);
                        //}
                        // 初始化活动主表
                        T_ActivityEntity activityModel = new T_ActivityEntity();
                        activityModel.Create();
                        activityModel.Activityname = dt.Columns[j].ToString() + "搞起！";
                        activityModel.Activitycode = dt.Columns[j].ToString();
                        activityModel.Activitystarttime = dateTime;
                        activityModel.Activityendtime = dateTime;
                        activityModel.Signupstarttime = dateTime.AddDays(-1);
                        activityModel.Signupendtime = dateTime.AddHours(-1);
                        activityModel.Deletemark = 0;
                        activityModel.Enabledmark = 1;

                        db.Insert(activityModel);

                        int n = 1;
                        // 循环每一行数据，根据行列坐标获取单元格值进行数据插入操作
                        for (int k = 0; k < dt.Rows.Count; k++)
                        {
                            if (dt.Rows[k][j].ToString() == "●")
                            {
                                T_Activity_DetailEntity activityDetailModel = new T_Activity_DetailEntity();
                                activityDetailModel.Create();
                                activityDetailModel.Activityid = activityModel.Activityid;
                                // 匹配数据库中的用户
                                string usercode = dt.Rows[k]["序号"].ToString();
                                string username = dt.Rows[k]["姓名"].ToString();
                                string usernickname = dt.Rows[k]["昵称"].ToString();
                                var userList = db.IQueryable<UserEntity>().Where(ele => ele.Account == usercode || ele.RealName == username || ele.NickName == usernickname).ToList();
                                if (userList != null && userList.Count > 0)
                                {
                                    activityDetailModel.Userid = userList.FirstOrDefault().UserId;
                                }
                                activityDetailModel.Time = dateTime;
                                activityDetailModel.Sortcode = n;
                                activityDetailModel.Deletemark = 0;
                                activityDetailModel.Enabledmark = 1;

                                db.Insert(activityDetailModel);
                                n++;
                            }
                        }
                    }
                }
                #endregion
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
