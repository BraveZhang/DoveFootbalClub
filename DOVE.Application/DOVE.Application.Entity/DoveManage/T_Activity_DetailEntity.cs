using System;
using DOVE.Application.Code;

namespace DOVE.Application.Entity.DoveManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创 建：超级管理员
    /// 日 期：2017-11-30 17:00
    /// 描 述：活动信息明细表
    /// </summary>
    public class T_Activity_DetailEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 活动明细主键ID
        /// </summary>
        /// <returns></returns>
        public string Activitydetailid { get; set; }
        /// <summary>
        /// 活动ID
        /// </summary>
        /// <returns></returns>
        public string Activityid { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        /// <returns></returns>
        public string Userid { get; set; }
        /// <summary>
        /// 报名时间
        /// </summary>
        /// <returns></returns>
        public DateTime? Time { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        public string Description { get; set; }
        /// <summary>
        /// 队别
        /// </summary>
        /// <returns></returns>
        public string Teamname { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>
        /// <returns></returns>
        public int? Sortcode { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>
        /// <returns></returns>
        public int? Deletemark { get; set; }
        /// <summary>
        /// 有效标志
        /// </summary>
        /// <returns></returns>
        public int? Enabledmark { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        /// <returns></returns>
        public DateTime? Createdate { get; set; }
        /// <summary>
        /// 创建用户主键
        /// </summary>
        /// <returns></returns>
        public string Createuserid { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <returns></returns>
        public string Createusername { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        /// <returns></returns>
        public DateTime? Modifydate { get; set; }
        /// <summary>
        /// 修改用户主键
        /// </summary>
        /// <returns></returns>
        public string Modifyuserid { get; set; }
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <returns></returns>
        public string Modifyusername { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.Activitydetailid = Guid.NewGuid().ToString();
            this.Createdate = DateTime.Now;
            this.Createuserid = OperatorProvider.Provider.Current().UserId;
            this.Createusername = OperatorProvider.Provider.Current().UserName;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.Activitydetailid = keyValue;
            this.Modifydate = DateTime.Now;
            this.Modifyuserid = OperatorProvider.Provider.Current().UserId;
            this.Modifyusername = OperatorProvider.Provider.Current().UserName;
        }
        #endregion
    }
}