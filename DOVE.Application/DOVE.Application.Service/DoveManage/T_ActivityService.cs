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
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ���Ӷ�������ֲ�
    /// �� ������������Ա
    /// �� �ڣ�2017-11-30 15:59
    /// �� �������Ϣ��
    /// </summary>
    public class T_ActivityService : RepositoryFactory, T_ActivityIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
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
                strSql.Append(" or w.activitystarttime is null");// Ϊ��С����������excel��ʱ��û����������ʼʱ�����
                return this.BaseRepository().FindTable(strSql.ToString(), parameter.ToArray(), pagination);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// ��ȡ�����б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
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
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<T_ActivityEntity> GetList(string queryJson)
        {
            return this.BaseRepository().IQueryable<T_ActivityEntity>().ToList();
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public T_ActivityEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity<T_ActivityEntity>(keyValue);
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
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
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <param name="strUserIds">������id�ַ���</param>
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

                    //ֻ���½����ʱ����жϲ�����Ӳ������������ȥ����Ϊ����ѡ�е�Ҫ�ز�ȫ���޸ĻҲ���������߼��Ļ����׵���������������Ϣ��ʧ��
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
        /// С������Excel���뱣��
        /// </summary>
        /// <param name="dt">����dt</param>
        /// <param name="sheetName">sheetName</param>
        /// <returns></returns>
        public void XiaoliSaveForm(DataTable dt, string sheetName)
        {
            IRepository db = new RepositoryFactory().BaseRepository().BeginTrans();
            try
            {
                #region ����
                // ��ʼ�������
                DateTime dateTime = DateTime.MinValue;
                IFormatProvider ifp = new CultureInfo("zh-CN", true);
                DateTime.TryParseExact(sheetName, "yyyyMMdd", ifp, DateTimeStyles.None, out dateTime);
                T_ActivityEntity activityModel = new T_ActivityEntity();
                activityModel.Create();
                activityModel.Activityname = "";
                activityModel.Activitycode = sheetName;
                activityModel.Activitystarttime = dateTime;// ��Ҫ�Լ��޸�
                activityModel.Activityendtime = dateTime;// ��Ҫ�Լ��޸�
                activityModel.Deletemark = 0;
                activityModel.Enabledmark = 1;

                db.Insert(activityModel);

                int n = 1;
                // ѭ��ÿһ�����ݣ��������������ȡ��Ԫ��ֵ�������ݲ������
                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    string wechat = dt.Rows[k]["΢��"].ToString();
                    string username = dt.Rows[k]["����"].ToString();

                    var userList = db.IQueryable<UserEntity>().Where(ele =>
                    ele.WeChat == wechat ||
                    ele.RealName == username ||
                    ele.RealName == wechat ||
                    ele.WeChat == username).ToList();

                    if (userList != null && userList.Count == 0)
                    {
                        throw new Exception("�û���Ϣ�����ݿ��в����ڣ�" + wechat + " " + username);
                    }

                    if (!dt.Columns.Contains("����ʱ��")) throw new Exception("�С�����ʱ�䡿��Excel�в����ڣ�" + wechat + " " + username);
                    if (!dt.Columns.Contains("��ע")) throw new Exception("�С���ע����Excel�в����ڣ�" + wechat + " " + username);

                    T_Activity_DetailEntity activityDetailModel = new T_Activity_DetailEntity();
                    activityDetailModel.Create();
                    activityDetailModel.Activityid = activityModel.Activityid;
                    activityDetailModel.Userid = userList.FirstOrDefault().UserId;
                    activityDetailModel.Time = DateTime.Parse(dt.Rows[k]["����ʱ��"].ToString());
                    activityDetailModel.Description = dt.Rows[k]["��ע"].ToString();
                    activityDetailModel.Teamname = dt.Columns.Contains("�ӱ�") == true ? dt.Rows[k]["�ӱ�"].ToString() : "";
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
        /// ��Excel���뱣��
        /// </summary>
        /// <param name="dt">����dt</param>
        /// <returns></returns>
        public void ActivitiesSaveForm(DataTable dt)
        {
            IRepository db = new RepositoryFactory().BaseRepository().BeginTrans();
            try
            {
                #region ����
                if (dt != null && dt.Rows.Count > 0)
                {
                    // ѭ��ÿ�εĻ�У����л���룬������в���ʱ���ʽ��������
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        DateTime dateTime = DateTime.MinValue;
                        IFormatProvider ifp = new CultureInfo("zh-CN", true);
                        bool result = DateTime.TryParseExact(dt.Columns[j].ToString(), "yyyyMMdd", ifp, DateTimeStyles.None, out dateTime);
                        if (!result) continue;
                        //// ��ѯ���ݿ����Ƿ���ڸû���
                        //List<T_ActivityEntity> activityEntityList = t_activityBLL.GetList("where activitycode='" + dtActivities.Columns[j].ToString() + "'").ToList();
                        //if (activityEntityList != null && activityEntityList.ToList().Count > 0)
                        //{
                        //    if (activityEntityList.ToList().Count > 1)
                        //        return Error("�����ж����");
                        //    t_activityBLL.GetEntity(activityEntityList.ToList().First().Activityid);
                        //}
                        // ��ʼ�������
                        T_ActivityEntity activityModel = new T_ActivityEntity();
                        activityModel.Create();
                        activityModel.Activityname = dt.Columns[j].ToString() + "����";
                        activityModel.Activitycode = dt.Columns[j].ToString();
                        activityModel.Activitystarttime = dateTime;
                        activityModel.Activityendtime = dateTime;
                        activityModel.Signupstarttime = dateTime.AddDays(-1);
                        activityModel.Signupendtime = dateTime.AddHours(-1);
                        activityModel.Deletemark = 0;
                        activityModel.Enabledmark = 1;

                        db.Insert(activityModel);

                        int n = 1;
                        // ѭ��ÿһ�����ݣ��������������ȡ��Ԫ��ֵ�������ݲ������
                        for (int k = 0; k < dt.Rows.Count; k++)
                        {
                            if (dt.Rows[k][j].ToString() == "��")
                            {
                                T_Activity_DetailEntity activityDetailModel = new T_Activity_DetailEntity();
                                activityDetailModel.Create();
                                activityDetailModel.Activityid = activityModel.Activityid;
                                // ƥ�����ݿ��е��û�
                                string usercode = dt.Rows[k]["���"].ToString();
                                string username = dt.Rows[k]["����"].ToString();
                                string usernickname = dt.Rows[k]["�ǳ�"].ToString();
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
