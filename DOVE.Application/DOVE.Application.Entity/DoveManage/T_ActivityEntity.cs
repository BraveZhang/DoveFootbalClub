using System;
using DOVE.Application.Code;

namespace DOVE.Application.Entity.DoveManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 鸽子队足球俱乐部
    /// 创 建：超级管理员
    /// 日 期：2017-11-30 15:59
    /// 描 述：活动信息表
    /// </summary>
    public class T_ActivityEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 活动主键ID
        /// </summary>
        /// <returns></returns>
        public string Activityid { get; set; }
        /// <summary>
        /// 活动名称
        /// </summary>
        /// <returns></returns>
        public string Activityname { get; set; }
        /// <summary>
        /// 活动编号
        /// </summary>
        /// <returns></returns>
        public string Activitycode { get; set; }
        /// <summary>
        /// 活动地点
        /// </summary>
        /// <returns></returns>
        public string Address { get; set; }
        /// <summary>
        /// 活动内容
        /// </summary>
        /// <returns></returns>
        public string Content { get; set; }
        /// <summary>
        /// 活动开始时间
        /// </summary>
        /// <returns></returns>
        public DateTime? Activitystarttime { get; set; }
        /// <summary>
        /// 活动结束时间
        /// </summary>
        /// <returns></returns>
        public DateTime? Activityendtime { get; set; }
        /// <summary>
        /// 报名开始时间
        /// </summary>
        /// <returns></returns>
        public DateTime? Signupstarttime { get; set; }
        /// <summary>
        /// 报名截止时间
        /// </summary>
        /// <returns></returns>
        public DateTime? Signupendtime { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>
        /// <returns></returns>
        public int? Sortcode { get; set; }
        /// <summary>
        /// 发起人ID
        /// </summary>
        /// <returns></returns>
        public string Initiator { get; set; }
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
        /// 备注
        /// </summary>
        /// <returns></returns>
        public string Description { get; set; }
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
            this.Activityid = Guid.NewGuid().ToString();
            this.Createdate = DateTime.Now;
            this.Enabledmark = 1;// add by zy 20171206
            this.Deletemark = 0;// add by zy 20171206
            this.Createuserid = OperatorProvider.Provider.Current().UserId;
            this.Createusername = OperatorProvider.Provider.Current().UserName;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.Activityid = keyValue;
            this.Modifydate = DateTime.Now;
            this.Modifyuserid = OperatorProvider.Provider.Current().UserId;
            this.Modifyusername = OperatorProvider.Provider.Current().UserName;
        }
        #endregion
    }
}