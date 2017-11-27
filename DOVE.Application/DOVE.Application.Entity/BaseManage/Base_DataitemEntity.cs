using System;
using RH.Application.Code;

namespace RH.Application.Entity.BaseManage
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 辽宁瑞华实业集团高新科技有限公司
    /// 创 建：超级管理员
    /// 日 期：2017-09-18 16:14
    /// 描 述：数据字典分类表
    /// </summary>
    public class Base_DataitemEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 分类主键
        /// </summary>
        /// <returns></returns>
        public string Itemid { get; set; }
        /// <summary>
        /// 父级主键
        /// </summary>
        /// <returns></returns>
        public string Parentid { get; set; }
        /// <summary>
        /// 分类编码
        /// </summary>
        /// <returns></returns>
        public string Itemcode { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        /// <returns></returns>
        public string Itemname { get; set; }
        /// <summary>
        /// 树型结构
        /// </summary>
        /// <returns></returns>
        public int? Istree { get; set; }
        /// <summary>
        /// 导航标志
        /// </summary>
        /// <returns></returns>
        public int? Isnav { get; set; }
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
            this.Itemid = Guid.NewGuid().ToString();
            this.CreateDate = DateTime.Now;
            this.CreateUserId = OperatorProvider.Provider.Current().UserId;
            this.CreateUserName = OperatorProvider.Provider.Current().UserName;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.Itemid = keyValue;
            this.ModifyDate = DateTime.Now;
            this.ModifyUserId = OperatorProvider.Provider.Current().UserId;
            this.ModifyUserName = OperatorProvider.Provider.Current().UserName;
        }
        #endregion
    }
}